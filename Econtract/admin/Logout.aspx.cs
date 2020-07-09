using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        this.Session.Clear();
        this.Session.Abandon();
        base.Response.Clear();
        base.Response.Redirect("Login.aspx", false);
    }
}