/**  
* scene_upfile.cs
*
* 功 能： N/A
* 类 名： scene_upfile
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2020/4/23 11:19:38   N/A    初版
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
	/// scene_upfile:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class scene_upfile
	{
		public scene_upfile()
		{}
		#region Model
		private int _id;
		private int _userid=0;
		private int _filetype=0;
		private string _fileurl;
		private DateTime _addtime= DateTime.Now;
		private decimal? _sizekb;
		private string _filethumburl;
		private string _extension;
		private string _filename;
		private int _isdelete=0;
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
		public int userid
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int filetype
		{
			set{ _filetype=value;}
			get{return _filetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fileurl
		{
			set{ _fileurl=value;}
			get{return _fileurl;}
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
		public decimal? sizekb
		{
			set{ _sizekb=value;}
			get{return _sizekb;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string filethumburl
		{
			set{ _filethumburl=value;}
			get{return _filethumburl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string extension
		{
			set{ _extension=value;}
			get{return _extension;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string filename
		{
			set{ _filename=value;}
			get{return _filename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int isdelete
		{
			set{ _isdelete=value;}
			get{return _isdelete;}
		}
		#endregion Model

	}
}

