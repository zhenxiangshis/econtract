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
*│　版权所有：XXXXXXXXXX　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
namespace IDAL
{
	/// <summary>
	/// 接口层Topic_InfoBLL
	/// </summary>
	public interface ITopic_Info
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int TopicID);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(Model.Topic_Info model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(Model.Topic_Info model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int TopicID);
		bool DeleteList(string TopicIDlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Model.Topic_Info GetModel(int TopicID);
		Model.Topic_Info DataRowToModel(DataRow row);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);
        DataSet GetList(int PageSize,int PageIndex,string OrderfldName,int OrderType,ref int IsReCount,string strWhere);
        int GetRecordCount(string strWhere);
		DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
		/// <summary>
		/// 根据分页获得数据列表
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  成员方法
		#region  MethodEx

		#endregion  MethodEx
	} 
}
