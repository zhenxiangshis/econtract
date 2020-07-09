using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace IDAL.Stat
{
    public interface IRpt_Daycount
    {
        DataSet GetRpt_DaycountList(string strTop, string strOrder, string strWhere);
    }
}
