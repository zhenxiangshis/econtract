using System;
using System.Collections.Generic;
using System.Text;
using IDAL.Account;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using DBUtility;
namespace SQLServerDAL.Account
{
    public class Accounts_Users : IAccounts_Users
    {
        public Accounts_Users() { }

        public void AddPermissionToRole(Model.Account.Accounts_Users model)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@RoleID", SqlDbType.Int, 4), new SqlParameter("@PermissionID", SqlDbType.Int, 4) };
            parameters[0].Value = model.RoleID;
            parameters[1].Value = model.PermissionID;
            DbHelperSQL.RunProcedure("Accounts_AddPermissionToRole", parameters, out rowsAffected);
        }

        public void AddUserToRole(Model.Account.Accounts_Users model)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@UserID", SqlDbType.Int, 4), new SqlParameter("@RoleID", SqlDbType.Int, 4) };
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.RoleID;
            DbHelperSQL.RunProcedure("Accounts_AddUserToRole", parameters, out rowsAffected);
        }

        public void CreatePermission(Model.Account.Accounts_Users model)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@CategoryID", SqlDbType.Int, 4), new SqlParameter("@Description", SqlDbType.VarChar, 50) };
            parameters[0].Value = model.CategoryID;
            parameters[1].Value = model.Description;
            DbHelperSQL.RunProcedure("Accounts_CreatePermission", parameters, out rowsAffected);
        }

        public void CreatePermissionCategory(Model.Account.Accounts_Users model)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@Description", SqlDbType.VarChar, 50) };
            parameters[0].Value = model.Description;
            DbHelperSQL.RunProcedure("Accounts_CreatePermissionCategory", parameters, out rowsAffected);
        }

        public int CreateRole(Model.Account.Accounts_Users model)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@Description", SqlDbType.VarChar, 0xff) };
            parameters[0].Value = model.Description;
            DbHelperSQL.RunProcedure("Accounts_CreateRole", parameters, out rowsAffected);
            return rowsAffected;
        }

        public int CreateUser(Model.Account.Accounts_Users model)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@UserID", SqlDbType.Int, 4), new SqlParameter("@UserName", SqlDbType.VarChar, 50), new SqlParameter("@Password", SqlDbType.VarChar, 0x26), new SqlParameter("@TrueName", SqlDbType.VarChar, 50), new SqlParameter("@Sex", SqlDbType.VarChar, 2), new SqlParameter("@Phone", SqlDbType.VarChar, 20), new SqlParameter("@Email", SqlDbType.VarChar, 100), new SqlParameter("@EmployeeID", SqlDbType.Int, 4), new SqlParameter("@DepartmentID", SqlDbType.VarChar, 15), new SqlParameter("@Activity", SqlDbType.Bit, 1), new SqlParameter("@UserType", SqlDbType.VarChar, 8), new SqlParameter("@Style", SqlDbType.Int, 4) };
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.Password;
            parameters[3].Value = model.TrueName;
            parameters[4].Value = model.Sex;
            parameters[5].Value = model.Phone;
            parameters[6].Value = model.Email;
            parameters[7].Value = model.EmployeeID;
            parameters[8].Value = model.DepartmentID;
            parameters[9].Value = model.Activity;
            parameters[10].Value = model.UserType;
            parameters[11].Value = model.Style;
            DbHelperSQL.RunProcedure("Accounts_CreateUser", parameters, out rowsAffected);
            return Convert.ToInt32(parameters[0].Value.ToString());
        }

        public void DeletePermission(int PermissionID)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@PermissionID", SqlDbType.Int, 4) };
            parameters[0].Value = PermissionID;
            DbHelperSQL.RunProcedure("Accounts_DeletePermission", parameters, out rowsAffected);
        }

        public void DeletePermissionCategory(int CategoryID)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@CategoryID", SqlDbType.Int, 4) };
            parameters[0].Value = CategoryID;
            DbHelperSQL.RunProcedure("Accounts_DeletePermissionCategory", parameters, out rowsAffected);
        }

        public void DeletePermissionFromRole(int RoleID, int PermissionID)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@RoleID", SqlDbType.Int, 4), new SqlParameter("@PermissionID", SqlDbType.Int, 4) };
            parameters[0].Value = RoleID;
            parameters[1].Value = PermissionID;
            DbHelperSQL.RunProcedure("Accounts_DeletePermissionFromRole", parameters, out rowsAffected);
        }
        public void DeleteRole(int RoleID)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@RoleID", SqlDbType.Int, 4) };
            parameters[0].Value = RoleID;
            DbHelperSQL.RunProcedure("Accounts_DeleteRole", parameters, out rowsAffected);
        }

        public void DeleteUser(int UserID)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@UserID", SqlDbType.Int, 4) };
            parameters[0].Value = UserID;
            DbHelperSQL.RunProcedure("Accounts_DeleteByUserID", parameters, out rowsAffected);
        }

        public bool Exists(int UserID)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@UserID", SqlDbType.Int, 4) };
            parameters[0].Value = UserID;
            return (DbHelperSQL.RunProcedure("Accounts_ExistsByUserID", parameters, out rowsAffected) == 1);
        }
        public bool Exists(string UserName)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@UserName", SqlDbType.VarChar, 50) };
            parameters[0].Value = UserName;
            return (DbHelperSQL.RunProcedure("Accounts_ExistsByUserName", parameters, out rowsAffected) == 1);
        }
        public DataSet GetAllCategories()
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@strWhere", SqlDbType.VarChar, 0xff) };
            parameters[0].Value = "strWhere";
            return DbHelperSQL.RunProcedure("Accounts_GetAllCategories", parameters, "ds");
        }

        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Accounts_Users ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by UserID ");
            return DbHelperSQL.Query(strSql.ToString());
        }

        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("UserID", "Accounts_Users");
        }
        public Model.Account.Accounts_Users GetModel(int UserID)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@UserID", SqlDbType.Int, 4) };
            parameters[0].Value = UserID;
            Model.Account.Accounts_Users model = new Model.Account.Accounts_Users();
            DataSet ds = DbHelperSQL.RunProcedure("Accounts_GetModelByUserID", parameters, "ds");
            model.UserID = UserID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                model.TrueName = ds.Tables[0].Rows[0]["TrueName"].ToString();
                model.Sex = ds.Tables[0].Rows[0]["Sex"].ToString();
                model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                if (ds.Tables[0].Rows[0]["EmployeeID"].ToString() != "")
                {
                    model.EmployeeID = int.Parse(ds.Tables[0].Rows[0]["EmployeeID"].ToString());
                }
                model.DepartmentID = ds.Tables[0].Rows[0]["DepartmentID"].ToString();
                if (ds.Tables[0].Rows[0]["Activity"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Activity"].ToString() == "1") || (ds.Tables[0].Rows[0]["Activity"].ToString().ToLower() == "true"))
                    {
                        model.Activity = true;
                    }
                    else
                    {
                        model.Activity = false;
                    }
                }
                model.UserType = ds.Tables[0].Rows[0]["UserType"].ToString();
                if (ds.Tables[0].Rows[0]["Style"].ToString() != "")
                {
                    model.Style = int.Parse(ds.Tables[0].Rows[0]["Style"].ToString());
                }
                return model;
            }
            return null;
        }

        public Model.Account.Accounts_Users GetModel(string UserName)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@UserName", SqlDbType.VarChar, 50) };
            parameters[0].Value = UserName;
            Model.Account.Accounts_Users model = new Model.Account.Accounts_Users();
            DataSet ds = DbHelperSQL.RunProcedure("Accounts_GetModelByUserName", parameters, "ds");
            model.UserName = UserName;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                model.TrueName = ds.Tables[0].Rows[0]["TrueName"].ToString();
                model.Sex = ds.Tables[0].Rows[0]["Sex"].ToString();
                model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                if (ds.Tables[0].Rows[0]["EmployeeID"].ToString() != "")
                {
                    model.EmployeeID = int.Parse(ds.Tables[0].Rows[0]["EmployeeID"].ToString());
                }
                model.DepartmentID = ds.Tables[0].Rows[0]["DepartmentID"].ToString();
                if (ds.Tables[0].Rows[0]["Activity"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Activity"].ToString() == "1") || (ds.Tables[0].Rows[0]["Activity"].ToString().ToLower() == "true"))
                    {
                        model.Activity = true;
                    }
                    else
                    {
                        model.Activity = false;
                    }
                }
                model.UserType = ds.Tables[0].Rows[0]["UserType"].ToString();
                if (ds.Tables[0].Rows[0]["Style"].ToString() != "")
                {
                    model.Style = int.Parse(ds.Tables[0].Rows[0]["Style"].ToString());
                }
                return model;
            }
            return null;
        }

        public ArrayList GetNoPermissionList(int RoleID, int CategoryID)
        {
            ArrayList list = new ArrayList();
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@RoleID", SqlDbType.Int, 4), new SqlParameter("@CategoryID", SqlDbType.Int, 4) };
            parameters[0].Value = RoleID;
            parameters[1].Value = CategoryID;
            SqlDataReader reader = DbHelperSQL.RunProcedure("Accounts_GetNoPermissionList", parameters);
            while (reader.Read())
            {
                Model.Account.Accounts_Users model = new Model.Account.Accounts_Users();
                model.Description = reader["Description"].ToString();
                model.PermissionID = int.Parse(reader["PermissionID"].ToString());
                list.Add(model);
            }
            reader.Close();
            return list;
        }

        public DataSet GetPermissionCategories()
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@strWhere", SqlDbType.VarChar, 50) };
            parameters[0].Value = "strWhere";
            return DbHelperSQL.RunProcedure("Accounts_GetPermissionCategories", parameters, "ds");
        }

        public ArrayList GetPermissionList(int RoleID, int CategoryID)
        {
            ArrayList list = new ArrayList();
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@RoleID", SqlDbType.Int, 4), new SqlParameter("@CategoryID", SqlDbType.Int, 4) };
            parameters[0].Value = RoleID;
            parameters[1].Value = CategoryID;
            SqlDataReader reader = DbHelperSQL.RunProcedure("Accounts_GetPermissionList", parameters);
            while (reader.Read())
            {
                Model.Account.Accounts_Users model = new Model.Account.Accounts_Users();
                model.Description = reader["Description"].ToString();
                model.PermissionID = int.Parse(reader["PermissionID"].ToString());
                list.Add(model);
            }
            reader.Close();
            return list;
        }

        public DataSet GetPermissionsByCategory(int CategoryID)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@CategoryID", SqlDbType.Int, 4) };
            parameters[0].Value = CategoryID;
            return DbHelperSQL.RunProcedure("Accounts_GetPermissionsByCategory", parameters, "ds");
        }

        public Model.Account.Accounts_Users GetPermissionsDetails(int PermissionID)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@PermissionID", SqlDbType.Int, 4) };
            parameters[0].Value = PermissionID;
            Model.Account.Accounts_Users model = new Model.Account.Accounts_Users();
            DataSet ds = DbHelperSQL.RunProcedure("Accounts_GetPermissionsDetails", parameters, "ds");
            model.PermissionID = PermissionID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PermissionID"].ToString() != "")
                {
                    model.PermissionID = int.Parse(ds.Tables[0].Rows[0]["PermissionID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CategoryID"].ToString() != "")
                {
                    model.CategoryID = int.Parse(ds.Tables[0].Rows[0]["CategoryID"].ToString());
                }
                model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                return model;
            }
            return null;
        }

        public Model.Account.Accounts_Users GetRoleDetails(int RoleID)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@RoleID", SqlDbType.Int, 4) };
            parameters[0].Value = RoleID;
            Model.Account.Accounts_Users model = new Model.Account.Accounts_Users();
            DataSet ds = DbHelperSQL.RunProcedure("Accounts_GetRoleDetails", parameters, "ds");
            model.RoleID = RoleID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["RoleID"].ToString() != "")
                {
                    model.RoleID = int.Parse(ds.Tables[0].Rows[0]["RoleID"].ToString());
                }
                model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                return model;
            }
            return null;
        }

        public DataSet GetRoleList()
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@strWhere", SqlDbType.VarChar, 50) };
            parameters[0].Value = "strWhere";
            return DbHelperSQL.RunProcedure("Accounts_GetAllRoles", parameters, "ds");
        }

        public ArrayList GetUserAccountList(int UserId)
        {
            ArrayList list = new ArrayList();
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@UserId", SqlDbType.Int, 4) };
            parameters[0].Value = UserId;
            SqlDataReader reader = DbHelperSQL.RunProcedure("Accounts_GetUserAccountList", parameters);
            while (reader.Read())
            {
                Model.Account.Accounts_Users model = new Model.Account.Accounts_Users();
                model.Description = reader["Description"].ToString();
                model.PermissionID = int.Parse(reader["PermissionID"].ToString());
                list.Add(model);
            }
            reader.Close();
            return list;
        }

        public DataSet GetUserInfoList(int PageSize, int PageIndex, ref int IsReCount, string strWhere)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@tblName", SqlDbType.VarChar, 0xff), new SqlParameter("@fldName", SqlDbType.VarChar, 500), new SqlParameter("@OrderfldName", SqlDbType.VarChar, 0xff), new SqlParameter("@PageSize", SqlDbType.Int), new SqlParameter("@PageIndex", SqlDbType.Int), new SqlParameter("@IsReCount", SqlDbType.Int), new SqlParameter("@OrderType", SqlDbType.Int), new SqlParameter("@strWhere", SqlDbType.VarChar, 0x3e8) };
            parameters[0].Value = "Accounts_Users";
            parameters[1].Value = "[UserID],[UserName],[TrueName],[Sex],[Phone],[Email],[EmployeeID],[DepartmentID],[Activity],[UserType],[Style]";
            parameters[2].Value = "UserID";
            parameters[3].Value = PageSize;
            parameters[4].Value = PageIndex;
            parameters[5].Direction = ParameterDirection.Output;
            parameters[6].Value = 1;
            parameters[7].Value = " UserName like '%" + strWhere + "%' Or TrueName like '%" + strWhere + "%'";
            DataSet redata = DbHelperSQL.RunProcedure("GetRecordByPage", parameters, "ds");
            IsReCount = int.Parse(parameters[5].Value.ToString());
            return redata;
        }

        public DataSet GetUserList(string strWhere)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@strWhere", SqlDbType.VarChar, 50) };
            parameters[0].Value = strWhere;
            return DbHelperSQL.RunProcedure("Accounts_GetUsers", parameters, "ds");
        }

        public bool PageByUserId(int UserId, string PageName)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@UserId", SqlDbType.Int, 4), new SqlParameter("@PageName", SqlDbType.VarChar, 0x3e8) };
            parameters[0].Value = UserId;
            parameters[1].Value = PageName;
            return (DbHelperSQL.RunProcedure("Accounts_PageByUserId", parameters, out rowsAffected) == 1);
        }

        public bool PermissionByUserId(int UserId, int PermissionId)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@UserId", SqlDbType.Int, 4), new SqlParameter("@PermissionId", SqlDbType.Int, 4) };
            parameters[0].Value = UserId;
            parameters[1].Value = PermissionId;
            return (DbHelperSQL.RunProcedure("Accounts_PermissionByUserId", parameters, out rowsAffected) == 1);
        }
        public void UpdateByAdmin(Model.Account.Accounts_Users model)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@UserID", SqlDbType.Int, 4), new SqlParameter("@TrueName", SqlDbType.VarChar, 50), new SqlParameter("@Password", SqlDbType.VarChar, 0x26), new SqlParameter("@Sex", SqlDbType.Char, 2), new SqlParameter("@Phone", SqlDbType.VarChar, 20), new SqlParameter("@Email", SqlDbType.VarChar, 100), new SqlParameter("@EmployeeID", SqlDbType.Int, 4), new SqlParameter("@DepartmentID", SqlDbType.VarChar, 15), new SqlParameter("@Activity", SqlDbType.Bit, 1), new SqlParameter("@UserType", SqlDbType.Char, 2), new SqlParameter("@Style", SqlDbType.Int, 4) };
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.TrueName;
            parameters[2].Value = model.Password;
            parameters[3].Value = model.Sex;
            parameters[4].Value = model.Phone;
            parameters[5].Value = model.Email;
            parameters[6].Value = model.EmployeeID;
            parameters[7].Value = model.DepartmentID;
            parameters[8].Value = model.Activity;
            parameters[9].Value = model.UserType;
            parameters[10].Value = model.Style;
            DbHelperSQL.RunProcedure("Accounts_UpdateByAdmin", parameters, out rowsAffected);
        }

        public void UpdatePassword(Model.Account.Accounts_Users model)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@UserID", SqlDbType.Int, 4), new SqlParameter("@Password", SqlDbType.VarChar, 0x26) };
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.Password;
            DbHelperSQL.RunProcedure("Accounts_UpdatePassword", parameters, out rowsAffected);
        }

        public void UpdatePermission(Model.Account.Accounts_Users model)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@PermissionID", SqlDbType.Int, 4), new SqlParameter("@Description", SqlDbType.VarChar, 50) };
            parameters[0].Value = model.PermissionID;
            parameters[1].Value = model.Description;
            DbHelperSQL.RunProcedure("Accounts_UpdatePermission", parameters, out rowsAffected);
        }

        public void UpdateRole(Model.Account.Accounts_Users model)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@RoleID", SqlDbType.Int, 4), new SqlParameter("@Description", SqlDbType.VarChar, 50) };
            parameters[0].Value = model.RoleID;
            parameters[1].Value = model.Description;
            DbHelperSQL.RunProcedure("Accounts_UpdateRole", parameters, out rowsAffected);
        }

        public void UpdateUsers(Model.Account.Accounts_Users model)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@UserID", SqlDbType.Int, 4), new SqlParameter("@TrueName", SqlDbType.VarChar, 50), new SqlParameter("@Sex", SqlDbType.Char, 2), new SqlParameter("@Phone", SqlDbType.VarChar, 20), new SqlParameter("@Email", SqlDbType.VarChar, 100), new SqlParameter("@EmployeeID", SqlDbType.Int, 4), new SqlParameter("@DepartmentID", SqlDbType.VarChar, 15), new SqlParameter("@Activity", SqlDbType.Bit, 1), new SqlParameter("@UserType", SqlDbType.Char, 2), new SqlParameter("@Style", SqlDbType.Int, 4) };
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.TrueName;
            parameters[2].Value = model.Sex;
            parameters[3].Value = model.Phone;
            parameters[4].Value = model.Email;
            parameters[5].Value = model.EmployeeID;
            parameters[6].Value = model.DepartmentID;
            parameters[7].Value = model.Activity;
            parameters[8].Value = model.UserType;
            parameters[9].Value = model.Style;
            DbHelperSQL.RunProcedure("Accounts_UpdateUsers", parameters, out rowsAffected);
        }

        public bool UserLogin(string UserName, string Password)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@UserName", SqlDbType.VarChar, 50), new SqlParameter("@Password", SqlDbType.VarChar, 0x26) };
            parameters[0].Value = UserName;
            parameters[1].Value = Password;
            return (DbHelperSQL.RunProcedure("Accounts_ValidateLogin", parameters, out rowsAffected) == 1);
        }

    }
}
