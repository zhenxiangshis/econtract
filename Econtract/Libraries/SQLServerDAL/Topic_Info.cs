/**  
* Topic_InfoDAL.cs
*
* 功 能： N/A
* 类 名： Topic_InfoDAL
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2018-05-30 14:43:04   N/A    初版
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
	/// 数据访问类:Topic_InfoDAL
	/// </summary>
	public partial class Topic_Info:ITopic_Info
	{
		public Topic_Info()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("TopicID", "Topic_Info"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int TopicID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Topic_Info");
			strSql.Append(" where TopicID=@TopicID");
			SqlParameter[] parameters = {
					new SqlParameter("@TopicID", SqlDbType.Int,4)
			};
			parameters[0].Value = TopicID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.Topic_Info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Topic_Info(");
			strSql.Append("Title,Keyword,Description,ClassID,Url,BackColor,PCContent,WapContent,AddTime,VisitCount)");
			strSql.Append(" values (");
			strSql.Append("@Title,@Keyword,@Description,@ClassID,@Url,@BackColor,@PCContent,@WapContent,@AddTime,@VisitCount)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@Keyword", SqlDbType.NVarChar,200),
					new SqlParameter("@Description", SqlDbType.NVarChar,500),
					new SqlParameter("@ClassID", SqlDbType.Int,4),
					new SqlParameter("@Url", SqlDbType.NVarChar,100),
					new SqlParameter("@BackColor", SqlDbType.NVarChar,10),
					new SqlParameter("@PCContent", SqlDbType.NVarChar,-1),
					new SqlParameter("@WapContent", SqlDbType.NVarChar,-1),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@VisitCount", SqlDbType.Int,4)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.Keyword;
			parameters[2].Value = model.Description;
			parameters[3].Value = model.ClassID;
			parameters[4].Value = model.Url;
			parameters[5].Value = model.BackColor;
			parameters[6].Value = model.PCContent;
			parameters[7].Value = model.WapContent;
			parameters[8].Value = model.AddTime;
			parameters[9].Value = model.VisitCount;

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
		public bool Update(Model.Topic_Info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Topic_Info set ");
			strSql.Append("Title=@Title,");
			strSql.Append("Keyword=@Keyword,");
			strSql.Append("Description=@Description,");
			strSql.Append("ClassID=@ClassID,");
			strSql.Append("Url=@Url,");
			strSql.Append("BackColor=@BackColor,");
			strSql.Append("PCContent=@PCContent,");
			strSql.Append("WapContent=@WapContent,");
			strSql.Append("AddTime=@AddTime,");
			strSql.Append("VisitCount=@VisitCount");
			strSql.Append(" where TopicID=@TopicID");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@Keyword", SqlDbType.NVarChar,200),
					new SqlParameter("@Description", SqlDbType.NVarChar,500),
					new SqlParameter("@ClassID", SqlDbType.Int,4),
					new SqlParameter("@Url", SqlDbType.NVarChar,100),
					new SqlParameter("@BackColor", SqlDbType.NVarChar,10),
					new SqlParameter("@PCContent", SqlDbType.NVarChar,-1),
					new SqlParameter("@WapContent", SqlDbType.NVarChar,-1),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@VisitCount", SqlDbType.Int,4),
					new SqlParameter("@TopicID", SqlDbType.Int,4)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.Keyword;
			parameters[2].Value = model.Description;
			parameters[3].Value = model.ClassID;
			parameters[4].Value = model.Url;
			parameters[5].Value = model.BackColor;
			parameters[6].Value = model.PCContent;
			parameters[7].Value = model.WapContent;
			parameters[8].Value = model.AddTime;
			parameters[9].Value = model.VisitCount;
			parameters[10].Value = model.TopicID;

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
		public bool Delete(int TopicID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Topic_Info ");
			strSql.Append(" where TopicID=@TopicID");
			SqlParameter[] parameters = {
					new SqlParameter("@TopicID", SqlDbType.Int,4)
			};
			parameters[0].Value = TopicID;

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
		public bool DeleteList(string TopicIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Topic_Info ");
			strSql.Append(" where TopicID in ("+TopicIDlist + ")  ");
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
		public Model.Topic_Info GetModel(int TopicID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 TopicID,Title,Keyword,Description,ClassID,Url,BackColor,PCContent,WapContent,AddTime,VisitCount from Topic_Info ");
			strSql.Append(" where TopicID=@TopicID");
			SqlParameter[] parameters = {
					new SqlParameter("@TopicID", SqlDbType.Int,4)
			};
			parameters[0].Value = TopicID;

			Model.Topic_Info model=new Model.Topic_Info();
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
		public Model.Topic_Info DataRowToModel(DataRow row)
		{
			Model.Topic_Info model=new Model.Topic_Info();
			if (row != null)
			{
				if(row["TopicID"]!=null && row["TopicID"].ToString()!="")
				{
					model.TopicID=int.Parse(row["TopicID"].ToString());
				}
				if(row["Title"]!=null)
				{
					model.Title=row["Title"].ToString();
				}
				if(row["Keyword"]!=null)
				{
					model.Keyword=row["Keyword"].ToString();
				}
				if(row["Description"]!=null)
				{
					model.Description=row["Description"].ToString();
				}
				if(row["ClassID"]!=null && row["ClassID"].ToString()!="")
				{
					model.ClassID=int.Parse(row["ClassID"].ToString());
				}
				if(row["Url"]!=null)
				{
					model.Url=row["Url"].ToString();
				}
				if(row["BackColor"]!=null)
				{
					model.BackColor=row["BackColor"].ToString();
				}
				if(row["PCContent"]!=null)
				{
					model.PCContent=row["PCContent"].ToString();
				}
				if(row["WapContent"]!=null)
				{
					model.WapContent=row["WapContent"].ToString();
				}
				if(row["AddTime"]!=null && row["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(row["AddTime"].ToString());
				}
				if(row["VisitCount"]!=null && row["VisitCount"].ToString()!="")
				{
					model.VisitCount=int.Parse(row["VisitCount"].ToString());
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
			strSql.Append("select TopicID,Title,Keyword,Description,ClassID,Url,BackColor,PCContent,WapContent,AddTime,VisitCount ");
			strSql.Append(" FROM Topic_Info ");
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
			strSql.Append(" TopicID,Title,Keyword,Description,ClassID,Url,BackColor,PCContent,WapContent,AddTime,VisitCount ");
			strSql.Append(" FROM Topic_Info ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}
        public DataSet GetList(int PageSize,int PageIndex,string OrderfldName,int OrderType,ref int IsReCount,string strWhere)
        {

            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@tblName",SqlDbType.VarChar,0xff),new SqlParameter("@fldName",SqlDbType.VarChar,500),new SqlParameter("@OrderfldName",SqlDbType.VarChar,0xff),new SqlParameter("@PageSize",SqlDbType.Int),new SqlParameter("@PageIndex",SqlDbType.Int),new SqlParameter("@IsReCount",SqlDbType.Int),new SqlParameter("@OrderType",SqlDbType.Int),new SqlParameter("@strWhere",SqlDbType.VarChar,0x3e8) };
            parameters[0].Value = "Topic_Info";
            parameters[1].Value = "TopicID,Title,Keyword,Description,ClassID,Url,BackColor,PCContent,WapContent,AddTime,VisitCount";
            parameters[2].Value = OrderfldName;
            parameters[3].Value = PageSize;
            parameters[4].Value = PageIndex;
            parameters[5].Direction = ParameterDirection.Output;
            parameters[6].Value = OrderType;
            parameters[7].Value = strWhere;
            DataSet redata = DbHelperSQL.RunProcedure("GetRecordByPage",parameters,"ds");
            IsReCount = int.Parse(parameters[5].Value.ToString());
            return redata;

        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Topic_Info ");
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
				strSql.Append("order by T.TopicID desc");
			}
			strSql.Append(")AS Row, T.*  from Topic_Info T ");
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
			parameters[0].Value = "Topic_Info";
			parameters[1].Value = "TopicID";
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

