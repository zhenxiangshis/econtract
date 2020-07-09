using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Account;
using DBUtility;
using Utility;

namespace qihang.admin.Account
{
    public partial class User_EditInfo : System.Web.UI.Page
    {
        public StringBuilder Target = new StringBuilder();
        public Model.Account.Accounts_Users model;
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
                try
                {
                    model = users.GetModel(UserId);
                    model.UserName = Request.Form["txtUserName"].Trim().ToString();
                    //model.Password = StringHelper.Tomd5(Request.Form["txtPassword"].Trim().ToString());
                    model.TrueName = Request.Form["txtTrueName"].Trim().ToString();
                    model.Sex = Request.Form["optSex"].Trim().ToString();
                    model.Phone = Request.Form["txtPhone"].Trim().ToString();
                    model.Email = Request.Form["txtEmail"].Trim().ToString();

                    model.RoleID = Convert.ToInt32(Request.Form["optRole"].Trim().ToString());

                    users.UpdateByAdmin(model);

                    DbHelperSQL.ExecuteSql("UPDATE [Accounts_UserRoles] SET [UserID] = " + UserId + ",[RoleID] = '" + model.RoleID + "' WHERE [UserID]=" + UserId);

                    setCookie("success","资料修改成功!");

                    //base.Response.Redirect("UserInfo.aspx", false);

                }
                catch(Exception ex)
                {
                    setCookie("error",ex.Message);
                }
            }

            model = users.GetModel(UserId);
            model.RoleID = Convert.ToInt32(DbHelperSQL.ExecuteSqlGet("SELECT b.RoleID FROM [Accounts_Users] a, [Accounts_UserRoles] b  where a.UserID = b.UserID and a.UserID=" + model.UserID,""));


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

        public string BindUser()
        {
            DataTable dt = DbHelperSQL.Query("SELECT * FROM Accounts_Roles").Tables[0];
            Target.AppendFormat("<option value=\"{0}\">{1}</option>","","");
            foreach(DataRow row in dt.Rows)
            {
                string str = row["RoleID"].ToString();
                string text = row["Description"].ToString();
                Target.AppendFormat("<option value=\"{0}\" >{1}</option>",str,text);
            }
            return Target.ToString();
        }
    }
}