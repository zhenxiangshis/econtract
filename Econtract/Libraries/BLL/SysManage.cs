using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DALFactory;
using IDAL;
using Model;

namespace BLL
{
    public class SysManage
    {
        // Fields
        private static readonly ISysManage dal;

        // Methods
        static SysManage() 
        { 
            dal = DataAccess.CreateSysManage(); 
        }
        public SysManage() {
            
        }
        public void AddLog(string time, string loginfo, string Particular)
        {
            dal.AddLog(time, loginfo, Particular);
        }

        public int AddTreeNode(SysNode node)
        {
            return dal.AddTreeNode(node);
        }

        public void DeleteLog(string Idlist)
        {
            string str = "";
            if (Idlist.Trim() != "")
            {
                str = " ID in (" + Idlist + ")";
            }
            dal.DeleteLog(str);
        }
        public void DeleteLog(string timestart, string timeend)
        {
            string str = " datetime>'" + timestart + "' and datetime<'" + timeend + "'";
            dal.DeleteLog(str);
        }
        public void DelOverdueLog(int days)
        {
            dal.DelOverdueLog(days);
        }
        public void DelTreeNode(int nodeid)
        {
            dal.DelTreeNode(nodeid);
        }

        public DataRow GetLog(string ID)
        {
            return dal.GetLog(ID);
        }
        public DataSet GetLogs(string strWhere)
        {
            return dal.GetLogs(strWhere);
        }

        public DataSet GetMenutreeList(int PageSize, int PageIndex, ref int IsReCount, string strWhere)
        {
            return dal.GetMenutreeList(PageSize, PageIndex, ref IsReCount, strWhere);
        }

        public SysNode GetNode(int NodeID)
        {
            return dal.GetNode(NodeID);
        }

        public DataSet GetTreeList(string strWhere)
        {
            return dal.GetTreeList(strWhere);
        }

        public void UpdateNode(SysNode node)
        {
            dal.UpdateNode(node);
        }

    }


}
