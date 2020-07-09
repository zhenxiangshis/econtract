using System;
using System.Collections.Generic;
using System.Text;
using Model.Link;
using System.Data;
using System.Collections;

namespace IDAL.Link
{
    public interface ILink_Info
    {
        // Methods
        int AddLinkInfo(Link_Info model);
        void DeleteLinkInfo(int LinkID);
        void DeleteLinkInfo(string LinkID);
        bool Exists(int PicID);
        ArrayList GetLinkIDList(string strWhere);
        DataSet GetLinkInfoList(int PageSize, int PageIndex, string OrderfldName, int OrderType, ref int IsReCount, string strWhere);
        Link_Info GetLinkInfoModel(int LinkID);
        DataSet GetLinkList(int strClassID, int strTop, string strOrder, string strWhere);
        int GetMaxId();
        int UpdateLinkInfo(Link_Info model);
        void UpLinkInfo(string LinkID, string Act, string YesNo);
        int VisitLinkInfo(int LinkID);
    }


}
