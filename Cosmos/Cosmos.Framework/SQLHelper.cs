using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.Framework
{
    public class SQLHelper
    {

        private static bool m_UseTheSameConnection;
        public static bool UseTheSameConnection
        {
            get
            {
                return m_UseTheSameConnection;
            }
            set
            {
                m_UseTheSameConnection = value;
                if (!value)
                {
                    if (!(Connection == null) && Connection.State == ConnectionState.Open)
                        Connection.Close();
                }
            }
        }

        public static string ConnectionString { get; set; }

        private static int m_CommandTimeout;
        public static int CommandTimeout
        {
            get
            {
                return m_CommandTimeout;
            }
            set
            {
                m_CommandTimeout = value;
            }
        }

        

        public static bool ConnectionOK(string connectionString, ref Exception exSQL)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            exSQL = null;
            bool r = false;
            try
            {
                conn.Open();
                r = true;
            }
            catch (Exception ex)
            {
                exSQL = ex;
                r = false;
            }
            if (conn.State == ConnectionState.Open)
                conn.Close();
            return r;
        }

        private static SqlConnection _Connection;
        public static SqlConnection Connection
        {
            get
            {
                if (UseTheSameConnection)
                {
                    if (_Connection == null)
                    {
                        if (!string.IsNullOrEmpty(ConnectionString))
                            _Connection = new SqlConnection(ConnectionString);
                    }
                    return _Connection;
                }
                if (string.IsNullOrEmpty(ConnectionString))
                    return null;
                return new SqlConnection(ConnectionString);
            }
        }

        public static bool ConnectionOK()
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConnectionString);
                conn.Open();
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static SqlCommand GetSPCommand(string storedProcedureName, params object[] parameters)
        {
            // crea un nuevo objeto, asignale la conexion
            SqlCommand cmd = new SqlCommand(storedProcedureName, Connection);
            // especifica que es un stored procedure lo que se ejecutara
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = SQLHelper.CommandTimeout;

            // carga los parametros
            if (cmd.Parameters.Count != parameters.Length || cmd.Parameters.Count == 0)
            {
                if (!(cmd.Connection.State == ConnectionState.Open))
                    cmd.Connection.Open();
                SqlCommandBuilder.DeriveParameters(cmd);
                if (!UseTheSameConnection)
                    cmd.Connection.Close();
            }

            // asigna los valores
            if (cmd.Parameters.Count > 0 && parameters.Length > 0)
            {
                // valida para no tomar en cuenta los parametros de tipo return value
                int i, j,iStart;
                i = 0; j = 0; iStart=0;
                if (cmd.Parameters[0].Direction == ParameterDirection.ReturnValue)
                {
                    iStart = 1;
                }
                var loopTo = cmd.Parameters.Count - 1;
                for (i = iStart; i <= loopTo; i++)
                {
                    try
                    {
                        switch (cmd.Parameters[i].DbType)
                        {
                            case var @case when @case == DbType.Date:
                            case var case1 when case1 == DbType.DateTime:
                            case var case2 when case2 == DbType.DateTime2:
                                {
                                    if (parameters[j] == null || (DateTime)parameters[j]==DateTime.MinValue)
                                        cmd.Parameters[i].Value = DBNull.Value;
                                    else
                                        cmd.Parameters[i].Value = parameters[j];
                                    break;
                                }

                            case var case3 when case3 == DbType.String:
                                {
                                    if (string.IsNullOrEmpty(CastHelper.CStr2(parameters[j])))
                                        cmd.Parameters[i].Value = string.Empty;
                                    else
                                        cmd.Parameters[i].Value = parameters[j];
                                    break;
                                }

                            default:
                                {
                                    cmd.Parameters[i].Value = parameters[j];
                                    break;
                                }
                        }
                    }
                    catch
                    {
                    }
                    j += 1;
                }
            }

            // devuelve el objeto cmd
            return cmd;
        }

        private static bool ValidateSafeSQL(string sql)
        {
            if (sql.ToLower().Contains("delete ") || sql.ToLower().Contains("insert ") || sql.ToLower().Contains("update ") || sql.ToLower().Contains("/*") || sql.ToLower().Contains("--") || sql.ToLower().Contains("alter ") || sql.ToLower().Contains("truncate ") || sql.ToLower().Contains("create ") || sql.ToLower().Contains("drop ") || sql.ToLower().Contains("set "))
            {
                throw new Exception("SQL contains unsafe text.");
            }
            return true;
        }

        internal static SqlCommand GetCommand(string query, bool safeSQL = false)
        {
            if (safeSQL)
            {
                if (ValidateSafeSQL(query))
                {
                    SqlCommand cmd = new SqlCommand(query, Connection);
                    cmd.CommandTimeout = SQLHelper.CommandTimeout;
                    return cmd;
                }
            }
            else
            {
                SqlCommand cmd = new SqlCommand(query, Connection);
                cmd.CommandTimeout = SQLHelper.CommandTimeout;
                return cmd;
            }
            return null;
        }

        public static SqlDataReader GetReader(string StoredProcedureName, params object[] parameters)
        {
            SqlCommand cmd = GetSPCommand(StoredProcedureName, parameters);
            return GetReader(cmd);
        }

        public static SqlDataReader GetReader(SqlCommand cmd)
        {
            try
            {
                {
                    var withBlock = cmd;
                    if (withBlock.Connection.State == ConnectionState.Closed)
                        withBlock.Connection.Open();
                }
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

       
        public static SqlDataReader GetReaderFromQuery(string query, bool safeSQL = true)
        {
            if (safeSQL)
            {
                if (query.ToLower().Contains("delete ") || query.ToLower().Contains("insert ") || query.ToLower().Contains("update ") || query.ToLower().Contains("/*") || query.ToLower().Contains("--") || query.ToLower().Contains("alter ") || query.ToLower().Contains("truncate ") || query.ToLower().Contains("create ") || query.ToLower().Contains("drop ") || query.ToLower().Contains("set "))
                    return null;
                else
                    return GetReader(GetCommand(query));
            }
            else
                return GetReader(GetCommand(query));
        }

        public static DataTable GetTableWithName(string tableName, string StoredProcedureName, params object[] parameters)
        {
            DataTable dt = new DataTable(tableName);
            SqlDataReader dr = GetReader(StoredProcedureName, parameters);
            if (!(dr == null))
            {
                dt.Load(dr);
                dr.Close();
            }
            return dt;
        }

        public static DataTable GetTableFromQueryWithName(string tableName, string query, bool safeSQL = true)
        {
            DataTable dt = new DataTable(tableName);
            SqlDataReader dr = GetReaderFromQuery(query, safeSQL);
            if (!(dr == null))
            {
                dt.Load(dr);
                dr.Close();
            }
            return dt;
        }

        public static DataTable GetTable(string StoredProcedureName, params object[] parameters)
        {
            return GetTableWithName("Table1", StoredProcedureName, parameters);
        }

        public static DataTable GetTableFromQuery(string query, bool safeSQL = true)
        {
            return GetTableFromQueryWithName("Table1", query, safeSQL);
        }

        public static object ExecuteScalar(string storedProcedureName, params object[] parameters)
        {
            SqlCommand cmd = GetSPCommand(storedProcedureName, parameters);
            return ExecuteScalar(cmd);
        }

        public static object ExecuteScalarFromText(string query, bool safeSQL = false)
        {
            SqlCommand cmd = GetCommand(query, safeSQL);
            return ExecuteScalar(cmd);
        }

        public static object ExecuteScalar(SqlCommand cmd)
        {
            object r = null;
            if (cmd != null) {
                if (cmd.Connection.State == ConnectionState.Closed) { cmd.Connection.Open(); }
                r = cmd.ExecuteScalar();
                if (!UseTheSameConnection) {
                    cmd.Connection.Close();
                }
            }
            return r;
        }

        public static int ExecuteNonQuery(string storedProcedureName, params object[] parameters)
        {
            SqlCommand cmd = GetSPCommand(storedProcedureName, parameters);
            return (int)ExecuteNonQuery(cmd);
        }

        public static int ExecuteNonQueryFromText(SqlConnection conn, string query)
        {
            SqlCommand cmd = GetCommand(query);
            cmd.Connection = conn;
            return ExecuteNonQuery(cmd);
        }

        public static int ExecuteNonQueryFromText(string query)
        {
            return ExecuteNonQuery(GetCommand(query));
        }

        public static int ExecuteNonQuery(SqlCommand cmd)
        {
            int r = 0;
            if (cmd != null)
            {
                if (cmd.Connection.State == ConnectionState.Closed) { cmd.Connection.Open(); }
                r = cmd.ExecuteNonQuery();
                if (!UseTheSameConnection)
                {
                    cmd.Connection.Close();
                }
            }
            return r;            
        }
      
        public static DataRow GetFirstRow(string StoredProcedureName, params object[] parameters)
        {
            DataTable dt = GetTable(StoredProcedureName, parameters);
            if (!(dt == null) && dt.Rows.Count > 0) {
                return dt.Rows[0];
            }                
            return null;
        }

      



        /// <summary>
        /// Recibe un datarow, revisa si contiene la columna de "Errores", evalua el resultado y si encontro errores
        /// genera un System.Exception con el mensaje de error contenido en la columna "Mensaje" del datarow, 
        /// en caso de que no exista la columna o venga vacia, se utiliza un mensaje genérico de error.
        /// </summary>
        /// <param name="dr"></param>
        public static bool ErrorRespuestaSQL(DataRow dr)
            {
                bool errores = false;
                string mensajeError = "";
                if (dr != null)
                {
                    if (dr.Table.Columns["Errores"] != null)
                    {
                        errores = (CastHelper.CInt2(dr["Errores"]) != 0);
                        if (dr.Table.Columns["Mensaje"] != null)
                        {
                            mensajeError = CastHelper.CStr2(dr["Mensaje"]).Trim();
                        }
                    }
                }
                if (errores)
                {
                    if (mensajeError.Equals(""))
                    {
                        mensajeError = "Se encontró un error al procesar el comando SQL.";
                    }
                    throw new Exception(mensajeError);
                }
                return errores;
            }


    }
}
