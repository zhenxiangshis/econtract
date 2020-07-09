/**  
* dt_job.cs
*
* 功 能： N/A
* 类 名： dt_job
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2020/6/24 13:43:46   N/A    初版
*
* Copyright (c) 2012 bjzkty Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：北京中科腾宇科技发展有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using IDAL;
using DBUtility;//Please add references
namespace SQLServerDAL
{
	/// <summary>
	/// 数据访问类:dt_job
	/// </summary>
	public partial class dt_job:Idt_job
	{
		public dt_job()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "dt_job"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from dt_job");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.dt_job model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into dt_job(");
			strSql.Append("GroupName,JobName,TriggerName,Cron,TriggerState,StartTime,EndTime,PreTime,NextTime,Description,requestUrl,CreateTime)");
			strSql.Append(" values (");
			strSql.Append("@GroupName,@JobName,@TriggerName,@Cron,@TriggerState,@StartTime,@EndTime,@PreTime,@NextTime,@Description,@requestUrl,@CreateTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@GroupName", SqlDbType.NVarChar,50),
					new SqlParameter("@JobName", SqlDbType.NVarChar,50),
					new SqlParameter("@TriggerName", SqlDbType.NVarChar,50),
					new SqlParameter("@Cron", SqlDbType.VarChar,50),
					new SqlParameter("@TriggerState", SqlDbType.VarChar,50),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@PreTime", SqlDbType.DateTime),
					new SqlParameter("@NextTime", SqlDbType.DateTime),
					new SqlParameter("@Description", SqlDbType.NVarChar,200),
					new SqlParameter("@requestUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@CreateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.GroupName;
			parameters[1].Value = model.JobName;
			parameters[2].Value = model.TriggerName;
			parameters[3].Value = model.Cron;
			parameters[4].Value = model.TriggerState;
			parameters[5].Value = model.StartTime;
			parameters[6].Value = model.EndTime;
			parameters[7].Value = model.PreTime;
			parameters[8].Value = model.NextTime;
			parameters[9].Value = model.Description;
			parameters[10].Value = model.requestUrl;
			parameters[11].Value = model.CreateTime;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.dt_job model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update dt_job set ");
			strSql.Append("GroupName=@GroupName,");
			strSql.Append("JobName=@JobName,");
			strSql.Append("TriggerName=@TriggerName,");
			strSql.Append("Cron=@Cron,");
			strSql.Append("TriggerState=@TriggerState,");
			strSql.Append("StartTime=@StartTime,");
			strSql.Append("EndTime=@EndTime,");
			strSql.Append("PreTime=@PreTime,");
			strSql.Append("NextTime=@NextTime,");
			strSql.Append("Description=@Description,");
			strSql.Append("requestUrl=@requestUrl,");
			strSql.Append("CreateTime=@CreateTime");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@GroupName", SqlDbType.NVarChar,50),
					new SqlParameter("@JobName", SqlDbType.NVarChar,50),
					new SqlParameter("@TriggerName", SqlDbType.NVarChar,50),
					new SqlParameter("@Cron", SqlDbType.VarChar,50),
					new SqlParameter("@TriggerState", SqlDbType.VarChar,50),
					new SqlParameter("@StartTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@PreTime", SqlDbType.DateTime),
					new SqlParameter("@NextTime", SqlDbType.DateTime),
					new SqlParameter("@Description", SqlDbType.NVarChar,200),
					new SqlParameter("@requestUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.GroupName;
			parameters[1].Value = model.JobName;
			parameters[2].Value = model.TriggerName;
			parameters[3].Value = model.Cron;
			parameters[4].Value = model.TriggerState;
			parameters[5].Value = model.StartTime;
			parameters[6].Value = model.EndTime;
			parameters[7].Value = model.PreTime;
			parameters[8].Value = model.NextTime;
			parameters[9].Value = model.Description;
			parameters[10].Value = model.requestUrl;
			parameters[11].Value = model.CreateTime;
			parameters[12].Value = model.id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from dt_job ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from dt_job ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.dt_job GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,GroupName,JobName,TriggerName,Cron,TriggerState,StartTime,EndTime,PreTime,NextTime,Description,requestUrl,CreateTime from dt_job ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Model.dt_job model=new Model.dt_job();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.dt_job DataRowToModel(DataRow row)
		{
			Model.dt_job model=new Model.dt_job();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["GroupName"]!=null)
				{
					model.GroupName=row["GroupName"].ToString();
				}
				if(row["JobName"]!=null)
				{
					model.JobName=row["JobName"].ToString();
				}
				if(row["TriggerName"]!=null)
				{
					model.TriggerName=row["TriggerName"].ToString();
				}
				if(row["Cron"]!=null)
				{
					model.Cron=row["Cron"].ToString();
				}
				if(row["TriggerState"]!=null)
				{
					model.TriggerState=row["TriggerState"].ToString();
				}
				if(row["StartTime"]!=null && row["StartTime"].ToString()!="")
				{
					model.StartTime=DateTime.Parse(row["StartTime"].ToString());
				}
				if(row["EndTime"]!=null && row["EndTime"].ToString()!="")
				{
					model.EndTime=DateTime.Parse(row["EndTime"].ToString());
				}
				if(row["PreTime"]!=null && row["PreTime"].ToString()!="")
				{
					model.PreTime=DateTime.Parse(row["PreTime"].ToString());
				}
				if(row["NextTime"]!=null && row["NextTime"].ToString()!="")
				{
					model.NextTime=DateTime.Parse(row["NextTime"].ToString());
				}
				if(row["Description"]!=null)
				{
					model.Description=row["Description"].ToString();
				}
				if(row["requestUrl"]!=null)
				{
					model.requestUrl=row["requestUrl"].ToString();
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,GroupName,JobName,TriggerName,Cron,TriggerState,StartTime,EndTime,PreTime,NextTime,Description,requestUrl,CreateTime ");
			strSql.Append(" FROM dt_job ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" id,GroupName,JobName,TriggerName,Cron,TriggerState,StartTime,EndTime,PreTime,NextTime,Description,requestUrl,CreateTime ");
			strSql.Append(" FROM dt_job ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM dt_job ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from dt_job T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "dt_job";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

