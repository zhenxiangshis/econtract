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

        DataSet set = new DataSet();
        Pro_Info Probll = new Pro_Info();
        int id = context.Request.QueryString["i"] != null ? int.Parse(context.Request.QueryString["i"].ToString()) : 0;
        Model.Pro.Pro_Info pro = new Model.Pro.Pro_Info();
        pro = Probll.GetProInfoModel(id);
        pro.AddTime = DateTime.Now;
        Probll.AddProInfo(pro);
        Probll.DeleteProInfo(id);
        

        context.Response.Write("s");
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