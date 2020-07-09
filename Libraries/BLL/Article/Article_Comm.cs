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
    public class Article_Comm
    {
        // Fields
        private readonly IArticle_Comm dal;

        // Methods
        public Article_Comm()
        {
            this.dal = DataAccess.CreateArticle_Comm();
        }

        public int AddArticleComm(Model.Article.Article_Comm model)
        {
            int result = this.dal.AddArticleComm(model);
            if (result >= 1)
            {
                try
                {
                    new Article_Info().CreateHtml(model.ArticleID);
                }
                catch
                {
                }
            }
            return result;
        }
        public void DeleteArticleComm(int CommID)
        {
            this.dal.DeleteArticleComm(CommID);
        }

        public void DeleteArticleComm(string CommID)
        {
            this.dal.DeleteArticleComm(CommID);
        }
        public DataSet GetArticleCommList(int ArticleID)
        {
            return this.dal.GetArticleCommList(ArticleID);
        }
        public DataSet GetArticleCommList(int PageSize, int PageIndex, string OrderfldName, int OrderType, ref int IsReCount, string strWhere)
        {
            return this.dal.GetArticleCommList(PageSize, PageIndex, OrderfldName, OrderType, ref IsReCount, strWhere);
        }
        public Model.Article.Article_Comm GetArticleCommModel(int CommID)
        {
            return this.dal.GetArticleCommModel(CommID);
        }
        public void UpdateArticleComm(Model.Article.Article_Comm model)
        {
            this.dal.UpdateArticleComm(model);
        }
    }


}
