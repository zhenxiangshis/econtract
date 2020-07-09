using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using DALFactory;
using IDAL.Job;
using Model;
using Utility;
using System.IO;
using System.Configuration;
using System.Web;
namespace BLL.Job
{
    public class Job_Info
    {
        // Fields
        private readonly IJob_Info dal;

        // Methods
        public Job_Info()
        {
            this.dal = DataAccess.CreateJob_Info();
        }

        public int AddJobInfo(Model.Job.Job_Info model)
        {
            int result = this.dal.AddJobInfo(model);
            if (result > 0)
            {
                try
                {
                    this.CreateHtml(result);
                }
                catch
                {
                }
            }
            return result;
        }

        public void CreateHtml(int JobID)
        {
            try
            {
                Model.Job.Job_Info model = this.GetJobInfoModel(JobID);
                Temp.Temp_Info Tempbll = new Temp.Temp_Info();
                string sHtmlTemp = Tempbll.GetTempInfoModel(5).Content;
                string sJobID = model.JobID.ToString();
                string sPositions = model.Positions.ToString();
                string sObj = model.Obj.ToString();
                string sNumber = model.Number.ToString();
                string sSex = model.Sex.ToString();
                string sAge = model.Age.ToString();
                string sEdu = model.Edu.ToString();
                string sSpecia = model.Specia.ToString();
                string sLangua = model.Langua.ToString();
                string sExperience = model.Experience.ToString();
                string sPay = model.Pay.ToString();
                string sValidTime = model.ValidTime.ToString();
                string sRemark = HttpUtility.HtmlDecode(model.Remark.ToString()).ToString();
                string sAddTime = model.AddTime.ToString();
                sHtmlTemp = sHtmlTemp.Replace("$jobid$", sJobID).Replace("$positions$", sPositions).Replace("$obj$", sObj).Replace("$number$", sNumber).Replace("$sex$", sSex).Replace("$age$", sAge).Replace("$edu$", sEdu).Replace("$specia$", sSpecia).Replace("$langua$", sLangua).Replace("$experience$", sExperience).Replace("$pay$", sPay).Replace("$validtime$", sValidTime).Replace("$remark$", sRemark).Replace("$addtime$", sAddTime);
                string sNewPath = ConfigurationManager.AppSettings["JobPath"];
                sNewPath = string.Concat(new object[] { sNewPath, "/", StringHelper.DateToYear(model.AddTime.ToString()), "/", model.JobID, ".sHtml" });
                FileHelper.CreateFile(sNewPath);
                using (StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath(sNewPath).ToString(), false, Encoding.GetEncoding("GB2312")))
                {
                    sw.WriteLine(sHtmlTemp);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch
            {
            }
        }

        public void DeleteJobInfo(int JobID)
        {
            this.dal.DeleteJobInfo(JobID);
        }

        public void DeleteJobInfo(string JobID)
        {
            this.dal.DeleteJobInfo(JobID);
        }

        public ArrayList GetJobIDList(string strWhere)
        {
            return this.dal.GetJobIDList(strWhere);
        }

        public DataSet GetJobInfoList(string strWhere)
        {
            return this.dal.GetJobInfoList(strWhere);
        }
        public DataSet GetJobInfoList(int PageSize, int PageIndex, string OrderfldName, int OrderType, ref int IsReCount, string strWhere)
        {
            return this.dal.GetJobInfoList(PageSize, PageIndex, OrderfldName, OrderType, ref IsReCount, strWhere);
        }
        public Model.Job.Job_Info GetJobInfoModel(int JobID)
        {
            return this.dal.GetJobInfoModel(JobID);
        }

        public int UpdateJobInfo(Model.Job.Job_Info model)
        {
            int result = this.dal.UpdateJobInfo(model);
            if (result > 0)
            {
                try
                {
                    this.CreateHtml(model.JobID);
                }
                catch
                {
                }
            }
            return result;
        }

    }
}
