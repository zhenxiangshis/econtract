using System;
using System.Collections.Generic;
using System.Text;
using IDAL.User;
using System.Data;
using System.Data.SqlClient;
using DBUtility;
using System.Collections;

namespace SQLServerDAL.User
{
    public class H_User : IH_User
    {
        // Methods
        public H_User() { }
        public int Add(Model.User.H_User model)
        {
            int rowsAffected;
            model.Id = this.GetMaxId();
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@LoginId", SqlDbType.VarChar, 30), new SqlParameter("@PassWord", SqlDbType.VarChar, 0x20), new SqlParameter("@Sex", SqlDbType.VarChar, 5), new SqlParameter("@Email", SqlDbType.VarChar, 50) };
            parameters[0].Value = model.LoginId;
            parameters[1].Value = model.PassWord;
            parameters[2].Value = model.Sex;
            parameters[3].Value = model.Email;
            DbHelperSQL.RunProcedure("H_User_Reg", parameters, out rowsAffected);
            return model.Id;
        }

        public void Delete(int Id)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@Id", SqlDbType.Int, 4) };
            parameters[0].Value = Id;
            DbHelperSQL.RunProcedure("UP_H_User_Delete", parameters, out rowsAffected);
        }
        public bool Exists(string LoginId)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@LoginId", SqlDbType.VarChar, 30) };
            parameters[0].Value = LoginId;
            return (DbHelperSQL.RunProcedure("H_User_Exists", parameters, out rowsAffected) == 1);
        }
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from T_User ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by Id ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetList(int PageSize, int PageIndex, string strWhere)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@tblName", SqlDbType.VarChar, 0xff), new SqlParameter("@fldName", SqlDbType.VarChar, 0xff), new SqlParameter("@PageSize", SqlDbType.Int), new SqlParameter("@PageIndex", SqlDbType.Int), new SqlParameter("@IsReCount", SqlDbType.Bit), new SqlParameter("@OrderType", SqlDbType.Bit), new SqlParameter("@strWhere", SqlDbType.VarChar, 0x3e8) };
            parameters[0].Value = "H_User";
            parameters[1].Value = "Id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage", parameters, "ds");
        }

        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Id", "H_User");
        }
        public Model.User.H_User GetModel(int Id)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@Id", SqlDbType.Int, 4) };
            parameters[0].Value = Id;
            Model.User.H_User model = new Model.User.H_User();
            DataSet ds = DbHelperSQL.RunProcedure("UP_H_User_GetModel", parameters, "ds");
            model.Id = Id;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.LoginId = ds.Tables[0].Rows[0]["LoginId"].ToString();
                model.NickName = ds.Tables[0].Rows[0]["NickName"].ToString();
                model.PassWord = ds.Tables[0].Rows[0]["PassWord"].ToString();
                model.Sex = ds.Tables[0].Rows[0]["Sex"].ToString();
                if (ds.Tables[0].Rows[0]["BirDay"].ToString() != "")
                {
                    model.BirDay = DateTime.Parse(ds.Tables[0].Rows[0]["BirDay"].ToString());
                }
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                model.Provin = ds.Tables[0].Rows[0]["Provin"].ToString();
                model.City = ds.Tables[0].Rows[0]["City"].ToString();
                model.County = ds.Tables[0].Rows[0]["County"].ToString();
                if (ds.Tables[0].Rows[0]["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LogTime"].ToString() != "")
                {
                    model.LogTime = DateTime.Parse(ds.Tables[0].Rows[0]["LogTime"].ToString());
                }
                model.LogIp = ds.Tables[0].Rows[0]["LogIp"].ToString();
                if (ds.Tables[0].Rows[0]["LogCount"].ToString() != "")
                {
                    model.LogCount = int.Parse(ds.Tables[0].Rows[0]["LogCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Lock"].ToString() != "")
                {
                    model.Lock = int.Parse(ds.Tables[0].Rows[0]["Lock"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LockTime"].ToString() != "")
                {
                    model.LockTime = DateTime.Parse(ds.Tables[0].Rows[0]["LockTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Types"].ToString() != "")
                {
                    model.Types = int.Parse(ds.Tables[0].Rows[0]["Types"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Rank"].ToString() != "")
                {
                    model.Rank = int.Parse(ds.Tables[0].Rows[0]["Rank"].ToString());
                }
                model.Dep = ds.Tables[0].Rows[0]["Dep"].ToString();
                model.Vis = ds.Tables[0].Rows[0]["Vis"].ToString();
                return model;
            }
            return null;
        }

        public void Update(Model.User.H_User model)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { 
        new SqlParameter("@Id", SqlDbType.Int, 4), new SqlParameter("@LoginId", SqlDbType.VarChar, 30), new SqlParameter("@NickName", SqlDbType.VarChar, 30), new SqlParameter("@PassWord", SqlDbType.VarChar, 0x20), new SqlParameter("@Sex", SqlDbType.VarChar, 5), new SqlParameter("@BirDay", SqlDbType.DateTime), new SqlParameter("@Email", SqlDbType.VarChar, 50), new SqlParameter("@Provin", SqlDbType.VarChar, 0x12), new SqlParameter("@City", SqlDbType.VarChar, 0x12), new SqlParameter("@County", SqlDbType.VarChar, 0x12), new SqlParameter("@CreateTime", SqlDbType.DateTime), new SqlParameter("@LogTime", SqlDbType.DateTime), new SqlParameter("@LogIp", SqlDbType.VarChar, 0x12), new SqlParameter("@LogCount", SqlDbType.Int, 4), new SqlParameter("@Lock", SqlDbType.Int, 4), new SqlParameter("@LockTime", SqlDbType.DateTime), 
        new SqlParameter("@Types", SqlDbType.Int, 4), new SqlParameter("@Rank", SqlDbType.Int, 4), new SqlParameter("@Dep", SqlDbType.VarChar, 200), new SqlParameter("@Vis", SqlDbType.VarChar, 50)
     };
            parameters[0].Value = model.Id;
            parameters[1].Value = model.LoginId;
            parameters[2].Value = model.NickName;
            parameters[3].Value = model.PassWord;
            parameters[4].Value = model.Sex;
            parameters[5].Value = model.BirDay;
            parameters[6].Value = model.Email;
            parameters[7].Value = model.Provin;
            parameters[8].Value = model.City;
            parameters[9].Value = model.County;
            parameters[10].Value = model.CreateTime;
            parameters[11].Value = model.LogTime;
            parameters[12].Value = model.LogIp;
            parameters[13].Value = model.LogCount;
            parameters[14].Value = model.Lock;
            parameters[15].Value = model.LockTime;
            parameters[0x10].Value = model.Types;
            parameters[0x11].Value = model.Rank;
            parameters[0x12].Value = model.Dep;
            parameters[0x13].Value = model.Vis;
            DbHelperSQL.RunProcedure("UP_H_User_Update", parameters, out rowsAffected);
        }

        public bool UserLogin(string LoginId, string Password)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@LoginId", SqlDbType.VarChar, 30), new SqlParameter("@Password", SqlDbType.VarChar, 0x20) };
            parameters[0].Value = LoginId;
            parameters[1].Value = Password;
            return (DbHelperSQL.RunProcedure("H_User_Login", parameters, out rowsAffected) == 1);
        }

    }


}
