using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace IDAL.Article
{
    public interface IArticle_Comm
    {
        // Methods
        int AddArticleComm(Model.Article.Article_Comm model);
        void DeleteArticleComm(int CommID);
        void DeleteArticleComm(string CommID);
        DataSet GetArticleCommList(int ArticleID);
        DataSet GetArticleCommList(int PageSize, int PageIndex, string OrderfldName, int OrderType, ref int IsReCount, string strWhere);
        Model.Article.Article_Comm GetArticleCommModel(int CommID);
        void UpdateArticleComm(Model.Article.Article_Comm model);
    }

}
