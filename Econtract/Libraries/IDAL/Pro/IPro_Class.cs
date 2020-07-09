using System;
using System.Collections.Generic;
using System.Text;
using Model.Pro;
using System.Data;

namespace IDAL.Pro
{
    public interface IPro_Class
    {
        // Methods
        int CreateProClass(Pro_Class model);
        int DeleteProClass(int ClassID);
        bool Exists(int ClassID);
        DataSet GetList(int PageSize, int PageIndex, string strWhere);
        int GetMaxId();
        DataSet GetProClassList(string strWhere);
        Pro_Class GetProClassModel(int ClassID);
        void UpdateProClass(Pro_Class model);
    }


}
