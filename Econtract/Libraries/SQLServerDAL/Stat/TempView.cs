using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using IDAL.Stat;
using DBUtility;

namespace SQLServerDAL.Stat
{
    public class TempView : ITempView
    {
         // Methods
        public TempView() { }

        public DataSet GetTempViewList(string strTop, string strOrder, string strWhere)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@strTop", SqlDbType.VarChar, 50), new SqlParameter("@strOrder", SqlDbType.VarChar, 50), new SqlParameter("@strWhere", SqlDbType.VarChar, 500) };
            parameters[0].Value = strTop;
            parameters[1].Value = strOrder;
            parameters[2].Value = strWhere;
            return DbHelperSQL.RunProcedure("Stat_GetTempViewList", parameters, "ds");
        }
        public DataSet GetTempViewInfoList(int PageSize, int PageIndex, string OrderfldName, int OrderType, ref int IsReCount, string strWhere)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@tblName", SqlDbType.VarChar, 0xff), new SqlParameter("@fldName", SqlDbType.VarChar, 500), new SqlParameter("@OrderfldName", SqlDbType.VarChar, 0xff), new SqlParameter("@PageSize", SqlDbType.Int), new SqlParameter("@PageIndex", SqlDbType.Int), new SqlParameter("@IsReCount", SqlDbType.Int), new SqlParameter("@OrderType", SqlDbType.Int), new SqlParameter("@strWhere", SqlDbType.VarChar, 0x3e8) };
            parameters[0].Value = "tempview";
            parameters[1].Value = "[id],[vyear],[vmonth],[vday],[vhour],[vtime],[vweek],[vip],[vwhere],[vwheref],[vcome],[vpage],[vsoft],[vOS],[vwidth],[bakdays],[bakstats],[bakpage]";
            parameters[2].Value = OrderfldName;
            parameters[3].Value = PageSize;
            parameters[4].Value = PageIndex;
            parameters[5].Direction = ParameterDirection.Output;
            parameters[6].Value = OrderType;
            parameters[7].Value = strWhere;
            DataSet redata = DbHelperSQL.RunProcedure("GetRecordByPage", parameters, "ds");
            IsReCount = int.Parse(parameters[5].Value.ToString());
            return redata;
        }
        public int AddTempView(Model.Stat.TempView model)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@vyear", SqlDbType.Int, 4), new SqlParameter("@vmonth", SqlDbType.Int, 4), new SqlParameter("@vday", SqlDbType.Int, 4), new SqlParameter("@vhour", SqlDbType.Int, 4), new SqlParameter("@vtime", SqlDbType.DateTime, 20), new SqlParameter("@vweek", SqlDbType.Int, 4), new SqlParameter("@vip", SqlDbType.VarChar, 255), new SqlParameter("@vwhere", SqlDbType.VarChar, 255), new SqlParameter("@vwheref", SqlDbType.VarChar, 255), new SqlParameter("@vcome", SqlDbType.VarChar, 255), new SqlParameter("@vpage", SqlDbType.VarChar, 255), new SqlParameter("@vsoft", SqlDbType.VarChar, 255), new SqlParameter("@vos", SqlDbType.VarChar, 255), new SqlParameter("@vwidth", SqlDbType.Int, 8) };
            parameters[0].Value = model.Vyear;
            parameters[1].Value = model.Vmonth;
            parameters[2].Value = model.Vday;
            parameters[3].Value = model.Vhour;
            parameters[4].Value = model.Vtime;
            parameters[5].Value = model.Vweek;
            parameters[6].Value = model.Vip;
            parameters[7].Value = model.Vwhere;
            parameters[8].Value = model.Vwheref;
            parameters[9].Value = model.Vcome;
            parameters[10].Value = model.Vpage;
            parameters[11].Value = model.Vsoft;
            parameters[12].Value = model.Vos;
            parameters[13].Value = model.Vwidth;
            DbHelperSQL.RunStatProcedure("ins_tempview", parameters, out rowsAffected);
            return rowsAffected;
        }
    }
}
