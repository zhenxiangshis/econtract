using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DALFactory;
using IDAL.Stat;


namespace BLL.Stat
{
    public class Vjian
    {
        // Fields
        private readonly IVjian dal;

        // Methods
        public Vjian()
        {
            this.dal = DataAccess.CreateVjian();
        }
        public DataSet GetVjianList(string strTop, string strOrder, string strWhere)
        {
            return this.dal.GetVjianList( strTop, strOrder, strWhere);
        }
        public int UpdateVjian(Model.Stat.Vjian model)
        {
            return this.dal.UpdateVjian(model);
        }
    }
}
