/**  
* scene_page.cs
*
* 功 能： N/A
* 类 名： scene_page
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2020/4/23 11:19:37   N/A    初版
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
	/// scene_page:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class scene_page
	{
		public scene_page()
		{}
		#region Model
		private int _id;
		private int _sceneid=0;
		private int _pagecurrentnum=1;
		private DateTime _addtime= DateTime.Now;
		private string _content;
		private string _properties;
		private string _title;
		private int _userid=0;
		private string _ip;
		private string _thumburl;
		private int _isdelete=0;
		private int _ismodel=0;
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
		public int sceneid
		{
			set{ _sceneid=value;}
			get{return _sceneid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int pagecurrentnum
		{
			set{ _pagecurrentnum=value;}
			get{return _pagecurrentnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime addtime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string properties
		{
			set{ _properties=value;}
			get{return _properties;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int userid
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ip
		{
			set{ _ip=value;}
			get{return _ip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string thumburl
		{
			set{ _thumburl=value;}
			get{return _thumburl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int isdelete
		{
			set{ _isdelete=value;}
			get{return _isdelete;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ismodel
		{
			set{ _ismodel=value;}
			get{return _ismodel;}
		}
		#endregion Model

	}
}

