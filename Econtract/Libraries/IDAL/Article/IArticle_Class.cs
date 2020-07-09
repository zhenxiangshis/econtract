using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace IDAL.Article
{
    public interface IArticle_Class
    {
        // Methods
        int CreateArticleClass(Model.Article.Article_Class model);
        int DeleteArticleClass(int ClassID);
        bool Exists(int ClassID);
        DataSet GetArticleClassList(string strWhere);
        Model.Article.Article_Class GetArticleClassModel(int ClassID);
        DataSet GetDemoList(string strWhere);
        DataSet GetList(int PageSize, int PageIndex, string strWhere);
        int GetMaxId();
        void UpdateArticleClass(Model.Article.Article_Class model);
    }


}
