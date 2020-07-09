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
    public class Job_Resume
    {
        // Fields
        private readonly IJob_Resume dal;

        // Methods
        public Job_Resume()
        {
            this.dal = DataAccess.CreateJob_Resume();
        }

        public int AddJobResume(Model.Job.Job_Resume model)
        {
            return this.dal.AddJobResume(model);
        }

        public void DeleteJobResume(int ResumeID)
        {
            this.dal.DeleteJobResume(ResumeID);
        }
        public void DeleteJobResume(string ResumeID)
        {
            this.dal.DeleteJobResume(ResumeID);
        }

        public DataSet GetJobResumeList(int PageSize, int PageIndex, string OrderfldName, int OrderType, ref int IsReCount, string strWhere)
        {
            return this.dal.GetJobResumeList(PageSize, PageIndex, OrderfldName, OrderType, ref IsReCount, strWhere);
        }
        public Model.Job.Job_Resume GetJobResumeModel(int ResumeID)
        {
            return this.dal.GetJobResumeModel(ResumeID);
        }
        public int UpdateJobResume(Model.Job.Job_Resume model)
        {
            return this.dal.UpdateJobResume(model);
        }

    }
}
