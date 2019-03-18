using System;
using System.Collections.Generic;
using System.Text;

namespace spGenerator
{
    public class spParam
    {
        private int _precision;

        public int Precision
        {
            get { return _precision; }
            set { _precision = value; }
        }
        private int _size;

        public int Size
        {
            get { return _size; }
            set { _size = value; }
        }
        private int _scale;

        public int Scale
        {
            get { return _scale; }
            set { _scale = value; }
        }
        private string _spName;

        public string SpName
        {
            get { return _spName; }
            set { _spName = value; }
        }
        private string _paramName;

        public string ParamName
        {
            get { return _paramName; }
            set { _paramName = value; }
        }
        private string _paramType;

        public string ParamType
        {
            get { return _paramType; }
            set { _paramType = value; }
        }

        private string _direction;

        public string Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }
        private int _ordinal;

        public int Ordinal
        {
            get { return _ordinal; }
            set { _ordinal = value; }
        }
        public string ParamDef()
        {
            string pdef = string.Empty;
            switch (this._paramType)
            {
                case "bigint":
                    pdef = "SqlDbType.BigInt";
                    break;
                case "binary":
                    pdef = "SqlDbType.Binary, " + this._size.ToString();
                    break;
                case "bit":
                    pdef = "SqlDbType.Bit";
                    break;
                case "char":
                    pdef = "SqlDbType.Char," + this._size.ToString();
                    break;
                case "datetime":
                    pdef = "SqlDbType.DateTime";
                    break;
                case "decimal":
                    pdef = "SqlDbType.Decimal";
                    break;
                case "float":
                    pdef = "SqlDbType.Float";
                    break;
                case "image":
                    pdef = "SqlDbType.Image";
                    break;
                case "int":
                    pdef = "SqlDbType.Int";
                    break;
                case "money":
                    pdef = "SqlDbType.Money";
                    break;
                case "nchar":
                    pdef = "SqlDbType.NChar," + this._size.ToString();
                    break;
                case "ntext":
                    pdef = "SqlDbType.NText";
                    break;
                case "numeric":
                    //this is something special - come back to this
                    if (this._scale > 0)
                    {
                        //could be decimal or float - default to decimal
                        pdef = "SqlDbType.Decimal";
                    }
                    else
                    {
                        //could by some variation of int - default to int
                        pdef = "SqlDbType.Int";
                    }
                    break;
                case "nvarchar":
                    //includes MAX - size=-1
                    if (this._size > 0)
                    { pdef = "SqlDbType.NVarChar," + this._size.ToString(); }
                    else
                    { pdef = "SqlDbType.NVarChar"; }
                    break;
                case "real":
                    pdef = "SqlDbType.Real";
                    break;
                case "smalldatetime":
                    pdef = "SqlDbType.SmallDateTime";
                    break;
                case "smallint":
                    pdef = "SqlDbType.SmallInt";
                    break;
                case "smallmoney":
                    pdef = "SqlDbType.SmallMoney";
                    break;
                case "sql_variant":
                    pdef = "SqlDbType.Variant";
                    break;
                case "text":
                    pdef = "SqlDbType.Text";
                    break;
                case "tinyint":
                    pdef = "SqlDbType.TinyInt";
                    break;
                case "uniqueidentifier":
                    pdef = "SqlDbType.UniqueIdentifier";
                    break;
                case "varbinary":
                    if (this._size > 0)
                    { pdef = "SqlDbType.VarBinary," + this._size.ToString(); }
                    else
                    { pdef = "SqlDbType.VarBinary"; }
                    //includes MAX - size=-1
                    break;
                case "varchar":
                    pdef = "SqlDbType.VarChar," + this._size.ToString();
                    break;
                case "xml":
                    pdef = "SqlDbType.Xml";
                    break;
                default:
                    //unknown
                    pdef = "[UNKNOWN DATA TYPE]";
                    break;
            }
            return pdef;
        }
        public string VariableName()
        {
            return "_parm_" + this.ParamName.Replace("@", string.Empty).ToLower();
        }
        public string VariableType()
        {
            string _vt = string.Empty;
            switch (this._paramType)
            {

                case "bigint":
                    _vt = "int";
                    break;
                case "binary":
                    _vt = "Byte[]";
                    break;
                case "bit":
                    _vt = "bool";
                    break;
                case "char":
                    _vt = "char";
                    break;
                case "datetime":
                    _vt = "DateTime";
                    break;
                case "decimal":
                    _vt = "decimal";
                    break;
                case "float":
                    _vt = "float";
                    break;
                case "image":
                    _vt = "Byte[]";
                    break;
                case "int":
                    _vt = "int";
                    break;
                case "money":
                    _vt = "double";
                    break;
                case "nchar":
                    _vt = "string";
                    break;
                case "ntext":
                    _vt = "string";
                    break;
                case "numeric":
                    //this is something special - come back to this
                    if (this._scale > 0)
                    {
                        //could be decimal or float - default to decimal
                        _vt = "decimal";
                    }
                    else
                    {
                        //could by some variation of int - default to int
                        _vt = "int";
                    }
                    break;
                case "nvarchar":
                    _vt = "string";
                    break;
                case "real":
                    _vt = "double";
                    break;
                case "smalldatetime":
                    _vt = "DateTime";
                    break;
                case "smallint":
                    _vt = "int";
                    break;
                case "smallmoney":
                    _vt = "double";
                    break;
                case "sql_variant":
                    _vt = "object";
                    break;
                case "text":
                    _vt = "string";
                    break;
                case "tinyint":
                    _vt = "int";
                    break;
                case "uniqueidentifier":
                    _vt = "System.Guid";
                    break;
                case "varbinary":
                    _vt = "Byte[]";
                    break;
                case "varchar":
                    _vt = "string";
                    break;
                case "xml":
                    _vt = "System.Xml.XmlDocument";
                    break;
                default:
                    //unknown
                    _vt = "[UNKNOWN DATA TYPE]";
                    break;
            }
            return _vt;
        }
        public string VariableconversionType()
        {
            string _vt = string.Empty;
            switch (this._paramType)
            {

                case "bigint":
                    _vt = "Integer";
                    break;
                case "binary":
                    _vt = "Byte()";
                    break;
                case "bit":
                    _vt = "Boolean";
                    break;
                case "char":
                    _vt = "Char";
                    break;
                case "datetime":
                    _vt = "DateTime";
                    break;
                case "decimal":
                    _vt = "Decimal";
                    break;
                case "float":
                    _vt = "Double";
                    break;
                case "image":
                    _vt = "Byte()";
                    break;
                case "int":
                    _vt = "Integer";
                    break;
                case "money":
                    _vt = "Double";
                    break;
                case "nchar":
                    _vt = "String";
                    break;
                case "ntext":
                    _vt = "String";
                    break;
                case "numeric":
                    //this is something special - come back to this
                    if (this._scale > 0)
                    {
                        //could be decimal or float - default to decimal
                        _vt = "Decimal";
                    }
                    else
                    {
                        //could by some variation of int - default to int
                        _vt = "Integer";
                    }
                    break;
                case "nvarchar":
                    _vt = "String";
                    break;
                case "real":
                    _vt = "Double";
                    break;
                case "smalldatetime":
                    _vt = "DateTime";
                    break;
                case "smallint":
                    _vt = "Integer";
                    break;
                case "smallmoney":
                    _vt = "Double";
                    break;
                case "sql_variant":
                    _vt = "Object";
                    break;
                case "text":
                    _vt = "String";
                    break;
                case "tinyint":
                    _vt = "Integer";
                    break;
                case "uniqueidentifier":
                    _vt = "System.Guid";
                    break;
                case "varbinary":
                    _vt = "Byte()";
                    break;
                case "varchar":
                    _vt = "String";
                    break;
                case "xml":
                    _vt = "System.Xml.XmlDocument";
                    break;
                default:
                    //unknown
                    _vt = "[UNKNOWN DATA TYPE]";
                    break;
            }
            return _vt;
        }

    }

}
