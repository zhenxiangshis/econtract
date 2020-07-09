using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace IDAL.Stat
{
    public interface IVjian
    {
        DataSet GetVjianList(string strTop, string strOrder, string strWhere);
        int UpdateVjian(Model.Stat.Vjian model);
    }
}
