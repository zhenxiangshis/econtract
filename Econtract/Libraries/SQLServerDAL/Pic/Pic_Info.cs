using System;
using System.Collections.Generic;
using System.Text;
using IDAL.Pic;
using DBUtility;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace SQLServerDAL.Pic
{
    public class Pic_Info : IPic_Info
    {
        // Methods
        public Pic_Info() { }
        public int AddPicInfo(Model.Pic.Pic_Info model)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@PicID", SqlDbType.Int, 4), new SqlParameter("@ClassID", SqlDbType.Int, 4), new SqlParameter("@UserID", SqlDbType.Int, 4), new SqlParameter("@UserName", SqlDbType.VarChar, 0x19), new SqlParameter("@Title", SqlDbType.VarChar, 200), new SqlParameter("@Tag", SqlDbType.VarChar, 200), new SqlParameter("@Remark", SqlDbType.VarChar, 0xfa0), new SqlParameter("@Manage", SqlDbType.VarChar, 200), new SqlParameter("@PicPath", SqlDbType.VarChar, 100), new SqlParameter("@PicName", SqlDbType.VarChar, 100), new SqlParameter("@CommFlag", SqlDbType.Int, 4), new SqlParameter("@Aud", SqlDbType.Int, 4), new SqlParameter("@Shoper", SqlDbType.VarChar, 50), new SqlParameter("@CreateShop", SqlDbType.DateTime), new SqlParameter("@Address", SqlDbType.VarChar, 200) };
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.ClassID;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.UserName;
            parameters[4].Value = model.Title;
            parameters[5].Value = model.Tag;
            parameters[6].Value = model.Remark;
            parameters[7].Value = model.Manage;
            parameters[8].Value = model.PicPath;
            parameters[9].Value = model.PicName;
            parameters[10].Value = model.CommFlag;
            parameters[11].Value = model.Aud;
            parameters[12].Value = model.Shoper;
            parameters[13].Value = model.CreateShop;
            parameters[14].Value = model.Address;
            DbHelperSQL.RunProcedure("Pic_AddPicInfo", parameters, out rowsAffected);
            return int.Parse(parameters[0].Value.ToString());
        }

        public void DeletePicInfo(int PicID)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@PicID", SqlDbType.Int, 4) };
            parameters[0].Value = PicID;
            DbHelperSQL.RunProcedure("Pic_DeletePicInfo", parameters, out rowsAffected);
        }
        public void DeletePicInfo(string PicID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Pic_Info ");
            strSql.Append(" where PicID in (" + PicID + ")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        public bool Exists(int PicID)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@PicID", SqlDbType.Int, 4) };
            parameters[0].Value = PicID;
            return (DbHelperSQL.RunProcedure("Pic_InfoExists", parameters, out rowsAffected) == 1);
        }
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("PicID", "Pic_Info");
        }

        public ArrayList GetPicIDList(string strWhere)
        {
            ArrayList list = new ArrayList();
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@strWhere", SqlDbType.VarChar, 0x3e8) };
            parameters[0].Value = strWhere;
            SqlDataReader reader = DbHelperSQL.RunProcedure("Pic_GetPicIDList", parameters);
            while (reader.Read())
            {
                Model.Pic.Pic_Info model = new Model.Pic.Pic_Info();
                model.PicID = int.Parse(reader["PicID"].ToString());
                list.Add(model);
            }
            reader.Close();
            return list;
        }
        public DataSet GetPicInfoList(int PageSize, int PageIndex, string OrderfldName, int OrderType, ref int IsReCount, string strWhere)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@tblName", SqlDbType.VarChar, 0xff), new SqlParameter("@fldName", SqlDbType.VarChar, 500), new SqlParameter("@OrderfldName", SqlDbType.VarChar, 0xff), new SqlParameter("@PageSize", SqlDbType.Int), new SqlParameter("@PageIndex", SqlDbType.Int), new SqlParameter("@IsReCount", SqlDbType.Int), new SqlParameter("@OrderType", SqlDbType.Int), new SqlParameter("@strWhere", SqlDbType.VarChar, 0x3e8) };
            parameters[0].Value = "Pic_Info";
            parameters[1].Value = "[PicID],[ClassID],[UserID],[UserName],[Title],[Tag],[Remark],[PicPath],[PicName],[CommFlag],[AddTime],[VisitCount],[IsTop],[IsVouch],[IsDelete],[Aud]";
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

        public Model.Pic.Pic_Info GetPicInfoModel(int PicID)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@PicID", SqlDbType.Int, 4) };
            parameters[0].Value = PicID;
            Model.Pic.Pic_Info model = new Model.Pic.Pic_Info();
            DataSet ds = DbHelperSQL.RunProcedure("Pic_GetPicInfoModel", parameters, "ds");
            model.PicID = PicID;
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
                model.Tag = ds.Tables[0].Rows[0]["Tag"].ToString();
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                model.Manage = ds.Tables[0].Rows[0]["Manage"].ToString();
                model.Shoper = ds.Tables[0].Rows[0]["Shoper"].ToString();
                model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                model.PicPath = ds.Tables[0].Rows[0]["PicPath"].ToString();
                model.PicName = ds.Tables[0].Rows[0]["PicName"].ToString();
                if (ds.Tables[0].Rows[0]["CommFlag"].ToString() != "")
                {
                    model.CommFlag = int.Parse(ds.Tables[0].Rows[0]["CommFlag"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateShop"].ToString() != "")
                {
                    model.CreateShop = DateTime.Parse(ds.Tables[0].Rows[0]["CreateShop"].ToString());
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

        public DataSet GetPicList(int strClassID, int strTop, string strOrder, string strWhere)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@strClassID", SqlDbType.Int, 4), new SqlParameter("@strTop", SqlDbType.Int, 4), new SqlParameter("@strOrder", SqlDbType.VarChar, 50), new SqlParameter("@strWhere", SqlDbType.VarChar, 500) };
            parameters[0].Value = strClassID;
            parameters[1].Value = strTop;
            parameters[2].Value = strOrder;
            parameters[3].Value = strWhere;
            return DbHelperSQL.RunProcedure("Pic_GetPicList", parameters, "ds");
        }

        public DataSet GetPicPageList(string tableName, string tableId, string order, string where, int pageCurrent, int pageSize, ref int recordAmount, ref int pageAmount)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@tbName", SqlDbType.NVarChar, 0xfa0), new SqlParameter("@FieldKey", SqlDbType.NVarChar, 0xfa0), new SqlParameter("@PageCurrent", SqlDbType.Int), new SqlParameter("@PageSize", SqlDbType.Int), new SqlParameter("@FieldShow", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@FieldOrder", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@Where", SqlDbType.NVarChar, 0x3e8), new SqlParameter("@PageCount", SqlDbType.Int), new SqlParameter("@RecordCount", SqlDbType.Int) };
            parameters[0].Value = "Pic_Info";
            parameters[1].Value = tableId;
            parameters[2].Value = pageCurrent;
            parameters[3].Value = pageSize;
            parameters[4].Value = "[PicID],[ClassID],[UserID],[UserName],[Title],[Tag],[Remark],[PicPath],[PicName],[CommFlag],[AddTime],[VisitCount],[IsTop],[IsVouch],[IsDelete],[Aud]";
            parameters[5].Value = order;
            parameters[6].Value = where;
            parameters[7].Direction = ParameterDirection.Output;
            parameters[8].Direction = ParameterDirection.Output;
            DataSet redata = DbHelperSQL.RunProcedure("Do_Page", parameters, "ds");
            recordAmount = int.Parse(parameters[7].Value.ToString());
            pageAmount = int.Parse(parameters[8].Value.ToString());
            return redata;
        }

        public int UpdatePicInfo(Model.Pic.Pic_Info model)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { 
        new SqlParameter("@PicID", SqlDbType.Int, 4), new SqlParameter("@ClassID", SqlDbType.Int, 4), new SqlParameter("@UserID", SqlDbType.Int, 4), new SqlParameter("@UserName", SqlDbType.VarChar, 0x19), new SqlParameter("@Title", SqlDbType.VarChar, 200), new SqlParameter("@Tag", SqlDbType.VarChar, 200), new SqlParameter("@Remark", SqlDbType.VarChar, 0xfa0), new SqlParameter("@PicPath", SqlDbType.VarChar, 100), new SqlParameter("@PicName", SqlDbType.VarChar, 100), new SqlParameter("@CommFlag", SqlDbType.Int, 4), new SqlParameter("@IsTop", SqlDbType.Int, 4), new SqlParameter("@IsVouch", SqlDbType.Int, 4), new SqlParameter("@IsDelete", SqlDbType.Int, 4), new SqlParameter("@Manage", SqlDbType.VarChar, 200), new SqlParameter("@Shoper", SqlDbType.VarChar, 50), new SqlParameter("@CreateShop", SqlDbType.DateTime), 
        new SqlParameter("@Address", SqlDbType.VarChar, 200)
     };
            parameters[0].Value = model.PicID;
            parameters[1].Value = model.ClassID;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.UserName;
            parameters[4].Value = model.Title;
            parameters[5].Value = model.Tag;
            parameters[6].Value = model.Remark;
            parameters[7].Value = model.PicPath;
            parameters[8].Value = model.PicName;
            parameters[9].Value = model.CommFlag;
            parameters[10].Value = model.IsTop;
            parameters[11].Value = model.IsVouch;
            parameters[12].Value = model.IsDelete;
            parameters[13].Value = model.Manage;
            parameters[14].Value = model.Shoper;
            parameters[15].Value = model.CreateShop;
            parameters[0x10].Value = model.Address;
            DbHelperSQL.RunProcedure("Pic_UpdatePicInfo", parameters, out rowsAffected);
            return rowsAffected;
        }

        public void UpPicInfo(string PicID, string Act, string YesNo)
        {
            StringBuilder strSql = new StringBuilder();
            if (Act == "Top")
            {
                strSql.Append("update Pic_Info set IsTop=0 ");
                strSql.Append(string.Concat(new object[] { "update Pic_Info set IsTop=", YesNo, ",TopTime='", DateTime.Now, "'" }));
                strSql.Append(" where PicID =" + PicID);
            }
            else if (Act == "Vouch")
            {
                strSql.Append(string.Concat(new object[] { "update Pic_Info set IsVouch=", YesNo, ",VouchTime='", DateTime.Now, "'" }));
                strSql.Append(" where PicID =" + PicID);
            }
            else
            {
                strSql.Append("update Pic_Info set Aud=" + YesNo + " ");
                strSql.Append(" where PicID =" + PicID);
            }
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        public int VisitPicInfo(int PicID)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@PicID", SqlDbType.Int, 4), new SqlParameter("@VisitCount", SqlDbType.Int, 4) };
            parameters[0].Value = PicID;
            parameters[1].Direction = ParameterDirection.Output;
            DbHelperSQL.RunProcedure("Pic_VisitPicInfo", parameters, out rowsAffected);
            return int.Parse(parameters[1].Value.ToString());
        }

    }


}
