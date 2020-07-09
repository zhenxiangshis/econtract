using System;
namespace Model
{
	/// <summary>
	/// Download_Info:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Download_Info
	{
		public Download_Info()
		{}
		#region Model
		private int _downinfoid;
		private int _userid;
		private int _fileid;
		private string _ip;
		private DateTime? _addtime;
		/// <summary>
		/// 
		/// </summary>
		public int DownInfoID
		{
			set{ _downinfoid=value;}
			get{return _downinfoid;}
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
		public int FileID
		{
			set{ _fileid=value;}
			get{return _fileid;}
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
		public DateTime? AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model

	}
}

