using System;
using System.Collections.Generic;
using System.Text;
using Model.Link;
using System.Data;

namespace IDAL.Link
{
    public interface ILink_Class
    {
        // Methods
        int CreateLinkClass(Link_Class model);
        int DeleteLinkClass(int ClassID);
        bool Exists(int ClassID);
        DataSet GetLinkClassList(string strWhere);
        Link_Class GetLinkClassModel(int ClassID);
        DataSet GetList(int PageSize, int PageIndex, string strWhere);
        int GetMaxId();
        void UpdateLinkClass(Link_Class model);
    }


}
