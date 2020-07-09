using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DALFactory;
using IDAL.Stat;

namespace BLL.Stat
{
    public class Rpt_Daycount
    {
         // Fields
        private readonly IRpt_Daycount dal;

        // Methods
        public Rpt_Daycount()
        {
            this.dal = DataAccess.CreateRpt_Daycount();
        }
        public DataSet GetRpt_DaycountList(string strTop, string strOrder, string strWhere)
        {
            return this.dal.GetRpt_DaycountList(strTop, strOrder, strWhere);
        }
    }
}
