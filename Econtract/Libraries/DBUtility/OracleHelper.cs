using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;

namespace DBUtility
{
    public class OracleHelper
    {
        // Fields
    public static readonly string ConnectionStringInventoryDistributedTransaction;
    public static readonly string ConnectionStringLocalTransaction;
    public static readonly string ConnectionStringMembership;
    public static readonly string ConnectionStringOrderDistributedTransaction;
    public static readonly string ConnectionStringProfile;
    private static Hashtable parmCache;

    // Methods
    static OracleHelper()
    {
    ConnectionStringLocalTransaction = ConfigurationManager.AppSettings["OraConnString1"];
    ConnectionStringInventoryDistributedTransaction = ConfigurationManager.AppSettings["OraConnString2"];
    ConnectionStringOrderDistributedTransaction = ConfigurationManager.AppSettings["OraConnString3"];
    ConnectionStringProfile = ConfigurationManager.AppSettings["OraProfileConnString"];
    ConnectionStringMembership = ConfigurationManager.AppSettings["OraMembershipConnString"];
    parmCache = Hashtable.Synchronized(new Hashtable());
    }

    protected OracleHelper(){}
    public static void CacheParameters(string cacheKey, params OracleParameter[] commandParameters){
    parmCache[cacheKey] = commandParameters;
    }

    public static int ExecuteNonQuery(OracleConnection connection, CommandType cmdType, string cmdText, params OracleParameter[] commandParameters){
    OracleCommand cmd = new OracleCommand();
    PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
    int val = cmd.ExecuteNonQuery();
    cmd.Parameters.Clear();
    return val;
    }

    public static int ExecuteNonQuery(OracleTransaction trans, CommandType cmdType, string cmdText, params OracleParameter[] commandParameters){
    OracleCommand cmd = new OracleCommand();
    PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
    int val = cmd.ExecuteNonQuery();
    cmd.Parameters.Clear();
    return val;
    }

    public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params OracleParameter[] commandParameters){
    OracleCommand cmd = new OracleCommand();
    using (OracleConnection connection = new OracleConnection(connectionString))
    {
        PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
        int val = cmd.ExecuteNonQuery();
        cmd.Parameters.Clear();
        return val;
    }
    }
    public static OracleDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params OracleParameter[] commandParameters){
    OracleDataReader odr;
    OracleCommand cmd = new OracleCommand();
    OracleConnection conn = new OracleConnection(connectionString);
    try
    {
        PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
        OracleDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        cmd.Parameters.Clear();
        odr = rdr;
    }
    catch
    {
        conn.Close();
        throw;
    }
    return odr;
    }

    public static object ExecuteScalar(OracleConnection connectionString, CommandType cmdType, string cmdText, params OracleParameter[] commandParameters){
    OracleCommand cmd = new OracleCommand();
    PrepareCommand(cmd, connectionString, null, cmdType, cmdText, commandParameters);
    object val = cmd.ExecuteScalar();
    cmd.Parameters.Clear();
    return val;
    }

    public static object ExecuteScalar(OracleTransaction transaction, CommandType commandType, string commandText, params OracleParameter[] commandParameters){
    if (transaction == null)
    {
        throw new ArgumentNullException("transaction");
    }
    if ((transaction != null) && (transaction.Connection == null))
    {
        throw new ArgumentException("The transaction was rollbacked\tor commited, please\tprovide\tan open\ttransaction.", "transaction");
    }
    OracleCommand cmd = new OracleCommand();
    PrepareCommand(cmd, transaction.Connection, transaction, commandType, commandText, commandParameters);
    object retval = cmd.ExecuteScalar();
    cmd.Parameters.Clear();
    return retval;
    }

    public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params OracleParameter[] commandParameters){
    OracleCommand cmd = new OracleCommand();
    using (OracleConnection conn = new OracleConnection(connectionString))
    {
        PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
        object val = cmd.ExecuteScalar();
        cmd.Parameters.Clear();
        return val;
    }
}

    public static OracleParameter[] GetCachedParameters(string cacheKey){
    OracleParameter[] cachedParms = (OracleParameter[]) parmCache[cacheKey];
    if (cachedParms == null)
    {
        return null;
    }
    OracleParameter[] clonedParms = new OracleParameter[cachedParms.Length];
    int i = 0;
    int j = cachedParms.Length;
    while (i < j)
    {
        clonedParms[i] = (OracleParameter) ((ICloneable) cachedParms[i]).Clone();
        i++;
    }
    return clonedParms;
}

    public static string OraBit(bool value){
    if (value)
    {
        return "Y";
    }
    return "N";
}

    public static bool OraBool(string value){
    return value.Equals("Y");
    }

 
    private static void PrepareCommand(OracleCommand cmd, OracleConnection conn, OracleTransaction trans, CommandType cmdType, string cmdText, OracleParameter[] commandParameters){
    if (conn.State != ConnectionState.Open)
    {
        conn.Open();
    }
    cmd.Connection = conn;
    cmd.CommandText = cmdText;
    cmd.CommandType = cmdType;
    if (trans != null)
    {
        cmd.Transaction = trans;
    }
    if (commandParameters != null)
    {
        foreach (OracleParameter parm in commandParameters)
        {
            cmd.Parameters.Add(parm);
        }
    }
}

 

}


    }

