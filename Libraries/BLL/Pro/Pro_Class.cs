using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using DALFactory;
using IDAL.Pro;
using Model;
using Utility;
using System.IO;
using System.Configuration;
using System.Web;

namespace BLL.Pro
{
    public class Pro_Class
    {
        // Fields
        private readonly IPro_Class dal;

        // Methods
        public Pro_Class()
        {
            this.dal = DataAccess.CreatePro_Class();
        }
        public int CreateProClass(Model.Pro.Pro_Class model)
        {
            return this.dal.CreateProClass(model);
        }

        public int DeleteProClass(int ClassID)
        {
            return this.dal.DeleteProClass(ClassID);
        }
        public bool Exists(int ClassID)
        {
            return this.dal.Exists(ClassID);
        }
        public DataSet GetList(int PageSize, int PageIndex, string strWhere)
        {
            return this.dal.GetList(PageSize, PageIndex, strWhere);
        }
        public int GetMaxId()
        {
            return this.dal.GetMaxId();
        }
        public DataSet GetProClassList(string strWhere)
        {
            return this.dal.GetProClassList(strWhere);
        }
        public Model.Pro.Pro_Class GetProClassModel(int ClassID)
        {
            return this.dal.GetProClassModel(ClassID);
        }
        public void UpdateProClass(Model.Pro.Pro_Class model)
        {
            this.dal.UpdateProClass(model);
        }
    }


}
