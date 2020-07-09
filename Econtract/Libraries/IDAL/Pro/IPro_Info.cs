using System;
using System.Collections.Generic;
using System.Text;
using Model.Pro;
using System.Data;
using System.Collections;

namespace IDAL.Pro
{
    public interface IPro_Info
    {
        // Methods
        int AddProInfo(Pro_Info model);
        void DeleteProInfo(int ProID);
        void DeleteProInfo(string ProID);
        bool Exists(int ProID);
        int GetMaxId();
        ArrayList GetProIDList(string strWhere);
        DataSet GetProInfoList(int PageSize, int PageIndex, string OrderfldName, int OrderType, ref int IsReCount, string strWhere);
        Pro_Info GetProInfoModel(int ProID);
        DataSet GetProList(int strClassID, int strTop, string strOrder, string strWhere);
        int UpdateProInfo(Pro_Info model);
        void UpProInfo(string ProID, string Act, string YesNo);
        int VisitProInfo(int ProID);
    }

 

}
