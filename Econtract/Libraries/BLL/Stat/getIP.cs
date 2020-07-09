using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DALFactory;
using IDAL.Stat;

namespace BLL.Stat
{
    public class getIP
    {
         // Fields
        private readonly IgetIP dal;

        // Methods
        public getIP()
        {
            this.dal = DataAccess.CreategetIP();
        }
        public DataSet getIPList(long ipnow, ref string addj, ref string addf)
        {
            return this.dal.getIPList(ipnow, ref addj,ref addf);
        }
    }
}
