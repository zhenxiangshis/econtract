<%@ WebHandler Language="C#" Class="surveyInfo" %>

using System;
using System.Web;
using System.Text;
using BLL.Article;
using System.Data;
using DBUtility;

public class surveyInfo : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "application/Json";


        StringBuilder dataJson = new StringBuilder();
        StringBuilder data = new StringBuilder();
        StringBuilder data2 = new StringBuilder();
        string dateStart = context.Request.QueryString["s"].ToString();


        DataSet ds = DbHelperSQL.Query("SELECT * FROM [surveyInfo] where classid=15 and DATEDIFF(\"DAY\",Addtime,'"+dateStart+"')=0 order by id desc", "ds");
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            data.AppendFormat(",{0}\"user\":{2},\"time\":\"{3}\"{1}","{","}", dr["userinfo"].ToString(),dr["Addtime"].ToString());
        }
        //dataJson.AppendFormat("{0}\"data\":{1}{2}{3}{4}","{","[", data.Length != 0 ? data.ToString().Substring(1, data.Length - 1) : "", "]","}");
        dataJson.AppendFormat("{0}{1}{2}", "[", data.Length != 0 ? data.ToString().Substring(1, data.Length - 1) : "", "]");

        
        // System.Threading.Thread.Sleep(3000); 

        context.Response.Write(dataJson.ToString());
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