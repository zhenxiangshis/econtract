using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using DALFactory;
using IDAL.Article;
using Model;

namespace BLL.Article
{
    public class Article_Class
    {
        // Fields
        private readonly IArticle_Class dal;

        // Methods
        public Article_Class()
        {
            this.dal = DataAccess.CreateArticle_Class();
        }

        public int CreateArticleClass(Model.Article.Article_Class model)
        {
            return this.dal.CreateArticleClass(model);
        }

        public int DeleteArticleClass(int ClassID)
        {
            return this.dal.DeleteArticleClass(ClassID);
        }
        public bool Exists(int ClassID)
        {
            return this.dal.Exists(ClassID);
        }

        public DataSet GetArticleClassList(string strWhere)
        {
            return this.dal.GetArticleClassList(strWhere);
        }
        public Model.Article.Article_Class GetArticleClassModel(int ClassID)
        {
            return this.dal.GetArticleClassModel(ClassID);
        }
        public DataSet GetDemoList(string strWhere)
        {
            return this.dal.GetDemoList(strWhere);
        }
        public DataSet GetList(int PageSize, int PageIndex, string strWhere)
        {
            return this.dal.GetList(PageSize, PageIndex, strWhere);
        }

        public int GetMaxId()
        {
            return this.dal.GetMaxId();
        }

        public void UpdateArticleClass(Model.Article.Article_Class model)
        {
            this.dal.UpdateArticleClass(model);
        }
    }

}
