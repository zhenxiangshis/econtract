using System;
using System.Collections.Generic;
using System.Text;
using Model.Article;
using System.Data;
using System.Collections;

namespace IDAL.Article
{
    public interface IArticle_Info
    {
        // Methods
        int AddArticleInfo(Article_Info model);
        void DeleteArticleInfo(int ArticleID);
        void DeleteArticleInfo(string ArticleID);
        bool Exists(int ArticleID);
        ArrayList GetArticleIDList(string strWhere);
        DataSet GetArticleInfoList(int PageSize, int PageIndex, string OrderfldName, int OrderType, ref int IsReCount, string strWhere);
        Article_Info GetArticleInfoModel(int ArticleID);
        Article_Info GetTopArticleInfoModel(int ClassID, int IsTop);
        DataSet GetArticleList(int strClassID, int strTop, string strOrder, string strWhere);
        Article_Info DataRowToModel(DataRow row);
        int GetMaxId();
        void UpArticleInfo(string ArticleID, string Act, string YesNo, string ClassID);
        int UpdateArticleInfo(Article_Info model);
        int VisitArticleInfo(int ArticleID);
    }

}
