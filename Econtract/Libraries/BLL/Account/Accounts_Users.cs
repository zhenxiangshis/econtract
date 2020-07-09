using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using DALFactory;
using IDAL.Account;
using Model;

namespace BLL.Account
{
    public class Accounts_Users
    {
        // Fields
        private readonly IAccounts_Users dal;

        // Methods
        public Accounts_Users()
        {
            this.dal = DataAccess.CreateAccounts_Users();
        }

        public void AddPermissionToRole(Model.Account.Accounts_Users model)
        {
            this.dal.AddPermissionToRole(model);
        }

        public void AddUserToRole(Model.Account.Accounts_Users model)
        {
            this.dal.AddUserToRole(model);
        }

        public void CreatePermission(Model.Account.Accounts_Users model)
        {
            this.dal.CreatePermission(model);
        }

        public void CreatePermissionCategory(Model.Account.Accounts_Users model)
        {
            this.dal.CreatePermissionCategory(model);
        }
        public int CreateRole(Model.Account.Accounts_Users model)
        {
            return this.dal.CreateRole(model);
        }

        public int CreateUser(Model.Account.Accounts_Users model)
        {
            return this.dal.CreateUser(model);
        }

        public void DeletePermission(int PermissionID)
        {
            this.dal.DeletePermission(PermissionID);
        }

        public void DeletePermissionCategory(int CategoryID)
        {
            this.dal.DeletePermissionCategory(CategoryID);
        }

        public void DeletePermissionFromRole(int RoleID, int PermissionID)
        {
            this.dal.DeletePermissionFromRole(RoleID, PermissionID);
        }

        public void DeleteRole(int RoleID)
        {
            this.dal.DeleteRole(RoleID);
        }

        public void DeleteUser(int UserID)
        {
            this.dal.DeleteUser(UserID);
        }
        public bool Exists(int UserID)
        {
            return this.dal.Exists(UserID);
        }

        public bool Exists(string UserName)
        {
            return this.dal.Exists(UserName);
        }

        public DataSet GetAllCategories()
        {
            return this.dal.GetAllCategories();
        }

        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }

        public int GetMaxId()
        {
            return this.dal.GetMaxId();
        }

        public Model.Account.Accounts_Users GetModel(int UserID)
        {
            return this.dal.GetModel(UserID);
        }

        public Model.Account.Accounts_Users GetModel(string UserName)
        {
            return this.dal.GetModel(UserName);
        }
        public ArrayList GetNoPermissionList(int RoleID, int CategoryID)
        {
            return this.dal.GetNoPermissionList(RoleID, CategoryID);
        }

        public DataSet GetPermissionCategories()
        {
            return this.dal.GetPermissionCategories();
        }
        public ArrayList GetPermissionList(int RoleID, int CategoryID)
        {
            return this.dal.GetPermissionList(RoleID, CategoryID);
        }
        public DataSet GetPermissionsByCategory(int CategoryID)
        {
            return this.dal.GetPermissionsByCategory(CategoryID);
        }
        public Model.Account.Accounts_Users GetPermissionsDetails(int PermissionID)
        {
            return this.dal.GetPermissionsDetails(PermissionID);
        }

        public Model.Account.Accounts_Users GetRoleDetails(int RoleID)
        {
            return this.dal.GetRoleDetails(RoleID);
        }
        public DataSet GetRoleList()
        {
            return this.dal.GetRoleList();
        }
        public ArrayList GetUserAccountList(int UserId)
        {
            return this.dal.GetUserAccountList(UserId);
        }

        public DataSet GetUserInfoList(int PageSize, int PageIndex, ref int IsReCount, string strWhere)
        {
            return this.dal.GetUserInfoList(PageSize, PageIndex, ref IsReCount, strWhere);
        }
        public DataSet GetUserList(string strWhere)
        {
            return this.dal.GetUserList(strWhere);
        }

        public bool PageByUserId(int UserId, string PageName)
        {
            return this.dal.PageByUserId(UserId, PageName);
        }

        public bool PermissionByUserId(int UserId, int PermissionId)
        {
            return this.dal.PermissionByUserId(UserId, PermissionId);
        }
        public void UpdateByAdmin(Model.Account.Accounts_Users model)
        {
            this.dal.UpdateByAdmin(model);
        }
        public void UpdatePassword(Model.Account.Accounts_Users model)
        {
            this.dal.UpdatePassword(model);
        }

        public void UpdatePermission(Model.Account.Accounts_Users model)
        {
            this.dal.UpdatePermission(model);
        }
        public void UpdateRole(Model.Account.Accounts_Users model)
        {
            this.dal.UpdateRole(model);
        }
        public void UpdateUsers(Model.Account.Accounts_Users model)
        {
            this.dal.UpdateUsers(model);
        }

        public bool UserLogin(string UserName, string Password)
        {
            return this.dal.UserLogin(UserName, Password);
        }
    }


}
