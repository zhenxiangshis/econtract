using BLL;
using Model;
using System;
using System.Web;

namespace qihang.admin.Menu
{
    public partial class Menu_TreeView : System.Web.UI.Page
    {
        public viewodel model = new viewodel();
        protected void Page_Load(object sender, EventArgs e)
        {

            string s = base.Request.Params["id"];
            if ((s == null) || (s.Trim() == ""))
            {
                setCookie("warning", "参数错误!");
                base.Response.Redirect("Menu_TreeList.aspx", false);
            }
            else
            {
                try
                {

                    SysManage manage = new SysManage();
                    SysNode node = manage.GetNode(int.Parse(s));

                    model.id = node.NodeID.ToString();
                    model.text = node.Text;

                    if (node.ParentID == 0)
                    {
                        model.pname = "根目录";
                    }
                    else
                    {
                        model.pname = manage.GetNode(node.ParentID).Text;
                    }
                    model.url = node.Url;
                    model.icon = node.Comment;
                }
                catch (Exception ex)
                {
                    setCookie("error", ex.Message);
                }
            }
        }

        public class viewodel
        {

            public string _id;
            public string _text;
            public string _pname;
            public string _order;
            public string _icon;
            public string _url;

            public string id { get { return _id; } set { _id = value; } }
            public string text { get { return _text; } set { _text = value; } }
            public string pname { get { return _pname; } set { _pname = value; } }
            public string order { get { return _order; } set { _order = value; } }
            public string icon { get { return _icon; } set { _icon = value; } }
            public string url { get { return _url; } set { _url = value; } }
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
    }
}