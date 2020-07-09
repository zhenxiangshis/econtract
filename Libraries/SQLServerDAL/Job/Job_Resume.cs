using System;
using System.Collections.Generic;
using System.Text;
using IDAL.Job;
using DBUtility;
using System.Data;
using System.Data.SqlClient;

namespace SQLServerDAL.Job
{
    public class Job_Resume : IJob_Resume
    {
        // Methods
        public Job_Resume() { }
        public int AddJobResume(Model.Job.Job_Resume model)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { 
        new SqlParameter("@ResumeID", SqlDbType.Int, 4), new SqlParameter("@JobID", SqlDbType.Int, 4), new SqlParameter("@Positions", SqlDbType.VarChar, 50), new SqlParameter("@TrueName", SqlDbType.VarChar, 8), new SqlParameter("@Sex", SqlDbType.VarChar, 5), new SqlParameter("@Birth", SqlDbType.DateTime), new SqlParameter("@Card", SqlDbType.VarChar, 20), new SqlParameter("@Nation", SqlDbType.VarChar, 20), new SqlParameter("@Visage", SqlDbType.VarChar, 8), new SqlParameter("@Native", SqlDbType.VarChar, 50), new SqlParameter("@Marry", SqlDbType.VarChar, 5), new SqlParameter("@Tall", SqlDbType.VarChar, 8), new SqlParameter("@Edu", SqlDbType.VarChar, 20), new SqlParameter("@JobName", SqlDbType.VarChar, 50), new SqlParameter("@JobGrade", SqlDbType.VarChar, 20), new SqlParameter("@ProName", SqlDbType.VarChar, 50), 
        new SqlParameter("@ProGrade", SqlDbType.VarChar, 20), new SqlParameter("@School", SqlDbType.VarChar, 50), new SqlParameter("@Specia", SqlDbType.VarChar, 50), new SqlParameter("@Langua1", SqlDbType.VarChar, 20), new SqlParameter("@Langua1Leve", SqlDbType.VarChar, 10), new SqlParameter("@Langua2", SqlDbType.VarChar, 20), new SqlParameter("@Langua2Leve", SqlDbType.VarChar, 10), new SqlParameter("@Mandarin", SqlDbType.VarChar, 10), new SqlParameter("@Guangd", SqlDbType.VarChar, 10), new SqlParameter("@Computer", SqlDbType.VarChar, 10), new SqlParameter("@TelePhone", SqlDbType.VarChar, 0x19), new SqlParameter("@Mobile", SqlDbType.VarChar, 15), new SqlParameter("@Email", SqlDbType.VarChar, 50), new SqlParameter("@Address", SqlDbType.VarChar, 50), new SqlParameter("@Post", SqlDbType.VarChar, 10), new SqlParameter("@RMB", SqlDbType.VarChar, 15), 
        new SqlParameter("@ComTime", SqlDbType.DateTime), new SqlParameter("@JobGo", SqlDbType.VarChar, 500), new SqlParameter("@Skill", SqlDbType.VarChar, 0x7d0), new SqlParameter("@Opinion", SqlDbType.VarChar, 0x7d0), new SqlParameter("@Experience", SqlDbType.NText)
     };
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Value = model.JobID;
            parameters[2].Value = model.Positions;
            parameters[3].Value = model.TrueName;
            parameters[4].Value = model.Sex;
            parameters[5].Value = model.Birth;
            parameters[6].Value = model.Card;
            parameters[7].Value = model.Nation;
            parameters[8].Value = model.Visage;
            parameters[9].Value = model.Native;
            parameters[10].Value = model.Marry;
            parameters[11].Value = model.Tall;
            parameters[12].Value = model.Edu;
            parameters[13].Value = model.JobName;
            parameters[14].Value = model.JobGrade;
            parameters[15].Value = model.ProName;
            parameters[0x10].Value = model.ProGrade;
            parameters[0x11].Value = model.School;
            parameters[0x12].Value = model.Specia;
            parameters[0x13].Value = model.Langua1;
            parameters[20].Value = model.Langua1Leve;
            parameters[0x15].Value = model.Langua2;
            parameters[0x16].Value = model.Langua2Leve;
            parameters[0x17].Value = model.Mandarin;
            parameters[0x18].Value = model.Guangd;
            parameters[0x19].Value = model.Computer;
            parameters[0x1a].Value = model.TelePhone;
            parameters[0x1b].Value = model.Mobile;
            parameters[0x1c].Value = model.Email;
            parameters[0x1d].Value = model.Address;
            parameters[30].Value = model.Post;
            parameters[0x1f].Value = model.RMB;
            parameters[0x20].Value = model.ComTime;
            parameters[0x21].Value = model.JobGo;
            parameters[0x22].Value = model.Skill;
            parameters[0x23].Value = model.Opinion;
            parameters[0x24].Value = model.Experience;
            DbHelperSQL.RunProcedure("Job_AddJobResume", parameters, out rowsAffected);
            return int.Parse(parameters[0].Value.ToString());
        }

