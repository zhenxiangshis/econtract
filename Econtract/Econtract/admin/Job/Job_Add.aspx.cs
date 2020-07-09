using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace qihang.admin.Job
{
    public partial class Job_Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "POST")
            {
                try
                {
                    BLL.dt_job bllJob = new BLL.dt_job();
                    Model.dt_job model = new Model.dt_job();
                    model.GroupName = Request.Form["txtGroupName"].Trim().ToString();
                    model.JobName = Request.Form["txtJobName"].Trim().ToString();
                    model.TriggerName = Request.Form["txtTriggerName"].Trim().ToString();
                    model.TriggerState = "None";
                    model.Cron = Request.Form["txtCron"].Trim().ToString();
                    model.Description = Request.Form["txtDes"].Trim().ToString();
                    model.requestUrl = Request.Form["txtUrl"].Trim().ToString();
                    model.CreateTime = DateTime.Now;
                    bllJob.Add(model);
                    setCookie("success", model.JobName + "添加成功!");

                    base.Response.Redirect("Job_list.aspx", false);


                }
                catch (Exception ex)
                {
                    setCookie("error", ex.Message);
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

    }
}