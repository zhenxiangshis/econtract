<%@ WebHandler Language="C#" Class="ExcelTo" %>

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Utility;
using System.Drawing.Imaging;

public class ExcelTo : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        UploadResult result = new UploadResult();
        if (context.Request.Files.Count == 0)
        {
            result.State = UploadState.FileAccessError;
            result.ErrorMessage = "选择文件不能为空";
            context.Response.Write(JsonConvert.SerializeObject(result));
            //return AjaxResult("error","选择文件不能为空");
        }
        else
        {
            var file = context.Request.Files[0];
            var id = context.Request.Params["sid"];
            var model = new BLL.Student_Info().GetModel(int.Parse(id));
            string fileName = file.FileName;
            string extension = Path.GetExtension(fileName);
            if (extension.ToLower() != ".pdf")
            {
                result.State = UploadState.TypeNotAllow;
                result.ErrorMessage = "请选择正确的pdf文件";
                context.Response.Write(JsonConvert.SerializeObject(result));
            }
            else
            {
                var date = DateTime.Now;
                //   return AjaxResult("error","请选择正确的excel文件");
                //string result = Uploads.SaveUplaodProductImage(file);
                var filePath = "/contracts/" + model.Phone + "/" + date.ToString("yyyyMMddHHmmss") + "/" + file.FileName;
                string savePath = HttpContext.Current.Server.MapPath(filePath);//Server.MapPath 获得虚拟服务器相对路径
                if (!Directory.Exists(Path.GetDirectoryName(savePath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(savePath));
                }
                file.SaveAs(savePath);
                BLL.Student_Contract bll = new BLL.Student_Contract();
                var contract = new Model.Student_Contract();
                contract.StudentID = int.Parse(id);
                contract.Addtime = date;
                contract.FilePath = filePath;
                contract.Type = file.FileName;
                
                bll.Add(contract);
                PdfHelper.ConvertToImage(savePath, Path.GetDirectoryName(savePath) + "/", ImageFormat.Png);
                context.Response.Write(JsonConvert.SerializeObject(result));
            }
        }
    }
    public void insertToSql(DataRow dr)
    {
        BLL.OutUser bll = new BLL.OutUser();
        var _list = bll.GetModelList(" OutUserName='" + dr["馆号"].ToString() + "00" + "' and StoreNum='" + dr["馆号"].ToString() + "'");
        if (_list.Count == 0)
        {
            Model.OutUser model = new Model.OutUser()
            {
                OutUserName = dr["馆号"].ToString() + "00",
                Password = StringHelper.Tomd5("888888"),
                CardNum = "",// Request.Form["txtCardNum"].Trim().ToString();
                TrueName = dr["馆号"].ToString(),
                Activity = true,
                StoreNum = dr["馆号"].ToString(),// Request.Form["txtStoreNum"].Trim().ToString();
                UserType = 1,//Convert.ToInt32(Request.Form["listTarget"].Trim().ToString());
                State = (int)Utility.Enum.State.Normal,
                AddTime = DateTime.Now,
            };
            bll.Add(model);
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}
public class UploadResult
{
    public UploadState State { get; set; }
    public string Url { get; set; }
    public string OriginFileName { get; set; }

    public string ErrorMessage { get; set; }
}

public enum UploadState
{
    Success = 0,
    SizeLimitExceed = -1,
    TypeNotAllow = -2,
    FileAccessError = -3,
    NetworkError = -4,
    Unknown = 1,
}