        public void DeleteJobResume(int ResumeID)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@ResumeID", SqlDbType.Int, 4) };
            parameters[0].Value = ResumeID;
            DbHelperSQL.RunProcedure("Job_DeleteJobResume", parameters, out rowsAffected);
        }

        public void DeleteJobResume(string ResumeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Job_Resume ");
            strSql.Append(" where ResumeID in (" + ResumeID + ")");
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        public DataSet GetJobResumeList(int PageSize, int PageIndex, string OrderfldName, int OrderType, ref int IsReCount, string strWhere)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@tblName", SqlDbType.VarChar, 0xff), new SqlParameter("@fldName", SqlDbType.VarChar, 500), new SqlParameter("@OrderfldName", SqlDbType.VarChar, 0xff), new SqlParameter("@PageSize", SqlDbType.Int), new SqlParameter("@PageIndex", SqlDbType.Int), new SqlParameter("@IsReCount", SqlDbType.Int), new SqlParameter("@OrderType", SqlDbType.Int), new SqlParameter("@strWhere", SqlDbType.VarChar, 0x3e8) };
            parameters[0].Value = "Job_Resume";
            parameters[1].Value = "[ResumeID],[JobID],[Positions],[TrueName],[Sex],[Birth],[Card],[Nation],[Visage],[Native],[Marry],[Tall],[Edu],[JobName],[JobGrade],[ProName],[ProGrade],[School],[Specia],[Langua1],[Langua1Leve],[Langua2],[Langua2Leve],[Mandarin],[Guangd],[Computer],[TelePhone],[Mobile],[Email],[Address],[Post],[RMB],[ComTime],[JobGo],[Skill],[Opinion],[Experience]";
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

        public Model.Job.Job_Resume GetJobResumeModel(int ResumeID)
        {
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@ResumeID", SqlDbType.Int, 4) };
            parameters[0].Value = ResumeID;
            Model.Job.Job_Resume model = new Model.Job.Job_Resume();
            DataSet ds = DbHelperSQL.RunProcedure("Job_GetJobResumeModel", parameters, "ds");
            model.ResumeID = ResumeID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["JobID"].ToString() != "")
                {
                    model.JobID = int.Parse(ds.Tables[0].Rows[0]["JobID"].ToString());
                }
                model.Positions = ds.Tables[0].Rows[0]["Positions"].ToString();
                model.TrueName = ds.Tables[0].Rows[0]["TrueName"].ToString();
                model.Sex = ds.Tables[0].Rows[0]["Sex"].ToString();
                if (ds.Tables[0].Rows[0]["Birth"].ToString() != "")
                {
                    model.Birth = DateTime.Parse(ds.Tables[0].Rows[0]["Birth"].ToString());
                }
                model.Card = ds.Tables[0].Rows[0]["Card"].ToString();
                model.Nation = ds.Tables[0].Rows[0]["Nation"].ToString();
                model.Visage = ds.Tables[0].Rows[0]["Visage"].ToString();
                model.Native = ds.Tables[0].Rows[0]["Native"].ToString();
                model.Marry = ds.Tables[0].Rows[0]["Marry"].ToString();
                model.Tall = ds.Tables[0].Rows[0]["Tall"].ToString();
                model.Edu = ds.Tables[0].Rows[0]["Edu"].ToString();
                model.JobName = ds.Tables[0].Rows[0]["JobName"].ToString();
                model.JobGrade = ds.Tables[0].Rows[0]["JobGrade"].ToString();
                model.ProName = ds.Tables[0].Rows[0]["ProName"].ToString();
                model.ProGrade = ds.Tables[0].Rows[0]["ProGrade"].ToString();
                model.School = ds.Tables[0].Rows[0]["School"].ToString();
                model.Specia = ds.Tables[0].Rows[0]["Specia"].ToString();
                model.Langua1 = ds.Tables[0].Rows[0]["Langua1"].ToString();
                model.Langua1Leve = ds.Tables[0].Rows[0]["Langua1Leve"].ToString();
                model.Langua2 = ds.Tables[0].Rows[0]["Langua2"].ToString();
                model.Langua2Leve = ds.Tables[0].Rows[0]["Langua2Leve"].ToString();
                model.Mandarin = ds.Tables[0].Rows[0]["Mandarin"].ToString();
                model.Guangd = ds.Tables[0].Rows[0]["Guangd"].ToString();
                model.Computer = ds.Tables[0].Rows[0]["Computer"].ToString();
                model.TelePhone = ds.Tables[0].Rows[0]["TelePhone"].ToString();
                model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                model.Post = ds.Tables[0].Rows[0]["Post"].ToString();
                model.RMB = ds.Tables[0].Rows[0]["RMB"].ToString();
                if (ds.Tables[0].Rows[0]["ComTime"].ToString() != "")
                {
                    model.ComTime = DateTime.Parse(ds.Tables[0].Rows[0]["ComTime"].ToString());
                }
                model.JobGo = ds.Tables[0].Rows[0]["JobGo"].ToString();
                model.Skill = ds.Tables[0].Rows[0]["Skill"].ToString();
                model.Opinion = ds.Tables[0].Rows[0]["Opinion"].ToString();
                model.Experience = ds.Tables[0].Rows[0]["Experience"].ToString();
                return model;
            }
            return null;
        }

        public int UpdateJobResume(Model.Job.Job_Resume model)
        {
            int rowsAffected;
            SqlParameter[] parameters = new SqlParameter[] { 
        new SqlParameter("@ResumeID", SqlDbType.Int, 4), new SqlParameter("@JobID", SqlDbType.Int, 4), new SqlParameter("@Positions", SqlDbType.VarChar, 50), new SqlParameter("@TrueName", SqlDbType.VarChar, 8), new SqlParameter("@Sex", SqlDbType.VarChar, 5), new SqlParameter("@Birth", SqlDbType.DateTime), new SqlParameter("@Card", SqlDbType.VarChar, 20), new SqlParameter("@Nation", SqlDbType.VarChar, 20), new SqlParameter("@Visage", SqlDbType.VarChar, 8), new SqlParameter("@Native", SqlDbType.VarChar, 50), new SqlParameter("@Marry", SqlDbType.VarChar, 5), new SqlParameter("@Tall", SqlDbType.VarChar, 8), new SqlParameter("@Edu", SqlDbType.VarChar, 20), new SqlParameter("@JobName", SqlDbType.VarChar, 50), new SqlParameter("@JobGrade", SqlDbType.VarChar, 20), new SqlParameter("@ProName", SqlDbType.VarChar, 50), 
        new SqlParameter("@ProGrade", SqlDbType.VarChar, 20), new SqlParameter("@School", SqlDbType.VarChar, 50), new SqlParameter("@Specia", SqlDbType.VarChar, 50), new SqlParameter("@Langua1", SqlDbType.VarChar, 20), new SqlParameter("@Langua1Leve", SqlDbType.VarChar, 10), new SqlParameter("@Langua2", SqlDbType.VarChar, 20), new SqlParameter("@Langua2Leve", SqlDbType.VarChar, 10), new SqlParameter("@Mandarin", SqlDbType.VarChar, 10), new SqlParameter("@Guangd", SqlDbType.VarChar, 10), new SqlParameter("@Computer", SqlDbType.VarChar, 10), new SqlParameter("@TelePhone", SqlDbType.VarChar, 0x19), new SqlParameter("@Mobile", SqlDbType.VarChar, 15), new SqlParameter("@Email", SqlDbType.VarChar, 50), new SqlParameter("@Address", SqlDbType.VarChar, 50), new SqlParameter("@Post", SqlDbType.VarChar, 10), new SqlParameter("@RMB", SqlDbType.VarChar, 15), 
        new SqlParameter("@ComTime", SqlDbType.DateTime), new SqlParameter("@JobGo", SqlDbType.VarChar, 500), new SqlParameter("@Skill", SqlDbType.VarChar, 0x7d0), new SqlParameter("@Opinion", SqlDbType.VarChar, 0x7d0), new SqlParameter("@Experience", SqlDbType.NText)
     };
            parameters[0].Value = model.ResumeID;
            parameters[1].Value = model.JobID;
            parameters[2].Value = model.Positions;
            parameters[3].Value = model.TrueName;
            parameters[4].Value = model.Sex;
            parameters[5].Value = model.Birth;
            parameters[6].Value = model.Card;
            parameters[7].Value = model.Nation;
            parameters[8].Value = model.Visage;
            parameters[9].Value = model.Native;
            parameters[10].Value = model.Marry;
            parameters[11].Value = model.Tall;
            parameters[12].Value = model.Edu;
            parameters[13].Value = model.JobName;
            parameters[14].Value = model.JobGrade;
            parameters[15].Value = model.ProName;
            parameters[0x10].Value = model.ProGrade;
            parameters[0x11].Value = model.School;
            parameters[0x12].Value = model.Specia;
            parameters[0x13].Value = model.Langua1;
            parameters[20].Value = model.Langua1Leve;
            parameters[0x15].Value = model.Langua2;
            parameters[0x16].Value = model.Langua2Leve;
            parameters[0x17].Value = model.Mandarin;
            parameters[0x18].Value = model.Guangd;
            parameters[0x19].Value = model.Computer;
            parameters[0x1a].Value = model.TelePhone;
            parameters[0x1b].Value = model.Mobile;
            parameters[0x1c].Value = model.Email;
            parameters[0x1d].Value = model.Address;
            parameters[30].Value = model.Post;
            parameters[0x1f].Value = model.RMB;
            parameters[0x20].Value = model.ComTime;
            parameters[0x21].Value = model.JobGo;
            parameters[0x22].Value = model.Skill;
            parameters[0x23].Value = model.Opinion;
            parameters[0x24].Value = model.Experience;
            DbHelperSQL.RunProcedure("Job_UpdateJobResume", parameters, out rowsAffected);
            return rowsAffected;
        }

    }


}
