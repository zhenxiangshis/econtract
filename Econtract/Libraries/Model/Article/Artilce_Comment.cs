/**  版本信息模板在安装目录下，可自行修改。
* Artilce_Comment.cs
*
* 功 能： N/A
* 类 名： Artilce_Comment
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2019/10/19 18:55:43   N/A    初版
*
* Copyright (c) 2019 bjzktyCorporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：北京中科腾宇科技发展有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Model.Article
{
	/// <summary>
	/// Artilce_Comment:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Artilce_Comment
	{
		public Artilce_Comment()
		{}
		#region Model
		private int _id;
		private int _articleid=0;
		private int _parentid=0;
		private string _openid= "0";
		private string _username="";
		private string _userip;
		private string _content;
		private int _islock=0;
		private DateTime _addtime= DateTime.Now;
		private int _support=0;
		private int _nosupport=0;
		/// <summary>
		/// 自增ID
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 主表ID
		/// </summary>
		public int ArticleID
		{
			set{ _articleid=value;}
			get{return _articleid;}
		}
		/// <summary>
		/// 父评论ID
		/// </summary>
		public int ParentID
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 用户ID
		/// </summary>
		public string Openid
		{
			set{ _openid=value;}
			get{return _openid;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 用户IP
		/// </summary>
		public string UserIP
		{
			set{ _userip=value;}
			get{return _userip;}
		}
		/// <summary>
		/// 评论内容
		/// </summary>
		public string Content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 是否锁定
		/// </summary>
		public int IsLock
		{
			set{ _islock=value;}
			get{return _islock;}
		}
		/// <summary>
		/// 发表时间
		/// </summary>
		public DateTime AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Support
		{
			set{ _support=value;}
			get{return _support;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int NoSupport
		{
			set{ _nosupport=value;}
			get{return _nosupport;}
		}
		#endregion Model

	}
}

