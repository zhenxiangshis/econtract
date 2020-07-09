using BLL.Account;
using DBUtility;
using System;
using System.Web;

namespace qihang.admin.Account
{
    public partial class Role_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {

                if (Request.HttpMethod == "POST")
                {
                    try
                    {
                        string s = base.Request.Params["action"];
                        if (s.Trim() == "add")
                        {
                            string _name = Request.Form["txtName"].Trim().ToString();
                            Accounts_Users Accbll = new Accounts_Users();
                            Model.Account.Accounts_Users model = new Model.Account.Accounts_Users();
                            model.Description = _name;
                            try
                            {
                                Accbll.CreateRole(model);
                            }
                            catch
                            {
                            }
                            setCookie("success", _name + "添加成功!");
                        }
                    }
                    catch (Exception ex)
                    {
                        setCookie("error", ex.Message);
                    }
                }

                this.dataBind();
            }
        }

        private void dataBind()
        {
            this.Repeater1.DataSource = DbHelperSQL.Query("SELECT * FROM Accounts_Roles");
            this.Repeater1.DataBind();
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