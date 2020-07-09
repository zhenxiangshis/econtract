using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace IDAL.Stat
{
    public interface IgetIP
    {
        DataSet getIPList(long ipnow, ref string addj, ref string addf);
    }
}
