using System;
using System.Collections.Generic;
using System.Text;
using IDAL.Link;
using DBUtility;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace SQLServerDAL.Link
{
    public class Link_Info : ILink_Info
    {
        // Methods
        public Link_Info() { }
        public int AddLinkInfo(Model.Link.Link_Info model)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@LinkID", SqlDbType.Int, 4), new SqlParameter("@ClassID", SqlDbType.Int, 4), new SqlParameter("@UserID", SqlDbType.Int, 4), new SqlParameter("@UserName", SqlDbType.VarChar, 0x19), new SqlParameter("@Title", SqlDbType.VarChar, 200), new SqlParameter("@Tag", SqlDbType.VarChar, 200), new SqlParameter("@Remark", SqlDbType.VarChar, 0xfa0), new SqlParameter("@LinkPath", SqlDbType.VarChar, 100), new SqlParameter("@LinkName", SqlDbType.VarChar, 100), new SqlParameter("@CommFlag", SqlDbType.Int, 4), new SqlParameter("@Aud", SqlDbType.Int, 4), new SqlParameter("@LinkUrl", SqlDbType.VarChar, 200), new SqlParameter("@Importance", SqlDbType.Int, 4) };
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.ClassID;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.UserName;
            parameters[4].Value = model.Title;
            parameters[5].Value = model.Tag;
            parameters[6].Value = model.Remark;
            parameters[7].Value = model.LinkPath;
            parameters[8].Value = model.LinkName;
            parameters[9].Value = model.CommFlag;
            parameters[10].Value = model.Aud;
            parameters[11].Value = model.LinkUrl;
            parameters[12].Value = model.Importance;
            DbHelperSQL.RunProcedure("Link_AddLinkInfo", parameters, out rowsAffected);
            return int.Parse(parameters[0].Value.ToString());
        }

        public void DeleteLinkInfo(int LinkID)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@LinkID", SqlDbType.Int, 4) };
            parameters[0].Value = LinkID;
            DbHelperSQL.RunProcedure("Link_DeleteLinkInfo", parameters, out rowsAffected);
        }
        public void DeleteLinkInfo(string LinkID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Link_Info ");
            strSql.Append(" where LinkID in (" + LinkID + ")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        public bool Exists(int LinkID)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@LinkID", SqlDbType.Int, 4) };
            parameters[0].Value = LinkID;
            return (DbHelperSQL.RunProcedure("Link_InfoExists", parameters, out rowsAffected) == 1);
        }

        public ArrayList GetLinkIDList(string strWhere)
        {
            ArrayList list = new ArrayList();
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@strWhere", SqlDbType.VarChar, 0x3e8) };
            parameters[0].Value = strWhere;
            SqlDataReader reader = DbHelperSQL.RunProcedure("Link_GetLinkIDList", parameters);
            while (reader.Read())
            {
                Model.Link.Link_Info model = new Model.Link.Link_Info();
                model.LinkID = int.Parse(reader["LinkID"].ToString());
                list.Add(model);
            }
            reader.Close();
            return list;
        }

        public DataSet GetLinkInfoList(int PageSize, int PageIndex, string OrderfldName, int OrderType, ref int IsReCount, string strWhere)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@tblName", SqlDbType.VarChar, 0xff), new SqlParameter("@fldName", SqlDbType.VarChar, 500), new SqlParameter("@OrderfldName", SqlDbType.VarChar, 0xff), new SqlParameter("@PageSize", SqlDbType.Int), new SqlParameter("@PageIndex", SqlDbType.Int), new SqlParameter("@IsReCount", SqlDbType.Int), new SqlParameter("@OrderType", SqlDbType.Int), new SqlParameter("@strWhere", SqlDbType.VarChar, 0x3e8) };
            parameters[0].Value = "Link_Info";
            parameters[1].Value = "[LinkID],[ClassID],[UserID],[UserName],[Title],[Tag],[Remark],[LinkPath],[LinkName],[CommFlag],[AddTime],[VisitCount],[IsTop],[IsVouch],[IsDelete],[Aud],[LinkUrl]";
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

        public Model.Link.Link_Info GetLinkInfoModel(int LinkID)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@LinkID", SqlDbType.Int, 4) };
            parameters[0].Value = LinkID;
            Model.Link.Link_Info model = new Model.Link.Link_Info();
            DataSet ds = DbHelperSQL.RunProcedure("Link_GetLinkInfoModel", parameters, "ds");
            model.LinkID = LinkID;
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
                model.LinkPath = ds.Tables[0].Rows[0]["LinkPath"].ToString();
                model.LinkName = ds.Tables[0].Rows[0]["LinkName"].ToString();
                model.LinkUrl = ds.Tables[0].Rows[0]["LinkUrl"].ToString();
                model.Importance = ds.Tables[0].Rows[0]["Importance"].ToString();
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

        public DataSet GetLinkList(int strClassID, int strTop, string strOrder, string strWhere)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@strClassID", SqlDbType.Int, 4), new SqlParameter("@strTop", SqlDbType.Int, 4), new SqlParameter("@strOrder", SqlDbType.VarChar, 50), new SqlParameter("@strWhere", SqlDbType.VarChar, 500) };
            parameters[0].Value = strClassID;
            parameters[1].Value = strTop;
            parameters[2].Value = strOrder;
            parameters[3].Value = strWhere;
            return DbHelperSQL.RunProcedure("Link_GetLinkList", parameters, "ds");
        }

        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("LinkID", "Link_Info");
        }
        public int UpdateLinkInfo(Model.Link.Link_Info model)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@LinkID", SqlDbType.Int, 4), new SqlParameter("@ClassID", SqlDbType.Int, 4), new SqlParameter("@UserID", SqlDbType.Int, 4), new SqlParameter("@UserName", SqlDbType.VarChar, 0x19), new SqlParameter("@Title", SqlDbType.VarChar, 200), new SqlParameter("@Tag", SqlDbType.VarChar, 200), new SqlParameter("@Remark", SqlDbType.VarChar, 0xfa0), new SqlParameter("@LinkPath", SqlDbType.VarChar, 100), new SqlParameter("@LinkName", SqlDbType.VarChar, 100), new SqlParameter("@CommFlag", SqlDbType.Int, 4), new SqlParameter("@IsTop", SqlDbType.Int, 4), new SqlParameter("@IsVouch", SqlDbType.Int, 4), new SqlParameter("@IsDelete", SqlDbType.Int, 4), new SqlParameter("@LinkUrl", SqlDbType.VarChar, 200), new SqlParameter("@Importance", SqlDbType.Int, 4) };
            parameters[0].Value = model.LinkID;
            parameters[1].Value = model.ClassID;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.UserName;
            parameters[4].Value = model.Title;
            parameters[5].Value = model.Tag;
            parameters[6].Value = model.Remark;
            parameters[7].Value = model.LinkPath;
            parameters[8].Value = model.LinkName;
            parameters[9].Value = model.CommFlag;
            parameters[10].Value = model.IsTop;
            parameters[11].Value = model.IsVouch;
            parameters[12].Value = model.IsDelete;
            parameters[13].Value = model.LinkUrl;
            parameters[14].Value = model.Importance;
            DbHelperSQL.RunProcedure("Link_UpdateLinkInfo", parameters, out rowsAffected);
            return rowsAffected;
        }

        public void UpLinkInfo(string LinkID, string Act, string YesNo)
        {
            StringBuilder strSql = new StringBuilder();
            if (Act == "Top")
            {
                strSql.Append(string.Concat(new object[] { "update Link_Info set IsTop=", YesNo, ",TopTime='", DateTime.Now, "'" }));
                strSql.Append(" where LinkID =" + LinkID);
            }
            else if (Act == "Vouch")
            {
                strSql.Append(string.Concat(new object[] { "update Link_Info set IsVouch=", YesNo, ",VouchTime='", DateTime.Now, "'" }));
                strSql.Append(" where LinkID =" + LinkID);
            }
            else
            {
                strSql.Append("update Link_Info set Aud=" + YesNo + " ");
                strSql.Append(" where LinkID =" + LinkID);
            }
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        public int VisitLinkInfo(int LinkID)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@LinkID", SqlDbType.Int, 4), new SqlParameter("@VisitCount", SqlDbType.Int, 4) };
            parameters[0].Value = LinkID;
            parameters[1].Direction = ParameterDirection.Output;
            DbHelperSQL.RunProcedure("Link_VisitLinkInfo", parameters, out rowsAffected);
            return int.Parse(parameters[1].Value.ToString());
        }

    }


}
