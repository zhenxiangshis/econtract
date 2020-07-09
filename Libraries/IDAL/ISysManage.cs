using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Model;
namespace IDAL
{
    public interface ISysManage
    {
        // Methods
        void AddLog(string time, string loginfo, string Particular);
        int AddTreeNode(SysNode node);
        void DeleteLog(int ID);
        void DeleteLog(string strWhere);
        void DelOverdueLog(int days);
        void DelTreeNode(int nodeid);
        DataRow GetLog(string ID);
        DataSet GetLogs(string strWhere);
        DataSet GetMenutreeList(int PageSize, int PageIndex, ref int IsReCount, string strWhere);
        SysNode GetNode(int NodeID);
        DataSet GetTreeList(string strWhere);
        void UpdateNode(SysNode node);

    }
}
