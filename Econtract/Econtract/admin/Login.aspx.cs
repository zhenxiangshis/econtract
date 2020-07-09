using BLL.Account;
using System;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using Utility;

public partial class sys_Login : Page, IRequiresSessionState
{

    public string _err = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.HttpMethod == "POST")
        {
            string userName = NoHTML(Request.Form["txtUsername"].Trim().ToString());
            string password = StringHelper.Tomd5(NoHTML(Request.Form["txtPass"].Trim().ToString()));
            Accounts_Users users = new Accounts_Users();
            if (!users.UserLogin(userName, password))
            {
                this._err = "登陆失败： " + userName;
            }
            else if (!users.Exists(userName))
            {
                this._err = "不存在这个用户！";
            }
            else
            {
                FormsAuthentication.SetAuthCookie(userName, false);
                Model.Account.Accounts_Users model = users.GetModel(userName);
                this.Session["UserId"] = model.UserID;
                this.Session["UserName"] = model.UserName;
                if (this.Session["returnPage"] != null)
                {
                    string url = this.Session["returnPage"].ToString();
                    this.Session["returnPage"] = null;
                    base.Response.Redirect(url);
                }
                else
                {
                    base.Response.Redirect("main.aspx");
                }
            }
        }
    }
    /// <summary>
    /// 过滤标记
    /// </summary>
    /// <param name="NoHTML">包括HTML，脚本，数据库关键字，特殊字符的源码 </param>
    /// <returns>已经去除标记后的文字</returns>
    public string NoHTML(string Htmlstring)
    {
        if (Htmlstring == null)
        {
            return "-";
        }
        else
        {
            //删除脚本
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([rn])[s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(d+);", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "xp_cmdshell", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, " ", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "/r", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "/n", "", RegexOptions.IgnoreCase);

            //特殊的字符
            Htmlstring = Htmlstring.Replace("<", "");
            Htmlstring = Htmlstring.Replace(">", "");
            Htmlstring = Htmlstring.Replace("*", "");
            Htmlstring = Htmlstring.Replace("-", "");
            Htmlstring = Htmlstring.Replace("?", "");
            Htmlstring = Htmlstring.Replace(",", "");
            Htmlstring = Htmlstring.Replace("/", "");
            Htmlstring = Htmlstring.Replace(";", "");
            Htmlstring = Htmlstring.Replace("*/", "");
            Htmlstring = Htmlstring.Replace("rn", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            return Htmlstring;
        }
    }
}
