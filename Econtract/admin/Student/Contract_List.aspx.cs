using DBUtility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace qihang.admin.Student
{
    public partial class Contract_List : System.Web.UI.Page
    {
        public Model.Student_Info model = new Model.Student_Info();
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = base.Request.Params["id"];
            if ((s == null) || (s.Trim() == ""))
            {
                setCookie("warning", "参数错误!");
                base.Response.Redirect("Student_List.aspx", false);
            }
            else {
                model = new BLL.Student_Info().GetModel(int.Parse(s));
            }
            if (!this.Page.IsPostBack)
            {
                this.dataBind(s);
            }
        }
        private void dataBind(string s)
        {
            //Model.Student_Info student;
            //object url;
            //NewMethod(s, out student, out url, bll);
   
            BLL.Student_Contract bll = new BLL.Student_Contract();
            var list = bll.GetModelList(" studentid=" + s).OrderByDescending(m=>m.ContractID).Select(m => new
            {
                m.Addtime,
                m.ContractFile,
                m.ContractID,
                m.CreateTime,
                m.Type,
                LinkUrl=SetUrl(m.ContractID)
            });
            this.Repeater1.DataSource = list;// DbHelperSQL.Query("SELECT * FROM [Student_Contract] where studentid=" + s + " order by ContractID desc");
            this.Repeater1.DataBind();
        }

        private string SetUrl(int contractID)
        {
            BLL.Student_Contract bll = new BLL.Student_Contract();
            var contract = bll.GetModel(contractID);
            if (string.IsNullOrWhiteSpace(contract.Url))
            {
                var student = new BLL.Student_Info().GetModel(contract.StudentID);
                var shorturl = ShortUrlHelper.AddUrl("/weixin/contract.html?m=" + student.Phone + "&d=" + contract.Addtime.ToString("yyyyMMddHHmmss") + "&i=" + contract.ContractID);
                var url =  "/v.aspx?u=" + shorturl;
                contract.Url = url;
                var issuc=bll.Update(contract);
                
                return url;
            }
            else {
                return contract.Url;
            }
            
        }

        public string SetDownload(string ContractFile) {
            if (string.IsNullOrWhiteSpace(ContractFile))
                return "";
            else {
                return "<a href = \"" + ContractFile + "\" target = \"_blank\" class=\"btn mini green\"><i class=\"icon-download\"></i>下载</a>";
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

    }
}