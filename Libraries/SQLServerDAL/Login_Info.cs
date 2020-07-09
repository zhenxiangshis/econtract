using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using IDAL;
using DBUtility;//Please add references
namespace SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Login_Info
	/// </summary>
	public partial class Login_Info:ILogin_Info
	{
		public Login_Info()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("LoginID", "Login_Info"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int LoginID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Login_Info");
			strSql.Append(" where LoginID=@LoginID");
			SqlParameter[] parameters = {
					new SqlParameter("@LoginID", SqlDbType.Int,4)
			};
			parameters[0].Value = LoginID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.Login_Info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Login_Info(");
			strSql.Append("UserID,IP,AddTime,OutTime)");
			strSql.Append(" values (");
			strSql.Append("@UserID,@IP,@AddTime,@OutTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@IP", SqlDbType.NVarChar,50),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@OutTime", SqlDbType.DateTime)};
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.IP;
			parameters[2].Value = model.AddTime;
			parameters[3].Value = model.OutTime;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.Login_Info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Login_Info set ");
			strSql.Append("UserID=@UserID,");
			strSql.Append("IP=@IP,");
			strSql.Append("AddTime=@AddTime,");
			strSql.Append("OutTime=@OutTime");
			strSql.Append(" where LoginID=@LoginID");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@IP", SqlDbType.NVarChar,50),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@OutTime", SqlDbType.DateTime),
					new SqlParameter("@LoginID", SqlDbType.Int,4)};
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.IP;
			parameters[2].Value = model.AddTime;
			parameters[3].Value = model.OutTime;
			parameters[4].Value = model.LoginID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int LoginID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Login_Info ");
			strSql.Append(" where LoginID=@LoginID");
			SqlParameter[] parameters = {
					new SqlParameter("@LoginID", SqlDbType.Int,4)
			};
			parameters[0].Value = LoginID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string LoginIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Login_Info ");
			strSql.Append(" where LoginID in ("+LoginIDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.Login_Info GetModel(int LoginID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 LoginID,UserID,IP,AddTime,OutTime from Login_Info ");
			strSql.Append(" where LoginID=@LoginID");
			SqlParameter[] parameters = {
					new SqlParameter("@LoginID", SqlDbType.Int,4)
			};
			parameters[0].Value = LoginID;

			Model.Login_Info model=new Model.Login_Info();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.Login_Info DataRowToModel(DataRow row)
		{
			Model.Login_Info model=new Model.Login_Info();
			if (row != null)
			{
				if(row["LoginID"]!=null && row["LoginID"].ToString()!="")
				{
					model.LoginID=int.Parse(row["LoginID"].ToString());
				}
				if(row["UserID"]!=null && row["UserID"].ToString()!="")
				{
					model.UserID=int.Parse(row["UserID"].ToString());
				}
				if(row["IP"]!=null)
				{
					model.IP=row["IP"].ToString();
				}
				if(row["AddTime"]!=null && row["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(row["AddTime"].ToString());
				}
				if(row["OutTime"]!=null && row["OutTime"].ToString()!="")
				{
					model.OutTime=DateTime.Parse(row["OutTime"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select LoginID,UserID,IP,AddTime,OutTime ");
			strSql.Append(" FROM Login_Info ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" LoginID,UserID,IP,AddTime,OutTime ");
			strSql.Append(" FROM Login_Info ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Login_Info ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.LoginID desc");
			}
			strSql.Append(")AS Row, T.*  from Login_Info T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Login_Info";
			parameters[1].Value = "LoginID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

