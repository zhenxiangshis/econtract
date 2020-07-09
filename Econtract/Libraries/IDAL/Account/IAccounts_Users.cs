using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model.Account;
using System.Collections;

namespace IDAL.Account
{
    public interface IAccounts_Users
    {
        // Methods
        void AddPermissionToRole(Accounts_Users model);
        void AddUserToRole(Accounts_Users model);
        void CreatePermission(Accounts_Users model);
        void CreatePermissionCategory(Accounts_Users model);
        int CreateRole(Accounts_Users model);
        int CreateUser(Accounts_Users model);
        void DeletePermission(int PermissionID);
        void DeletePermissionCategory(int CategoryID);
        void DeletePermissionFromRole(int RoleID, int PermissionID);
        void DeleteRole(int RoleID);
        void DeleteUser(int UserID);
        bool Exists(int UserID);
        bool Exists(string UserName);
        DataSet GetAllCategories();
        DataSet GetList(string strWhere);
        int GetMaxId();
        Accounts_Users GetModel(int UserID);
        Accounts_Users GetModel(string UserName);
        ArrayList GetNoPermissionList(int RoleID, int CategoryID);
        DataSet GetPermissionCategories();
        ArrayList GetPermissionList(int RoleID, int CategoryID);
        DataSet GetPermissionsByCategory(int CategoryID);
        Accounts_Users GetPermissionsDetails(int PermissionID);
        Accounts_Users GetRoleDetails(int RoleID);
        DataSet GetRoleList();
        ArrayList GetUserAccountList(int UserId);
        DataSet GetUserInfoList(int PageSize, int PageIndex, ref int IsReCount, string strWhere);
        DataSet GetUserList(string strWhere);
        bool PageByUserId(int UserId, string PageName);
        bool PermissionByUserId(int UserId, int PermissionId);
        void UpdateByAdmin(Accounts_Users model);
        void UpdatePassword(Accounts_Users model);
        void UpdatePermission(Accounts_Users model);
        void UpdateRole(Accounts_Users model);
        void UpdateUsers(Accounts_Users model);
        bool UserLogin(string UserName, string Password);

    }
}
