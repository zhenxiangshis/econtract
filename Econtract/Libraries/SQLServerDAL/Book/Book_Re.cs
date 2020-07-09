using System;
using System.Collections.Generic;
using System.Text;
using IDAL.Book;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using DBUtility;

namespace SQLServerDAL.Book
{
    public class Book_Re : IBook_Re
    {
        // Methods

        public int AddBookRe(Model.Book.Book_Re model)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@ReID", SqlDbType.Int, 4), new SqlParameter("@UserID", SqlDbType.Int, 4), new SqlParameter("@ReName", SqlDbType.VarChar, 50), new SqlParameter("@BookID", SqlDbType.Int, 4), new SqlParameter("@Content", SqlDbType.NText), new SqlParameter("@Ip", SqlDbType.VarChar, 50) };
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.ReName;
            parameters[3].Value = model.BookID;
            parameters[4].Value = model.Content;
            parameters[5].Value = model.Ip;
            DbHelperSQL.RunProcedure("Book_AddBookRe", parameters, out rowsAffected);
            return int.Parse(parameters[0].Value.ToString());
        }

        public void DeleteBookRe(int ReID)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@ReID", SqlDbType.Int, 4) };
            parameters[0].Value = ReID;
            DbHelperSQL.RunProcedure("Book_DeleteBookRe", parameters, out rowsAffected);
        }
        public int Exists(int BookID)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@BookID", SqlDbType.Int, 4) };
            parameters[0].Value = BookID;
            int result = DbHelperSQL.RunProcedure("Book_ReExists", parameters, out rowsAffected);
            if (result > 0)
            {
                return result;
            }
            return 0;
        }
        public ArrayList GetBookReList(string strWhere)
        {
            ArrayList list = new ArrayList();
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@strWhere", SqlDbType.VarChar, 0x3e8) };
            parameters[0].Value = strWhere;
            SqlDataReader reader = DbHelperSQL.RunProcedure("Book_GetBookReList", parameters);
            while (reader.Read())
            {
                Model.Book.Book_Re model = new Model.Book.Book_Re();
                model.ReID = int.Parse(reader["ReID"].ToString());
                model.UserID = int.Parse(reader["UserID"].ToString());
                model.ReName = reader["ReName"].ToString();
                model.BookID = int.Parse(reader["BookID"].ToString());
                model.Content = reader["Content"].ToString();
                model.Ip = reader["Ip"].ToString();
                model.AddTime = Convert.ToDateTime(reader["AddTime"].ToString());
                list.Add(model);
            }
            reader.Close();
            return list;
        }
        public DataSet GetBookReList(int PageSize, int PageIndex, ref int IsReCount, string strWhere)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@tblName", SqlDbType.VarChar, 0xff), new SqlParameter("@fldName", SqlDbType.VarChar, 500), new SqlParameter("@OrderfldName", SqlDbType.VarChar, 0xff), new SqlParameter("@PageSize", SqlDbType.Int), new SqlParameter("@PageIndex", SqlDbType.Int), new SqlParameter("@IsReCount", SqlDbType.Int), new SqlParameter("@OrderType", SqlDbType.Int), new SqlParameter("@strWhere", SqlDbType.VarChar, 0x3e8) };
            parameters[0].Value = "Book_Re";
            parameters[1].Value = "[ReID],[UserID],[ReName],[BookID],[Content],[Ip],[AddTime]";
            parameters[2].Value = "ReID";
            parameters[3].Value = PageSize;
            parameters[4].Value = PageIndex;
            parameters[5].Direction = ParameterDirection.Output;
            parameters[6].Value = 1;
            parameters[7].Value = " Content like '%" + strWhere + "%'";
            DataSet redata = DbHelperSQL.RunProcedure("GetRecordByPage", parameters, "ds");
            IsReCount = int.Parse(parameters[5].Value.ToString());
            return redata;
        }
        public Model.Book.Book_Re GetBookReModel(int BookID)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@BookID", SqlDbType.Int, 4) };
            parameters[0].Value = BookID;
            Model.Book.Book_Re model = new Model.Book.Book_Re();
            DataSet ds = DbHelperSQL.RunProcedure("Book_GetBookReModel", parameters, "ds");
            model.BookID = BookID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                model.ReName = ds.Tables[0].Rows[0]["ReName"].ToString();
                if (ds.Tables[0].Rows[0]["ReID"].ToString() != "")
                {
                    model.ReID = int.Parse(ds.Tables[0].Rows[0]["ReID"].ToString());
                }
                model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                model.Ip = ds.Tables[0].Rows[0]["Ip"].ToString();
                if (ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
                return model;
            }
            return null;
        }

        public int UpdateBookRe(Model.Book.Book_Re model)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@ReID", SqlDbType.Int, 4), new SqlParameter("@UserID", SqlDbType.Int, 4), new SqlParameter("@ReName", SqlDbType.VarChar, 50), new SqlParameter("@BookID", SqlDbType.Int, 4), new SqlParameter("@Content", SqlDbType.NText), new SqlParameter("@Ip", SqlDbType.VarChar, 50) };
            parameters[0].Value = model.ReID;
            parameters[1].Value = model.UserID;
            parameters[2].Value = model.ReName;
            parameters[3].Value = model.BookID;
            parameters[4].Value = model.Content;
            parameters[5].Value = model.Ip;
            DbHelperSQL.RunProcedure("Book_UpdateBookRe", parameters, out rowsAffected);
            return rowsAffected;
        }
    }


}
