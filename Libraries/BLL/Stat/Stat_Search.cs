using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DALFactory;
using IDAL.Stat;

namespace BLL.Stat
{
    public class Stat_Search
    {
        // Fields
        private readonly IStat_Search dal;

        // Methods
        public Stat_Search()
        {
            this.dal = DataAccess.CreateStat_Search();
        }
        public DataSet GetStatSearchList(string SQLString)
        {
            return this.dal.GetStatSearchList(SQLString);
        }
    }
}
