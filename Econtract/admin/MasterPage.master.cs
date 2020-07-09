using System;
using System.Data;
using System.Text;
using Utility;

public partial class admin_MasterPage : System.Web.UI.MasterPage {

    public string userName = "";
    public int UserId = 0;    

    protected void Page_Load(object sender, EventArgs e) {
        if (!this.Page.IsPostBack && (!this.Context.User.Identity.IsAuthenticated || this.Session["UserName"] == null && this.Session["UserId"]==null)) {
            base.Response.Clear();
            JavaScriptHelper.Alert(@"您还没有登陆管理系统！\n请登录或与管理员联系！");
            JavaScriptHelper.JavaScriptLocationHref("/admin/Login.aspx");
            base.Response.End();
        } else {
            UserId = int.Parse(this.Session["UserId"].ToString());
            userName = this.Session["UserName"].ToString();
        }
    }
   
}
