using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace IDAL.Stat
{
    public interface IView
    {
        DataSet GetViewList(string strTop, string strOrder, string strWhere);
    }
}
