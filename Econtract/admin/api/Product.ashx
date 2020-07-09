<%@ WebHandler Language="C#" Class="Product" %>

using System;
using System.Web;
using System.Text;
using BLL.Pro;
using System.Data;
using DBUtility;

public class Product : IHttpHandler {

    public void ProcessRequest(HttpContext context) {
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

        int iTotalRecords = System.Convert.ToInt32(DbHelperSQL.ExecuteSqlGet("SELECT count(*) FROM [Pro_Info]", ""));
        int iDisplayStart = 1;
        int iDisplayLength = int.Parse(context.Request.QueryString["iDisplayLength"].ToString());
        string[] aColumns = new string[] { "", "ProID", "Title", "AddTime", "", "", "", "" };
        int iSortingCols = 1;
        int sSortDir = 1;
        string aColumn = "ProID";
        string sEcho = context.Request.QueryString["sEcho"].ToString();
        string strWhere = " IsDelete = 0";
        int IsReCount = 0;
        // 分页       
        if (context.Request.QueryString["iDisplayStart"] != null && context.Request.QueryString["iDisplayLength"] != "-1") {
            iDisplayLength = int.Parse(context.Request.QueryString["iDisplayLength"].ToString());
            iDisplayStart = int.Parse(context.Request.QueryString["iDisplayStart"].ToString()) / iDisplayLength + 1;
        }
        if (context.Request.QueryString["iDisplayLength"] == "-1")
        {
            iDisplayLength = iTotalRecords;
            iDisplayStart = 1;
        }
        // 排序
        if (context.Request.QueryString["iSortCol_0"] != null) {
            iSortingCols = int.Parse(context.Request.QueryString["iSortCol_0"].ToString());
            sSortDir = context.Request.QueryString["sSortDir_0"].ToString() == "desc" ? 1 : 0;
            aColumn = aColumns[iSortingCols];
        }
        //获取客户端的Cookie对象
        HttpCookie cok = context.Request.Cookies["Product_List"];
        if (cok != null && cok.Value != "0") {
            //修改Cookie的两种方法
            strWhere = " ClassID = " + cok.Value;
        }
        // 搜索
          if (!String.IsNullOrEmpty(context.Request.QueryString["sSearch"])){
            string _s = context.Server.UrlDecode(context.Request.QueryString["sSearch"].ToString());
            //context.Response.Write(_s);
            strWhere += (strWhere != "" ? " and " : "") + " (Charindex('" + _s + "',ProID) > 0 or Charindex('" + _s + "',Title) > 0) ";
        }

        DataSet set = new DataSet();
        Pro_Info Probll = new Pro_Info();
        set = Probll.GetProInfoList(iDisplayLength, iDisplayStart, aColumn, sSortDir, ref IsReCount, strWhere);
        
        StringBuilder data = new StringBuilder();

        foreach (DataRow row in set.Tables[0].Rows) {
            data.AppendFormat(",[\"{4}\",\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{5}\",\"{6}\",\"{7}\"]", row["ProID"].ToString(), row["Title"].ToString(), DateTime.Parse(row["AddTime"].ToString()).ToString("yyyy-MM-dd HH:mm:ss"), GcName(System.Convert.ToInt32(row["ClassID"])), row["SpecialUrl"].ToString() != "" ? row["SpecialUrl"].ToString() : "/Pro/Html/" + Utility.StringHelper.DateToYear(row["AddTime"].ToString()) + "/" + row["ProID"].ToString() + ".html", row["IsTop"].ToString(), row["IsVouch"].ToString(), row["Aud"].ToString());
        }

        StringBuilder dataJson = new StringBuilder();

        dataJson.AppendFormat("{4}\"sEcho\": {0},\"iTotalRecords\": {1},\"iTotalDisplayRecords\": {2},\"aaData\": [{3}]{5}", sEcho, iTotalRecords, IsReCount, data.Length != 0 ? data.ToString().Substring(1, data.Length - 1) : "", "{", "}");


        // System.Threading.Thread.Sleep(3000); 

        context.Response.Write(dataJson.ToString());
    }

    public string GcName(int ClassID) {
        Pro_Class class2 = new Pro_Class();
        return class2.GetProClassModel(ClassID).ClassName.ToString();
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}