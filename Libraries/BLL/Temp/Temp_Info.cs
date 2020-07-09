using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using DALFactory;
using IDAL.Temp;
using Model;
using Utility;
using System.IO;
using System.Configuration;
using System.Web;

namespace BLL.Temp
{
    public class Temp_Info
    {
        // Fields
        private readonly ITemp_Info dal;

        // Methods
        public Temp_Info()
        {
            this.dal = DataAccess.CreateTemp_Info();
        }
        public int AddTempInfo(Model.Temp.Temp_Info model)
        {
            return this.dal.AddTempInfo(model);
        }

        public void DeleteTempInfo(int TempID)
        {
            this.dal.DeleteTempInfo(TempID);
        }
        public bool Exists(int TempID)
        {
            return this.dal.Exists(TempID);
        }
        public int GetMaxId()
        {
            return this.dal.GetMaxId();
        }
        public DataSet GetTempInfoList(string strWhere)
        {
            return this.dal.GetTempInfoList(strWhere);
        }
        public DataSet GetTempInfoList(int PageSize, int PageIndex, ref int IsReCount, string strWhere)
        {
            return this.dal.GetTempInfoList(PageSize, PageIndex, ref IsReCount, strWhere);
        }
        public Model.Temp.Temp_Info GetTempInfoModel(int TempID)
        {
            return this.dal.GetTempInfoModel(TempID);
        }
        public void UpdateTempInfo(Model.Temp.Temp_Info model)
        {
            this.dal.UpdateTempInfo(model);
        }
    }


}
