using System;
using System.Data;
using System.Collections.Generic;
using Model;
using DALFactory;
using IDAL;
namespace BLL
{
	/// <summary>
	/// Download
	/// </summary>
	public partial class Download
	{
		private readonly IDownload dal=DataAccess.CreateDownload();
		public Download()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int DownloadID)
		{
			return dal.Exists(DownloadID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Model.Download model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.Download model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int DownloadID)
		{
			
			return dal.Delete(DownloadID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string DownloadIDlist )
		{
			return dal.DeleteList(DownloadIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.Download GetModel(int DownloadID)
		{
			
			return dal.GetModel(DownloadID);
		}

	
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.Download> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.Download> DataTableToList(DataTable dt)
		{
			List<Model.Download> modelList = new List<Model.Download>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Model.Download model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
        /// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(int PageSize, int PageIndex, string OrderfldName, int OrderType, ref int IsReCount, string strWhere)
        {
            return dal.GetListByPage(PageSize, PageIndex, OrderfldName, OrderType, ref  IsReCount,  strWhere);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

