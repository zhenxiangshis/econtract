using System;
using System.Collections.Generic;
using System.Text;
using IDAL.Pro;
using System.Data;
using System.Data.SqlClient;
using DBUtility;
using System.Collections;

namespace SQLServerDAL.Pro
{
    public class Pro_Info : IPro_Info
    {
        // Methods
        public Pro_Info() { }
        public int AddProInfo(Model.Pro.Pro_Info model)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@ProID", SqlDbType.Int, 4), new SqlParameter("@ClassID", SqlDbType.Int, 4), new SqlParameter("@UserID", SqlDbType.Int, 4), new SqlParameter("@UserName", SqlDbType.VarChar, 0x19), new SqlParameter("@Title", SqlDbType.VarChar, 200), new SqlParameter("@Content", SqlDbType.VarChar, 200), new SqlParameter("@Remark", SqlDbType.NText), new SqlParameter("@Element", SqlDbType.VarChar, 0xfa0), new SqlParameter("@PicPath", SqlDbType.VarChar, 100), new SqlParameter("@PicName", SqlDbType.VarChar, 100), new SqlParameter("@CommFlag", SqlDbType.Int, 4), new SqlParameter("@Aud", SqlDbType.Int, 4), new SqlParameter("@Price", SqlDbType.VarChar, 100), new SqlParameter("@SpecialUrl", SqlDbType.VarChar, 200), new SqlParameter("@Method", SqlDbType.NVarChar) };
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.ClassID;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.UserName;
            parameters[4].Value = model.Title;
            parameters[5].Value = model.Content;
            parameters[6].Value = model.Remark;
            parameters[7].Value = model.Element;
            parameters[8].Value = model.PicPath;
            parameters[9].Value = model.PicName;
            parameters[10].Value = model.CommFlag;
            parameters[11].Value = model.Aud;
            parameters[12].Value = model.Price;
            parameters[13].Value = model.SpecialUrl;
            parameters[14].Value = model.Method;
            DbHelperSQL.RunProcedure("Pro_AddProInfo", parameters, out rowsAffected);
            return int.Parse(parameters[0].Value.ToString());
        }
        public void DeleteProInfo(int ProID)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@ProID", SqlDbType.Int, 4) };
            parameters[0].Value = ProID;
            DbHelperSQL.RunProcedure("Pro_DeleteProInfo", parameters, out rowsAffected);
        }

        public void DeleteProInfo(string ProID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Pro_Info ");
            strSql.Append(" where ProID in (" + ProID + ")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        public bool Exists(int ProID)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@ProID", SqlDbType.Int, 4) };
            parameters[0].Value = ProID;
            return (DbHelperSQL.RunProcedure("Pro_InfoExists", parameters, out rowsAffected) == 1);
        }
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ProID", "Pro_Info");
        }
        public ArrayList GetProIDList(string strWhere)
        {
            ArrayList list = new ArrayList();
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@strWhere", SqlDbType.VarChar, 0x3e8) };
            parameters[0].Value = strWhere;
            SqlDataReader reader = DbHelperSQL.RunProcedure("Pro_GetProIDList", parameters);
            while (reader.Read())
            {
                Model.Pro.Pro_Info model = new Model.Pro.Pro_Info();
                model.ProID = int.Parse(reader["ProID"].ToString());
                list.Add(model);
            }
            reader.Close();
            return list;
        }

        public DataSet GetProInfoList(int PageSize, int PageIndex, string OrderfldName, int OrderType, ref int IsReCount, string strWhere)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@tblName", SqlDbType.VarChar, 0xff), new SqlParameter("@fldName", SqlDbType.VarChar, 500), new SqlParameter("@OrderfldName", SqlDbType.VarChar, 0xff), new SqlParameter("@PageSize", SqlDbType.Int), new SqlParameter("@PageIndex", SqlDbType.Int), new SqlParameter("@IsReCount", SqlDbType.Int), new SqlParameter("@OrderType", SqlDbType.Int), new SqlParameter("@strWhere", SqlDbType.VarChar, 0x3e8) };
            parameters[0].Value = "Pro_Info";
            parameters[1].Value = "[ProID],[ClassID],[UserID],[UserName],[Title],[Content],[Remark],[Method],[PicPath],[PicName],[CommFlag],[AddTime],[VisitCount],[IsTop],[IsVouch],[IsDelete],[Aud],[Element],[Price],[SpecialUrl]";
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

        public Model.Pro.Pro_Info GetProInfoModel(int ProID)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@ProID", SqlDbType.Int, 4) };
            parameters[0].Value = ProID;
            Model.Pro.Pro_Info model = new Model.Pro.Pro_Info();
            DataSet ds = DbHelperSQL.RunProcedure("Pro_GetProInfoModel", parameters, "ds");
            model.ProID = ProID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ClassID"].ToString() != "")
                {
                    model.ClassID = int.Parse(ds.Tables[0].Rows[0]["ClassID"].ToString());
                }
                model.ClassName = ds.Tables[0].Rows[0]["ClassName"].ToString();
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                model.Method = ds.Tables[0].Rows[0]["Method"].ToString();
                model.Element = ds.Tables[0].Rows[0]["Element"].ToString();
                model.Price = ds.Tables[0].Rows[0]["Price"].ToString();
                model.PicPath = ds.Tables[0].Rows[0]["PicPath"].ToString();
                model.PicName = ds.Tables[0].Rows[0]["PicName"].ToString();
                model.SpecialUrl = ds.Tables[0].Rows[0]["SpecialUrl"].ToString();
                if (ds.Tables[0].Rows[0]["CommFlag"].ToString() != "")
                {
                    model.CommFlag = int.Parse(ds.Tables[0].Rows[0]["CommFlag"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["VisitCount"].ToString() != "")
                {
                    model.VisitCount = int.Parse(ds.Tables[0].Rows[0]["VisitCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsTop"].ToString() != "")
                {
                    model.IsTop = int.Parse(ds.Tables[0].Rows[0]["IsTop"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsVouch"].ToString() != "")
                {
                    model.IsVouch = int.Parse(ds.Tables[0].Rows[0]["IsVouch"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsDelete"].ToString() != "")
                {
                    model.IsDelete = int.Parse(ds.Tables[0].Rows[0]["IsDelete"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Aud"].ToString() != "")
                {
                    model.Aud = int.Parse(ds.Tables[0].Rows[0]["Aud"].ToString());
                }
                return model;
            }
            return null;
        }

        public DataSet GetProList(int strClassID, int strTop, string strOrder, string strWhere)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@strClassID", SqlDbType.Int, 4), new SqlParameter("@strTop", SqlDbType.Int, 4), new SqlParameter("@strOrder", SqlDbType.VarChar, 50), new SqlParameter("@strWhere", SqlDbType.VarChar, 500) };
            parameters[0].Value = strClassID;
            parameters[1].Value = strTop;
            parameters[2].Value = strOrder;
            parameters[3].Value = strWhere;
            return DbHelperSQL.RunProcedure("Pro_GetProList", parameters, "ds");
        }

        public int UpdateProInfo(Model.Pro.Pro_Info model)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@ProID", SqlDbType.Int, 4), new SqlParameter("@ClassID", SqlDbType.Int, 4), new SqlParameter("@UserID", SqlDbType.Int, 4), new SqlParameter("@UserName", SqlDbType.VarChar, 0x19), new SqlParameter("@Title", SqlDbType.VarChar, 200), new SqlParameter("@Content", SqlDbType.VarChar, 400), new SqlParameter("@Remark", SqlDbType.NText), new SqlParameter("@PicPath", SqlDbType.VarChar, 100), new SqlParameter("@PicName", SqlDbType.VarChar, 100), new SqlParameter("@CommFlag", SqlDbType.Int, 4), new SqlParameter("@IsTop", SqlDbType.Int, 4), new SqlParameter("@IsVouch", SqlDbType.Int, 4), new SqlParameter("@IsDelete", SqlDbType.Int, 4), new SqlParameter("@Element", SqlDbType.VarChar, 200), new SqlParameter("@Price", SqlDbType.VarChar, 200), new SqlParameter("@SpecialUrl", SqlDbType.VarChar, 200), new SqlParameter("@Method", SqlDbType.NVarChar) };
            parameters[0].Value = model.ProID;
            parameters[1].Value = model.ClassID;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.UserName;
            parameters[4].Value = model.Title;
            parameters[5].Value = model.Content;
            parameters[6].Value = model.Remark;
            parameters[7].Value = model.PicPath;
            parameters[8].Value = model.PicName;
            parameters[9].Value = model.CommFlag;
            parameters[10].Value = model.IsTop;
            parameters[11].Value = model.IsVouch;
            parameters[12].Value = model.IsDelete;
            parameters[13].Value = model.Element;
            parameters[14].Value = model.Price;
            parameters[15].Value = model.SpecialUrl;
            parameters[16].Value = model.Method;
            DbHelperSQL.RunProcedure("Pro_UpdateProInfo", parameters, out rowsAffected);
            return rowsAffected;
        }

        public void UpProInfo(string ProID, string Act, string YesNo)
        {
            StringBuilder strSql = new StringBuilder();
            if (Act == "Top")
            {
                strSql.Append(string.Concat(new object[] { "update Pro_Info set IsTop=", YesNo, ",TopTime='", DateTime.Now, "'" }));
                strSql.Append(" where ProID =" + ProID);
            }
            else if (Act == "Vouch")
            {
                strSql.Append(string.Concat(new object[] { "update Pro_Info set IsVouch=", YesNo, ",VouchTime='", DateTime.Now, "'" }));
                strSql.Append(" where ProID =" + ProID);
            }
            else
            {
                strSql.Append("update Pro_Info set Aud=" + YesNo + " ");
                strSql.Append(" where ProID =" + ProID);
            }
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        public int VisitProInfo(int ProID)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@ProID", SqlDbType.Int, 4), new SqlParameter("@VisitCount", SqlDbType.Int, 4) };
            parameters[0].Value = ProID;
            parameters[1].Direction = ParameterDirection.Output;
            DbHelperSQL.RunProcedure("Pro_VisitProInfo", parameters, out rowsAffected);
            return int.Parse(parameters[1].Value.ToString());
        }
    }


}
