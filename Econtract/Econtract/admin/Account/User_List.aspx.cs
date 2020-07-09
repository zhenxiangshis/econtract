using DBUtility;
using System;

namespace qihang.admin.Account
{
    public partial class User_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.dataBind();
            }
        }

        private void dataBind()
        {
            this.Repeater1.DataSource = DbHelperSQL.Query("SELECT a.*,b.RoleID,c.Description FROM [Accounts_Users] a, [Accounts_UserRoles] b ,[Accounts_Roles] c where a.UserID = b.UserID and b.RoleID=c.RoleID");
            this.Repeater1.DataBind();
        }
    }
}