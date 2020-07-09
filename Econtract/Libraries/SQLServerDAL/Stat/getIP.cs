using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using IDAL.Stat;
using DBUtility;

namespace SQLServerDAL.Stat
{
    public class getIP : IgetIP
    {
        // Methods
        public getIP() { }

        public DataSet getIPList(long  ipnow,ref string addj,ref string addf)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@ipnow", SqlDbType.VarChar, 255), new SqlParameter("@addj", SqlDbType.VarChar, 255), new SqlParameter("@addf", SqlDbType.VarChar, 255) };
            parameters[0].Value = ipnow.ToString();
            parameters[1].Direction = ParameterDirection.Output;
            parameters[2].Direction = ParameterDirection.Output;
            DataSet redata = DbHelperSQL.RunProcedure("get_iplocation", parameters, "ds");
            addj = parameters[1].Value.ToString();
            addf = parameters[2].Value.ToString();
            return redata;
        }
    }
}
