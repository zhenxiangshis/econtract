using System;
using System.Collections.Generic;
using System.Text;
using Model.Pic;
using System.Data;

namespace IDAL.Pic
{
    public interface IPic_Comm
    {
        // Methods
        int AddPicComm(Pic_Comm model);
        void DeletePicComm(int CommID);
        void DeletePicComm(string CommID);
        DataSet GetPicCommList(int PicID);
        DataSet GetPicCommList(int PageSize, int PageIndex, string OrderfldName, int OrderType, ref int IsReCount, string strWhere);
        Pic_Comm GetPicCommModel(int CommID);
        void UpdatePicComm(Pic_Comm model);
    }


}
