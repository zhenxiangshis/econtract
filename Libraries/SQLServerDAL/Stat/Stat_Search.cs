using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using IDAL.Stat;
using DBUtility;

namespace SQLServerDAL.Stat
{
    public class Stat_Search : IStat_Search
    {
        public Stat_Search() { }

        public DataSet GetStatSearchList(string SQLString)
        {
            return DbHelperSQL.Query(SQLString);
        }
    }
}
