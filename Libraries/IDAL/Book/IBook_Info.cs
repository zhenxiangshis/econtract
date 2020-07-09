using System;
using System.Collections.Generic;
using System.Text;
using Model.Book;
using System.Collections;
using System.Data;

namespace IDAL.Book
{
    public interface IBook_Info
    {
        // Methods
        int AddBookInfo(Book_Info model);
        void DeleteBookInfo(int BookID);
        void DeleteBookInfo(string BookID);
        ArrayList GetBookIDList(string strWhere);
        DataSet GetBookInfoList(int PageSize, int PageIndex, string OrderfldName, int OrderType, ref int IsReCount, string strWhere);
        Book_Info GetBookInfoModel(int BookID);
        DataSet GetBookList(int strClassID, int strTop, string strOrder, string strWhere);
        void UpBookInfo(string BookID, string YesNo);
        int UpdateBookInfo(Book_Info model);
    }
}
