using System;
using System.Collections.Generic;
using System.Text;
using Model.Job;
using System.Collections;
using System.Data;

namespace IDAL.Job
{
    public interface IJob_Info
    {
        // Methods
        int AddJobInfo(Job_Info model);
        void DeleteJobInfo(int JobID);
        void DeleteJobInfo(string JobID);
        ArrayList GetJobIDList(string strWhere);
        DataSet GetJobInfoList(string strWhere);
        DataSet GetJobInfoList(int PageSize, int PageIndex, string OrderfldName, int OrderType, ref int IsReCount, string strWhere);
        Job_Info GetJobInfoModel(int JobID);
        int UpdateJobInfo(Job_Info model);
    }


}
