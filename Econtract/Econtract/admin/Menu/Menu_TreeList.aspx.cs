using BLL;
using System;
using System.Data;
using System.Text;

namespace qihang.admin.Menu
{
    public partial class Menu_TreeList : System.Web.UI.Page
    {
        public StringBuilder Target = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.dataBind();
            }

        }
        private void dataBind()
        {
            //this.Repeater1.DataSource = DbHelperSQL.Query("SELECT * FROM Menu_Tree");
            //this.Repeater1.DataBind();
        }

        private void BindNode(int parentid, DataTable dt, string blank)
        {
            foreach (DataRow row in dt.Select("ParentID= " + parentid))
            {
                string str = row["NodeID"].ToString();
                string text = row["Text"].ToString();
                text = blank + text;
                tableAdd(str, row["ParentID"].ToString(), row["OrderID"].ToString(), text, row["comment"].ToString(), row["Url"].ToString());
                int num = int.Parse(str);
                string str3 = blank + "&nbsp;&nbsp;&nbsp;&nbsp;";
                this.BindNode(num, dt, str3);
            }
        }

        public string BiudTree()
        {
            SysManage manage = new SysManage();
            DataTable dt = manage.GetTreeList("").Tables[0];
            foreach (DataRow row in dt.Select("ParentID= " + 0))
            {
                string str = row["NodeID"].ToString();
                tableAdd(str, row["ParentID"].ToString(), row["OrderID"].ToString(), row["Text"].ToString(), row["comment"].ToString(), row["Url"].ToString());
                int parentid = int.Parse(str);
                string blank = "&nbsp;&nbsp;&nbsp;&nbsp;";
                this.BindNode(parentid, dt, blank);
            }
            return Target.ToString();
        }

        private void tableAdd(string id, string pid, string oid, string text, string icon, string url)
        {

            Target.AppendFormat("<tr>{0}", System.Environment.NewLine);
            Target.AppendFormat("<td>{0}</td>{1}", id, System.Environment.NewLine);
            Target.AppendFormat("<td>{0}</td>{1}", pid, System.Environment.NewLine);
            Target.AppendFormat("<td>{0}</td>{1}", oid, System.Environment.NewLine);
            Target.AppendFormat("<td>{0}</td>{1}", text, System.Environment.NewLine);
            Target.AppendFormat("<td class=\"center\"><i class=\"{0}\"></i></td>{1}", icon, System.Environment.NewLine);
            Target.AppendFormat("<td>{0}</td>{1}", url, System.Environment.NewLine);
            Target.AppendFormat("<td class=\"center marginmini\">{0}", System.Environment.NewLine);
            Target.AppendFormat("<button onclick=\"DataTables.TableAction('{0}','v')\" class=\"btn mini blue\"><i class=\"icon-share\"></i> 详情</button>{1}", id, System.Environment.NewLine);
            Target.AppendFormat("<button onclick=\"DataTables.TableAction('{0}','e')\" class=\"btn mini purple\"><i class=\"icon-edit\"></i> 修改</button>{1}", id, System.Environment.NewLine);
            Target.AppendFormat("<button onclick=\"DataTables.TableAction('{0}','d')\" class=\"btn mini black\"><i class=\"icon-trash\"></i> 删除</button>{1}", id, System.Environment.NewLine);
            Target.AppendFormat("</td>{0}", System.Environment.NewLine);
            Target.AppendFormat("</tr>{0}", System.Environment.NewLine);
        }
    }
}