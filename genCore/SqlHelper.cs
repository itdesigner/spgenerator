namespace spGenerator.genCore
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    using System.Data.Sql;

    public class SqlHelper
    {
        public static string[] EnumerateSPs(string connString)
        {
            string[] sSPList = new string[0];
            int iCount;
            string sQuery = "SELECT DISTINCT ROUTINE_SCHEMA + '.' + ROUTINE_NAME AS SP_NAME FROM INFORMATION_SCHEMA.ROUTINES AS i WHERE (LEFT(ROUTINE_NAME, 3) <> 'dt_') AND (ROUTINE_TYPE = 'PROCEDURE')";
            try
            {
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sQuery;
                SqlDataReader sqlReader = cmd.ExecuteReader();
                // Call Read before accessing data.
                iCount = 0;
                while (sqlReader.Read())
                {
                    iCount++;
                    string[] sTemp = new string[iCount];
                    for (int iTCount = 0; iTCount < iCount - 1; iTCount++)
                    { sTemp[iTCount] = sSPList[iTCount]; }
                    sTemp[iCount - 1] = String.Format("{0}", sqlReader[0]);
                    sSPList = null;
                    sSPList = sTemp;
                }

                // Call Close when done reading.
                sqlReader.Close();
            }
            catch (Exception ex)
            {
                sSPList = new string[1];
                sSPList[0] = ex.Message;
            }
            return sSPList;
        }
        public static string GetSPText(string spName, string connString)
        {
            string sSPResult = string.Empty;
            string sQuery = "SELECT c.text, c.colid FROM sys.sysobjects AS o INNER JOIN sys.syscomments AS c ON o.id = c.id WHERE (o.id = OBJECT_ID('" + spName + "'))";
            try
            {
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sQuery;
                SqlDataReader sqlReader = cmd.ExecuteReader();
                // Call Read before accessing data.
                while (sqlReader.Read())
                {
                    sSPResult += String.Format("{0}, {1}", sqlReader[0], sqlReader[1]);
                }

                // Call Close when done reading.
                sqlReader.Close();
                while (sSPResult.StartsWith("\r\n"))
                {
                    sSPResult = sSPResult.Substring(2);
                }
            }
            catch (Exception ex)
            {
                sSPResult = ex.Message;
            }
            return sSPResult;
        }
        public static bool PublishText(string txt2pub, string connString)
        {
            bool bResult = false;
            try
            {
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = txt2pub.Replace("\n",System.Environment.NewLine);
                int rows_affected = cmd.ExecuteNonQuery();
                if (rows_affected == -1) { bResult = true; } else { bResult = false; }
            }
            catch (Exception ex)
            {
                string sTemp = ex.Message;
            }
            return bResult;
        }

        public string[] EnumerateSQLServerDatabases(string sqlServer, string userName, string password, bool useWindowsAuthentication)
        {
            if (useWindowsAuthentication)
            {
                userName = string.Empty;
            }
            return this.RetrieveInformation(string.Concat(new string[] { "DRIVER=SQL SERVER;SERVER=", sqlServer, ";UID=", userName, ";PWD=", password }), useWindowsAuthentication, true);
        }

        public string[] EnumerateSQLServers()
        {
            return this.RetrieveInformation("DRIVER=SQL SERVER", false, false);
        }

        private void FreeConnection(IntPtr handleToFree)
        {
            if (handleToFree != IntPtr.Zero)
            {
                SqlHelper.SQLFreeHandle(2, handleToFree);
            }
        }

        private string[] ParseSQLOutConnection(string outConnection)
        {
            int num1 = outConnection.IndexOf("{") + 1;
            int num2 = outConnection.IndexOf("}") - num1;
            if ((num1 > 0) && (num2 > 0))
            {
                outConnection = outConnection.Substring(num1, num2);
            }
            else
            {
                outConnection = string.Empty;
            }
            return outConnection.Split(",".ToCharArray());
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
        public string[] EnumerateDatabaseTables(string connectionString)
        {
            System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connectionString);
            System.Data.SqlClient.SqlCommand comm = new System.Data.SqlClient.SqlCommand();
            comm.Connection = conn;
            string sCommand = string.Empty;
            if (!IsSqlServer2005(connectionString))
            {
                sCommand = "select table_name as Name from INFORMATION_SCHEMA.Tables where TABLE_TYPE = 'BASE TABLE' ORDER BY TABLE_NAME";
            }
            else
            {
                sCommand = "SELECT T.TABLE_NAME AS Name FROM INFORMATION_SCHEMA.TABLES T WHERE T.TABLE_TYPE = 'BASE TABLE' ORDER BY T.TABLE_NAME";
            }
            comm.CommandText = sCommand;
            comm.CommandType = CommandType.Text;
            DataSet DS = new DataSet();
            System.Data.SqlClient.SqlDataAdapter DA = new System.Data.SqlClient.SqlDataAdapter(comm);
            conn.Open();
            DA.Fill(DS);
            conn.Close();
            string[] sResults = new string[DS.Tables[0].Rows.Count];
            int i = 0;
            foreach (System.Data.DataRow dr in DS.Tables[0].Rows)
            {
                sResults[i] = dr["Name"].ToString().Trim();
                i++;
            }
            return sResults;
        }

        private string[] RetrieveInformation(string InputParam, bool useWindowsAuthentication, bool retrivingDatabases)
        {
            IntPtr ptr1 = IntPtr.Zero;
            IntPtr ptr2 = IntPtr.Zero;
            StringBuilder builder1 = new StringBuilder(InputParam);
            short num1 = (short) builder1.Length;
            StringBuilder builder2 = new StringBuilder(0x400);
            short num2 = 0;
            try
            {
                if (((SqlHelper.SQLAllocHandle(1, ptr1, out ptr1) == 0) && (SqlHelper.SQLSetEnvAttr(ptr1, 200, (IntPtr) 3, 0) == 0)) && (SqlHelper.SQLAllocHandle(2, ptr1, out ptr2) == 0))
                {
                    int num3 = 0;
                    if (useWindowsAuthentication)
                    {
                        num3 = SqlHelper.SQLSetConnectAttr(ptr2, 0x4b3, (IntPtr) 1, 0);
                    }
                    if ((0x63 == SqlHelper.SQLBrowseConnect(ptr2, builder1, num1, builder2, 0x400, out num2)) && (0x63 != SqlHelper.SQLBrowseConnect(ptr2, builder1, num1, builder2, 0x400, out num2)))
                    {
                        throw new ApplicationException("No Data Returned.");
                    }
                }
            }
            catch (Exception)
            {
                throw new ApplicationException("Cannot Locate SQL Server.");
            }
            finally
            {
                this.FreeConnection(ptr2);
                this.FreeConnection(ptr1);
            }
            if (builder2.Length > 0)
            {
                if (retrivingDatabases && (builder2.ToString().Substring(0, 9) != "*DATABASE"))
                {
                    return null;
                }
                return this.ParseSQLOutConnection(builder2.ToString());
            }
            return null;
        }

        [DllImport("odbc32.dll")]
        private static extern short SQLAllocHandle(short handleType, IntPtr inputHandle, out IntPtr outputHandlePtr);
        [DllImport("odbc32.dll", CharSet=CharSet.Ansi)]
        private static extern short SQLBrowseConnect(IntPtr handleConnection, StringBuilder inConnection, short stringLength, StringBuilder outConnection, short bufferLength, out short stringLength2Ptr);
        [DllImport("odbc32.dll")]
        private static extern short SQLFreeHandle(short hType, IntPtr Handle);
        [DllImport("odbc32.dll")]
        private static extern short SQLSetConnectAttr(IntPtr environmentHandle, int attribute, IntPtr valuePtr, int stringLength);
        [DllImport("odbc32.dll")]
        private static extern short SQLSetEnvAttr(IntPtr environmentHandle, int attribute, IntPtr valuePtr, int stringLength);

        private const short DEFAULT_RESULT_SIZE = 0x400;
        private const string END_STR = "}";
        private const int SQL_ATTR_ODBC_VERSION = 200;
        private const int SQL_COPT_SS_BASE = 0x4b0;
        private const string SQL_DRIVER_STR = "DRIVER=SQL SERVER";
        private const short SQL_HANDLE_DBC = 2;
        private const short SQL_HANDLE_ENV = 1;
        private const int SQL_INTEGRATED_SECURITY = 0x4b3;
        private const int SQL_IS_ON = 1;
        private const short SQL_NEED_DATA = 0x63;
        private const int SQL_OV_ODBC3 = 3;
        private const short SQL_SUCCESS = 0;
        private const string START_STR = "{";
    }
}

