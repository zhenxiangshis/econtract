using System;
namespace Model
{
	/// <summary>
	/// UserType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class UserType
	{
		public UserType()
		{}
		#region Model
		private int _usertypeid;
		private string _type;
		/// <summary>
		/// 
		/// </summary>
		public int UserTypeID
		{
			set{ _usertypeid=value;}
			get{return _usertypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Type
		{
			set{ _type=value;}
			get{return _type;}
		}
		#endregion Model

	}
}

