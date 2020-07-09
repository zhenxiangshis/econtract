using System;
using System.Collections.Generic;
using System.Text;
using IDAL.Pic;
using DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace SQLServerDAL.Pic
{
    public class Pic_Class : IPic_Class
    {
        // Methods
        public Pic_Class() { }
        public int CreatePicClass(Model.Pic.Pic_Class model)
        {
            int rowsAffected;
            model.ClassID = this.GetMaxId();
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@ParentID", SqlDbType.Int, 4), new SqlParameter("@ClassName", SqlDbType.VarChar, 50), new SqlParameter("@ClassIntro", SqlDbType.VarChar, 0x3e8) };
            parameters[0].Value = model.ParentID;
            parameters[1].Value = model.ClassName;
            parameters[2].Value = model.ClassIntro;
            DbHelperSQL.RunProcedure("Pic_CreatePicClass", parameters, out rowsAffected);
            return model.ClassID;
        }
        public int DeletePicClass(int ClassID)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@ClassID", SqlDbType.Int, 4) };
            parameters[0].Value = ClassID;
            DbHelperSQL.RunProcedure("Pic_DeletePicClass", parameters, out rowsAffected);
            return rowsAffected;
        }

        public bool Exists(int ClassID)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@ClassID", SqlDbType.Int, 4) };
            parameters[0].Value = ClassID;
            return (DbHelperSQL.RunProcedure("Pic_ClassExists", parameters, out rowsAffected) == 1);
        }
        public DataSet GetList(int PageSize, int PageIndex, string strWhere)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@tblName", SqlDbType.VarChar, 0xff), new SqlParameter("@fldName", SqlDbType.VarChar, 500), new SqlParameter("@OrderfldName", SqlDbType.VarChar, 0xff), new SqlParameter("@PageSize", SqlDbType.Int), new SqlParameter("@PageIndex", SqlDbType.Int), new SqlParameter("@IsReCount", SqlDbType.Int), new SqlParameter("@OrderType", SqlDbType.Int), new SqlParameter("@strWhere", SqlDbType.VarChar, 0x3e8) };
            parameters[0].Value = "Pic_Class";
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
            return DbHelperSQL.GetMaxID("ClassID", "Pic_Class");
        }

        public DataSet GetPicClassList(string strWhere)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@strWhere", SqlDbType.VarChar, 0x3e8) };
            parameters[0].Value = "strWhere";
            return DbHelperSQL.RunProcedure("Pic_GetPicClassList", parameters, "ds");
        }

        public Model.Pic.Pic_Class GetPicClassModel(int ClassID)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@ClassID", SqlDbType.Int, 4) };
            parameters[0].Value = ClassID;
            Model.Pic.Pic_Class model = new Model.Pic.Pic_Class();
            DataSet ds = DbHelperSQL.RunProcedure("Pic_GetPicClassModel", parameters, "ds");
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
                return model;
            }
            return null;
        }

        public void UpdatePicClass(Model.Pic.Pic_Class model)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@ClassID", SqlDbType.Int, 4), new SqlParameter("@ParentID", SqlDbType.Int, 4), new SqlParameter("@ClassName", SqlDbType.VarChar, 50), new SqlParameter("@ClassIntro", SqlDbType.VarChar, 0x3e8) };
            parameters[0].Value = model.ClassID;
            parameters[1].Value = model.ParentID;
            parameters[2].Value = model.ClassName;
            parameters[3].Value = model.ClassIntro;
            DbHelperSQL.RunProcedure("Pic_UpdatePicClass", parameters, out rowsAffected);
        }
    }


}
