using DBUtility;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Utility;

public partial class admin_MenuTree : System.Web.UI.UserControl
{

    public DataSet treeList;

    protected void Page_Load(object sender, EventArgs e)
    {
        int UserId = int.Parse(this.Session["UserId"] != null ? this.Session["UserId"].ToString() : "0");
        // treeList = new SysManage().GetTreeList("");
        SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@userID", SqlDbType.Int) };
        parameters[0].Value = UserId;
        treeList = DbHelperSQL.RunProcedure("Accounts_GetTreeListNew", parameters, "ds");
    }
    public DataRow[] getTreeDr(string pid) {
        return treeList.Tables[0].Select("ParentID =" + pid);
    }

    public string getTreeHtml(string pid) {
        DataRow[] _dr = getTreeDr(pid);
        if (_dr.Length > 0) {
            StringBuilder _sb = new StringBuilder();

            foreach (DataRow dr in _dr) {
                string _nodeID = dr["NodeID"].ToString();
                string _title = dr["Text"].ToString();
                string _url = dr["Url"].ToString();
                string _icon = dr["comment"].ToString();
                string _html = getTreeHtml(_nodeID);
                _sb.AppendFormat("<li>" + System.Environment.NewLine);
                // 有子集
                if (_html != "0") {
                    _sb.AppendFormat("  <a href=\"javascript:;\" menuid=\"{0}\" pmenuid=\"{1}\">" + System.Environment.NewLine, _nodeID, pid);
                    _sb.AppendFormat("      <i class=\"{0}\"></i>" + System.Environment.NewLine, _icon);
                    _sb.AppendFormat("      <span class=\"title\">{0}</span>" + System.Environment.NewLine, _title);
                    _sb.AppendFormat("      <span class=\"arrow \"></span>" + System.Environment.NewLine);
                    _sb.AppendFormat("  </a>" + System.Environment.NewLine);
                    _sb.AppendFormat("  <ul class=\"sub-menu\">" + System.Environment.NewLine);
                    _sb.Append(_html);
                    _sb.AppendFormat("  </ul>" + System.Environment.NewLine);
                } else {
                    _sb.AppendFormat("  <a href=\"{0}\" menuid=\"{1}\" pmenuid=\"{2}\">" + System.Environment.NewLine, _url, _nodeID, pid);
                    _sb.AppendFormat("      <i class=\"{0}\"></i>" + System.Environment.NewLine, _icon);
                    _sb.AppendFormat("      <span class=\"title\">{0}</span>" + System.Environment.NewLine, _title);
                    _sb.AppendFormat("  </a>" + System.Environment.NewLine);
                }
                _sb.AppendFormat("</li>" + System.Environment.NewLine);
            }
            return _sb.ToString();
        } else {
            return "0";
        }
    }
}