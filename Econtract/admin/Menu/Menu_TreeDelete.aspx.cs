using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace qihang.admin.Menu
{
    public partial class Menu_TreeDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "GET")
            {
                try
                {
                    string s = base.Request.Params["id"];
                    if ((s == null) || (s.Trim() == ""))
                    {
                        setCookie("warning", "参数错误!");
                    }
                    else
                    {
                        SysManage manage = new SysManage();
                        manage.DelTreeNode(int.Parse(s));
                        setCookie("success", "删除成功!");
                    }
                }
                catch (Exception ex)
                {
                    setCookie("error", ex.Message);
                }
            }
            base.Response.Redirect("Menu_TreeList.aspx", false);
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