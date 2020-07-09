using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace qihang
{
    public partial class v : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = base.Request.Params["u"];
            if ((s == null) || (s.Trim() == ""))
            {
                base.Response.Redirect("http://www.qihang119.com", false);
            }
            else
            {
                var url = ShortUrlHelper.ParseUrl(s);
                //url
                base.Response.Redirect(url, false);
            }
        }
    }
}