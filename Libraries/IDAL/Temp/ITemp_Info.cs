using System;
using System.Collections.Generic;
using System.Text;
using Model.Temp;
using System.Data;

namespace IDAL.Temp
{
    public interface ITemp_Info
    {
        // Methods
        int AddTempInfo(Temp_Info model);
        void DeleteTempInfo(int TempID);
        bool Exists(int TempID);
        int GetMaxId();
        DataSet GetTempInfoList(string strWhere);
        DataSet GetTempInfoList(int PageSize, int PageIndex, ref int IsReCount, string strWhere);
        Temp_Info GetTempInfoModel(int TempID);
        void UpdateTempInfo(Temp_Info model);
    }
}
