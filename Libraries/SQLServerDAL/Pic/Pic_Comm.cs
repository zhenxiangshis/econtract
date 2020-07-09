using System;
using System.Collections.Generic;
using System.Text;
using IDAL.Pic;
using DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace SQLServerDAL.Pic
{
    public class Pic_Comm : IPic_Comm
    {
        // Methods
        public Pic_Comm() { }
        public int AddPicComm(Model.Pic.Pic_Comm model)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@CommID", SqlDbType.Int, 4), new SqlParameter("@UserID", SqlDbType.Int, 4), new SqlParameter("@UserName", SqlDbType.VarChar, 50), new SqlParameter("@PicID", SqlDbType.Int, 4), new SqlParameter("@Content", SqlDbType.NText), new SqlParameter("@Ip", SqlDbType.VarChar, 50), new SqlParameter("@Fen", SqlDbType.Int, 4), new SqlParameter("@PicTime", SqlDbType.VarChar, 50) };
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.PicID;
            parameters[4].Value = model.Content;
            parameters[5].Value = model.Ip;
            parameters[6].Value = model.Fen;
            parameters[7].Value = model.PicTime;
            DbHelperSQL.RunProcedure("Pic_AddPicComm", parameters, out rowsAffected);
            return int.Parse(parameters[0].Value.ToString());
        }

        public void DeletePicComm(int CommID)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@CommID", SqlDbType.Int, 4) };
            parameters[0].Value = CommID;
            DbHelperSQL.RunProcedure("Pic_DeletePicComm", parameters, out rowsAffected);
        }

        public void DeletePicComm(string CommID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Pic_Comm ");
            strSql.Append(" where CommID in (" + CommID + ")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        public DataSet GetPicCommList(int PicID)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@PicID", SqlDbType.Int, 4) };
            parameters[0].Value = PicID;
            return DbHelperSQL.RunProcedure("Pic_GetPicCommList", parameters, "ds");
        }

        public DataSet GetPicCommList(int PageSize, int PageIndex, string OrderfldName, int OrderType, ref int IsReCount, string strWhere)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@tblName", SqlDbType.VarChar, 0xff), new SqlParameter("@fldName", SqlDbType.VarChar, 500), new SqlParameter("@OrderfldName", SqlDbType.VarChar, 0xff), new SqlParameter("@PageSize", SqlDbType.Int), new SqlParameter("@PageIndex", SqlDbType.Int), new SqlParameter("@IsReCount", SqlDbType.Int), new SqlParameter("@OrderType", SqlDbType.Int), new SqlParameter("@strWhere", SqlDbType.VarChar, 0x3e8) };
            parameters[0].Value = "Pic_Comm";
            parameters[1].Value = "[CommID],[UserID],[UserName],[PicID],[Content],[Ip],[AddTime],[Fen],[PicTime]";
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
        public Model.Pic.Pic_Comm GetPicCommModel(int CommID)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@CommID", SqlDbType.Int, 4) };
            parameters[0].Value = CommID;
            Model.Pic.Pic_Comm model = new Model.Pic.Pic_Comm();
            DataSet ds = DbHelperSQL.RunProcedure("Pic_GetPicCommModel", parameters, "ds");
            model.CommID = CommID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                if (ds.Tables[0].Rows[0]["PicID"].ToString() != "")
                {
                    model.PicID = int.Parse(ds.Tables[0].Rows[0]["PicID"].ToString());
                }
                model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                model.Ip = ds.Tables[0].Rows[0]["Ip"].ToString();
                if (ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Fen"].ToString() != "")
                {
                    model.Fen = int.Parse(ds.Tables[0].Rows[0]["Fen"].ToString());
                }
                model.PicTime = ds.Tables[0].Rows[0]["PicTime"].ToString();
                return model;
            }
            return null;
        }

        public void UpdatePicComm(Model.Pic.Pic_Comm model)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@CommID", SqlDbType.Int, 4), new SqlParameter("@UserID", SqlDbType.Int, 4), new SqlParameter("@UserName", SqlDbType.VarChar, 50), new SqlParameter("@PicID", SqlDbType.Int, 4), new SqlParameter("@Content", SqlDbType.NText), new SqlParameter("@Ip", SqlDbType.VarChar, 50), new SqlParameter("@Fen", SqlDbType.Int, 4) };
            parameters[0].Value = model.CommID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.PicID;
            parameters[4].Value = model.Content;
            parameters[5].Value = model.Ip;
            parameters[6].Value = model.Fen;
            DbHelperSQL.RunProcedure("Pic_UpdatePicComm", parameters, out rowsAffected);
        }
    }


}
