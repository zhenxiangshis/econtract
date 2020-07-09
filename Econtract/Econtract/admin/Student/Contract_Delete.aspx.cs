using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace qihang.admin.Student
{
    public partial class Contract_Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "GET")
            {
                try
                {
                    string s = base.Request.Params["id"];
                    BLL.Student_Contract bll = new BLL.Student_Contract();
                    if ((s == null) || (s.Trim() == ""))
                    {
                        setCookie("warning", "参数错误!");
                    }
                    else
                    {
                        bll.Delete(int.Parse(s));
                        setCookie("success", "删除成功!");
                    }

                }
                catch (Exception ex)
                {
                    setCookie("error", ex.Message);
                }
            }
           var url= HttpContext.Current.Request.UrlReferrer.ToString();
            base.Response.Redirect(url, false);
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