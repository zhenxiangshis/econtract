using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using DBUtility;
using IDAL.Article;
namespace SQLServerDAL.Article
{
    public class Article_Info : IArticle_Info
    {
        // Methods
        
        public int AddArticleInfo(Model.Article.Article_Info model)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@ArticleID", SqlDbType.Int, 4), new SqlParameter("@ClassID", SqlDbType.Int, 4), new SqlParameter("@UserID", SqlDbType.Int, 4), new SqlParameter("@PicID", SqlDbType.Int, 4), new SqlParameter("@PicUrl", SqlDbType.VarChar, 100), new SqlParameter("@Title", SqlDbType.VarChar, 200), new SqlParameter("@Tag", SqlDbType.VarChar, 200), new SqlParameter("@Content", SqlDbType.NText), new SqlParameter("@CommFlag", SqlDbType.Int, 4), new SqlParameter("@SubTitle", SqlDbType.VarChar, 200), new SqlParameter("@AddTime", SqlDbType.DateTime, 8), new SqlParameter("@Importance", SqlDbType.Int, 4), new SqlParameter("@GoUrl", SqlDbType.VarChar, 200), new SqlParameter("@FlashUrl", SqlDbType.VarChar, 200), new SqlParameter("@Keyword", SqlDbType.VarChar, 200) };
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.ClassID;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.PicID;
            parameters[4].Value = model.PicUrl;
            parameters[5].Value = model.Title;
            parameters[6].Value = model.Tag;
            parameters[7].Value = model.Content;
            parameters[8].Value = model.CommFlag;
            parameters[9].Value = model.SubTitle;
            parameters[10].Value = model.AddTime;
            parameters[11].Value = model.Importance;
            parameters[12].Value = model.GoUrl;
            parameters[13].Value = model.FlashUrl;
            parameters[14].Value = model.Keyword;
            DbHelperSQL.RunProcedure("Article_AddArticleInfo", parameters, out rowsAffected);
            return int.Parse(parameters[0].Value.ToString());
        }

