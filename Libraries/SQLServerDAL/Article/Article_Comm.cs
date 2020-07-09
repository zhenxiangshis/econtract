using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DBUtility;
using IDAL.Article;

namespace SQLServerDAL.Article
{
    public class Article_Comm : IArticle_Comm
    {
        // Methods
       
        public int AddArticleComm(Model.Article.Article_Comm model)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@CommID", SqlDbType.Int, 4), new SqlParameter("@UserID", SqlDbType.Int, 4), new SqlParameter("@UserName", SqlDbType.VarChar, 50), new SqlParameter("@ArticleID", SqlDbType.Int, 4), new SqlParameter("@Content", SqlDbType.NText), new SqlParameter("@Ip", SqlDbType.VarChar, 50), new SqlParameter("@Fen", SqlDbType.Int, 4), new SqlParameter("@ArticleTime", SqlDbType.VarChar, 50) };
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.ArticleID;
            parameters[4].Value = model.Content;
            parameters[5].Value = model.Ip;
            parameters[6].Value = model.Fen;
            parameters[7].Value = model.ArticleTime;
            DbHelperSQL.RunProcedure("Article_AddArticleComm", parameters, out rowsAffected);
            return int.Parse(parameters[0].Value.ToString());
        }
        public void DeleteArticleComm(int CommID)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@CommID", SqlDbType.Int, 4) };
            parameters[0].Value = CommID;
            DbHelperSQL.RunProcedure("Article_DeleteArticleComm", parameters, out rowsAffected);
        }

        public void DeleteArticleComm(string CommID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Article_Comm ");
            strSql.Append(" where CommID in (" + CommID + ")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        public DataSet GetArticleCommList(int ArticleID)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@ArticleID", SqlDbType.Int, 4) };
            parameters[0].Value = ArticleID;
            return DbHelperSQL.RunProcedure("Article_GetArticleCommList", parameters, "ds");
        }

        public DataSet GetArticleCommList(int PageSize, int PageIndex, string OrderfldName, int OrderType, ref int IsReCount, string strWhere)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@tblName", SqlDbType.VarChar, 0xff), new SqlParameter("@fldName", SqlDbType.VarChar, 500), new SqlParameter("@OrderfldName", SqlDbType.VarChar, 0xff), new SqlParameter("@PageSize", SqlDbType.Int), new SqlParameter("@PageIndex", SqlDbType.Int), new SqlParameter("@IsReCount", SqlDbType.Int), new SqlParameter("@OrderType", SqlDbType.Int), new SqlParameter("@strWhere", SqlDbType.VarChar, 0x3e8) };
            parameters[0].Value = "Article_Comm";
            parameters[1].Value = "[CommID],[UserID],[UserName],[ArticleID],[Content],[Ip],[AddTime],[Fen],[ArticleTime]";
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

        public Model.Article.Article_Comm GetArticleCommModel(int CommID)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@CommID", SqlDbType.Int, 4) };
            parameters[0].Value = CommID;
            Model.Article.Article_Comm model = new Model.Article.Article_Comm();
            DataSet ds = DbHelperSQL.RunProcedure("Article_GetArticleCommModel", parameters, "ds");
            model.CommID = CommID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                if (ds.Tables[0].Rows[0]["ArticleID"].ToString() != "")
                {
                    model.ArticleID = int.Parse(ds.Tables[0].Rows[0]["ArticleID"].ToString());
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
                model.ArticleTime = ds.Tables[0].Rows[0]["ArticleTime"].ToString();
                return model;
            }
            return null;
        }

        public void UpdateArticleComm(Model.Article.Article_Comm model)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@CommID", SqlDbType.Int, 4), new SqlParameter("@UserID", SqlDbType.Int, 4), new SqlParameter("@UserName", SqlDbType.Int, 4), new SqlParameter("@ArticleID", SqlDbType.Int, 4), new SqlParameter("@Content", SqlDbType.NText), new SqlParameter("@Ip", SqlDbType.VarChar, 50), new SqlParameter("@Fen", SqlDbType.Int, 4) };
            parameters[0].Value = model.CommID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.ArticleID;
            parameters[4].Value = model.Content;
            parameters[5].Value = model.Ip;
            parameters[6].Value = model.Fen;
            DbHelperSQL.RunProcedure("Article_UpdateArticleComm", parameters, out rowsAffected);
        }

    }

 

}
