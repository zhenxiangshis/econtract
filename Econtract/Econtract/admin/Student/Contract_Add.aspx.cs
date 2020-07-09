using iTextSharp.text.pdf;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility;

namespace qihang.admin.Student
{
    public partial class Contract_Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = base.Request.Params["sid"];
            BLL.Student_Info BllStudent = new BLL.Student_Info();
            if ((s == null) || (s.Trim() == ""))
            {
                setCookie("warning", "参数错误!");
                Request.UrlReferrer.ToString();
                base.Response.Redirect(Request.UrlReferrer.ToString(), false);
            }
            else
            {
                if (Request.HttpMethod == "POST")
                {
                    try
                    {
                        var model = new BLL.Student_Info().GetModel(int.Parse(s));
                        var date = DateTime.Now;
                        var temppath = Request.Form["listClass"].Trim().ToString();
                        var filePath = "/contracts/" + model.Phone + "/" + date.ToString("yyyyMMddHHmmss") + "/" + Request.Form["txtName"].Trim().ToString() + ".pdf";
                        BLL.Student_Contract bll = new BLL.Student_Contract();
                        var contract = new Model.Student_Contract();
                        contract.StudentID = int.Parse(s);
                        contract.Addtime = date;
                        contract.FilePath = filePath;
                        contract.Type = Request.Form["txtName"].Trim().ToString();
                        CreatePDF(temppath, filePath, model);
                        PdfHelper.ConvertToImage(HttpContext.Current.Server.MapPath(filePath), Path.GetDirectoryName(HttpContext.Current.Server.MapPath(filePath)) + "/", ImageFormat.Png);

                        bll.Add(contract);
                        var shorturl = ShortUrlHelper.AddUrl("/weixin/contract.html?m=" + model.Phone + "&d=" + contract.Addtime.ToString("yyyyMMddHHmmss") + "&i=" + contract.ContractID);
                        var url = "/v.aspx?u=" + shorturl;
                        contract.Url = url;
                        var issuc = bll.Update(contract);
                        if (issuc)
                        {
                            QYWechatBotApi.SendText(model.Name + "同学，欢迎您加入起航教育，在正式开始学习前，您需要签署服务协议，以保障您的合法权益，请点击下面的签署链接完成协议签署！（http://" + Request.Url.Host + url + "）【起航教育】");
                        }
                    }
                    catch (Exception ex)
                    {
                        setCookie("error", HttpUtility.HtmlEncode(ex.Message));
                    }
                    base.Response.Redirect("Contract_List.aspx?id=" + s, false);
                }
                else
                {

                    base.Response.Redirect("Contract_List.aspx?id=" + s, false);
                }
            }
        }
        /// <summary>
        /// 填充文本域
        /// </summary>
        /// <param name="temp"></param>
        /// <param name="outfile"></param>
        /// <param name="student"></param>
        public void CreatePDF(string temp, string outfile, Model.Student_Info student)
        {
            BaseFont bfChinese = BaseFont.CreateFont("C:\\WINDOWS\\Fonts\\simsun.ttc,1", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            //获取PDF模板文件
            string templateFile = HttpContext.Current.Server.MapPath(temp);
            //输出生成的PDF文件
            string tempPDF = HttpContext.Current.Server.MapPath(outfile);
            if (!Directory.Exists(Path.GetDirectoryName(tempPDF)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(tempPDF));
            }
            //创建 PdfReader
            PdfReader reader = new PdfReader(templateFile);
            FileStream fFileStream = new FileStream(tempPDF, FileMode.Create);

            //进行PDF字段操作
            PdfStamper stamper = new PdfStamper(reader, fFileStream);
            AcroFields coderBlogForm = stamper.AcroFields;


            //填充PDF里的字段内容
            if (!string.IsNullOrEmpty(student.Name))
            {
                coderBlogForm.SetFieldProperty("name", "textfont", bfChinese, null);
                coderBlogForm.SetField("name", student.Name);
            }
            if (!string.IsNullOrEmpty(student.Sex))
            {
                coderBlogForm.SetFieldProperty("sex", "textfont", bfChinese, null);
                coderBlogForm.SetField("sex", student.Sex);
            }
            if (!string.IsNullOrEmpty(student.Birthday))
            {
                //coderBlogForm.SetFieldProperty("chushengriqi", "textfont", bfChinese, null);
                coderBlogForm.SetField("birthday", student.Birthday);
            }
            if (!string.IsNullOrEmpty(student.Education))
            {
                coderBlogForm.SetFieldProperty("educationCode", "textfont", bfChinese, null);
                coderBlogForm.SetField("educationCode", student.Education);
            }
            if (!string.IsNullOrEmpty(student.EduType))
            {
                coderBlogForm.SetFieldProperty("eduForm", "textfont", bfChinese, null);
                coderBlogForm.SetField("eduForm", student.EduType);
            }
            if (!string.IsNullOrEmpty(student.Major))
            {
                coderBlogForm.SetFieldProperty("major", "textfont", bfChinese, null);
                coderBlogForm.SetField("major", student.Major);
            }
            if (!string.IsNullOrEmpty(student.GraduationTime))
            {
                coderBlogForm.SetFieldProperty("biyeshijian", "textfont", bfChinese, null);
                coderBlogForm.SetField("biyeshijian", student.GraduationTime);
            }
            if (!string.IsNullOrEmpty(student.Address))
            {
                coderBlogForm.SetFieldProperty("address", "textfont", bfChinese, null);
                coderBlogForm.SetField("address", student.Address);
            }
            //coderBlogForm.SetFieldProperty("youbian", "textfont", bfChinese, null);
            //coderBlogForm.SetField("youbian", student.Zipcode);

            coderBlogForm.SetFieldProperty("documentTypeCode", "textfont", bfChinese, null);
            coderBlogForm.SetField("documentTypeCode", "身份证");
            if (!string.IsNullOrEmpty(student.IDCard))
            {
                coderBlogForm.SetFieldProperty("documentNumber", "textfont", bfChinese, null);
                coderBlogForm.SetField("documentNumber", student.IDCard);
            }
            if (!string.IsNullOrEmpty(student.Phone))
            {
                coderBlogForm.SetFieldProperty("account", "textfont", bfChinese, null);
                coderBlogForm.SetField("account", student.Phone);
            }
            if (!string.IsNullOrEmpty(student.TelPhone))
            {
                coderBlogForm.SetFieldProperty("gudingdianhua", "textfont", bfChinese, null);
                coderBlogForm.SetField("gudingdianhua", student.TelPhone);
            }
            if (!string.IsNullOrEmpty(student.Email))
            {
                coderBlogForm.SetFieldProperty("email", "textfont", bfChinese, null);
                coderBlogForm.SetField("email", student.Email);
            }
            if (!string.IsNullOrEmpty(student.QQ))
            {
                coderBlogForm.SetFieldProperty("qq", "textfont", bfChinese, null);
                coderBlogForm.SetField("qq", student.QQ);
            }
            if (!string.IsNullOrEmpty(student.LinkName))
            {
                coderBlogForm.SetFieldProperty("contact", "textfont", bfChinese, null);
                coderBlogForm.SetField("contact", student.LinkName);
            }
            if (!string.IsNullOrEmpty(student.LinkPhone))
            {
                coderBlogForm.SetFieldProperty("contactPhone", "textfont", bfChinese, null);
                coderBlogForm.SetField("contactPhone", student.LinkPhone);
            }
            if (!string.IsNullOrEmpty(student.Money.ToString()))
            {
                coderBlogForm.SetFieldProperty("payableAmount", "textfont", bfChinese, null);
                coderBlogForm.SetField("payableAmount", "￥" + student.Money);
            }

            coderBlogForm.SetFieldProperty("serviceStartTime", "textfont", bfChinese, null);
            coderBlogForm.SetField("serviceStartTime", DateTime.Now.ToString("yyyy/MM/dd"));

            coderBlogForm.SetFieldProperty("serviceEndTime", "textfont", bfChinese, null);
            coderBlogForm.SetField("serviceEndTime", DateTime.Now.AddYears(1).AddDays(-1).ToString("yyyy/MM/dd"));

            if (!string.IsNullOrEmpty(student.PayMethod))
            {
                coderBlogForm.SetFieldProperty("priceD", "textfont", bfChinese, null);
                coderBlogForm.SetField("priceD", StringHelper.MoneyToChinese(student.Money.ToString()));
            }
            if (!string.IsNullOrEmpty(student.PayMethod))
            {
                coderBlogForm.SetFieldProperty("payName", "textfont", bfChinese, null);
                coderBlogForm.SetField("payName", student.PayMethod);
            }
            if (!string.IsNullOrEmpty(student.ClassName))
            {
                coderBlogForm.SetFieldProperty("proname", "textfont", bfChinese, null);
                coderBlogForm.SetField("proname", student.ClassName);
            }

            coderBlogForm.SetFieldProperty("examDate", "textfont", bfChinese, null);
            coderBlogForm.SetField("examDate", DateTime.Now.ToString("yyyy年MM月dd日"));

            stamper.FormFlattening = true;
            //using(Stream inputPdfStream = new FileStream(HttpContext.Current.Server.MapPath("~") + "/pdfimage/ceshi1.pdf", FileMode.Open, FileAccess.Read, FileShare.Read))
            //using (Stream inputImageStream = new FileStream(HttpContext.Current.Server.MapPath("~") + "/upload/image/20191022/6370735446277096576364516.jpg", FileMode.Open, FileAccess.Read, FileShare.Read))
            //using (Stream outputPdfStream = new FileStream(HttpContext.Current.Server.MapPath("~") + "/pdfimage/ceshi2.pdf", FileMode.Create, FileAccess.Write, FileShare.None))
            //{
            //    //var reader = new PdfReader(inputPdfStream);
            //    //var stamper = new PdfStamper(reader, outputPdfStream);
            //    var pdfContentByte = stamper.GetOverContent(1);

            //    Image image = Image.GetInstance(inputImageStream);
            //    image.SetAbsolutePosition(100, 100);
            //    pdfContentByte.AddImage(image);
            //    stamper.Close();
            //}
            stamper.FormFlattening = true;
            //return File(HttpContext.Current.Server.MapPath("~") + "/pdfimage/ceshi2.pdf", "application/pdf", "TableDemo.pdf");
            if (stamper != null)
            {
                stamper.Close();
            }
            if (reader != null)
            {
                reader.Close();
            }
            if (fFileStream != null)
            {
                fFileStream.Close();
                fFileStream.Dispose();
            }


        }
        protected void setCookie(string e, string s)
        {
            s = Server.UrlEncode(s);
            string _err = "{0}\"err\":\"{2}\",\"msg\":\"{3}\" {1}";
            //获取客户端的Cookie对象
            HttpCookie cok = Request.Cookies["Exception"];

            if (cok != null)
            {
                //修改Cookie的两种方法
                cok.Value = string.Format(_err, "{", "}", e, s);
                Response.AppendCookie(cok);
            }
            else
            {
                HttpCookie cookie = new HttpCookie("Exception");//初使化并设置Cookie的名称
                cookie.Value = string.Format(_err, "{", "}", e, s);
                Response.AppendCookie(cookie);
            }
        }
    }
}