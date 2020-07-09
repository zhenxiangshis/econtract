using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using IDAL.Stat;
using DBUtility;

namespace SQLServerDAL.Stat
{
    public class View:IView
    {
        // Methods
        public View() { }

        public DataSet GetViewList(string strTop, string strOrder, string strWhere)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@strTop", SqlDbType.VarChar, 50), new SqlParameter("@strOrder", SqlDbType.VarChar, 50), new SqlParameter("@strWhere", SqlDbType.VarChar, 500) };
            parameters[0].Value = strTop;
            parameters[1].Value = strOrder;
            parameters[2].Value = strWhere;
            return DbHelperSQL.RunProcedure("Stat_GetViewList", parameters, "ds");
        }
    }
}
