using BLL;
using BLL.Account;
using DBUtility;
using System;
using System.Data;
using System.Text;
using System.Web;
using Utility;


namespace qihang.admin.Account
{
    public partial class User_Add : System.Web.UI.Page
    {
        public StringBuilder Target = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "POST")
            {

                try
                {

                    Accounts_Users users = new Accounts_Users();
                    if (users.Exists(Request.Form["txtUserName"].Trim().ToString()))
                    {
                        setCookie("error", "该用户名已存在");
                    }
                    else
                    {
                        Model.Account.Accounts_Users model = new Model.Account.Accounts_Users();
                        model.UserName = Request.Form["txtUserName"].Trim().ToString();
                        model.Password = StringHelper.Tomd5(Request.Form["txtPassword"].Trim().ToString());
                        model.TrueName = Request.Form["txtTrueName"].Trim().ToString();
                        model.Sex = Request.Form["optSex"].Trim().ToString();
                        model.Phone = Request.Form["txtPhone"].Trim().ToString();
                        model.Email = Request.Form["txtEmail"].Trim().ToString();
                        model.EmployeeID = 0;
                        model.Activity = true;
                        model.UserType = "AA";
                        model.Style = 1;
                        model.RoleID = Convert.ToInt32(Request.Form["listTarget"].Trim().ToString());

                        model.UserID = users.CreateUser(model);

                        users.AddUserToRole(model);

                        setCookie("success", model.UserName + "添加成功!");

                        base.Response.Redirect("User_Add.aspx", false);
                    }

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

        public string BindUser()
        {

            DataTable dt = DbHelperSQL.Query("SELECT * FROM Accounts_Roles").Tables[0];
            Target.AppendFormat("<option value=\"{0}\">{1}</option>", "", "");
            foreach (DataRow row in dt.Rows)
            {
                string str = row["RoleID"].ToString();
                string text = row["Description"].ToString();
                Target.AppendFormat("<option value=\"{0}\">{1}</option>", str, text);
            }
            return Target.ToString();
        }
    }
}