using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using DALFactory;
using IDAL.Pic;
using Model;
using Utility;
using System.IO;
using System.Configuration;
using System.Web;
namespace BLL.Pic
{
    public class Pic_Class
    {
        // Fields
        private readonly IPic_Class dal;

        // Methods
        public Pic_Class()
        {
            this.dal = DataAccess.CreatePic_Class();
        }

        public int CreatePicClass(Model.Pic.Pic_Class model)
        {
            return this.dal.CreatePicClass(model);
        }

        public int DeletePicClass(int ClassID)
        {
            return this.dal.DeletePicClass(ClassID);
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

        public DataSet GetPicClassList(string strWhere)
        {
            return this.dal.GetPicClassList(strWhere);
        }
        public Model.Pic.Pic_Class GetPicClassModel(int ClassID)
        {
            return this.dal.GetPicClassModel(ClassID);
        }

        public void UpdatePicClass(Model.Pic.Pic_Class model)
        {
            this.dal.UpdatePicClass(model);
        }

    }


}
