/**  
* Student_Info.cs
*
* 功 能： N/A
* 类 名： Student_Info
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2019/11/20 11:16:41   N/A    初版
*
* Copyright (c) 2012 bjzkty Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：北京中科腾宇科技发展有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
namespace IDAL
{
	/// <summary>
	/// 接口层Student_Info
	/// </summary>
	public interface IStudent_Info
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int StudentID);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(Model.Student_Info model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(Model.Student_Info model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int StudentID);
		bool DeleteList(string StudentIDlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Model.Student_Info GetModel(int StudentID);
		Model.Student_Info DataRowToModel(DataRow row);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);
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
