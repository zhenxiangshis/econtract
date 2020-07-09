using System;
using System.Collections.Generic;
using System.Text;
using IDAL.Book;
using System.Data;
using System.Data.SqlClient;
using DBUtility;
using System.Collections;

namespace SQLServerDAL.Book
{
    public class Book_Info : IBook_Info
    {
        // Methods
        
        public int AddBookInfo(Model.Book.Book_Info model)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@BookID", SqlDbType.Int, 4), new SqlParameter("@UserName", SqlDbType.VarChar, 0x26), new SqlParameter("@Sex", SqlDbType.VarChar, 2), new SqlParameter("@Telephone", SqlDbType.VarChar, 0x23), new SqlParameter("@Mobile", SqlDbType.VarChar, 15), new SqlParameter("@Email", SqlDbType.VarChar, 50), new SqlParameter("@VTime", SqlDbType.DateTime), new SqlParameter("@Title", SqlDbType.VarChar, 100), new SqlParameter("@Content", SqlDbType.NText), new SqlParameter("@QQ", SqlDbType.VarChar, 0x19), new SqlParameter("@Froms", SqlDbType.VarChar, 100) };
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.Sex;
            parameters[3].Value = model.Telephone;
            parameters[4].Value = model.Mobile;
            parameters[5].Value = model.Email;
            parameters[6].Value = model.VTime;
            parameters[7].Value = model.Title;
            parameters[8].Value = model.Content;
            parameters[9].Value = model.QQ;
            parameters[10].Value = model.Froms;
            DbHelperSQL.RunProcedure("Book_AddBookInfo", parameters, out rowsAffected);
            return int.Parse(parameters[0].Value.ToString());
        }

        public void DeleteBookInfo(int BookID)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@BookID", SqlDbType.Int, 4) };
            parameters[0].Value = BookID;
            DbHelperSQL.RunProcedure("Book_DeleteBookInfo", parameters, out rowsAffected);
        }
        public void DeleteBookInfo(string BookID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Book_Info ");
            strSql.Append(" where BookID in (" + BookID + ")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        public ArrayList GetBookIDList(string strWhere)
        {
            ArrayList list = new ArrayList();
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@strWhere", SqlDbType.VarChar, 0x3e8) };
            parameters[0].Value = strWhere;
            SqlDataReader reader = DbHelperSQL.RunProcedure("Book_GetBookIDList", parameters);
            while (reader.Read())
            {
                Model.Book.Book_Info model = new Model.Book.Book_Info();
                model.BookID = int.Parse(reader["BookID"].ToString());
                list.Add(model);
            }
            reader.Close();
            return list;
        }
        public DataSet GetBookInfoList(int PageSize, int PageIndex, string OrderfldName, int OrderType, ref int IsReCount, string strWhere)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@tblName", SqlDbType.VarChar, 0xff), new SqlParameter("@fldName", SqlDbType.VarChar, 500), new SqlParameter("@OrderfldName", SqlDbType.VarChar, 0xff), new SqlParameter("@PageSize", SqlDbType.Int), new SqlParameter("@PageIndex", SqlDbType.Int), new SqlParameter("@IsReCount", SqlDbType.Int), new SqlParameter("@OrderType", SqlDbType.Int), new SqlParameter("@strWhere", SqlDbType.VarChar, 0x3e8) };
            parameters[0].Value = "Book_Info";
            parameters[1].Value = "[BookID],[UserName],[Sex],[Telephone],[Mobile],[Email],[VTime],[AddTime],[Aud],[Title],[Content],[QQ],[Froms]";
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

        public Model.Book.Book_Info GetBookInfoModel(int BookID)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@BookID", SqlDbType.Int, 4) };
            parameters[0].Value = BookID;
            Model.Book.Book_Info model = new Model.Book.Book_Info();
            DataSet ds = DbHelperSQL.RunProcedure("Book_GetBookInfoModel", parameters, "ds");
            model.BookID = BookID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.Sex = ds.Tables[0].Rows[0]["Sex"].ToString();
                model.Telephone = ds.Tables[0].Rows[0]["Telephone"].ToString();
                model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                if (ds.Tables[0].Rows[0]["VTime"].ToString() != "")
                {
                    model.VTime = DateTime.Parse(ds.Tables[0].Rows[0]["VTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Aud"].ToString() != "")
                {
                    model.Aud = int.Parse(ds.Tables[0].Rows[0]["Aud"].ToString());
                }
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                model.QQ = ds.Tables[0].Rows[0]["QQ"].ToString();
                model.Froms = ds.Tables[0].Rows[0]["Froms"].ToString();
                return model;
            }
            return null;
        }
        public DataSet GetBookList(int strClassID, int strTop, string strOrder, string strWhere)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@strClassID", SqlDbType.Int, 4), new SqlParameter("@strTop", SqlDbType.Int, 4), new SqlParameter("@strOrder", SqlDbType.VarChar, 50), new SqlParameter("@strWhere", SqlDbType.VarChar, 500) };
            parameters[0].Value = strClassID;
            parameters[1].Value = strTop;
            parameters[2].Value = strOrder;
            parameters[3].Value = strWhere;
            return DbHelperSQL.RunProcedure("Book_GetBookList", parameters, "ds");
        }

        public void UpBookInfo(string BookID, string YesNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Book_Info set Aud=" + YesNo);
            strSql.Append(" where BookID =" + BookID);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        public int UpdateBookInfo(Model.Book.Book_Info model)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@BookID", SqlDbType.Int, 4), new SqlParameter("@UserName", SqlDbType.VarChar, 0x26), new SqlParameter("@Sex", SqlDbType.VarChar, 2), new SqlParameter("@Telephone", SqlDbType.VarChar, 0x23), new SqlParameter("@Mobile", SqlDbType.VarChar, 15), new SqlParameter("@Email", SqlDbType.VarChar, 50), new SqlParameter("@VTime", SqlDbType.DateTime), new SqlParameter("@Aud", SqlDbType.Int, 4), new SqlParameter("@Title", SqlDbType.VarChar, 100), new SqlParameter("@Content", SqlDbType.NText), new SqlParameter("@QQ", SqlDbType.VarChar, 0x19), new SqlParameter("@Froms", SqlDbType.VarChar, 100) };
            parameters[0].Value = model.BookID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.Sex;
            parameters[3].Value = model.Telephone;
            parameters[4].Value = model.Mobile;
            parameters[5].Value = model.Email;
            parameters[6].Value = model.VTime;
            parameters[7].Value = model.Aud;
            parameters[8].Value = model.Title;
            parameters[9].Value = model.Content;
            parameters[10].Value = model.QQ;
            parameters[11].Value = model.Froms;
            DbHelperSQL.RunProcedure("Book_UpdateBookInfo", parameters, out rowsAffected);
            return rowsAffected;
        }

    }


}
