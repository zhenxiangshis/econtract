using DBUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace qihang.admin.Student
{
    public partial class Student_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack && (!this.Context.User.Identity.IsAuthenticated || this.Session["UserName"] == null && this.Session["UserId"] == null))
            {
                base.Response.Clear();
                JavaScriptHelper.Alert(@"您还没有登陆管理系统！\n请登录或与管理员联系！");
                JavaScriptHelper.JavaScriptLocationHref("/admin/Login.aspx");
                base.Response.End();
            }
            else
            {
                var uid = int.Parse(this.Session["UserId"].ToString());
                string strWhere = "";
                if (!this.Page.IsPostBack)
                {
                    BLL.Account.Accounts_Users blluser = new BLL.Account.Accounts_Users();
                    var model = blluser.GetModel(uid);
                    model.RoleID = Convert.ToInt32(DbHelperSQL.ExecuteSqlGet("SELECT b.RoleID FROM [Accounts_Users] a, [Accounts_UserRoles] b  where a.UserID = b.UserID and a.UserID=" + model.UserID, ""));
                    if (model.RoleID == 1)
                    {

                    }
                    else
                    {
                        strWhere = " where userid=" + uid;
                    }
                    this.dataBind(strWhere);
                }
            }
            
        }
        private void dataBind(string strWhere)
        {
            this.Repeater1.DataSource = DbHelperSQL.Query("SELECT * FROM [Student_Info] "+ strWhere + " order by StudentID desc");
            this.Repeater1.DataBind();
        }
    }
}