using System;
using System.Collections.Generic;
using System.Text;
using Model.Job;
using System.Data;
using System.Collections;

namespace IDAL.Job
{
    public interface IJob_Resume
    {
        // Methods
        int AddJobResume(Job_Resume model);
        void DeleteJobResume(int ResumeID);
        void DeleteJobResume(string ResumeID);
        DataSet GetJobResumeList(int PageSize, int PageIndex, string OrderfldName, int OrderType, ref int IsReCount, string strWhere);
        Job_Resume GetJobResumeModel(int ResumeID);
        int UpdateJobResume(Job_Resume model);
    }
}
