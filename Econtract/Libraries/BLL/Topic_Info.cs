/**  
* Topic_InfoBLL.cs
*
* 功 能： N/A
* 类 名： Topic_InfoBLL
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
using System.Collections.Generic;
using DALFactory;
using IDAL;
using System.Configuration;
using System.Web;
using System.IO;
using Utility;
using System.Text;

namespace BLL
{
    /// <summary>
    /// Topic_InfoBLL
    /// </summary>
    public partial class Topic_Info
	{
		private readonly ITopic_Info dal=DataAccess.CreateTopic_InfoDAL();
		public Topic_Info()
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
		public bool Exists(int TopicID)
		{
			return dal.Exists(TopicID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Model.Topic_Info model)
		{
            int result = dal.Add(model);
            if(result > 0)
            {
                try
                {
                    this.CreateHtml(result);
                }
                catch
                {
                }
            }
            return result;
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.Topic_Info model)
		{
            if(dal.Update(model))
            {
                try
                {
                    CreateHtml(model.TopicID);
                }
                catch {
                }
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
			
			return dal.Delete(TopicID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string TopicIDlist )
		{
			return dal.DeleteList(TopicIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.Topic_Info GetModel(int TopicID)
		{
			
			return dal.GetModel(TopicID);
		}

        public void CreateHtml(int TopicID)
        {
            try
            {
                string filePath = ConfigurationManager.AppSettings["TopicTempPath"];
                filePath = HttpContext.Current.Server.MapPath(filePath);
                string fileContent = string.Empty;
                using(var reader = new StreamReader(filePath))
                {
                    fileContent = reader.ReadToEnd();
                }
                string sHtmlTemp = fileContent;
                Model.Topic_Info model = this.GetModel(TopicID);

                sHtmlTemp = sHtmlTemp.Replace("$TopicID$",model.TopicID.ToString()).Replace("$Title$",model.Title).Replace("$Keyword$",String.IsNullOrWhiteSpace(model.Keyword)?"":model.Keyword).Replace("$Description$",String.IsNullOrWhiteSpace(model.Description)?"":model.Description).Replace("$BackColor$",String.IsNullOrWhiteSpace(model.BackColor)?"":model.BackColor).Replace("$PCContent$",model.PCContent).Replace("$WapContent$",String.IsNullOrWhiteSpace(model.WapContent)?"": HttpUtility.HtmlDecode(model.WapContent));
                
                FileHelper.CreateFile(model.Url);
                using(StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath(model.Url).ToString(),false,Encoding.GetEncoding("utf-8")))
                {
                    sw.WriteLine(sHtmlTemp);
                    sw.Flush();
                    sw.Close();
                }
                //this.ProHotHtml(0, 3, "VouchTime", " AND IsVouch=1 ");
            }
            catch
            {
            }
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
        public DataSet GetList(int PageSize,int PageIndex,string OrderfldName,int OrderType,ref int IsReCount,string strWhere)
        {
            return this.dal.GetList(PageSize,PageIndex,OrderfldName,OrderType,ref IsReCount,strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Topic_Info> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.Topic_Info> DataTableToList(DataTable dt)
		{
			List<Model.Topic_Info> modelList = new List<Model.Topic_Info>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Model.Topic_Info model;
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
		/// 分页获取数据列表
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
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

