<%@ WebHandler Language="C#" Class="Product" %>

using System;
using System.Web;
using System.Text;
using System.Data;
using DBUtility;
using System.Data.SqlClient;

public class Product : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "application/Json";
        //        int iDisplayStart 显示的起始索引 
        //int iDisplayLength 显示的行数 
        //int iColumns 显示的列数  
        //string sSearch 全局搜索字段  
        //boolean bEscapeRegex 全局搜索是否正则 
        //boolean bSortable_(int) 表示一列是否在客户端被标志位可排序 
        //boolean bSearchable_(int) 表示一列是否在客户端被标志位可搜索 
        //string sSearch_(int) 个别列的搜索 
        //boolean bEscapeRegex_(int) 个别列是否使用正则搜索 
        //int iSortingCols  排序的列数  
        //int iSortCol_(int) 被排序的列 
        //string sSortDir_(int) 排序的方向 "desc" 或者 "asc".  
        //string sEcho  DataTables 用来生成的信息 


        //        int iTotalRecords 实际的行数 
        //int iTotalDisplayRecords 过滤之后，实际的行数。 
        //string sEcho 来自客户端 sEcho 的没有变化的复制品， 
        //string sColumns 可选，以逗号分隔的列名，　　　　 
        //array array mixed aaData 数组的数组，表格中的实际数据。　　　 

        int iTotalRecords = System.Convert.ToInt32(DbHelperSQL.ExecuteSqlGet("SELECT count(*) FROM [Download] where State != -1", ""));
        int iDisplayStart = 1;
        int iDisplayLength = int.Parse(context.Request.QueryString["iDisplayLength"].ToString());
        string[] aColumns = new string[] { "DownloadID", "FileName", "Hits", "AddTime", "" };
        int iSortingCols = 0;
        int sSortDir = 1;
        string aColumn = "DownloadID";
        string sEcho = context.Request.QueryString["sEcho"].ToString();
        string strWhere = " State != -1 ";
        int IsReCount = 0;
        // 分页       
        if (context.Request.QueryString["iDisplayStart"] != null && context.Request.QueryString["iDisplayLength"] != "-1")
        {
            iDisplayLength = int.Parse(context.Request.QueryString["iDisplayLength"].ToString());
            iDisplayStart = int.Parse(context.Request.QueryString["iDisplayStart"].ToString()) / iDisplayLength + 1;
        }
        if (context.Request.QueryString["iDisplayLength"] == "-1")
        {
            iDisplayLength = iTotalRecords;
            iDisplayStart = 1;
        }
        // 排序
        if (context.Request.QueryString["iSortCol_0"] != null)
        {
            iSortingCols = int.Parse(context.Request.QueryString["iSortCol_0"].ToString());
            sSortDir = context.Request.QueryString["sSortDir_0"].ToString() == "desc" ? 1 : 0;
            aColumn = aColumns[iSortingCols];
        }
        // 搜索
        if (!String.IsNullOrEmpty(context.Request.QueryString["sSearch"]))
        {
            string _s = context.Server.UrlDecode(context.Request.QueryString["sSearch"].ToString());
            strWhere = " and (Charindex('" + _s + "',DownloadID) > 0 or Charindex('" + _s + "',FileName) > 0) ";
        }

        DataSet set = new DataSet();

        set = GetList(iDisplayLength, iDisplayStart, aColumn, sSortDir, ref IsReCount, strWhere);

        //this.DataGrid1.DataSource = set.Tables[0].DefaultView;
        // this.DataGrid1.DataBind();

        StringBuilder data = new StringBuilder();

        foreach (DataRow row in set.Tables[0].Rows)
        {
            data.AppendFormat(",[\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\"]", row["DownloadID"].ToString(), row["FileName"].ToString(), row["Hits"].ToString(), DateTime.Parse(row["AddTime"].ToString()).ToString("yyyy-MM-dd"), GcName(System.Convert.ToInt32(row["UserType"])));
        }

        StringBuilder dataJson = new StringBuilder();

        dataJson.AppendFormat("{4}\"sEcho\": {0},\"iTotalRecords\": {1},\"iTotalDisplayRecords\": {2},\"aaData\": [{3}]{5}", sEcho, iTotalRecords, IsReCount, data.Length != 0 ? data.ToString().Substring(1, data.Length - 1) : "", "{", "}");


        // System.Threading.Thread.Sleep(3000); 

        context.Response.Write(dataJson.ToString());
    }

    public string GcName(int id)
    {

        return DbHelperSQL.ExecuteSqlGet("SELECT [Type] FROM [UserType] where [UserTypeID] = " + id, "").ToString();
    }

    public DataSet GetList(int PageSize, int PageIndex, string OrderfldName, int OrderType, ref int IsReCount, string strWhere)
    {

        SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@tblName", SqlDbType.VarChar, 0xff), new SqlParameter("@fldName", SqlDbType.VarChar, 500), new SqlParameter("@OrderfldName", SqlDbType.VarChar, 0xff), new SqlParameter("@PageSize", SqlDbType.Int), new SqlParameter("@PageIndex", SqlDbType.Int), new SqlParameter("@IsReCount", SqlDbType.Int), new SqlParameter("@OrderType", SqlDbType.Int), new SqlParameter("@strWhere", SqlDbType.VarChar, 0x3e8) };
        parameters[0].Value = "eBookiItem";
        parameters[1].Value = "[DownloadID],[UserType],[FileName],[Hits],[State],[AddTime],[Image]";
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
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}