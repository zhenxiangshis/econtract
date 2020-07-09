using System;
using System.Collections.Generic;
using System.Text;
using Model.User;
using System.Data;

namespace IDAL.User
{
    public interface IH_User
    {
        // Methods
        int Add(H_User model);
        void Delete(int Id);
        bool Exists(string LoginId);
        DataSet GetList(string strWhere);
        DataSet GetList(int PageSize, int PageIndex, string strWhere);
        int GetMaxId();
        H_User GetModel(int Id);
        void Update(H_User model);
        bool UserLogin(string LoginId, string Password);
    }


}
