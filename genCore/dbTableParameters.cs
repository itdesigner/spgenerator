namespace spGenerator.genCore
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Data;
    using System.Data.SqlClient;
    using System.Data.Sql;
    using System.Data.SqlTypes;

    public enum spType
    {
        SELECT,
        INSERT,
        UPDATE,
        DELETE,
        COMPILED
    }
    [Serializable]
    public class dbTableParameters
    {
        #region " Constructor Logic "
        public dbTableParameters()
        {
            //local parameters defaults on creation
            SetDefaults();
            //Load();
        }
        private void SetDefaults()
        {
            this.databaseName = "master";
            this.outputDir = System.Environment.SpecialFolder.Desktop.ToString();
            this.outputFile = "generatedSP.sql";
            this.password = "";
            this.savePassword = false;
            this.server = "(local)";
            this.user = "sa";
            this.useWindowsAuthetication = true;
            this.table = "";
            this.genDelete = false;
            this.genInsert = false;
            this.genSelect = false;
            this.genUpdate = false;
            tFields = new Hashtable();
        }
        #endregion

        #region " Database Connection Logic "
            public string ConnectionString
            {
                get
                {
                    return BuildConnectionString(); 
                }
            }
            public string BuildConnectionString()
            {
                StringBuilder builder1 = new StringBuilder("Data Source=");
                string text1 = this.Server;
                if (text1.Length == 0)
                {
                    builder1.Append(".");
                }
                else
                {
                    builder1.Append(text1);
                }
                builder1.Append(";Initial Catalog=");
                string text2 = this.DatabaseName;
                builder1.Append(text2);
                builder1.Append(";");
                if (this.UseWindowsAuthentication)
                {
                    builder1.Append("Integrated Security=SSPI;");
                }
                else
                {
                    string text3 = this.User;
                    string text4 = this.Password;
                    if (text3.Length == 0)
                    {
                        builder1.Append("Integrated Security=SSPI;");
                    }
                    else
                    {
                        builder1.Append("User Id=");
                        builder1.Append(text3);
                        builder1.Append(";Password=");
                        builder1.Append(text4);
                        builder1.Append(";");
                    }
                }
                return builder1.ToString();
            }
            private bool IsSqlServer2005(string ConnectionString)
            {
                try
                {
                    string result = string.Empty;
                    SqlConnection connection1 = new SqlConnection(ConnectionString);
                    connection1.Open();
                    SqlCommand command1 = new SqlCommand("SELECT @@VERSION", connection1);
                    result = (string)command1.ExecuteScalar();
                    connection1.Close();
                    if (result.Substring(0, 0x19) == "Microsoft SQL Server 2005")
                    {
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            public bool GetTableInfo()
            {
                bool bResult = false;
                tFields.Clear();
                try
                {
                    System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConnectionString);
                    System.Data.SqlClient.SqlCommand comm = new System.Data.SqlClient.SqlCommand();
                    comm.Connection = conn;
                    string sCommand=string.Empty;
                    if(!this.IsSqlServer2005(ConnectionString))
                    {
                    sCommand = "select DISTINCT c.column_name as columnName, c.data_type as dataType, c.CHARACTER_MAXIMUM_LENGTH As Length,c.CHARACTER_OCTET_LENGTH As PhysicalLength, c.NUMERIC_PRECISION As NumericPrecision, c.NUMERIC_SCALE As NumericScale ,c.IS_NULLABLE as IsNullable, c.table_schema as tableSchema, c.ordinal_position,";
                    sCommand += "(select a.constraint_type from information_schema.table_constraints a, information_schema.key_column_usage b where a.table_name = ";
                    sCommand += "'" + this.table + "' and a.table_catalog = '" + this.databaseName + "' and a.table_name = b.table_name and a.table_schema = b.table_schema and a.constraint_name = b.constraint_name and a.constraint_type='PRIMARY KEY' and b.column_name = c.column_name ) AS PrimaryKey";
                    sCommand += " from information_schema.columns c where c.table_catalog = '" + this.databaseName + "' and c.table_name = '" + this.table + "' ORDER BY c.ordinal_position ASC";
                    }
                    else
                    {
                        sCommand = "SELECT DISTINCT C.TABLE_SCHEMA as tableSchema, C.TABLE_NAME AS TABLE_NAME, C.COLUMN_NAME as columnName, C.DATA_TYPE as dataType, case ty.system_type_id when 231 then sys.columns.max_length / 2 when 239 then sys.columns.max_length / 2  when 167 then sys.columns.max_length when 175 then sys.columns.max_length else 0 end as Length, sys.columns.max_length as PhysicalLength, sys.columns.precision as NumericPrecision, sys.columns.scale as NumericScale, E.value AS COLUMN_DESCRIPTION, C.COLUMN_DEFAULT, C.IS_NULLABLE as IsNullable, C.ORDINAL_POSITION FROM INFORMATION_SCHEMA.COLUMNS C INNER JOIN INFORMATION_SCHEMA.TABLES T ON C.TABLE_NAME = T.TABLE_NAME INNER JOIN sys.columns ON C.COLUMN_NAME = sys.columns.name AND sys.columns.object_id = object_id(C.TABLE_SCHEMA + '.[' + C.TABLE_NAME + ']') INNER JOIN sys.types ty ON C.DATA_TYPE = ty.name LEFT JOIN sys.extended_properties E ON object_id(C.TABLE_SCHEMA + '.[' + C.TABLE_NAME + ']') = E.major_id AND C.ORDINAL_POSITION = E.minor_id AND E.class = 1 AND E.name = 'MS_Description' WHERE T.TABLE_TYPE = 'BASE TABLE' and C.TABLE_NAME='" + this.table + "' ORDER BY TABLE_NAME, C.ORDINAL_POSITION";

                    }
                    comm.CommandText = sCommand;
                    comm.CommandType = CommandType.Text;
                    DataSet DS = new DataSet();
                    System.Data.SqlClient.SqlDataAdapter DA = new System.Data.SqlClient.SqlDataAdapter(comm);
                    conn.Open();
                    DA.Fill(DS);
                    conn.Close();
                    foreach (System.Data.DataRow dr in DS.Tables[0].Rows)
                    {
                        ColumnProperties cp = new ColumnProperties();
                        cp.Column = dr["columnName"].ToString().Trim();
                        cp.Database = this.databaseName;
                        if (dr["Length"].ToString().Trim()!="") { cp.Length = int.Parse(dr["Length"].ToString().Trim()); } else { cp.Length = 0; }
                        if (dr["IsNullable"].ToString().Trim() == "YES") { cp.Nullable = true; } else { cp.Nullable = false; }
                        if (dr["PhysicalLength"].ToString().Trim() != "") { cp.PhysicalLength = int.Parse(dr["PhysicalLength"].ToString().Trim()); } else { cp.PhysicalLength = 0; }
                        cp.Position = int.Parse(dr["ordinal_position"].ToString().Trim());
                        if (dr["NumericPrecision"].ToString().Trim() != "") { cp.Precision = int.Parse(dr["NumericPrecision"].ToString().Trim()); } else { cp.Precision=0;}
                        if (dr["NumericScale"].ToString().Trim() != "") { cp.Scale = int.Parse(dr["NumericScale"].ToString().Trim()); } else { cp.Scale = 0; }
                        cp.Table = this.table.Trim();
                        cp.Type = dr["dataType"].ToString().Trim();
                        if(!this.IsSqlServer2005(ConnectionString))
                        {
                        
                            if (dr["PrimaryKey"].ToString().Trim() == "PRIMARY KEY") { cp.PriKey = true; } else { cp.PriKey = false; }
                        }
                        else
                        {
                            string sPKCommand = "SELECT TABLE_NAME, COLUMN_NAME, INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE.CONSTRAINT_NAME FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE WHERE CONSTRAINT_NAME IN (SELECT CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE CONSTRAINT_TYPE = 'PRIMARY KEY') AND TABLE_NAME='" + this.table + "' AND COLUMN_NAME = '" + cp.Column + "'";
                            System.Data.SqlClient.SqlCommand comm2 = new System.Data.SqlClient.SqlCommand();
                            comm2.Connection = conn;
                            comm2.CommandText = sPKCommand;
                            comm2.CommandType = CommandType.Text;
                            DataSet DS2 = new DataSet();
                            System.Data.SqlClient.SqlDataAdapter DA2 = new System.Data.SqlClient.SqlDataAdapter(comm2);
                            conn.Open();
                            DA2.Fill(DS2);
                            conn.Close();
                            if (DS2.Tables[0].Rows.Count > 0) { cp.PriKey = true; } else { cp.PriKey = false; }
                        }
                        tFields.Add(cp.Column, cp);
                        this.schema = dr["tableSchema"].ToString().Trim();
                    }
                    bResult = true;
                }
                catch (Exception ex)
                {
                    bResult = false;
                }
                return bResult;
            }
        #endregion

        #region " Business Logic "
            public bool IsValid()
            {
                bool bResult = false;
                try
                {
                    if ((databaseName.Length > 0) && (server.Length > 0) && (table.Length > 0))
                    {
                        bResult = GetTableInfo();
                    }
                }
                catch (Exception ex)
                {
                    bResult = false;
                }
                return bResult;
            }
            public string GetIdentityType()
            {
                string sType=string.Empty;
                // Loop through all items of a Hashtable
                IDictionaryEnumerator en = this.Columns.GetEnumerator();
                while (en.MoveNext())
                {
                    if (((ColumnProperties)en.Value).PriKey == true)
                    {
                        sType = ((ColumnProperties)en.Value).ColumnDefinition();
                        break;
                    }
                }
                return sType;
            }
            public string GetIdentityColumn()
            {
                string sCol = string.Empty;
                // Loop through all items of a Hashtable
                IDictionaryEnumerator en = this.Columns.GetEnumerator();
                while (en.MoveNext())
                {
                    if (((ColumnProperties)en.Value).PriKey == true)
                    {
                        sCol = ((ColumnProperties)en.Value).Column;
                        break;
                    }
                }
                return sCol;
            }
        #endregion

        #region " Public Accessors "
        public string DatabaseName
        {
            get
            {
                return this.databaseName;
            }
            set
            {
                this.databaseName = value.Trim();
            }
        }
        public string OutputDir
        {
            get
            {
                return this.outputDir;
            }
            set
            {
                this.outputDir = value;
            }
        }
        public string OutputFile
        {
            get
            {
                return this.outputFile;
            }
            set
            {
                this.outputFile = value.Trim();
            }
        }
        public string OutputFileFullPath
        {
            get
            {
                return Path.Combine(this.outputDir, this.outputFile);
            }
        }
        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }
        public bool SavePassword
        {
            get
            {
                return this.savePassword;
            }
            set
            {
                this.savePassword = value;
            }
        }
        public string Server
        {
            get
            {
                return this.server;
            }
            set
            {
                this.server = value.Trim();
            }
        }
        public string User
        {
            get
            {
                return this.user;
            }
            set
            {
                this.user = value.Trim();
            }
        }
        public bool UseWindowsAuthentication
        {
            get
            {
                return this.useWindowsAuthetication;
            }
            set
            {
                this.useWindowsAuthetication = value;
            }
        }
        public string Table
        {
            get { return table; }
            set { table = value; }
        }
        public string Schema
        {
            get { return schema; }
            set { schema = value; }
        }
        public bool GenSelect
        {
            get { return genSelect; }
            set { genSelect = value; }
        }
        public bool GenDelete
        {
            get { return genDelete; }
            set { genDelete = value; }
        }
        public bool GenUpdate
        {
            get { return genUpdate; }
            set { genUpdate = value; }
        }
        public bool GenInsert
        {
            get { return genInsert; }
            set { genInsert = value; }
        }
        public Hashtable Columns
        {
            get { return tFields; }
            set { tFields = value; }
        }
        #endregion

        #region " private variables "
        private string databaseName;
        private string outputDir;
        private string outputFile;
        private string password;
        private bool savePassword;
        private string server;
        private string user;
        private bool useWindowsAuthetication;
        private string table;
        private string schema;
        private bool genInsert;
        private bool genUpdate;
        private bool genDelete;
        private bool genSelect;
        [NonSerialized()]
        private Hashtable tFields;
    #endregion
    }
    public class dbTSelectParameters
    {
        //done on a per select sp operation
        private Hashtable SelectField;
        private Hashtable FilterField;

    }
    public class dbTUpdateParameters
    {
        //done on a per update sp operation

    }
    public class dbTDeleteParameters
    {
        //done on a per delete sp operation

    }
    public class dbTInsertParameters
    {
        //done on a per insert sp operation

    }
    public class ColumnProperties
    {
        private string _database;
        private string _table;
        private string _column;
        private string _type;
        private int _length;
        private int _physicalLength;
        private int _precision;
        private int _scale;
        private bool _nullable;
        private int _position;
        private bool _priKey;
        private string _columnDefinition;

        public string Database
        {
            get { return _database; }
            set { _database = value; }
        }
        public string Table
        {
            get { return _table; }
            set { _table = value; }
        }
        public string Column
        {
            get { return _column; }
            set { _column = value; }
        }
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public int Length
        {
            get { return _length; }
            set { _length = value; }
        }
        public int PhysicalLength
        {
            get { return _physicalLength; }
            set { _physicalLength = value; }
        }
        public int Precision
        {
            get { return _precision; }
            set { _precision = value; }
        }
        public int Scale
        {
            get { return _scale; }
            set { _scale = value; }
        }
        public bool Nullable
        {
            get { return _nullable; }
            set { _nullable = value; }
        }
        public int Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public bool PriKey
        {
            get { return _priKey; }
            set { _priKey = value; }
        }
        public string ColumnDefinition()
        {
            string sRes = this._type;
            switch(_type)
            {
                case "numeric":
                case "decimal":
                    sRes += "(" + this._precision.ToString().Trim() + "," + this._scale.ToString().Trim() + ")";
                    break;
                case "nchar":
                case "char":
                    sRes += "(" + this._length.ToString().Trim() + ")";
                    break;
                case "binary":
                    sRes += "(" + this._physicalLength.ToString().Trim() + ")";
                    break;
                case "nvarchar":
                    //check if MAX is used
                    if ((this._length.ToString().Trim() == "0") && (this._physicalLength.ToString().Trim() == "-1"))
                    {
                        sRes += "(max) ";
                    }
                    else
                    {
                        sRes += "(" + this._length.ToString().Trim() + ") ";
                    }
                    break;
                case "varbinary":
                    //check if MAX is used
                    if ((this._length.ToString().Trim() == "0") && (this._physicalLength.ToString().Trim() == "-1"))
                    {
                        sRes += "(max) ";
                    }
                    else
                    {
                        sRes += "(" + this._physicalLength.ToString().Trim() + ") ";
                    }
                    break;
                case "varchar":
                    //check if MAX is used
                    if ((this._length.ToString().Trim() == "-1") && (this._physicalLength.ToString().Trim() == "-1"))
                    {
                        sRes += "(max) ";
                    }
                    else
                    {
                        sRes += "(" + this._length.ToString().Trim() + ") ";
                    }
                    break;
                default:
                    //no additional info needed
                    break;
            }
            return sRes;
        }

    }
}

