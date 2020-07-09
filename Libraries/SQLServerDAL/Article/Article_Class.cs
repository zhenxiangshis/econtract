using System;
using System.Collections.Generic;
using System.Text;
using IDAL.Article;
using System.Data;
using System.Data.SqlClient;
using DBUtility;
using Model.Article;

namespace SQLServerDAL.Article
{
    public class Article_Class : IArticle_Class
    {

        public int CreateArticleClass(Model.Article.Article_Class model)
        {
            int rowsAffected;
            model.ClassID = this.GetMaxId();
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@ParentID", SqlDbType.Int, 4), new SqlParameter("@ClassName", SqlDbType.VarChar, 50), new SqlParameter("@ClassIntro", SqlDbType.VarChar, 0x3e8), new SqlParameter("@DemoID", SqlDbType.Int, 4) };
            parameters[0].Value = model.ParentID;
            parameters[1].Value = model.ClassName;
            parameters[2].Value = model.ClassIntro;
            parameters[3].Value = model.DemoID;
            DbHelperSQL.RunProcedure("Article_CreateArticleClass", parameters, out rowsAffected);
            return model.ClassID;
        }

        public int DeleteArticleClass(int ClassID)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@ClassID", SqlDbType.Int, 4) };
            parameters[0].Value = ClassID;
            DbHelperSQL.RunProcedure("Article_DeleteArticleClass", parameters, out rowsAffected);
            return rowsAffected;
        }

        public bool Exists(int ClassID)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@ClassID", SqlDbType.Int, 4) };
            parameters[0].Value = ClassID;
            return (DbHelperSQL.RunProcedure("Article_ClassExists", parameters, out rowsAffected) == 1);
        }
        public DataSet GetArticleClassList(string strWhere)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@strWhere", SqlDbType.VarChar, 0x3e8) };
            parameters[0].Value = strWhere;
            return DbHelperSQL.RunProcedure("Article_GetArticleClassList", parameters, "ds");
        }

        public Model.Article.Article_Class GetArticleClassModel(int ClassID)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@ClassID", SqlDbType.Int, 4) };
            parameters[0].Value = ClassID;
            Model.Article.Article_Class model = new Model.Article.Article_Class();
            DataSet ds = DbHelperSQL.RunProcedure("Article_GetArticleClassModel", parameters, "ds");
            model.ClassID = ClassID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ClassID"].ToString() != "")
                {
                    model.ClassID = int.Parse(ds.Tables[0].Rows[0]["ClassID"].ToString());
                }
                model.ClassName = ds.Tables[0].Rows[0]["ClassName"].ToString();
                if (ds.Tables[0].Rows[0]["ParentID"].ToString() != "")
                {
                    model.ParentID = int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
                }
                model.ClassPath = ds.Tables[0].Rows[0]["ClassPath"].ToString();
                if (ds.Tables[0].Rows[0]["ClassDepth"].ToString() != "")
                {
                    model.ClassDepth = int.Parse(ds.Tables[0].Rows[0]["ClassDepth"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ClassOrder"].ToString() != "")
                {
                    model.ClassOrder = int.Parse(ds.Tables[0].Rows[0]["ClassOrder"].ToString());
                }
                model.ClassIntro = ds.Tables[0].Rows[0]["ClassIntro"].ToString();
                if (ds.Tables[0].Rows[0]["DemoID"].ToString() != "")
                {
                    model.DemoID = int.Parse(ds.Tables[0].Rows[0]["DemoID"].ToString());
                }
                return model;
            }
            return null;
        }

        public DataSet GetDemoList(string strWhere)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@strWhere", SqlDbType.VarChar, 0x3e8) };
            parameters[0].Value = "strWhere";
            return DbHelperSQL.RunProcedure("Article_GetDemoList", parameters, "ds");
        }

        public DataSet GetList(int PageSize, int PageIndex, string strWhere)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@tblName", SqlDbType.VarChar, 0xff), new SqlParameter("@fldName", SqlDbType.VarChar, 500), new SqlParameter("@OrderfldName", SqlDbType.VarChar, 0xff), new SqlParameter("@PageSize", SqlDbType.Int), new SqlParameter("@PageIndex", SqlDbType.Int), new SqlParameter("@IsReCount", SqlDbType.Int), new SqlParameter("@OrderType", SqlDbType.Int), new SqlParameter("@strWhere", SqlDbType.VarChar, 0x3e8) };
            parameters[0].Value = "Article_Class";
            parameters[1].Value = "ClassID";
            parameters[2].Value = "ClassID";
            parameters[3].Value = PageSize;
            parameters[4].Value = PageIndex;
            parameters[5].Value = 0;
            parameters[6].Value = 1;
            parameters[7].Value = strWhere;
            return DbHelperSQL.RunProcedure("GetRecordByPage", parameters, "ds");
        }
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ClassID", "Article_Class");
        }

        public void UpdateArticleClass(Model.Article.Article_Class model)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@ClassID", SqlDbType.Int, 4), new SqlParameter("@ParentID", SqlDbType.Int, 4), new SqlParameter("@ClassName", SqlDbType.VarChar, 50), new SqlParameter("@ClassIntro", SqlDbType.VarChar, 0x3e8), new SqlParameter("@DemoID", SqlDbType.Int, 4) };
            parameters[0].Value = model.ClassID;
            parameters[1].Value = model.ParentID;
            parameters[2].Value = model.ClassName;
            parameters[3].Value = model.ClassIntro;
            parameters[4].Value = model.DemoID;
            DbHelperSQL.RunProcedure("Article_UpdateArticleClass", parameters, out rowsAffected);
        }
  }


}
