using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DALFactory;
using IDAL.Stat;

namespace BLL.Stat
{
    public class TempView
    {
        // Fields
        private readonly ITempView dal;

        // Methods
        public TempView()
        {
            this.dal = DataAccess.CreateTempView();
        }
        public DataSet GetTempViewList(string strTop, string strOrder, string strWhere)
        {
            return this.dal.GetTempViewList( strTop, strOrder, strWhere);
        }
        public DataSet GetTempViewInfoList(int PageSize, int PageIndex, string OrderfldName, int OrderType, ref int IsReCount, string strWhere)
        {
            return this.dal.GetTempViewInfoList(PageSize, PageIndex, OrderfldName, OrderType, ref IsReCount, strWhere);
        }
        public void AddTempView(Model.Stat.TempView model)
        {
            this.dal.AddTempView(model);
        }
    }
}
