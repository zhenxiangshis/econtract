using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DALFactory;
using IDAL.Stat;

namespace BLL.Stat
{
    public class View
    {
         // Fields
        private readonly IView dal;

        // Methods
        public View()
        {
            this.dal = DataAccess.CreateView();
        }
        public DataSet GetViewList(string strTop, string strOrder, string strWhere)
        {
            return this.dal.GetViewList( strTop, strOrder, strWhere);
        }
    }
}
