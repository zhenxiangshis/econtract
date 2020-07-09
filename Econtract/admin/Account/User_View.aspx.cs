using BLL.Account;
using DBUtility;
using System;
using System.Web;


namespace qihang.admin.Account
{
    public partial class User_View : System.Web.UI.Page
    {
        public Model.Account.Accounts_Users model;

        protected void Page_Load(object sender, EventArgs e)
        {
            string s = base.Request.Params["id"];

            if ((s == null) || (s.Trim() == ""))
            {

                setCookie("warning", "参数错误!");
                base.Response.Redirect("User_List.aspx", false);

            }
            else
            {

                try
                {

                    Accounts_Users users = new Accounts_Users();

                    model = users.GetModel(int.Parse(s));

                    model.Description = DbHelperSQL.ExecuteSqlGet("SELECT c.Description FROM [Accounts_Users] a, [Accounts_UserRoles] b ,[Accounts_Roles] c where a.UserID = b.UserID and b.RoleID=c.RoleID and a.UserID=" + s, "").ToString();

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
    }
}