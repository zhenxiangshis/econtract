using BLL.Account;
using DBUtility;
using System;
using System.Data;
using System.Text;
using System.Web;

namespace qihang.admin.Account
{
    public partial class User_Edit : System.Web.UI.Page
    {
        public StringBuilder Target = new StringBuilder();
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
                if (Request.HttpMethod == "POST")
                {
                    try
                    {
                        Accounts_Users users = new Accounts_Users();
                        model = users.GetModel(int.Parse(s));
                        model.UserName = Request.Form["txtUserName"].Trim().ToString();
                        //model.Password = StringHelper.Tomd5(Request.Form["txtPassword"].Trim().ToString());
                        model.TrueName = Request.Form["txtTrueName"].Trim().ToString();
                        model.Sex = Request.Form["optSex"].Trim().ToString();
                        model.Phone = Request.Form["txtPhone"].Trim().ToString();
                        model.Email = Request.Form["txtEmail"].Trim().ToString();

                        model.RoleID = Convert.ToInt32(Request.Form["optRole"].Trim().ToString());

                        users.UpdateByAdmin(model);

                        DbHelperSQL.ExecuteSql("UPDATE [Accounts_UserRoles] SET [UserID] = " + s + ",[RoleID] = '" + model.RoleID + "' WHERE [UserID]=" + s);

                        setCookie("success", model.TrueName + "修改成功!");

                        base.Response.Redirect("User_Edit.aspx?id=" + s, false);

                    }
                    catch (Exception ex)
                    {
                        setCookie("error", ex.Message);
                    }
                }
                else
                {

                    Accounts_Users users = new Accounts_Users();
                    model = users.GetModel(int.Parse(s));
                    model.RoleID = Convert.ToInt32(DbHelperSQL.ExecuteSqlGet("SELECT b.RoleID FROM [Accounts_Users] a, [Accounts_UserRoles] b  where a.UserID = b.UserID and a.UserID=" + model.UserID, ""));
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
                Target.AppendFormat("<option value=\"{0}\" >{1}</option>", str, text);
            }
            return Target.ToString();
        }
    }
}