using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Account;
using Utility;

namespace qihang.admin.Account
{
    public partial class User_EditPass : System.Web.UI.Page
    {
        protected void Page_Load(object sender,EventArgs e)
        {

            if(Session["UserId"] == null)
            {
                base.Response.Clear();
                JavaScriptHelper.Alert(@"您还没有登陆管理系统！\n请登录或与管理员联系！");
                JavaScriptHelper.JavaScriptLocationHref("/admin/Login.aspx");
                base.Response.End();
            }
            int UserId = int.Parse(this.Session["UserId"].ToString());

            Accounts_Users users = new Accounts_Users();

            if(Request.HttpMethod == "POST")
            {

                string oPassword = StringHelper.Tomd5(Request.Form["txtoPassword"].Trim().ToString());
                string nPassword = StringHelper.Tomd5(Request.Form["txtnPassword"].Trim().ToString());

                if(!users.UserLogin(this.Session["UserName"].ToString(),oPassword))
                {

                    setCookie("error","原密码输入错误！");

                }
                else
                {

                    Model.Account.Accounts_Users model2 = new Model.Account.Accounts_Users();
                    model2.UserID = int.Parse(this.Session["UserID"].ToString());
                    model2.Password = nPassword;
                    users.UpdatePassword(model2);

                    setCookie("success","用户密码更新成功！");
                }

            }

        }

        protected void setCookie(string e,string s)
        {
            s = Server.UrlEncode(s);
            string _err = "{0}\"err\":\"{2}\",\"msg\":\"{3}\" {1}";
            //获取客户端的Cookie对象
            HttpCookie cok = Request.Cookies["Exception"];

            if(cok != null)
            {
                //修改Cookie的两种方法
                cok.Value = string.Format(_err,"{","}",e,s);
                Response.AppendCookie(cok);
            }
            else
            {
                HttpCookie cookie = new HttpCookie("Exception");//初使化并设置Cookie的名称
                cookie.Value = string.Format(_err,"{","}",e,s);
                Response.AppendCookie(cookie);
            }
        }
    }
}