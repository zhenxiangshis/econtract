using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace IDAL.Stat
{
    
    public interface IStat_Search
    {
        DataSet GetStatSearchList(string SQLString);
    }
}
