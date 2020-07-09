using System;
using System.Collections.Generic;
using System.Text;
using IDAL.Job;
using DBUtility;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
namespace SQLServerDAL.Job
{
    public class Job_Info : IJob_Info
    {
        // Methods
        public Job_Info() { }
        public int AddJobInfo(Model.Job.Job_Info model)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@JobID", SqlDbType.Int, 4), new SqlParameter("@Positions", SqlDbType.VarChar, 50), new SqlParameter("@Obj", SqlDbType.VarChar, 15), new SqlParameter("@Number", SqlDbType.VarChar, 8), new SqlParameter("@Sex", SqlDbType.VarChar, 5), new SqlParameter("@Age", SqlDbType.VarChar, 20), new SqlParameter("@Edu", SqlDbType.VarChar, 20), new SqlParameter("@Specia", SqlDbType.VarChar, 50), new SqlParameter("@Langua", SqlDbType.VarChar, 50), new SqlParameter("@Experience", SqlDbType.VarChar, 12), new SqlParameter("@Pay", SqlDbType.VarChar, 50), new SqlParameter("@ValidTime", SqlDbType.VarChar, 50), new SqlParameter("@Remark", SqlDbType.VarChar, 0xbb8) };
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.Positions;
            parameters[2].Value = model.Obj;
            parameters[3].Value = model.Number;
            parameters[4].Value = model.Sex;
            parameters[5].Value = model.Age;
            parameters[6].Value = model.Edu;
            parameters[7].Value = model.Specia;
            parameters[8].Value = model.Langua;
            parameters[9].Value = model.Experience;
            parameters[10].Value = model.Pay;
            parameters[11].Value = model.ValidTime;
            parameters[12].Value = model.Remark;
            DbHelperSQL.RunProcedure("Job_AddJobInfo", parameters, out rowsAffected);
            return int.Parse(parameters[0].Value.ToString());
        }

        public void DeleteJobInfo(int JobID)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@JobID", SqlDbType.Int, 4) };
            parameters[0].Value = JobID;
            DbHelperSQL.RunProcedure("Job_DeleteJobInfo", parameters, out rowsAffected);
        }
        public void DeleteJobInfo(string JobID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Job_Info ");
            strSql.Append(" where JobID in (" + JobID + ")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
        public ArrayList GetJobIDList(string strWhere)
        {
            ArrayList list = new ArrayList();
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@strWhere", SqlDbType.VarChar, 0x3e8) };
            parameters[0].Value = strWhere;
            SqlDataReader reader = DbHelperSQL.RunProcedure("Job_GetJobIDList", parameters);
            while (reader.Read())
            {
                Model.Job.Job_Info model = new Model.Job.Job_Info();
                model.JobID = int.Parse(reader["JobID"].ToString());
                list.Add(model);
            }
            reader.Close();
            return list;
        }

        public DataSet GetJobInfoList(string strWhere)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@strWhere", SqlDbType.VarChar, 0x3e8) };
            parameters[0].Value = strWhere;
            return DbHelperSQL.RunProcedure("Job_GetJobInfoList", parameters, "ds");
        }

        public DataSet GetJobInfoList(int PageSize, int PageIndex, string OrderfldName, int OrderType, ref int IsReCount, string strWhere)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@tblName", SqlDbType.VarChar, 0xff), new SqlParameter("@fldName", SqlDbType.VarChar, 500), new SqlParameter("@OrderfldName", SqlDbType.VarChar, 0xff), new SqlParameter("@PageSize", SqlDbType.Int), new SqlParameter("@PageIndex", SqlDbType.Int), new SqlParameter("@IsReCount", SqlDbType.Int), new SqlParameter("@OrderType", SqlDbType.Int), new SqlParameter("@strWhere", SqlDbType.VarChar, 0x3e8) };
            parameters[0].Value = "Job_Info";
            parameters[1].Value = "[JobID],[Positions],[Obj],[Number],[Sex],[Age],[Edu],[Specia],[Langua],[Experience],[Pay],[ValidTime],[Remark],[AddTime]";
            parameters[2].Value = OrderfldName;
            parameters[3].Value = PageSize;
            parameters[4].Value = PageIndex;
            parameters[5].Direction = ParameterDirection.Output;
            parameters[6].Value = OrderType;
            parameters[7].Value = strWhere;
            DataSet redata = DbHelperSQL.RunProcedure("GetRecordByPage", parameters, "ds");
            IsReCount = int.Parse(parameters[5].Value.ToString());
            return redata;
        }
        public Model.Job.Job_Info GetJobInfoModel(int JobID)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@JobID", SqlDbType.Int, 4) };
            parameters[0].Value = JobID;
            Model.Job.Job_Info model = new Model.Job.Job_Info();
            DataSet ds = DbHelperSQL.RunProcedure("Job_GetJobInfoModel", parameters, "ds");
            model.JobID = JobID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Positions = ds.Tables[0].Rows[0]["Positions"].ToString();
                model.Obj = ds.Tables[0].Rows[0]["Obj"].ToString();
                model.Number = ds.Tables[0].Rows[0]["Number"].ToString();
                model.Sex = ds.Tables[0].Rows[0]["Sex"].ToString();
                model.Age = ds.Tables[0].Rows[0]["Age"].ToString();
                model.Edu = ds.Tables[0].Rows[0]["Edu"].ToString();
                model.Specia = ds.Tables[0].Rows[0]["Specia"].ToString();
                model.Langua = ds.Tables[0].Rows[0]["Langua"].ToString();
                model.Experience = ds.Tables[0].Rows[0]["Experience"].ToString();
                model.Pay = ds.Tables[0].Rows[0]["Pay"].ToString();
                model.ValidTime = ds.Tables[0].Rows[0]["ValidTime"].ToString();
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                if (ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
                return model;
            }
            return null;
        }

        public int UpdateJobInfo(Model.Job.Job_Info model)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@JobID", SqlDbType.Int, 4), new SqlParameter("@Positions", SqlDbType.VarChar, 50), new SqlParameter("@Obj", SqlDbType.VarChar, 15), new SqlParameter("@Number", SqlDbType.VarChar, 8), new SqlParameter("@Sex", SqlDbType.VarChar, 5), new SqlParameter("@Age", SqlDbType.VarChar, 20), new SqlParameter("@Edu", SqlDbType.VarChar, 20), new SqlParameter("@Specia", SqlDbType.VarChar, 50), new SqlParameter("@Langua", SqlDbType.VarChar, 50), new SqlParameter("@Experience", SqlDbType.VarChar, 12), new SqlParameter("@Pay", SqlDbType.VarChar, 50), new SqlParameter("@ValidTime", SqlDbType.VarChar, 50), new SqlParameter("@Remark", SqlDbType.VarChar, 0xbb8) };
            parameters[0].Value = model.JobID;
            parameters[1].Value = model.Positions;
            parameters[2].Value = model.Obj;
            parameters[3].Value = model.Number;
            parameters[4].Value = model.Sex;
            parameters[5].Value = model.Age;
            parameters[6].Value = model.Edu;
            parameters[7].Value = model.Specia;
            parameters[8].Value = model.Langua;
            parameters[9].Value = model.Experience;
            parameters[10].Value = model.Pay;
            parameters[11].Value = model.ValidTime;
            parameters[12].Value = model.Remark;
            DbHelperSQL.RunProcedure("Job_UpdateJobInfo", parameters, out rowsAffected);
            return rowsAffected;
        }

    }


}
