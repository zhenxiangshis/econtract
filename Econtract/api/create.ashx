<%@ WebHandler Language="C#" Class="create" %>

using System;
using System.Web;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing;
using System.IO;
using System.Text;
using Utility;
using Newtonsoft.Json;
using System.Collections.Generic;

public class create : IHttpHandler
{
    //public UploadResult Result { get; private set; }
    public void ProcessRequest(HttpContext context)
    {
        ResultJson result = new ResultJson();
        context.Response.ContentType = "application/Json";
        //var actions = context.Request.Files;
        //var ss = context.Request.Form["dataUrl"];
        string dataUrl = context.Request.Params["dataUrl"].ToString();
        string phone = context.Request.Params["phone"].ToString();
        string date = context.Request.Params["date"].ToString();
        string id = context.Request.Params["id"].ToString();
        var path = "/contracts/" + phone + "/" + date + "/";
        if (File.Exists(HttpContext.Current.Server.MapPath(path + phone + ".pdf")))
        {
            result.State = 1;
            result.Url = path + phone + ".pdf";
            result.Msg = "您已经签署过合同，无需重复签署！";
        }
        else
        {

            List<ContractPage> kcxy3 = new List<ContractPage>();
            kcxy3.Add(new ContractPage() { pageid = 1, isSigure = false, x = 0, y = 0 });
            kcxy3.Add(new ContractPage() { pageid = 2, isSigure = false, x = 0, y = 0 });
            kcxy3.Add(new ContractPage() { pageid = 3, isSigure = false, x = 0, y = 0 });
            kcxy3.Add(new ContractPage() { pageid = 4, isSigure = false, x = 0, y = 0 });
            kcxy3.Add(new ContractPage() { pageid = 5, isSigure = false, x = 0, y = 0 });
            kcxy3.Add(new ContractPage() { pageid = 6, isSigure = false, x = 0, y = 0 });
            kcxy3.Add(new ContractPage() { pageid = 7, isSigure = false, x = 0, y = 0 });
            kcxy3.Add(new ContractPage() { pageid = 8, isSigure = false, x = 0, y = 0 });
            kcxy3.Add(new ContractPage() { pageid = 9, isSigure = false, x = 0, y = 0 });
            kcxy3.Add(new ContractPage() { pageid = 10, isSigure = true, x = 827, y = 1320 });
            //var s =path + "/sigure.png";
            var s = PicHelper.decodeBase64ToImage(dataUrl, path + "/sigure.png");

            Draw(s, path, kcxy3);
            CreatePDFDoc(path, phone, kcxy3);

            result.State = 0;
            result.Url = path + phone + ".pdf";
            result.Msg = "签署成功,点击预览！";
            BLL.Student_Contract bll = new BLL.Student_Contract();
            var contract = bll.GetModel(int.Parse(id));
            contract.ContractFile = result.Url;
            contract.CreateTime = DateTime.Now;
            var issuc = bll.Update(contract);
            LogHelper.WriteLog(contract.Type + "协议签署完成，注意查看！");
            //QYWechatBotApi.SendText(contract.Type + "协议签署完成，注意查看！");

        }
        context.Response.Write(JsonConvert.SerializeObject(result));
    }

    /// <summary>
    /// 生成签名合同图片
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public UploadResult Draw(string pic, string path, List<ContractPage> listpage)
    {
        var Result = new UploadResult();
        try
        {
            //获取签名图片的绝对路径
            string logourl = HttpContext.Current.Server.MapPath(pic);
            //调整签名图片的尺寸（此处设置固定宽度等比缩放）
            System.Drawing.Image sigure = PicHelper.ReduceImage(logourl, 280, -1);
            //将需要签名的图片和签名合成
            foreach (var page in listpage)
            {
                if (page.isSigure)
                {
                    ImgMix(sigure, path + page.pageid + ".png", page.x, page.y, path + page.pageid + "s.png");
                }
            }
            Result.State = UploadState.Success;
            //Result.Url = billpath;
            return Result;
        }
        catch (Exception exp)
        {
            Result.State = UploadState.Unknown;
            Result.ErrorMessage = exp.Message;
            return Result;
        }
    }
    /// <summary>
    /// 图片合成
    /// </summary>
    /// <param name="img">需要绘入的图片</param>
    /// <param name="inpath">原始路径</param>
    /// <param name="x">绘制的位置x</param>
    /// <param name="y">绘制的位置y</param>
    /// <param name="outpath">合成保存的路径</param>
    /// <returns>操作是否成功</returns>
    public bool ImgMix(System.Drawing.Image img, string inpath, int x, int y, string outpath)
    {
        try
        {
            //原始图片路径
            string _inpath = HttpContext.Current.Server.MapPath(inpath);
            System.Drawing.Image imgSrc = System.Drawing.Image.FromFile(_inpath);
            using (Graphics g = Graphics.FromImage(imgSrc))
            {
                //画上签名图片
                g.DrawImage(img, x, y, img.Width, img.Height);
            }
            //输出图片路径
            string _outpath = HttpContext.Current.Server.MapPath(outpath);
            imgSrc.Save(_outpath, System.Drawing.Imaging.ImageFormat.Jpeg);
            imgSrc.Dispose();
            return true;
        }
        catch (Exception exp)
        {
            return false;
        }
    }

    private ResultJson CreatePDFDoc(string path, string phone, List<ContractPage> listpage)
    {
        ResultJson result = new ResultJson();
        try
        {
            Document document = new Document(PageSize.A4, 40, 40, 30, 30);
            string filename = path + phone + ".pdf";
            PdfWriter.GetInstance(document, new FileStream(HttpContext.Current.Server.MapPath(filename), FileMode.Create));
            document.Open();
            var width = 510;
            var height = 720;
            Paragraph p = new Paragraph();
            foreach (var page in listpage)
            {
                //需要签名，将签名后的图片插入pdf
                if (page.isSigure)
                {
                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path + page.pageid + "s.png"));
                    img.ScaleAbsolute(width, height);
                    p.Add(img);
                }
                else
                {
                    //不需要签名，将图片直接插入pdf
                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path + page.pageid + ".png"));
                    img.ScaleAbsolute(width, height);
                    p.Add(img);
                }
            }

            p.Alignment = Element.ALIGN_CENTER;
            //img1.Alignment = Element.ALIGN_CENTER;
            document.Add(p);
            document.Close();
            result.State = 0;
            result.Url = filename;
            result.Msg = "";

        }
        catch (Exception ex)
        {
            result.State = -1;
            result.Url = "";
            result.Msg = ex.Message;
        }
        return result;
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
    /// <summary>
    /// 上传结果
    /// </summary>
    public class UploadResult
    {
        /// <summary>
        /// 上传状态
        /// </summary>
        public UploadState State { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OriginFileName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ImgUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ErrorMessage { get; set; }
    }
    public class ResultJson
    {
        public int State { get; set; }
        public string Url { get; set; }
        public string Msg { get; set; }
    }
    /// <summary>
    /// 合同页
    /// </summary>
    public class ContractPage
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int pageid { get; set; }
        /// <summary>
        /// 是否需要签名
        /// </summary>
        public bool isSigure { get; set; }
        /// <summary>
        /// 签名位置x
        /// </summary>
        public int x { get; set; }
        /// <summary>
        /// 签名位置y
        /// </summary>
        public int y { get; set; }
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
}
