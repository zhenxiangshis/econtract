<%@ WebHandler Language="C#" Class="GetContract" %>

using System;
using System.Web;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using Utility;
using Newtonsoft.Json;
using System.Linq;
public class GetContract : IHttpHandler
{
    //public UploadResult Result { get; private set; }
    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "application/Json";
        string phone = context.Request.Params["phone"].ToString();
        string date = context.Request.Params["date"].ToString();
        var path = "/contracts/" + phone + "/" + date + "/";
        List<string> Files = new List<string>();
        if (File.Exists(HttpContext.Current.Server.MapPath(path + phone + ".pdf")))
        {
            //已签署，返回签署后的图片列表
            Files.Add(path + "1.png");
            Files.Add(path + "2.png");
            Files.Add(path + "3.png");
            Files.Add(path + "4.png");
            Files.Add(path + "5.png");
            Files.Add(path + "6.png");
            Files.Add(path + "7.png");
            Files.Add(path + "8.png");
            Files.Add(path + "9.png");
            Files.Add(path + "10s.png");
        }
        else
        {

            Files.Add(path + "1.png");
            Files.Add(path + "2.png");
            Files.Add(path + "3.png");
            Files.Add(path + "4.png");
            Files.Add(path + "5.png");
            Files.Add(path + "6.png");
            Files.Add(path + "7.png");
            Files.Add(path + "8.png");
            Files.Add(path + "9.png");
            Files.Add(path + "10.png");

        }
        //DirectoryInfo dir = new DirectoryInfo(HttpContext.Current.Server.MapPath(path));
        //Files = dir.GetFiles("*.png").Select(s=>path+s.Name).ToList();
        context.Response.Write(JsonConvert.SerializeObject(Files));
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}