        public void DeleteArticleInfo(int ArticleID)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@ArticleID", SqlDbType.Int, 4) };
            parameters[0].Value = ArticleID;
            DbHelperSQL.RunProcedure("Article_DeleteArticleInfo", parameters, out rowsAffected);
        }

        public void DeleteArticleInfo(string ArticleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Article_Info ");
            strSql.Append(" where ArticleID in (" + ArticleID + ")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        public bool Exists(int ArticleID)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@ArticleID", SqlDbType.Int, 4) };
            parameters[0].Value = ArticleID;
            return (DbHelperSQL.RunProcedure("Article_InfoExists", parameters, out rowsAffected) == 1);
        }
        public ArrayList GetArticleIDList(string strWhere)
        {
            ArrayList list = new ArrayList();
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@strWhere", SqlDbType.VarChar, 0x3e8) };
            parameters[0].Value = strWhere;
            SqlDataReader reader = DbHelperSQL.RunProcedure("Article_GetArticleIDList", parameters);
            while (reader.Read())
            {
                Model.Article.Article_Info model = new Model.Article.Article_Info();
                model.ArticleID = int.Parse(reader["ArticleID"].ToString());
                list.Add(model);
            }
            reader.Close();
            return list;
        }

        public DataSet GetArticleInfoList(int PageSize, int PageIndex, string OrderfldName, int OrderType, ref int IsReCount, string strWhere)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@tblName", SqlDbType.VarChar, 0xff),
                new SqlParameter("@fldName", SqlDbType.VarChar, 500),
                new SqlParameter("@OrderfldName", SqlDbType.VarChar, 0xff),
                new SqlParameter("@PageSize", SqlDbType.Int),
                new SqlParameter("@PageIndex", SqlDbType.Int),
                new SqlParameter("@IsReCount", SqlDbType.Int),
                new SqlParameter("@OrderType", SqlDbType.Int),
                new SqlParameter("@strWhere", SqlDbType.VarChar, 0x3e8) };
            parameters[0].Value = "Article_Info";
            parameters[1].Value = "[ArticleID],[ClassID],[UserID],[PicID],[PicUrl],[Title],[Tag],[Content],[CommFlag],[AddTime],[VisitCount],[IsTop],[IsVouch],[IsDelete],[SubTitle],[GoUrl],[flashUrl]";
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
        public Model.Article.Article_Info GetArticleInfoModel(int ArticleID)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@ArticleID", SqlDbType.Int, 4) };
            parameters[0].Value = ArticleID;
            Model.Article.Article_Info model = new Model.Article.Article_Info();
            DataSet ds = DbHelperSQL.RunProcedure("Article_GetArticleInfoModel", parameters, "ds");
            model.ArticleID = ArticleID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ClassID"].ToString() != "")
                {
                    model.ClassID = int.Parse(ds.Tables[0].Rows[0]["ClassID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PicID"].ToString() != "")
                {
                    model.PicID = int.Parse(ds.Tables[0].Rows[0]["PicID"].ToString());
                }
                model.PicUrl = ds.Tables[0].Rows[0]["PicUrl"].ToString();
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.SubTitle = ds.Tables[0].Rows[0]["SubTitle"].ToString();
                model.Tag = ds.Tables[0].Rows[0]["Tag"].ToString();
                model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                model.GoUrl = ds.Tables[0].Rows[0]["GoUrl"].ToString();
                model.FlashUrl = ds.Tables[0].Rows[0]["FlashUrl"].ToString();
                model.Keyword = ds.Tables[0].Rows[0]["Keyword"].ToString();
                if (ds.Tables[0].Rows[0]["Importance"].ToString() == "")
                {
                    model.Importance = 0;
                }
                else
                {
                    model.Importance = int.Parse(ds.Tables[0].Rows[0]["Importance"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DemoID"].ToString() != "")
                {
                    model.DemoID = int.Parse(ds.Tables[0].Rows[0]["DemoID"].ToString());
                }
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
                return model;
            }
            return null;
        }

        public Model.Article.Article_Info GetTopArticleInfoModel(int ClassID,int IsTop)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@ClassID", SqlDbType.Int, 4), new SqlParameter("@IsTop", SqlDbType.Int, 4) };
            parameters[0].Value = ClassID;
            parameters[1].Value = IsTop;
            Model.Article.Article_Info model = new Model.Article.Article_Info();
            DataSet ds = DbHelperSQL.RunProcedure("Article_GetTopArticleInfoModel", parameters, "ds");
            model.ClassID = ClassID;
            model.IsTop = IsTop;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ArticleID"].ToString() != "")
                {
                    model.ArticleID = int.Parse(ds.Tables[0].Rows[0]["ArticleID"].ToString());
                }
                model.ClassName = ds.Tables[0].Rows[0]["ClassName"].ToString();
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PicID"].ToString() != "")
                {
                    model.PicID = int.Parse(ds.Tables[0].Rows[0]["PicID"].ToString());
                }
                model.PicUrl = ds.Tables[0].Rows[0]["PicUrl"].ToString();
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.SubTitle = ds.Tables[0].Rows[0]["SubTitle"].ToString();
                model.Tag = ds.Tables[0].Rows[0]["Tag"].ToString();
                model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                model.GoUrl = ds.Tables[0].Rows[0]["GoUrl"].ToString();
                model.Keyword = ds.Tables[0].Rows[0]["Keyword"].ToString();

                if (ds.Tables[0].Rows[0]["Importance"].ToString() == "")
                {
                    model.Importance = 0;
                }
                else
                {
                    model.Importance = int.Parse(ds.Tables[0].Rows[0]["Importance"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DemoID"].ToString() != "")
                {
                    model.DemoID = int.Parse(ds.Tables[0].Rows[0]["DemoID"].ToString());
                }
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
                if (ds.Tables[0].Rows[0]["IsVouch"].ToString() != "")
                {
                    model.IsVouch = int.Parse(ds.Tables[0].Rows[0]["IsVouch"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsDelete"].ToString() != "")
                {
                    model.IsDelete = int.Parse(ds.Tables[0].Rows[0]["IsDelete"].ToString());
                }
                return model;
            }
            return null;
        }

        public DataSet GetArticleList(int strClassID, int strTop, string strOrder, string strWhere)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@strClassID", SqlDbType.Int, 4), new SqlParameter("@strTop", SqlDbType.Int, 4), new SqlParameter("@strOrder", SqlDbType.VarChar, 50), new SqlParameter("@strWhere", SqlDbType.VarChar, 500) };
            parameters[0].Value = strClassID;
            parameters[1].Value = strTop;
            parameters[2].Value = strOrder;
            parameters[3].Value = strWhere;
            return DbHelperSQL.RunProcedure("Article_GetArticleList", parameters, "ds");
        }
        /// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.Article.Article_Info DataRowToModel(DataRow row)
        {
            Model.Article.Article_Info model = new Model.Article.Article_Info();
            if (row != null)
            {
                if (row["ArticleID"].ToString() != "")
                {
                    model.ArticleID = int.Parse(row["ArticleID"].ToString());
                }

                if (row["ClassID"].ToString() != "")
                {
                    model.ClassID = int.Parse(row["ClassID"].ToString());
                }
                if (row["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(row["UserID"].ToString());
                }
                if (row["PicID"].ToString() != "")
                {
                    model.PicID = int.Parse(row["PicID"].ToString());
                }
                model.PicUrl = row["PicUrl"].ToString();
                model.Title = row["Title"].ToString();
                model.SubTitle = row["SubTitle"].ToString();
                model.Tag = row["Tag"].ToString();
                model.Content = row["Content"].ToString();
                model.GoUrl = row["GoUrl"].ToString();
                model.FlashUrl = row["FlashUrl"].ToString();
                model.Keyword = row["Keyword"].ToString();
                if (row["Importance"].ToString() == "")
                {
                    model.Importance = 0;
                }
                else
                {
                    model.Importance = int.Parse(row["Importance"].ToString());
                }
                
                if (row["CommFlag"].ToString() != "")
                {
                    model.CommFlag = int.Parse(row["CommFlag"].ToString());
                }
                if (row["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(row["AddTime"].ToString());
                }
                if (row["VisitCount"].ToString() != "")
                {
                    model.VisitCount = int.Parse(row["VisitCount"].ToString());
                }
                if (row["IsTop"].ToString() != "")
                {
                    model.IsTop = int.Parse(row["IsTop"].ToString());
                }
                if (row["IsVouch"].ToString() != "")
                {
                    model.IsVouch = int.Parse(row["IsVouch"].ToString());
                }
                if (row["IsDelete"].ToString() != "")
                {
                    model.IsDelete = int.Parse(row["IsDelete"].ToString());
                }
            }
            return model;
        }
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ArticleID", "Article_Info");
        }

        public void UpArticleInfo(string ArticleID, string Act, string YesNo, string ClassID)
        {
            StringBuilder strSql = new StringBuilder();
            if (Act == "Top")
            {
                strSql.Append("update Article_Info set IsTop=0 where ClassID=" + ClassID + " ");
                strSql.Append(string.Concat(new object[] { "update Article_Info set IsTop=", YesNo, ",TopTime='", DateTime.Now, "'" }));
                strSql.Append(" where ArticleID =" + ArticleID);
            }
            else
            {
                strSql.Append(string.Concat(new object[] { "update Article_Info set IsVouch=", YesNo, ",VouchTime='", DateTime.Now, "'" }));
                strSql.Append(" where ArticleID =" + ArticleID);
            }
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        public int UpdateArticleInfo(Model.Article.Article_Info model)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { 
        new SqlParameter("@ArticleID", SqlDbType.Int, 4), new SqlParameter("@ClassID", SqlDbType.Int, 4), new SqlParameter("@UserID", SqlDbType.Int, 4), new SqlParameter("@PicID", SqlDbType.Int, 4), new SqlParameter("@PicUrl", SqlDbType.VarChar, 100), new SqlParameter("@Title", SqlDbType.VarChar, 200), new SqlParameter("@Tag", SqlDbType.VarChar, 200), new SqlParameter("@Content", SqlDbType.NText), new SqlParameter("@CommFlag", SqlDbType.Int, 4), new SqlParameter("@VisitCount", SqlDbType.Int, 4), new SqlParameter("@IsTop", SqlDbType.Int, 4), new SqlParameter("@IsVouch", SqlDbType.Int, 4), new SqlParameter("@IsDelete", SqlDbType.Int, 4), new SqlParameter("@SubTitle", SqlDbType.VarChar, 200), new SqlParameter("@AddTime", SqlDbType.DateTime, 8), new SqlParameter("@Importance", SqlDbType.Int, 4), 
        new SqlParameter("@GoUrl", SqlDbType.VarChar, 200), new SqlParameter("@FlashUrl", SqlDbType.VarChar, 200),new SqlParameter("@Keyword", SqlDbType.VarChar, 500)
     };
            parameters[0].Value = model.ArticleID;
            parameters[1].Value = model.ClassID;
            parameters[2].Value = model.UserID;
            parameters[3].Value = model.PicID;
            parameters[4].Value = model.PicUrl;
            parameters[5].Value = model.Title;
            parameters[6].Value = model.Tag;
            parameters[7].Value = model.Content;
            parameters[8].Value = model.CommFlag;
            parameters[9].Value = model.VisitCount;
            parameters[10].Value = model.IsTop;
            parameters[11].Value = model.IsVouch;
            parameters[12].Value = model.IsDelete;
            parameters[13].Value = model.SubTitle;
            parameters[14].Value = model.AddTime;
            parameters[15].Value = model.Importance;
            parameters[16].Value = model.GoUrl;
            parameters[17].Value = model.FlashUrl;
            parameters[18].Value = model.Keyword;
            DbHelperSQL.RunProcedure("Article_UpdateArticleInfo", parameters, out rowsAffected);
            return rowsAffected;
        }

        public int VisitArticleInfo(int ArticleID)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@ArticleID", SqlDbType.Int, 4), new SqlParameter("@VisitCount", SqlDbType.Int, 4) };
            parameters[0].Value = ArticleID;
            parameters[1].Direction = ParameterDirection.Output;
            DbHelperSQL.RunProcedure("Article_VisitArticleInfo", parameters, out rowsAffected);
            return int.Parse(parameters[1].Value.ToString());
        }

    }


}
