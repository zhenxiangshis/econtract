<%@ WebHandler Language="C#" Class="activeuser" %>

using System;
using System.Web;
using System.Text;
using BLL.Article;
using System.Data;
using DBUtility;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public class activeuser : IHttpHandler
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

        int iTotalRecords = System.Convert.ToInt32(DbHelperSQL.ExecuteSqlGet("SELECT count(*) FROM [surveyInfo] where  Classid=1 ", ""));
        int iDisplayStart = 1;
        int iDisplayLength = int.Parse(context.Request.QueryString["iDisplayLength"].ToString());
        string[] aColumns = new string[] { "id", "", "", "",  "AddTime", "" };
        int iSortingCols = 1;
        string sSortDir = "desc";
        string aColumn = "AddTime";
        string sEcho = context.Request.QueryString["sEcho"].ToString();
        string strWhere = " AddTime > '2010' ";
        int IsReCount = 0;
        // 分页       
        if (context.Request.Form["iDisplayStart"] != null && context.Request.Form["iDisplayLength"] != "-1")
        {
            iDisplayLength = int.Parse(context.Request.Form["iDisplayLength"].ToString());
            iDisplayStart = int.Parse(context.Request.Form["iDisplayStart"].ToString()) + 1;
        }
        if (context.Request.Form["iDisplayLength"] == "-1")
        {
            iDisplayLength = iTotalRecords;
            iDisplayStart = 1;
        }
        // 排序
        if (context.Request.QueryString["iSortCol_0"] != null)
        {
            iSortingCols = int.Parse(context.Request.QueryString["iSortCol_0"].ToString());
            sSortDir = context.Request.QueryString["sSortDir_0"].ToString() ;
            aColumn = aColumns[iSortingCols];
        }
        //获取客户端的Cookie对象
        HttpCookie cok = context.Request.Cookies["ActiveUser_List"];
        if (cok != null && cok.Value != "0")
        {
            //修改Cookie的两种方法
            strWhere += " and ClassID = " + cok.Value;
        }
        // 搜索
        if (!String.IsNullOrEmpty(context.Request.QueryString["sSearch"]))
        {
            string _s = context.Server.UrlDecode(context.Request.QueryString["sSearch"].ToString());
            strWhere += " and (Charindex('" + _s + "',userinfo) > 0 )";
        }

        BLL.surveyInfo bllsurveyInfo = new BLL.surveyInfo();
        DataSet set = bllsurveyInfo.GetListByPage(strWhere, aColumn + " " + sSortDir, iDisplayStart, iDisplayStart + iDisplayLength - 1);
        IsReCount = System.Convert.ToInt32(bllsurveyInfo.GetRecordCount(strWhere));
        StringBuilder data = new StringBuilder();
        var iso = new IsoDateTimeConverter();
        iso.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        var plist = bllsurveyInfo.DataTableToList(set.Tables[0]);

        object dataJson = new
        {
            sEcho = sEcho,
            iTotalRecords = iTotalRecords,
            iTotalDisplayRecords = IsReCount,
            data = plist
        };
        // System.Threading.Thread.Sleep(3000); 
        context.Response.Write(JsonConvert.SerializeObject(dataJson, iso));
    }

    public string GcName(int ClassID)
    {
        Article_Class class2 = new Article_Class();
        return class2.GetArticleClassModel(ClassID).ClassName.ToString();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}