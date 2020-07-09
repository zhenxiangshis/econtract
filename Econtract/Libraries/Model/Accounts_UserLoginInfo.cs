/**  
* Accounts_UserLoginInfo.cs
*
* 功 能： N/A
* 类 名： Accounts_UserLoginInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2019/7/4 10:17:19   N/A    初版
*
* Copyright (c) 2012 bjzkty Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：北京中科腾宇科技发展有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Model
{
	/// <summary>
	/// Accounts_UserLoginInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Accounts_UserLoginInfo
	{
		public Accounts_UserLoginInfo()
		{}
		#region Model
		private int _loginid;
		private int _userid;
		private string _ip;
		private int _errortimes;
		private DateTime _errordate= DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public int LoginID
		{
			set{ _loginid=value;}
			get{return _loginid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IP
		{
			set{ _ip=value;}
			get{return _ip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ErrorTimes
		{
			set{ _errortimes=value;}
			get{return _errortimes;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime ErrorDate
		{
			set{ _errordate=value;}
			get{return _errordate;}
		}
		#endregion Model

	}
}

