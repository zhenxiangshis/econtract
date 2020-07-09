using System;
using System.Collections.Generic;
using System.Text;
using Model.Book;
using System.Data;
using System.Collections;

namespace IDAL.Book
{
    public interface IBook_Re
    {
        // Methods
        int AddBookRe(Book_Re model);
        void DeleteBookRe(int ReID);
        int Exists(int BookID);
        ArrayList GetBookReList(string strWhere);
        DataSet GetBookReList(int PageSize, int PageIndex, ref int IsReCount, string strWhere);
        Book_Re GetBookReModel(int BookID);
        int UpdateBookRe(Book_Re model);
    }
}
