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
    public class Pic_Comm
    {
        // Fields
        private readonly IPic_Comm dal;

        // Methods
        public Pic_Comm()
        {
            this.dal = DataAccess.CreatePic_Comm();
        }

        public int AddPicComm(Model.Pic.Pic_Comm model)
        {
            int result = this.dal.AddPicComm(model);
            if (result >= 1)
            {
                try
                {
                    new Pic_Info().CreateHtml(model.PicID);
                }
                catch
                {
                }
            }
            return result;
        }

        public void DeletePicComm(int CommID)
        {
            this.dal.DeletePicComm(CommID);
        }

        public void DeletePicComm(string CommID)
        {
            this.dal.DeletePicComm(CommID);
        }
        public DataSet GetPicCommList(int PicID)
        {
            return this.dal.GetPicCommList(PicID);
        }
        public DataSet GetPicCommList(int PageSize, int PageIndex, string OrderfldName, int OrderType, ref int IsReCount, string strWhere)
        {
            return this.dal.GetPicCommList(PageSize, PageIndex, OrderfldName, OrderType, ref IsReCount, strWhere);
        }

        public Model.Pic.Pic_Comm GetPicCommModel(int CommID)
        {
            return this.dal.GetPicCommModel(CommID);
        }
        public void UpdatePicComm(Model.Pic.Pic_Comm model)
        {
            this.dal.UpdatePicComm(model);
        }

    }


}
