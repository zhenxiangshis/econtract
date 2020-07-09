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
*│　版权所有：XXXXXXXXXX　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Model
{
	/// <summary>
	/// dt_job:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class dt_job
	{
		public dt_job()
		{}
		#region Model
		private int _id;
		private string _groupname;
		private string _jobname;
		private string _triggername;
		private string _cron;
		private string _triggerstate;
		private DateTime? _starttime;
		private DateTime? _endtime;
		private DateTime? _pretime;
		private DateTime? _nexttime;
		private string _description;
		private string _requesturl;
		private DateTime? _createtime= DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string GroupName
		{
			set{ _groupname=value;}
			get{return _groupname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string JobName
		{
			set{ _jobname=value;}
			get{return _jobname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TriggerName
		{
			set{ _triggername=value;}
			get{return _triggername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Cron
		{
			set{ _cron=value;}
			get{return _cron;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TriggerState
		{
			set{ _triggerstate=value;}
			get{return _triggerstate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? StartTime
		{
			set{ _starttime=value;}
			get{return _starttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EndTime
		{
			set{ _endtime=value;}
			get{return _endtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? PreTime
		{
			set{ _pretime=value;}
			get{return _pretime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? NextTime
		{
			set{ _nexttime=value;}
			get{return _nexttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string requestUrl
		{
			set{ _requesturl=value;}
			get{return _requesturl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		#endregion Model

	}
}

