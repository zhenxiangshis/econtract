using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using DALFactory;
using IDAL.Link;
using Model;
using Utility;
using System.IO;
using System.Configuration;
using System.Web;
namespace BLL.Link
{
    public class Link_Class
    {
        // Fields
        private readonly ILink_Class dal;

        // Methods
        public Link_Class()
        {
            this.dal = DataAccess.CreateLink_Class();
        }
        public int CreateLinkClass(Model.Link.Link_Class model)
        {
            return this.dal.CreateLinkClass(model);
        }
        public int DeleteLinkClass(int ClassID)
        {
            return this.dal.DeleteLinkClass(ClassID);
        }
        public bool Exists(int ClassID)
        {
            return this.dal.Exists(ClassID);
        }

        public DataSet GetLinkClassList(string strWhere)
        {
            return this.dal.GetLinkClassList(strWhere);
        }
        public Model.Link.Link_Class GetLinkClassModel(int ClassID)
        {
            return this.dal.GetLinkClassModel(ClassID);
        }

        public DataSet GetList(int PageSize, int PageIndex, string strWhere)
        {
            return this.dal.GetList(PageSize, PageIndex, strWhere);
        }
        public int GetMaxId()
        {
            return this.dal.GetMaxId();
        }

        public void UpdateLinkClass(Model.Link.Link_Class model)
        {
            this.dal.UpdateLinkClass(model);
        }
    }


}
