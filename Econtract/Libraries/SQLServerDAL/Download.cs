using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using IDAL;
using DBUtility;//Please add references
namespace SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Download
	/// </summary>
	public partial class Download:IDownload
	{
		public Download()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("DownloadID", "Download"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int DownloadID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Download");
			strSql.Append(" where DownloadID=@DownloadID");
			SqlParameter[] parameters = {
					new SqlParameter("@DownloadID", SqlDbType.Int,4)
			};
			parameters[0].Value = DownloadID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.Download model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Download(");
			strSql.Append("FileName,FileUrl,Type,Content,Image,UserType,Hits,DownNum,State,AddTime)");
			strSql.Append(" values (");
			strSql.Append("@FileName,@FileUrl,@Type,@Content,@Image,@UserType,@Hits,@DownNum,@State,@AddTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@FileName", SqlDbType.NVarChar,200),
					new SqlParameter("@FileUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@Type", SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.NVarChar,-1),
					new SqlParameter("@Image", SqlDbType.NVarChar,200),
					new SqlParameter("@UserType", SqlDbType.Int,4),
					new SqlParameter("@Hits", SqlDbType.Int,4),
					new SqlParameter("@DownNum", SqlDbType.Int,4),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime)};
			parameters[0].Value = model.FileName;
			parameters[1].Value = model.FileUrl;
			parameters[2].Value = model.Type;
			parameters[3].Value = model.Content;
			parameters[4].Value = model.Image;
			parameters[5].Value = model.UserType;
			parameters[6].Value = model.Hits;
			parameters[7].Value = model.DownNum;
			parameters[8].Value = model.State;
			parameters[9].Value = model.AddTime;

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
		public bool Update(Model.Download model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Download set ");
			strSql.Append("FileName=@FileName,");
			strSql.Append("FileUrl=@FileUrl,");
			strSql.Append("Type=@Type,");
			strSql.Append("Content=@Content,");
			strSql.Append("Image=@Image,");
			strSql.Append("UserType=@UserType,");
			strSql.Append("Hits=@Hits,");
			strSql.Append("DownNum=@DownNum,");
			strSql.Append("State=@State,");
			strSql.Append("AddTime=@AddTime");
			strSql.Append(" where DownloadID=@DownloadID");
			SqlParameter[] parameters = {
					new SqlParameter("@FileName", SqlDbType.NVarChar,200),
					new SqlParameter("@FileUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@Type", SqlDbType.Int,4),
					new SqlParameter("@Content", SqlDbType.NVarChar,-1),
					new SqlParameter("@Image", SqlDbType.NVarChar,200),
					new SqlParameter("@UserType", SqlDbType.Int,4),
					new SqlParameter("@Hits", SqlDbType.Int,4),
					new SqlParameter("@DownNum", SqlDbType.Int,4),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@DownloadID", SqlDbType.Int,4)};
			parameters[0].Value = model.FileName;
			parameters[1].Value = model.FileUrl;
			parameters[2].Value = model.Type;
			parameters[3].Value = model.Content;
			parameters[4].Value = model.Image;
			parameters[5].Value = model.UserType;
			parameters[6].Value = model.Hits;
			parameters[7].Value = model.DownNum;
			parameters[8].Value = model.State;
			parameters[9].Value = model.AddTime;
			parameters[10].Value = model.DownloadID;

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
		public bool Delete(int DownloadID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Download ");
			strSql.Append(" where DownloadID=@DownloadID");
			SqlParameter[] parameters = {
					new SqlParameter("@DownloadID", SqlDbType.Int,4)
			};
			parameters[0].Value = DownloadID;

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
		public bool DeleteList(string DownloadIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Download ");
			strSql.Append(" where DownloadID in ("+DownloadIDlist + ")  ");
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
		public Model.Download GetModel(int DownloadID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 DownloadID,FileName,FileUrl,Type,Content,Image,UserType,Hits,DownNum,State,AddTime from Download ");
			strSql.Append(" where DownloadID=@DownloadID");
			SqlParameter[] parameters = {
					new SqlParameter("@DownloadID", SqlDbType.Int,4)
			};
			parameters[0].Value = DownloadID;

			Model.Download model=new Model.Download();
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
		public Model.Download DataRowToModel(DataRow row)
		{
			Model.Download model=new Model.Download();
			if (row != null)
			{
				if(row["DownloadID"]!=null && row["DownloadID"].ToString()!="")
				{
					model.DownloadID=int.Parse(row["DownloadID"].ToString());
				}
				if(row["FileName"]!=null)
				{
					model.FileName=row["FileName"].ToString();
				}
				if(row["FileUrl"]!=null)
				{
					model.FileUrl=row["FileUrl"].ToString();
				}
				if(row["Type"]!=null && row["Type"].ToString()!="")
				{
					model.Type=int.Parse(row["Type"].ToString());
				}
				if(row["Content"]!=null)
				{
					model.Content=row["Content"].ToString();
				}
				if(row["Image"]!=null)
				{
					model.Image=row["Image"].ToString();
				}
				if(row["UserType"]!=null && row["UserType"].ToString()!="")
				{
					model.UserType=int.Parse(row["UserType"].ToString());
				}
				if(row["Hits"]!=null && row["Hits"].ToString()!="")
				{
					model.Hits=int.Parse(row["Hits"].ToString());
				}
				if(row["DownNum"]!=null && row["DownNum"].ToString()!="")
				{
					model.DownNum=int.Parse(row["DownNum"].ToString());
				}
				if(row["State"]!=null && row["State"].ToString()!="")
				{
					model.State=int.Parse(row["State"].ToString());
				}
				if(row["AddTime"]!=null && row["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(row["AddTime"].ToString());
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
			strSql.Append("select DownloadID,FileName,FileUrl,Type,Content,Image,UserType,Hits,DownNum,State,AddTime ");
			strSql.Append(" FROM Download ");
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
			strSql.Append(" DownloadID,FileName,FileUrl,Type,Content,Image,UserType,Hits,DownNum,State,AddTime ");
			strSql.Append(" FROM Download ");
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
			strSql.Append("select count(1) FROM Download ");
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.DownloadID desc");
            }
            strSql.Append(")AS Row, T.*  from Download T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(int PageSize, int PageIndex, string OrderfldName, int OrderType, ref int IsReCount, string strWhere)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@tblName", SqlDbType.VarChar, 0xff),
                new SqlParameter("@fldName", SqlDbType.VarChar, 500),
                new SqlParameter("@OrderfldName", SqlDbType.VarChar, 0xff),
                new SqlParameter("@PageSize", SqlDbType.Int),
                new SqlParameter("@PageIndex", SqlDbType.Int),
                new SqlParameter("@IsReCount", SqlDbType.Int),
                new SqlParameter("@OrderType", SqlDbType.Int),
                new SqlParameter("@strWhere", SqlDbType.VarChar, 0x3e8) };
            parameters[0].Value = "Download";
            parameters[1].Value = "DownloadID,FileName,FileUrl,Type,Content,Image,UserType,Hits,DownNum,State,AddTime";
            parameters[2].Value = OrderfldName;
            parameters[3].Value = PageSize;
            parameters[4].Value = PageIndex;
            parameters[5].Direction = ParameterDirection.Output;
            parameters[6].Value = OrderType;
            parameters[7].Value = strWhere;
            DataSet redata = DbHelperSQL.RunProcedure("GetRecordByPage", parameters, "ds");
            IsReCount = int.Parse(parameters[5].Value.ToString());
            return redata;
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

