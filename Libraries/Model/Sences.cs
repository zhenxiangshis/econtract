/**  版本信息模板在安装目录下，可自行修改。
* Sences.cs
*
* 功 能： N/A
* 类 名： Sences
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/1/7 10:34:08   N/A    初版
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
	/// Sences:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Sences
	{
		public Sences()
		{}
		#region Model
		private int _sencesid;
		private string _name;
		private string _picurl;
		private string _linkurl;
        private string _description;
		private string _qrcode;
		private int _isactivity=0;
		private int _sort=0;
		private int _status=0;
		private DateTime? _addtime= DateTime.Now;
		/// <summary>
		/// 
		/// </summary>
		public int SencesID
		{
			set{ _sencesid=value;}
			get{return _sencesid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PicUrl
		{
			set{ _picurl=value;}
			get{return _picurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LinkUrl
		{
			set{ _linkurl=value;}
			get{return _linkurl;}
		}
		/// <summary>
		/// 
		/// </summary>
        public string Description
		{
			set{ _description=value;}
            get { return _description; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string QRCode
		{
			set{ _qrcode=value;}
			get{return _qrcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int IsActivity
		{
			set{ _isactivity=value;}
			get{return _isactivity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Sort
		{
			set{ _sort=value;}
			get{return _sort;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model

	}
}

