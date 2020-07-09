/**  
* scene.cs
*
* 功 能： N/A
* 类 名： scene
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2020/4/23 11:19:35   N/A    初版
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
	/// scene:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class scene
	{
		public scene()
		{}
		#region Model
		private int _id;
		private int _scenetype=0;
		private int _userid=0;
		private int _hitcount=0;
		private string _title;
		private string _description;
		private string _ip;
		private string _thumburl;
		private string _musicurl;
		private DateTime _addtime= DateTime.Now;
		private int _isdelete=0;
		private int _ispublish;
		private DateTime? _publishtime;
		private int _pagetype=0;
		private string _qcode;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 场景类型
		/// </summary>
		public int scenetype
		{
			set{ _scenetype=value;}
			get{return _scenetype;}
		}
		/// <summary>
		/// 用户编号
		/// </summary>
		public int userid
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 点击量
		/// </summary>
		public int hitcount
		{
			set{ _hitcount=value;}
			get{return _hitcount;}
		}
		/// <summary>
		/// 标题
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 描述
		/// </summary>
		public string description
		{
			set{ _description=value;}
			get{return _description;}
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
		/// 分享缩略图
		/// </summary>
		public string thumburl
		{
			set{ _thumburl=value;}
			get{return _thumburl;}
		}
		/// <summary>
		/// 背景音乐
		/// </summary>
		public string musicurl
		{
			set{ _musicurl=value;}
			get{return _musicurl;}
		}
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime addtime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 是否删除：0正常，-1删除
		/// </summary>
		public int isdelete
		{
			set{ _isdelete=value;}
			get{return _isdelete;}
		}
		/// <summary>
		/// 是否发布：0不发布，1发布
		/// </summary>
		public int ispublish
		{
			set{ _ispublish=value;}
			get{return _ispublish;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? publishtime
		{
			set{ _publishtime=value;}
			get{return _publishtime;}
		}
		/// <summary>
		/// 翻页类型
		/// </summary>
		public int pagetype
		{
			set{ _pagetype=value;}
			get{return _pagetype;}
		}
		/// <summary>
		/// 二维码路径
		/// </summary>
		public string qcode
		{
			set{ _qcode=value;}
			get{return _qcode;}
		}
		#endregion Model

	}
}

