using BLL;
using System;
using System.Data;
using System.Text;
using System.Web;

namespace qihang.admin.Menu
{
    public partial class Menu_TreeAdd : System.Web.UI.Page
    {
        public StringBuilder Target = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "POST")
            {

                try
                {

                    string _name = Request.Form["txtName"].Trim().ToString();
                    int _pid = int.Parse(Request.Form["listTarget"].Trim().ToString());
                    int _order = int.Parse(Request.Form["txtId"].Trim().ToString());
                    string _url = Request.Form["txtUrl"].Trim().ToString();
                    string _icon = Request.Form["hicon"].ToString();

                    Model.SysNode node = new Model.SysNode();
                    node.Text = _name;
                    node.ParentID = _pid;
                    node.OrderID = _order;
                    node.Comment = _icon;
                    node.Url = _url;

                    new SysManage().AddTreeNode(node);

                    setCookie("success", _name + "添加成功!");

                    base.Response.Redirect("Menu_TreeAdd.aspx", false);


                }
                catch (Exception ex)
                {
                    setCookie("error", ex.Message);
                }

            }
        }

        protected void setCookie(string e, string s)
        {
            s = Server.UrlEncode(s);
            string _err = "{0}\"err\":\"{2}\",\"msg\":\"{3}\" {1}";
            //获取客户端的Cookie对象
            HttpCookie cok = Request.Cookies["Exception"];

            if (cok != null)
            {
                //修改Cookie的两种方法
                cok.Value = string.Format(_err, "{", "}", e, s);
                Response.AppendCookie(cok);
            }
            else
            {
                HttpCookie cookie = new HttpCookie("Exception");//初使化并设置Cookie的名称
                cookie.Value = string.Format(_err, "{", "}", e, s);
                Response.AppendCookie(cookie);
            }
        }

        private void BindNode(int parentid, DataTable dt, string blank)
        {
            foreach (DataRow row in dt.Select("ParentID= " + parentid))
            {
                string str = row["NodeID"].ToString();
                string text = row["Text"].ToString();
                text = blank + text;
                Target.AppendFormat("<option value=\"{0}\">{1}</option>", str, text);
                int num = int.Parse(str);
                string str3 = blank + "&nbsp;&nbsp;&nbsp;&nbsp;";
                this.BindNode(num, dt, str3);
            }
        }

        public string BiudTree()
        {
            SysManage manage = new SysManage();
            DataTable dt = manage.GetTreeList("").Tables[0];
            Target.AppendFormat("<option value=\"{0}\">{1}</option>", "0", "根目录");
            foreach (DataRow row in dt.Select("ParentID= " + 0))
            {
                string str = row["NodeID"].ToString();
                string text = row["Text"].ToString();
                Target.AppendFormat("<option value=\"{0}\">{1}</option>", str, text);
                int parentid = int.Parse(str);
                string blank = "&nbsp;&nbsp;&nbsp;&nbsp;";
                this.BindNode(parentid, dt, blank);
            }
            return Target.ToString();
        }
    }
}