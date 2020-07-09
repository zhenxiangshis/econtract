/**  
* Student_Contract.cs
*
* 功 能： N/A
* 类 名： Student_Contract
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2019/11/21 21:00:30   N/A    初版
*
* Copyright (c) 2012 bjzkty Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：XXXXXXXXXX　　　　　　　　　　　　　　│
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
	/// 数据访问类:Student_Contract
	/// </summary>
	public partial class Student_Contract:IStudent_Contract
	{
		public Student_Contract()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ContractID", "Student_Contract"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ContractID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Student_Contract");
			strSql.Append(" where ContractID=@ContractID");
			SqlParameter[] parameters = {
					new SqlParameter("@ContractID", SqlDbType.Int,4)
			};
			parameters[0].Value = ContractID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.Student_Contract model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Student_Contract(");
			strSql.Append("StudentID,Type,FilePath,Addtime,Url,ContractFile,CreateTime)");
			strSql.Append(" values (");
			strSql.Append("@StudentID,@Type,@FilePath,@Addtime,@Url,@ContractFile,@CreateTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@StudentID", SqlDbType.Int,4),
					new SqlParameter("@Type", SqlDbType.NVarChar,50),
					new SqlParameter("@FilePath", SqlDbType.NVarChar,200),
					new SqlParameter("@Addtime", SqlDbType.DateTime),
					new SqlParameter("@Url", SqlDbType.NVarChar,200),
					new SqlParameter("@ContractFile", SqlDbType.NVarChar,200),
					new SqlParameter("@CreateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.StudentID;
			parameters[1].Value = model.Type;
			parameters[2].Value = model.FilePath;
			parameters[3].Value = model.Addtime;
			parameters[4].Value = model.Url;
			parameters[5].Value = model.ContractFile;
			parameters[6].Value = model.CreateTime;

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
		public bool Update(Model.Student_Contract model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Student_Contract set ");
			strSql.Append("StudentID=@StudentID,");
			strSql.Append("Type=@Type,");
			strSql.Append("FilePath=@FilePath,");
			strSql.Append("Addtime=@Addtime,");
			strSql.Append("Url=@Url,");
			strSql.Append("ContractFile=@ContractFile,");
			strSql.Append("CreateTime=@CreateTime");
			strSql.Append(" where ContractID=@ContractID");
			SqlParameter[] parameters = {
					new SqlParameter("@StudentID", SqlDbType.Int,4),
					new SqlParameter("@Type", SqlDbType.NVarChar,50),
					new SqlParameter("@FilePath", SqlDbType.NVarChar,200),
					new SqlParameter("@Addtime", SqlDbType.DateTime),
					new SqlParameter("@Url", SqlDbType.NVarChar,200),
					new SqlParameter("@ContractFile", SqlDbType.NVarChar,200),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@ContractID", SqlDbType.Int,4)};
			parameters[0].Value = model.StudentID;
			parameters[1].Value = model.Type;
			parameters[2].Value = model.FilePath;
			parameters[3].Value = model.Addtime;
			parameters[4].Value = model.Url;
			parameters[5].Value = model.ContractFile;
			parameters[6].Value = model.CreateTime;
			parameters[7].Value = model.ContractID;

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
		public bool Delete(int ContractID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Student_Contract ");
			strSql.Append(" where ContractID=@ContractID");
			SqlParameter[] parameters = {
					new SqlParameter("@ContractID", SqlDbType.Int,4)
			};
			parameters[0].Value = ContractID;

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
		public bool DeleteList(string ContractIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Student_Contract ");
			strSql.Append(" where ContractID in ("+ContractIDlist + ")  ");
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
		public Model.Student_Contract GetModel(int ContractID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ContractID,StudentID,Type,FilePath,Addtime,Url,ContractFile,CreateTime from Student_Contract ");
			strSql.Append(" where ContractID=@ContractID");
			SqlParameter[] parameters = {
					new SqlParameter("@ContractID", SqlDbType.Int,4)
			};
			parameters[0].Value = ContractID;

			Model.Student_Contract model=new Model.Student_Contract();
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
		public Model.Student_Contract DataRowToModel(DataRow row)
		{
			Model.Student_Contract model=new Model.Student_Contract();
			if (row != null)
			{
				if(row["ContractID"]!=null && row["ContractID"].ToString()!="")
				{
					model.ContractID=int.Parse(row["ContractID"].ToString());
				}
				if(row["StudentID"]!=null && row["StudentID"].ToString()!="")
				{
					model.StudentID=int.Parse(row["StudentID"].ToString());
				}
				if(row["Type"]!=null)
				{
					model.Type=row["Type"].ToString();
				}
				if(row["FilePath"]!=null)
				{
					model.FilePath=row["FilePath"].ToString();
				}
				if(row["Addtime"]!=null && row["Addtime"].ToString()!="")
				{
					model.Addtime=DateTime.Parse(row["Addtime"].ToString());
				}
				if(row["Url"]!=null)
				{
					model.Url=row["Url"].ToString();
				}
				if(row["ContractFile"]!=null)
				{
					model.ContractFile=row["ContractFile"].ToString();
				}
				if(row["CreateTime"]!=null && row["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(row["CreateTime"].ToString());
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
			strSql.Append("select ContractID,StudentID,Type,FilePath,Addtime,Url,ContractFile,CreateTime ");
			strSql.Append(" FROM Student_Contract ");
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
			strSql.Append(" ContractID,StudentID,Type,FilePath,Addtime,Url,ContractFile,CreateTime ");
			strSql.Append(" FROM Student_Contract ");
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
			strSql.Append("select count(1) FROM Student_Contract ");
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
				strSql.Append("order by T.ContractID desc");
			}
			strSql.Append(")AS Row, T.*  from Student_Contract T ");
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
			parameters[0].Value = "Student_Contract";
			parameters[1].Value = "ContractID";
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

