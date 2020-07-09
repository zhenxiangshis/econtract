using System;
namespace Model
{
	/// <summary>
	/// Login_Info:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Login_Info
	{
		public Login_Info()
		{}
		#region Model
		private int _loginid;
		private int _userid;
		private string _ip;
		private DateTime? _addtime;
		private DateTime? _outtime;
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
		public DateTime? AddTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? OutTime
		{
			set{ _outtime=value;}
			get{return _outtime;}
		}
		#endregion Model

	}
}

