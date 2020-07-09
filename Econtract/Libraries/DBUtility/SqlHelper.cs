using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DBUtility
{
    public class SqlHelper
    {
        // Fields
    public static readonly string ConnectionStringInventoryDistributedTransaction;
    public static readonly string ConnectionStringLocalTransaction;
    public static readonly string ConnectionStringOrderDistributedTransaction;
    public static readonly string ConnectionStringProfile;
    private static Hashtable parmCache;

    // Methods
    static SqlHelper(){
    ConnectionStringLocalTransaction = ConfigurationManager.AppSettings["SQLConnString1"];
    ConnectionStringInventoryDistributedTransaction = ConfigurationManager.AppSettings["SQLConnString2"];
    ConnectionStringOrderDistributedTransaction = ConfigurationManager.AppSettings["SQLConnString3"];
    ConnectionStringProfile = ConfigurationManager.AppSettings["SQLProfileConnString"];
    parmCache = Hashtable.Synchronized(new Hashtable());
    }

    protected SqlHelper(){}
    public static void CacheParameters(string cacheKey, params SqlParameter[] commandParameters){
    parmCache[cacheKey] = commandParameters;
    }
    public static int ExecuteNonQuery(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters){
    SqlCommand cmd = new SqlCommand();
    PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
    int val = cmd.ExecuteNonQuery();
    cmd.Parameters.Clear();
    return val;
    }

        public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public static SqlDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                dr = rdr;
            }
            catch
            {
                conn.Close();
                throw;
            }
            return dr;
        }

        public static object ExecuteScalar(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }

        public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public static SqlParameter[] GetCachedParameters(string cacheKey)
        {
            SqlParameter[] cachedParms = (SqlParameter[])parmCache[cacheKey];
            if (cachedParms == null)
            {
                return null;
            }
            SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];
            int i = 0;
            int j = cachedParms.Length;
            while (i < j)
            {
                clonedParms[i] = (SqlParameter)((ICloneable)cachedParms[i]).Clone();
                i++;
            }
            return clonedParms;
        }

        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
            {
                cmd.Transaction = trans;
            }
            cmd.CommandType = cmdType;
            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                {
                    cmd.Parameters.Add(parm);
                }
            }
        }

     }


    }

