using DBUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility.Job;

namespace qihang.admin.Job
{
    public partial class Job_List : System.Web.UI.Page
    {
        BLL.dt_job bllJob = new BLL.dt_job();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!this.Page.IsPostBack)
            {
                if (Request.QueryString["a"] != null)
                {
                    var id = int.Parse(base.Request.Params["id"]);
                    string act = base.Request.Params["a"];
                    switch (act)
                    {
                        case "Run":
                            Run(id);
                            break;
                        case "Stop":
                            Stop(id);
                            break;
                        case "Pause":
                            Pause(id);
                            break;
                        case "Resume":
                            Resume(id);
                            break;
                        default:
                            break;
                    }
                }
                this.dataBind();
            }
        }
        private void dataBind()
        {
            this.Repeater1.DataSource = DbHelperSQL.Query("SELECT * FROM dt_job");
            this.Repeater1.DataBind();
        }
        public string SetState(string State)
        {
            var _State = "";
            switch (State)
            {
                case "None":
                    _State = "<label class=\"label-info\">未启动</label>";
                    break;
                case "Normal":
                    _State = "<label class=\"label-success\">运行中</label>";
                    break;
                case "Paused":
                    _State = "<label class=\"label-info\">暂停</label>";
                    break;
                default:
                    break;
            }
            return _State;
        }
        public string SetAction(string State, int id)
        {
            var _State = "";
            switch (State)
            {
                case "None":
                    _State = "<a href=\"Job_List.aspx?a=Run&id=" + id + "\"  class=\"btn btn-outline-success btn-sm\"><i class=\"fa fa-play\"></i>运行</a>";
                    break;
                case "Normal":
                    _State = "<a href=\"Job_List.aspx?a=Pause&id=" + id + "\"  class=\"btn btn-outline-warning btn-sm\"><i class=\"fa fa-pause\"></i>暂停</a><a href=\"Job_List.aspx?a=Stop&id=" + id + "\"  class=\"btn btn-outline-secondary  btn-sm\"><i class=\"fa fa-stop\"></i>停止</a>";
                    break;
                case "Paused":
                    _State = "<a href=\"Job_List.aspx?a=Resume&id=" + id + "\"  class=\"btn btn-outline-danger btn-sm\"><i class=\"fa fa-play\"></i>继续</a>";
                    break;
                default:
                    break;
            }
            return _State;
        }

        public void Run(int id)
        {
            try
            {
                var entity = bllJob.GetModel(id);
                entity.TriggerState = Quartz.TriggerState.Normal.ToString();
                bllJob.Update(entity);
                JobAsyncHelper.Run(entity);
                setCookie("success", entity.JobName + "操作成功!");
                base.Response.Redirect("Job_list.aspx", false);
            }
            catch (Exception ex)
            {
                setCookie("error", ex.Message);
            }

        }

        public void Pause(int id)
        {
            try
            {
                var entity = bllJob.GetModel(id);
                entity.TriggerState = Quartz.TriggerState.Paused.ToString();
                bllJob.Update(entity);
                JobAsyncHelper.Pause(entity);
                setCookie("success", entity.JobName + "操作成功!");
                base.Response.Redirect("Job_list.aspx", false);
            }
            catch (Exception ex)
            {
                setCookie("error", ex.Message);
            }


        }
        public void Stop(int id)
        {
            try
            {
                var entity = bllJob.GetModel(id);
                entity.TriggerState = Quartz.TriggerState.None.ToString();
                bllJob.Update(entity);
                JobAsyncHelper.Deltete(entity);
                setCookie("success", entity.JobName + "操作成功!");
                base.Response.Redirect("Job_list.aspx", false);
            }
            catch (Exception ex)
            {
                setCookie("error", ex.Message);
            }

        }
        public void Resume(int id)
        {
            try
            {
                var entity = bllJob.GetModel(id);
                entity.TriggerState = Quartz.TriggerState.Normal.ToString();
                bllJob.Update(entity);
                JobAsyncHelper.Resume(entity);
                setCookie("success", entity.JobName + "操作成功!");
                base.Response.Redirect("Job_list.aspx", false);
            }
            catch (Exception ex)
            {
                setCookie("error", ex.Message);
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