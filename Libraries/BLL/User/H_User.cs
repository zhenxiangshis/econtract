using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using DALFactory;
using IDAL.User;
using Model;
using Utility;
using System.IO;
using System.Configuration;
using System.Web;

namespace BLL.User
{
    public class H_User
    {
        // Fields
        private readonly IH_User dal;

        // Methods
        public H_User()
        {
            this.dal = DataAccess.CreateH_User();
        }
        public int Add(Model.User.H_User model)
        {
            return this.dal.Add(model);
        }
        public void Delete(int Id)
        {
            this.dal.Delete(Id);
        }
        public bool Exists(string LoginId)
        {
            return this.dal.Exists(LoginId);
        }
        public DataSet GetList(string strWhere)
        {
            return this.dal.GetList(strWhere);
        }
        public DataSet GetList(int PageSize, int PageIndex, string strWhere)
        {
            return this.dal.GetList(PageSize, PageIndex, strWhere);
        }
        public int GetMaxId()
        {
            return this.dal.GetMaxId();
        }
        public Model.User.H_User GetModel(int Id)
        {
            return this.dal.GetModel(Id);
        }
        public void Update(Model.User.H_User model)
        {
            this.dal.Update(model);
        }

        public bool UserLogin(string LoginId, string Password)
        {
            return this.dal.UserLogin(LoginId, Password);
        }

    }


}
