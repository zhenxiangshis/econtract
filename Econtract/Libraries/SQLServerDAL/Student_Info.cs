/**  
* Student_Info.cs
*
* 功 能： N/A
* 类 名： Student_Info
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2019/12/2 20:18:11   N/A    初版
*
* Copyright (c) 2012 bjzkty Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：北京中科腾宇科技发展有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using IDAL;
using DBUtility;//Please add references
namespace SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Student_Info
	/// </summary>
	public partial class Student_Info:IStudent_Info
	{
		public Student_Info()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("StudentID", "Student_Info"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int StudentID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Student_Info");
			strSql.Append(" where StudentID=@StudentID");
			SqlParameter[] parameters = {
					new SqlParameter("@StudentID", SqlDbType.Int,4)
			};
			parameters[0].Value = StudentID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.Student_Info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Student_Info(");
			strSql.Append("UserID,Name,Sex,Birthday,Education,EduType,Major,GraduationTime,Address,Zipcode,IDCard,Phone,QQ,TelPhone,Email,LinkName,LinkPhone,ClassName,Money,PayMethod,Addtime,State)");
			strSql.Append(" values (");
			strSql.Append("@UserID,@Name,@Sex,@Birthday,@Education,@EduType,@Major,@GraduationTime,@Address,@Zipcode,@IDCard,@Phone,@QQ,@TelPhone,@Email,@LinkName,@LinkPhone,@ClassName,@Money,@PayMethod,@Addtime,@State)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.NVarChar,50),
					new SqlParameter("@Birthday", SqlDbType.NVarChar,50),
					new SqlParameter("@Education", SqlDbType.NVarChar,50),
					new SqlParameter("@EduType", SqlDbType.NVarChar,50),
					new SqlParameter("@Major", SqlDbType.NVarChar,50),
					new SqlParameter("@GraduationTime", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,200),
					new SqlParameter("@Zipcode", SqlDbType.NVarChar,10),
					new SqlParameter("@IDCard", SqlDbType.NVarChar,50),
					new SqlParameter("@Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@QQ", SqlDbType.NVarChar,50),
					new SqlParameter("@TelPhone", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@LinkName", SqlDbType.NVarChar,50),
					new SqlParameter("@LinkPhone", SqlDbType.NVarChar,50),
					new SqlParameter("@ClassName", SqlDbType.NVarChar,50),
					new SqlParameter("@Money", SqlDbType.Decimal,9),
					new SqlParameter("@PayMethod", SqlDbType.NVarChar,10),
					new SqlParameter("@Addtime", SqlDbType.DateTime),
					new SqlParameter("@State", SqlDbType.Int,4)};
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Sex;
			parameters[3].Value = model.Birthday;
			parameters[4].Value = model.Education;
			parameters[5].Value = model.EduType;
			parameters[6].Value = model.Major;
			parameters[7].Value = model.GraduationTime;
			parameters[8].Value = model.Address;
			parameters[9].Value = model.Zipcode;
			parameters[10].Value = model.IDCard;
			parameters[11].Value = model.Phone;
			parameters[12].Value = model.QQ;
			parameters[13].Value = model.TelPhone;
			parameters[14].Value = model.Email;
			parameters[15].Value = model.LinkName;
			parameters[16].Value = model.LinkPhone;
			parameters[17].Value = model.ClassName;
			parameters[18].Value = model.Money;
			parameters[19].Value = model.PayMethod;
			parameters[20].Value = model.Addtime;
			parameters[21].Value = model.State;

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
		public bool Update(Model.Student_Info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Student_Info set ");
			strSql.Append("UserID=@UserID,");
			strSql.Append("Name=@Name,");
			strSql.Append("Sex=@Sex,");
			strSql.Append("Birthday=@Birthday,");
			strSql.Append("Education=@Education,");
			strSql.Append("EduType=@EduType,");
			strSql.Append("Major=@Major,");
			strSql.Append("GraduationTime=@GraduationTime,");
			strSql.Append("Address=@Address,");
			strSql.Append("Zipcode=@Zipcode,");
			strSql.Append("IDCard=@IDCard,");
			strSql.Append("Phone=@Phone,");
			strSql.Append("QQ=@QQ,");
			strSql.Append("TelPhone=@TelPhone,");
			strSql.Append("Email=@Email,");
			strSql.Append("LinkName=@LinkName,");
			strSql.Append("LinkPhone=@LinkPhone,");
			strSql.Append("ClassName=@ClassName,");
			strSql.Append("Money=@Money,");
			strSql.Append("PayMethod=@PayMethod,");
			strSql.Append("Addtime=@Addtime,");
			strSql.Append("State=@State");
			strSql.Append(" where StudentID=@StudentID");
			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.NVarChar,50),
					new SqlParameter("@Birthday", SqlDbType.NVarChar,50),
					new SqlParameter("@Education", SqlDbType.NVarChar,50),
					new SqlParameter("@EduType", SqlDbType.NVarChar,50),
					new SqlParameter("@Major", SqlDbType.NVarChar,50),
					new SqlParameter("@GraduationTime", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,200),
					new SqlParameter("@Zipcode", SqlDbType.NVarChar,10),
					new SqlParameter("@IDCard", SqlDbType.NVarChar,50),
					new SqlParameter("@Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@QQ", SqlDbType.NVarChar,50),
					new SqlParameter("@TelPhone", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@LinkName", SqlDbType.NVarChar,50),
					new SqlParameter("@LinkPhone", SqlDbType.NVarChar,50),
					new SqlParameter("@ClassName", SqlDbType.NVarChar,50),
					new SqlParameter("@Money", SqlDbType.Decimal,9),
					new SqlParameter("@PayMethod", SqlDbType.NVarChar,10),
					new SqlParameter("@Addtime", SqlDbType.DateTime),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@StudentID", SqlDbType.Int,4)};
			parameters[0].Value = model.UserID;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Sex;
			parameters[3].Value = model.Birthday;
			parameters[4].Value = model.Education;
			parameters[5].Value = model.EduType;
			parameters[6].Value = model.Major;
			parameters[7].Value = model.GraduationTime;
			parameters[8].Value = model.Address;
			parameters[9].Value = model.Zipcode;
			parameters[10].Value = model.IDCard;
			parameters[11].Value = model.Phone;
			parameters[12].Value = model.QQ;
			parameters[13].Value = model.TelPhone;
			parameters[14].Value = model.Email;
			parameters[15].Value = model.LinkName;
			parameters[16].Value = model.LinkPhone;
			parameters[17].Value = model.ClassName;
			parameters[18].Value = model.Money;
			parameters[19].Value = model.PayMethod;
			parameters[20].Value = model.Addtime;
			parameters[21].Value = model.State;
			parameters[22].Value = model.StudentID;

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
		public bool Delete(int StudentID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Student_Info ");
			strSql.Append(" where StudentID=@StudentID");
			SqlParameter[] parameters = {
					new SqlParameter("@StudentID", SqlDbType.Int,4)
			};
			parameters[0].Value = StudentID;

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
		public bool DeleteList(string StudentIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Student_Info ");
			strSql.Append(" where StudentID in ("+StudentIDlist + ")  ");
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
		public Model.Student_Info GetModel(int StudentID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 StudentID,UserID,Name,Sex,Birthday,Education,EduType,Major,GraduationTime,Address,Zipcode,IDCard,Phone,QQ,TelPhone,Email,LinkName,LinkPhone,ClassName,Money,PayMethod,Addtime,State from Student_Info ");
			strSql.Append(" where StudentID=@StudentID");
			SqlParameter[] parameters = {
					new SqlParameter("@StudentID", SqlDbType.Int,4)
			};
			parameters[0].Value = StudentID;

			Model.Student_Info model=new Model.Student_Info();
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
		public Model.Student_Info DataRowToModel(DataRow row)
		{
			Model.Student_Info model=new Model.Student_Info();
			if (row != null)
			{
				if(row["StudentID"]!=null && row["StudentID"].ToString()!="")
				{
					model.StudentID=int.Parse(row["StudentID"].ToString());
				}
				if(row["UserID"]!=null && row["UserID"].ToString()!="")
				{
					model.UserID=int.Parse(row["UserID"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["Sex"]!=null)
				{
					model.Sex=row["Sex"].ToString();
				}
				if(row["Birthday"]!=null)
				{
					model.Birthday=row["Birthday"].ToString();
				}
				if(row["Education"]!=null)
				{
					model.Education=row["Education"].ToString();
				}
				if(row["EduType"]!=null)
				{
					model.EduType=row["EduType"].ToString();
				}
				if(row["Major"]!=null)
				{
					model.Major=row["Major"].ToString();
				}
				if(row["GraduationTime"]!=null)
				{
					model.GraduationTime=row["GraduationTime"].ToString();
				}
				if(row["Address"]!=null)
				{
					model.Address=row["Address"].ToString();
				}
				if(row["Zipcode"]!=null)
				{
					model.Zipcode=row["Zipcode"].ToString();
				}
				if(row["IDCard"]!=null)
				{
					model.IDCard=row["IDCard"].ToString();
				}
				if(row["Phone"]!=null)
				{
					model.Phone=row["Phone"].ToString();
				}
				if(row["QQ"]!=null)
				{
					model.QQ=row["QQ"].ToString();
				}
				if(row["TelPhone"]!=null)
				{
					model.TelPhone=row["TelPhone"].ToString();
				}
				if(row["Email"]!=null)
				{
					model.Email=row["Email"].ToString();
				}
				if(row["LinkName"]!=null)
				{
					model.LinkName=row["LinkName"].ToString();
				}
				if(row["LinkPhone"]!=null)
				{
					model.LinkPhone=row["LinkPhone"].ToString();
				}
				if(row["ClassName"]!=null)
				{
					model.ClassName=row["ClassName"].ToString();
				}
				if(row["Money"]!=null && row["Money"].ToString()!="")
				{
					model.Money=decimal.Parse(row["Money"].ToString());
				}
				if(row["PayMethod"]!=null)
				{
					model.PayMethod=row["PayMethod"].ToString();
				}
				if(row["Addtime"]!=null && row["Addtime"].ToString()!="")
				{
					model.Addtime=DateTime.Parse(row["Addtime"].ToString());
				}
				if(row["State"]!=null && row["State"].ToString()!="")
				{
					model.State=int.Parse(row["State"].ToString());
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
			strSql.Append("select StudentID,UserID,Name,Sex,Birthday,Education,EduType,Major,GraduationTime,Address,Zipcode,IDCard,Phone,QQ,TelPhone,Email,LinkName,LinkPhone,ClassName,Money,PayMethod,Addtime,State ");
			strSql.Append(" FROM Student_Info ");
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
			strSql.Append(" StudentID,UserID,Name,Sex,Birthday,Education,EduType,Major,GraduationTime,Address,Zipcode,IDCard,Phone,QQ,TelPhone,Email,LinkName,LinkPhone,ClassName,Money,PayMethod,Addtime,State ");
			strSql.Append(" FROM Student_Info ");
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
			strSql.Append("select count(1) FROM Student_Info ");
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
				strSql.Append("order by T.StudentID desc");
			}
			strSql.Append(")AS Row, T.*  from Student_Info T ");
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
			parameters[0].Value = "Student_Info";
			parameters[1].Value = "StudentID";
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

