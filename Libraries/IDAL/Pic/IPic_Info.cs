using System;
using System.Collections.Generic;
using System.Text;
using Model.Pic;
using System.Data;
using System.Collections;

namespace IDAL.Pic
{
    public interface IPic_Info
    {
        // Methods
        int AddPicInfo(Pic_Info model);
        void DeletePicInfo(int PicID);
        void DeletePicInfo(string PicID);
        bool Exists(int PicID);
        int GetMaxId();
        ArrayList GetPicIDList(string strWhere);
        DataSet GetPicInfoList(int PageSize, int PageIndex, string OrderfldName, int OrderType, ref int IsReCount, string strWhere);
        Pic_Info GetPicInfoModel(int PicID);
        DataSet GetPicList(int strClassID, int strTop, string strOrder, string strWhere);
        DataSet GetPicPageList(string tableName, string tableId, string order, string where, int pageCurrent, int pageSize, ref int recordAmount, ref int pageAmount);
        int UpdatePicInfo(Pic_Info model);
        void UpPicInfo(string PicID, string Act, string YesNo);
        int VisitPicInfo(int PicID);
    }


}
