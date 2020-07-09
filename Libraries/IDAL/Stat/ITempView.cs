using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace IDAL.Stat
{
    public interface ITempView
    {
        DataSet GetTempViewList(string strTop, string strOrder, string strWhere);
        DataSet GetTempViewInfoList(int PageSize, int PageIndex, string OrderfldName, int OrderType, ref int IsReCount, string strWhere);
        int AddTempView(Model.Stat.TempView model);
    }
}
