using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using IDAL.Stat;
using DBUtility;

namespace SQLServerDAL.Stat
{
    public class Vjian : IVjian
    {
        // Methods
        public Vjian() { }

        public DataSet GetVjianList(string strTop, string strOrder, string strWhere)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@strTop", SqlDbType.VarChar, 50), new SqlParameter("@strOrder", SqlDbType.VarChar, 50), new SqlParameter("@strWhere", SqlDbType.VarChar, 500) };
            parameters[0].Value = strTop;
            parameters[1].Value = strOrder;
            parameters[2].Value = strWhere;
            return DbHelperSQL.RunProcedure("Stat_GetVjianList", parameters, "ds");
        }

        public int UpdateVjian(Model.Stat.Vjian model)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@today", SqlDbType.Int, 8), new SqlParameter("@yesterday", SqlDbType.Int, 8), new SqlParameter("@vdate", SqlDbType.DateTime, 4), new SqlParameter("@vtop", SqlDbType.Int, 8), new SqlParameter("@starttime", SqlDbType.DateTime, 4)};
            parameters[0].Value = model.Today;
            parameters[1].Value = model.Yesterday;
            parameters[2].Value = model.Vdate;
            parameters[3].Value = model.Vtop;
            parameters[4].Value = model.Starttime;
            DbHelperSQL.RunProcedure("Stat_UpdateVjian", parameters, out rowsAffected);
            return rowsAffected;
        }
    }
}
