/**  
* Topic_Info.cs
*
* 功 能： N/A
* 类 名： Topic_Info
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018-05-30 14:43:04   N/A    初版
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
	/// Topic_Info:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Topic_Info
	{
		public Topic_Info()
		{}
		#region Model
		private int _topicid;
		private string _title;
		private string _keyword;
		private string _description;
		private int _classid=0;
		private string _url;
		private string _backcolor;
		private string _pccontent;
		private string _wapcontent;
		private DateTime _addtime= DateTime.Now;
		private int _visitcount=0;
		/// <summary>
		/// 
		/// </summary>
		public int TopicID
		{
			set{ _topicid=value;}
			get{return _topicid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Keyword
		{
			set{ _keyword=value;}
			get{return _keyword;}
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
		public int ClassID
		{
			set{ _classid=value;}
			get{return _classid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Url
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BackColor
		{
			set{ _backcolor=value;}
			get{return _backcolor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PCContent
		{
			set{ _pccontent=value;}
			get{return _pccontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WapContent
		{
			set{ _wapcontent=value;}
			get{return _wapcontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int VisitCount
		{
			set{ _visitcount=value;}
			get{return _visitcount;}
		}
		#endregion Model

	}
}

