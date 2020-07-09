/**  版本信息模板在安装目录下，可自行修改。
* Artilce_Comment.cs
*
* 功 能： N/A
* 类 名： Artilce_Comment
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2019/10/19 18:55:44   N/A    初版
*
* Copyright (c) 2019 bjzktyCorporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：北京中科腾宇科技发展有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;//Please add references
using IDAL.Article;

namespace SQLServerDAL.Article
{
	/// <summary>
	/// 数据访问类:Artilce_Comment
	/// </summary>
	public partial class Artilce_Comment:IArtilce_Comment
	{
		public Artilce_Comment()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Artilce_Comment"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Artilce_Comment");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.Article.Artilce_Comment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Artilce_Comment(");
			strSql.Append("ArticleID,ParentID,Openid,UserName,UserIP,Content,IsLock,AddTime,Support,NoSupport)");
			strSql.Append(" values (");
			strSql.Append("@ArticleID,@ParentID,@Openid,@UserName,@UserIP,@Content,@IsLock,@AddTime,@Support,@NoSupport)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ArticleID", SqlDbType.Int,4),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@Openid", SqlDbType.NVarChar,50),
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@UserIP", SqlDbType.NVarChar,255),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@IsLock", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@Support", SqlDbType.Int,4),
					new SqlParameter("@NoSupport", SqlDbType.Int,4)};
			parameters[0].Value = model.ArticleID;
			parameters[1].Value = model.ParentID;
			parameters[2].Value = model.Openid;
			parameters[3].Value = model.UserName;
			parameters[4].Value = model.UserIP;
			parameters[5].Value = model.Content;
			parameters[6].Value = model.IsLock;
			parameters[7].Value = model.AddTime;
			parameters[8].Value = model.Support;
			parameters[9].Value = model.NoSupport;

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
		public bool Update(Model.Article.Artilce_Comment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Artilce_Comment set ");
			strSql.Append("ArticleID=@ArticleID,");
			strSql.Append("ParentID=@ParentID,");
			strSql.Append("Openid=@Openid,");
			strSql.Append("UserName=@UserName,");
			strSql.Append("UserIP=@UserIP,");
			strSql.Append("Content=@Content,");
			strSql.Append("IsLock=@IsLock,");
			strSql.Append("AddTime=@AddTime,");
			strSql.Append("Support=@Support,");
			strSql.Append("NoSupport=@NoSupport");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ArticleID", SqlDbType.Int,4),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@Openid", SqlDbType.NVarChar,50),
					new SqlParameter("@UserName", SqlDbType.NVarChar,100),
					new SqlParameter("@UserIP", SqlDbType.NVarChar,255),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@IsLock", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@Support", SqlDbType.Int,4),
					new SqlParameter("@NoSupport", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.ArticleID;
			parameters[1].Value = model.ParentID;
			parameters[2].Value = model.Openid;
			parameters[3].Value = model.UserName;
			parameters[4].Value = model.UserIP;
			parameters[5].Value = model.Content;
			parameters[6].Value = model.IsLock;
			parameters[7].Value = model.AddTime;
			parameters[8].Value = model.Support;
			parameters[9].Value = model.NoSupport;
			parameters[10].Value = model.ID;

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
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Artilce_Comment ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Artilce_Comment ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
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
		public Model.Article.Artilce_Comment GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,ArticleID,ParentID,Openid,UserName,UserIP,Content,IsLock,AddTime,Support,NoSupport from Artilce_Comment ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			Model.Article.Artilce_Comment model=new Model.Article.Artilce_Comment();
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
		public Model.Article.Artilce_Comment DataRowToModel(DataRow row)
		{
			Model.Article.Artilce_Comment model=new Model.Article.Artilce_Comment();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["ArticleID"]!=null && row["ArticleID"].ToString()!="")
				{
					model.ArticleID=int.Parse(row["ArticleID"].ToString());
				}
				if(row["ParentID"]!=null && row["ParentID"].ToString()!="")
				{
					model.ParentID=int.Parse(row["ParentID"].ToString());
				}
				if(row["Openid"]!=null)
				{
					model.Openid=row["Openid"].ToString();
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["UserIP"]!=null)
				{
					model.UserIP=row["UserIP"].ToString();
				}
				if(row["Content"]!=null)
				{
					model.Content=row["Content"].ToString();
				}
				if(row["IsLock"]!=null && row["IsLock"].ToString()!="")
				{
					model.IsLock=int.Parse(row["IsLock"].ToString());
				}
				if(row["AddTime"]!=null && row["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(row["AddTime"].ToString());
				}
				if(row["Support"]!=null && row["Support"].ToString()!="")
				{
					model.Support=int.Parse(row["Support"].ToString());
				}
				if(row["NoSupport"]!=null && row["NoSupport"].ToString()!="")
				{
					model.NoSupport=int.Parse(row["NoSupport"].ToString());
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
			strSql.Append("select ID,ArticleID,ParentID,Openid,UserName,UserIP,Content,IsLock,AddTime,Support,NoSupport ");
			strSql.Append(" FROM Artilce_Comment ");
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
			strSql.Append(" ID,ArticleID,ParentID,Openid,UserName,UserIP,Content,IsLock,AddTime,Support,NoSupport ");
			strSql.Append(" FROM Artilce_Comment ");
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
			strSql.Append("select count(1) FROM Artilce_Comment ");
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
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from Artilce_Comment T ");
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
			parameters[0].Value = "Artilce_Comment";
			parameters[1].Value = "ID";
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

