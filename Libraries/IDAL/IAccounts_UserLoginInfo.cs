/**  
* Accounts_UserLoginInfo.cs
*
* 功 能： N/A
* 类 名： Accounts_UserLoginInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2019/7/4 10:17:20   N/A    初版
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
	/// 接口层Accounts_UserLoginInfo
	/// </summary>
	public interface IAccounts_UserLoginInfo
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int LoginID);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		bool Add(Model.Accounts_UserLoginInfo model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(Model.Accounts_UserLoginInfo model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int LoginID);
		bool DeleteList(string LoginIDlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Model.Accounts_UserLoginInfo GetModel(int LoginID);
		Model.Accounts_UserLoginInfo DataRowToModel(DataRow row);
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
