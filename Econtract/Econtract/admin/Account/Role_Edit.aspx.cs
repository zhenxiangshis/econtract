using BLL;
using BLL.Account;
using DBUtility;
using System;
using System.Data;
using System.Text;
using System.Web;

namespace qihang.admin.Account
{
    public partial class Role_Edit : System.Web.UI.Page
    {
        public RoleModel model = new RoleModel();

        public StringBuilder Target = new StringBuilder();

        private Accounts_Users Accbll = new Accounts_Users();

        protected void Page_Load(object sender, EventArgs e)
        {

            string s = base.Request.Params["id"];

            if ((s == null) || (s.Trim() == ""))
            {

                setCookie("warning", "参数错误!");
                base.Response.Redirect("Role_List.aspx", false);

            }
            else
            {
                if (Request.HttpMethod == "POST")
                {
                    try
                    {
                        string _name = Request.Form["txtName"].Trim().ToString();
                        //Response.Write(Request.Form["role"]);
                        string[] _role = Request.Form["role"].ToString().Split(',');

                        DbHelperSQL.ExecuteSql("DELETE FROM [Accounts_RolePermissions] where RoleID=" + s);

                        foreach (string m in _role)
                        {
                            Model.Account.Accounts_Users _model = new Model.Account.Accounts_Users();
                            _model.RoleID = Convert.ToInt32(s);
                            _model.PermissionID = Convert.ToInt32(m);
                            Accbll.AddPermissionToRole(_model);
                        }

                        setCookie("success", _name + "修改成功!");

                        base.Response.Redirect("Role_Edit.aspx?id=" + s, false);
                    }
                    catch (Exception ex)
                    {
                        setCookie("error", ex.Message);
                    }
                }
                else
                {
                    model.ID = s;
                    model.Name = Accbll.GetRoleDetails(Convert.ToInt32(s)).Description;
                    object obj = DbHelperSQL.ExecuteSqlGet("select STUFF((select ',' + Ltrim(str([PermissionID])) from [Accounts_RolePermissions] where RoleID=" + s + " for xml path('')),1,1,'') b", "");
                    model.Json = obj != null ? obj.ToString() : "";
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

        private void BindNode(int parentid, DataTable dt, string blank)
        {
            foreach (DataRow row in dt.Select("ParentID= " + parentid))
            {
                string str = row["NodeID"].ToString();
                string text = row["Text"].ToString();
                string icon = row["comment"].ToString();
                text = blank + text;
                Target.AppendFormat("<tr>{2}<td><input type=\"checkbox\" name=\"role\" value=\"{0}\"/></td><td>{0}</td><td><i class=\"{3}\"><i></td><td>{1}</td>{2}</tr>", str, text, System.Environment.NewLine, icon);
                int num = int.Parse(str);
                string str3 = blank + "&nbsp;&nbsp;&nbsp;&nbsp;";
                this.BindNode(num, dt, str3);
            }
        }

        public string BiudTree()
        {
            SysManage manage = new SysManage();
            DataTable dt = manage.GetTreeList("").Tables[0];
            foreach (DataRow row in dt.Select("ParentID= " + 0))
            {
                string str = row["NodeID"].ToString();
                string text = row["Text"].ToString();
                string icon = row["comment"].ToString();
                Target.AppendFormat("<tr>{2}<td><input type=\"checkbox\" name=\"role\" value=\"{0}\"/></td><td>{0}</td><td><i class=\"{3}\"><i></td><td>{1}</td>{2}</tr>", str, text, System.Environment.NewLine, icon);
                int parentid = int.Parse(str);
                string blank = "&nbsp;&nbsp;&nbsp;&nbsp;";
                this.BindNode(parentid, dt, blank);
            }
            return Target.ToString();
        }

        public class RoleModel
        {

            private string _id;
            private string _name;
            private string _json;

            public string ID
            {
                get
                {
                    return this._id;
                }
                set
                {
                    this._id = value;
                }
            }
            public string Name
            {
                get
                {
                    return this._name;
                }
                set
                {
                    this._name = value;
                }
            }
            public string Json
            {
                get
                {
                    return this._json;
                }
                set
                {
                    this._json = value;
                }
            }

        }
    }
}