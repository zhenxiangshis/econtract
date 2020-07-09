using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace SQLServerDAL
{
    public class SysManage : ISysManage
    {
        // Methods
        public SysManage() { }
        public void AddLog(string time, string loginfo, string Particular)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into S_Log(");
            strSql.Append("datetime,loginfo,Particular)");
            strSql.Append(" values (");
            strSql.Append("'" + time + "',");
            strSql.Append("'" + loginfo + "',");
            strSql.Append("'" + Particular + "'");
            strSql.Append(")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        public int AddTreeNode(Model.SysNode node)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@NodeID", SqlDbType.Int, 4), new SqlParameter("@Text", SqlDbType.VarChar, 100), new SqlParameter("@ParentID", SqlDbType.Int, 4), new SqlParameter("@Location", SqlDbType.VarChar, 50), new SqlParameter("@OrderID", SqlDbType.Int, 4), new SqlParameter("@comment", SqlDbType.VarChar, 50), new SqlParameter("@Url", SqlDbType.VarChar, 100), new SqlParameter("@PermissionID", SqlDbType.Int, 4), new SqlParameter("@ImageUrl", SqlDbType.VarChar, 100) };
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = node.Text;
            parameters[2].Value = node.ParentID;
            parameters[3].Value = node.Location;
            parameters[4].Value = node.OrderID;
            parameters[5].Value = node.Comment;
            parameters[6].Value = node.Url;
            parameters[7].Value = node.PermissionID;
            parameters[8].Value = node.ImageUrl;
            DbHelperSQL.RunProcedure("Accounts_AddMenuTree", parameters, out rowsAffected);
            return int.Parse(parameters[0].Value.ToString());
        }

        public void DeleteLog(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete S_Log ");
            strSql.Append(" where ID= " + ID);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        public void DeleteLog(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete S_Log ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        public void DelOverdueLog(int days)
        {
            string str = " DATEDIFF(day,[datetime],getdate())>" + days;
            this.DeleteLog(str);
        }

        public void DelTreeNode(int nodeid)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@nodeid", SqlDbType.Int, 4) };
            parameters[0].Value = nodeid;
            DbHelperSQL.RunProcedure("Accounts_DelTreeNode", parameters, out rowsAffected);
        }

        public DataRow GetLog(string ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from S_Log ");
            strSql.Append(" where ID= " + ID);
            return DbHelperSQL.Query(strSql.ToString()).Tables[0].Rows[0];
        }

        public DataSet GetLogs(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from S_Log ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID DESC");
            return DbHelperSQL.Query(strSql.ToString());
        }

        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("NodeID", "Menu_Tree");
        }

        public DataSet GetMenutreeList(int PageSize, int PageIndex, ref int IsReCount, string strWhere)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@tblName", SqlDbType.VarChar, 0xff), new SqlParameter("@fldName", SqlDbType.VarChar, 500), new SqlParameter("@OrderfldName", SqlDbType.VarChar, 0xff), new SqlParameter("@PageSize", SqlDbType.Int), new SqlParameter("@PageIndex", SqlDbType.Int), new SqlParameter("@IsReCount", SqlDbType.Int), new SqlParameter("@OrderType", SqlDbType.Int), new SqlParameter("@strWhere", SqlDbType.VarChar, 0x3e8) };
            parameters[0].Value = "Menu_Tree";
            parameters[1].Value = "[NodeID],[Text],[ParentID],[ParentPath],[Location],[OrderID],[comment],[Url],[PermissionID],[ImageUrl],[ModuleID],[KeShiDM],[KeshiPublic]";
            parameters[2].Value = "NodeID";
            parameters[3].Value = PageSize;
            parameters[4].Value = PageIndex;
            parameters[5].Direction = ParameterDirection.Output;
            parameters[6].Value = 1;
            parameters[7].Value = " Text like '%" + strWhere + "%'";
            DataSet redata = DbHelperSQL.RunProcedure("GetRecordByPage", parameters, "ds");
            IsReCount = Convert.ToInt32(parameters[5].Value.ToString());
            return redata;
        }

        public Model.SysNode GetNode(int NodeID)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@NodeID", SqlDbType.Int, 4) };
            parameters[0].Value = NodeID;
            Model.SysNode node = new Model.SysNode();
            DataSet ds = DbHelperSQL.RunProcedure("Accounts_GetMenuTreeModel", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                node.NodeID = int.Parse(ds.Tables[0].Rows[0]["NodeID"].ToString());
                node.Text = ds.Tables[0].Rows[0]["text"].ToString();
                if (ds.Tables[0].Rows[0]["ParentID"].ToString() != "")
                {
                    node.ParentID = int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
                }
                node.Location = ds.Tables[0].Rows[0]["Location"].ToString();
                if (ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    node.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                node.Comment = ds.Tables[0].Rows[0]["comment"].ToString();
                node.Url = ds.Tables[0].Rows[0]["url"].ToString();
                if (ds.Tables[0].Rows[0]["PermissionID"].ToString() != "")
                {
                    node.PermissionID = int.Parse(ds.Tables[0].Rows[0]["PermissionID"].ToString());
                }
                node.ImageUrl = ds.Tables[0].Rows[0]["ImageUrl"].ToString();
                return node;
            }
            return null;
        }

        public DataSet GetTreeList(string strWhere)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@strWhere", SqlDbType.VarChar, 50) };
            parameters[0].Value = strWhere;
            return DbHelperSQL.RunProcedure("Accounts_GetTreeList", parameters, "ds");
        }
        public void UpdateNode(Model.SysNode node)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@NodeID", SqlDbType.Int, 4), new SqlParameter("@Text", SqlDbType.VarChar, 100), new SqlParameter("@ParentID", SqlDbType.Int, 4), new SqlParameter("@Location", SqlDbType.VarChar, 50), new SqlParameter("@OrderID", SqlDbType.Int, 4), new SqlParameter("@comment", SqlDbType.VarChar, 50), new SqlParameter("@Url", SqlDbType.VarChar, 100), new SqlParameter("@PermissionID", SqlDbType.Int, 4), new SqlParameter("@ImageUrl", SqlDbType.VarChar, 100) };
            parameters[0].Value = node.NodeID;
            parameters[1].Value = node.Text;
            parameters[2].Value = node.ParentID;
            parameters[3].Value = node.Location;
            parameters[4].Value = node.OrderID;
            parameters[5].Value = node.Comment;
            parameters[6].Value = node.Url;
            parameters[7].Value = node.PermissionID;
            parameters[8].Value = node.ImageUrl;
            DbHelperSQL.RunProcedure("Accounts_UpdateMenuTree", parameters, out rowsAffected);
        }


    }
}
