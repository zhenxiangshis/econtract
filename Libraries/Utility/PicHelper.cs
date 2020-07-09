using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Configuration;
using System.IO;
using ASPJPEGLib;
using System.Drawing;
using System.Net;
using System.Text.RegularExpressions;
using System.Linq;
using System.Drawing.Imaging;

namespace Utility
{
    public class PicHelper
    {
        // Methods
        public PicHelper() { }
        private static void ToMarkWater(string SourceFileName, string MarkFileNameBig, string MarkFileNameSmall, string SaveFileName, int WType)
        {
            string UserMarkFileName = "";
            int space = 0;
            try
            {
                int WidthS;
                int HeightS;
                IASPJpeg objJpegS;
                IASPJpeg objJpegM;
                if (WType == 2)
                {
                    objJpegS = new ASPJpegClass();
                    objJpegM = new ASPJpegClass();
                    objJpegS.Open(SourceFileName);
                    WidthS = objJpegS.OriginalWidth;
                    HeightS = objJpegS.OriginalHeight;
                    if ((WidthS >= 200) && (HeightS >= 100))
                    {
                        UserMarkFileName = MarkFileNameBig;
                        space = 10;
                    }
                    else if ((WidthS >= 60) && (HeightS >= 30))
                    {
                        UserMarkFileName = MarkFileNameSmall;
                        space = 1;
                    }
                    else
                    {
                        objJpegS.Save(SaveFileName);
                        objJpegS.Close();
                    }
                    objJpegM.Open(UserMarkFileName);
                    int WidthM = objJpegM.OriginalWidth;
                    int HeightM = objJpegM.OriginalHeight;
                    if ((WidthS > (WidthM + space)) && (HeightS > (HeightM + space)))
                    {
                        objJpegS.Canvas.DrawImage((WidthS - WidthM) - space, (HeightS - HeightM) - space, (ASPJpeg)objJpegM, 0.1, "&HFF0000", 10);
                    }
                    objJpegS.Save(SaveFileName);
                    objJpegS.Close();
                    objJpegM.Close();
                }
                else
                {
                    objJpegS = new ASPJpegClass();
                    objJpegM = new ASPJpegClass();
                    objJpegS.Open(SourceFileName);
                    WidthS = objJpegS.OriginalWidth;
                    HeightS = objJpegS.OriginalHeight;
                    objJpegS.Canvas.Font.Family = "Arial";
                    objJpegS.Canvas.Font.ShadowXoffset = 1;
                    objJpegS.Canvas.Font.ShadowYoffset = 1;
                    objJpegS.Canvas.Font.Color = 0xffffff;
                    objJpegS.Canvas.Font.ShadowColor = 0xcccccc;
                    objJpegS.Canvas.Font.Quality = 10;
                    objJpegS.Canvas.Brush.Solid = 1;
                    objJpegS.Canvas.Font.Bold = 1;
                    objJpegS.Canvas.Font.Size = 40;
                    objJpegS.Canvas.PrintText(WidthS - (WidthS - 120), HeightS - 50, "www.5dgz.com", null);
                    objJpegS.Save(SaveFileName);
                    objJpegS.Close();
                    IASPJpeg objJpegA = new ASPJpegClass();
                    objJpegA.Open(SourceFileName);
                    objJpegM.Open(SaveFileName);
                    objJpegA.Canvas.DrawImage(0, 0, (ASPJpeg)objJpegM, 0.6, "&HFF0000", 10);
                    objJpegA.Save(SaveFileName);
                    objJpegA.Close();
                    objJpegM.Close();
                }
            }
            catch
            {
            }
        }

        private static void ToThumbNail(string strFileName, int NewWidth, int NewHeight, string strContentType, string strNFileName)
        {
            try
            {
                IASPJpeg objJpeg = new ASPJpegClass();
                objJpeg.Open(strFileName);
                double rate = 0.0;
                double WidthSource = objJpeg.OriginalWidth;
                double HeightSource = objJpeg.OriginalHeight;
                objJpeg.Interpolation = 0;
                objJpeg.Quality = 100;
                if ((WidthSource <= NewWidth) && (HeightSource <= NewHeight))
                {
                    rate = 1.0;
                }
                else
                {
                    double rateW = ((double)NewWidth) / WidthSource;
                    double rateH = ((double)NewHeight) / HeightSource;
                    if (rateW > rateH)
                    {
                        rate = rateH;
                    }
                    else
                    {
                        rate = rateW;
                    }
                }
                double WidthSource2 = (int)(WidthSource * rate);
                double HeightSource2 = (int)(HeightSource * rate);
                if ((HeightSource2 < NewHeight) && (WidthSource2 >= NewWidth))
                {
                    objJpeg.Width = (int)(WidthSource * (((double)NewHeight) / HeightSource));
                    objJpeg.Height = (int)(HeightSource * (((double)NewHeight) / HeightSource));
                    objJpeg.Crop(0, 0, NewWidth, NewHeight);
                }
                else if (HeightSource2 > NewHeight)
                {
                    objJpeg.Width = (int)(WidthSource * (((double)NewHeight) / HeightSource));
                    objJpeg.Height = (int)(HeightSource * (((double)NewHeight) / HeightSource));
                    objJpeg.Crop(0, 0, NewWidth, NewHeight);
                }
                else if ((WidthSource2 < NewWidth) && (HeightSource2 >= NewHeight))
                {
                    objJpeg.Width = (int)(WidthSource * (((double)NewWidth) / WidthSource));
                    objJpeg.Height = (int)(HeightSource * (((double)NewWidth) / WidthSource));
                    objJpeg.Crop(0, 0, NewWidth, NewHeight);
                }
                else if (WidthSource2 > NewWidth)
                {
                    objJpeg.Width = (int)(WidthSource * (((double)NewWidth) / WidthSource));
                    objJpeg.Height = (int)(HeightSource * (((double)NewWidth) / WidthSource));
                    objJpeg.Crop(0, 0, NewWidth, NewHeight);
                }
                else
                {
                    objJpeg.Width = (int)(WidthSource * rate);
                    objJpeg.Height = (int)(HeightSource * rate);
                }
                objJpeg.Save(strNFileName);
                objJpeg.Close();
            }
            catch
            {
            }
        }

        public static string UploadLogo(HttpPostedFile oFile)
        {
            try
            {
                if (Path.GetFileName(oFile.FileName) != "")
                {
                    string FileTxt = Path.GetExtension(oFile.FileName);
                    string nFileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
                    Random sran = new Random();
                    string Rand = sran.Next(1, 9).ToString();
                    string sFileName = nFileName + Rand + FileTxt;
                    string reFileName = sFileName;
                    string sFilePath = ConfigurationManager.AppSettings["FCKeditor:LogoFilesPath"];
                    sFilePath = sFilePath + "/" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "/";
                    FileHelper.CreateFolder(sFilePath);
                    string reFilePath = sFilePath;
                    string strFilePath = Path.Combine(HttpContext.Current.Server.MapPath(sFilePath), sFileName);
                    oFile.SaveAs(strFilePath);
                    return (reFilePath + "|" + reFileName);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public static string UploadPic(HttpPostedFile oFile, int IsWater)
        {
            try
            {
                if (Path.GetFileName(oFile.FileName) != "")
                {
                    string FileTxt = Path.GetExtension(oFile.FileName);
                    string nFileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
                    Random sran = new Random();
                    string Rand = sran.Next(1, 9).ToString();
                    string sFileName = nFileName + Rand + FileTxt;
                    string reFileName = sFileName;
                    string sFilePath = ConfigurationManager.AppSettings["FCKeditor:UserFilesPath"];
                    if (IsWater == 2)
                    {
                        sFilePath = ConfigurationManager.AppSettings["Education"];
                    }
                    sFilePath = sFilePath + "/" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "/";
                    FileHelper.CreateFolder(sFilePath);
                    string reFilePath = sFilePath;
                    sFilePath = HttpContext.Current.Server.MapPath(sFilePath);
                    string strFilePath = Path.Combine(sFilePath, sFileName);
                    oFile.SaveAs(strFilePath);
                    if (((FileTxt.ToLowerInvariant() == ".jpg") || (FileTxt.ToLowerInvariant() == ".gif")) || (FileTxt.ToLowerInvariant() == ".bmp"))
                    {
                        string tFilePath = sFilePath + "189X132" + sFileName;
                        ToThumbNail(strFilePath, 0xbd, 0x84, FileTxt, tFilePath);
                        tFilePath = sFilePath + "109X75" + sFileName;
                        ToThumbNail(strFilePath, 0x6d, 0x4b, FileTxt, tFilePath);
                        tFilePath = sFilePath + "119_90_" + sFileName;
                        ToThumbNail(strFilePath, 0x77, 90, FileTxt, tFilePath);
                        if (IsWater == 1)
                        {
                            string strw = HttpContext.Current.Server.MapPath("/UpLoad/") + "w.gif";
                            if (ConfigurationManager.AppSettings["WaterMark"].ToString() == "1")
                            {
                                string wFilePath = sFilePath + "W" + sFileName;
                                ToMarkWater(strFilePath, strw, strw, wFilePath, 1);
                            }
                        }
                    }
                    return (reFilePath + "|" + reFileName);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public static string UploadPro(HttpPostedFile oFile, int IsWater)
        {
            try
            {
                if (Path.GetFileName(oFile.FileName) != "")
                {
                    string FileTxt = Path.GetExtension(oFile.FileName);
                    string nFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    Random sran = new Random();
                    string Rand = sran.Next(1, 9).ToString();
                    string sFileName = nFileName + Rand + FileTxt;
                    string reFileName = sFileName;
                    string sFilePath = ConfigurationManager.AppSettings["FCKeditor:UserFilesPath"];
                    sFilePath = sFilePath + "/Pro/" + DateTime.Now.ToString("yyyy-MM") + "/";
                    FileHelper.CreateFolder(sFilePath);
                    string reFilePath = sFilePath;
                    sFilePath = HttpContext.Current.Server.MapPath(sFilePath);
                    string strFilePath = Path.Combine(sFilePath, sFileName);
                    oFile.SaveAs(strFilePath);
                    if (((FileTxt.ToLowerInvariant() == ".jpg") || (FileTxt.ToLowerInvariant() == ".gif")) || (FileTxt.ToLowerInvariant() == ".bmp"))
                    {
                        string tFilePath = sFilePath + "189X127" + sFileName;
                        ToThumbNail(strFilePath, 0xbd, 0x7f, FileTxt, tFilePath);
                        tFilePath = sFilePath + "126X105" + sFileName;
                        ToThumbNail(strFilePath, 0x7e, 0x69, FileTxt, tFilePath);
                        if (IsWater == 1)
                        {
                            string strw = HttpContext.Current.Server.MapPath("/UpLoad/") + "w.gif";
                            if (ConfigurationManager.AppSettings["WaterMark"].ToString() == "1")
                            {
                                string wFilePath = sFilePath + "W" + sFileName;
                                ToMarkWater(strFilePath, strw, strw, wFilePath, 1);
                            }
                        }
                    }
                    return (reFilePath + "|" + reFileName);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public static string UploadArticle(HttpPostedFile oFile, int IsWater)
        {
            try
            {
                if (Path.GetFileName(oFile.FileName) != "")
                {
                    string FileTxt = Path.GetExtension(oFile.FileName);
                    string nFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    Random sran = new Random();
                    string Rand = sran.Next(1, 9).ToString();
                    string sFileName = nFileName + Rand + FileTxt;
                    string reFileName = sFileName;
                    string sFilePath = ConfigurationManager.AppSettings["FCKeditor:UserFilesPath"];
                    if (IsWater == 2)
                    {
                        sFilePath = ConfigurationManager.AppSettings["Education"];
                    }
                    sFilePath = sFilePath + "/" + DateTime.Now.ToString("yyyyMM") + "/";
                    FileHelper.CreateFolder(sFilePath);
                    string reFilePath = sFilePath;
                    sFilePath = HttpContext.Current.Server.MapPath(sFilePath);
                    string strFilePath = Path.Combine(sFilePath, sFileName);
                    oFile.SaveAs(strFilePath);
                    if (((FileTxt.ToLowerInvariant() == ".jpg") || (FileTxt.ToLowerInvariant() == ".gif")) || (FileTxt.ToLowerInvariant() == ".bmp"))
                    {
                        string tFilePath = sFilePath + "189X132" + sFileName;
                        ToThumbNail(strFilePath, 0xbd, 0x84, FileTxt, tFilePath);
                        tFilePath = sFilePath + "109X75" + sFileName;
                        ToThumbNail(strFilePath, 0x6d, 0x4b, FileTxt, tFilePath);
                        tFilePath = sFilePath + "119_90_" + sFileName;
                        ToThumbNail(strFilePath, 0x77, 90, FileTxt, tFilePath);
                        if (IsWater == 1)
                        {
                            string strw = HttpContext.Current.Server.MapPath("/UpLoad/") + "w.gif";
                            if (ConfigurationManager.AppSettings["WaterMark"].ToString() == "1")
                            {
                                string wFilePath = sFilePath + "W" + sFileName;
                                ToMarkWater(strFilePath, strw, strw, wFilePath, 1);
                            }
                        }
                    }
                    return (reFilePath + reFileName);
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static string UploadWenXuan(HttpPostedFile oFile, int IsWater)
        {
            try
            {
                if (Path.GetFileName(oFile.FileName) != "")
                {
                    string FileTxt = Path.GetExtension(oFile.FileName);
                    string nFileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
                    Random sran = new Random();
                    string Rand = sran.Next(1, 9).ToString();
                    string sFileName = nFileName + Rand + FileTxt;
                    string reFileName = sFileName;
                    string sFilePath = ConfigurationManager.AppSettings["FCKeditor:UserFilesPath"];
                    sFilePath = sFilePath + "/" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "/";
                    FileHelper.CreateFolder(sFilePath);
                    string reFilePath = sFilePath;
                    sFilePath = HttpContext.Current.Server.MapPath(sFilePath);
                    string strFilePath = Path.Combine(sFilePath, sFileName);
                    oFile.SaveAs(strFilePath);
                    if (((FileTxt.ToLowerInvariant() == ".jpg") || (FileTxt.ToLowerInvariant() == ".gif")) || (FileTxt.ToLowerInvariant() == ".bmp"))
                    {
                        string tFilePath = sFilePath + "189X132" + sFileName;
                        ToThumbNail(strFilePath, 0xbd, 0x84, FileTxt, tFilePath);
                        tFilePath = sFilePath + "109X75" + sFileName;
                        ToThumbNail(strFilePath, 0x6d, 0x4b, FileTxt, tFilePath);
                        tFilePath = sFilePath + "119_90_" + sFileName;
                        ToThumbNail(strFilePath, 0x77, 90, FileTxt, tFilePath);
                        if (IsWater == 1)
                        {
                            string strw = HttpContext.Current.Server.MapPath("/UpLoad/") + "w.gif";
                            if (ConfigurationManager.AppSettings["WaterMark"].ToString() == "1")
                            {
                                string wFilePath = sFilePath + "W" + sFileName;
                                ToMarkWater(strFilePath, strw, strw, wFilePath, 1);
                            }
                        }
                    }
                    return (reFilePath + reFileName);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        public static string UploadFlash(HttpPostedFile oFile)
        {
            try
            {
                if (Path.GetFileName(oFile.FileName) != "")
                {
                    string FileTxt = Path.GetExtension(oFile.FileName);
                    string nFileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
                    Random sran = new Random();
                    string Rand = sran.Next(1, 9).ToString();
                    string sFileName = nFileName + Rand + FileTxt;
                    string reFileName = sFileName;
                    string sFilePath = ConfigurationManager.AppSettings["FCKeditor:UserFlashPath"];
                    sFilePath = sFilePath + "/" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "/";
                    FileHelper.CreateFolder(sFilePath);
                    string reFilePath = sFilePath;
                    sFilePath = HttpContext.Current.Server.MapPath(sFilePath);
                    string strFilePath = Path.Combine(sFilePath, sFileName);
                    oFile.SaveAs(strFilePath);
                    if (FileTxt.ToLowerInvariant() == ".swf")
                    {
                        string tFilePath = sFilePath + "189X132" + sFileName;
                        ToThumbNail(strFilePath, 0xbd, 0x84, FileTxt, tFilePath);
                        tFilePath = sFilePath + "109X75" + sFileName;
                        ToThumbNail(strFilePath, 0x6d, 0x4b, FileTxt, tFilePath);
                        tFilePath = sFilePath + "119_90_" + sFileName;
                        ToThumbNail(strFilePath, 0x77, 90, FileTxt, tFilePath);
                        //if (IsWater == 1)
                        //{
                        //    string strw = HttpContext.Current.Server.MapPath("/UpLoad/") + "w.gif";
                        //    if (ConfigurationManager.AppSettings["WaterMark"].ToString() == "1")
                        //    {
                        //        string wFilePath = sFilePath + "W" + sFileName;
                        //        ToMarkWater(strFilePath, strw, strw, wFilePath, 1);
                        //    }
                        //}
                    }
                    return (reFilePath + reFileName);
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// 指定图片添加指定文字
        /// </summary>
        /// <param name="fileName">指定文件路径</param>
        /// <param name="text">添加的文字</param>
        /// <param name="picname">生成文件名</param>

        private void AddToImg(string file, string text, string picname)
        {
            //判断指定图片是否存在
            //if (!File.Exists(MapPath(fileName)))
            //{
            //    throw new FileNotFoundException("The file don't exist!");
            //}

            //if (text == string.Empty)
            //{
            //    return;
            //}


            System.Drawing.Image image = System.Drawing.Image.FromFile(file);
            Bitmap bitmap = new Bitmap(image, image.Width, image.Height);
            Graphics g = Graphics.FromImage(bitmap);

            float fontSize = 40.0f;             //字体大小
            float textWidth = text.Length * fontSize;  //文本的长度
            //下面定义一个矩形区域，以后在这个矩形里画上白底黑字
            float rectX = 120;
            float rectY = 200;
            float rectWidth = 200;  // text.Length * (fontSize + 40);
            float rectHeight = fontSize + 40;
            //声明矩形域
            RectangleF textArea = new RectangleF(rectX, rectY, 270, 270);



            Font font = new Font("华文隶书", fontSize, FontStyle.Bold);   //定义字体
            Font font2 = new Font("楷体", fontSize, FontStyle.Bold);   //定义字体
            //font.Bold = true;

            Brush whiteBrush = new SolidBrush(Color.DodgerBlue);   //白笔刷，画文字用
            //Brush blackBrush = new SolidBrush(Color.Black);   //黑笔刷，画背景用

            //g.FillRectangle(blackBrush, rectX, rectY, rectWidth, rectHeight);

            g.DrawString(text, font, whiteBrush, textArea, StringFormat.GenericDefault);

            g.DrawString(text, font, whiteBrush, new RectangleF(rectX, image.Height / 2, 270, 270));

            g.DrawString("168元", font2, new SolidBrush(Color.Firebrick), new RectangleF(rectX, image.Height - 150, rectWidth, rectHeight));

            ////-------------------  绘制高质量 -------------------------------------------
            //设置 System.Drawing.Graphics对象的SmoothingMode属性为HighQuality 
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //下面这个也设成高质量 
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            //下面这个设成High 
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //画专属推广二维码
            System.Drawing.Image qrCodeImage = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath(@"/Content/images/money-cards.png"));
            g.DrawImage(qrCodeImage, new Rectangle(image.Width - qrCodeImage.Width - 200,
            image.Height - qrCodeImage.Height - 200,
            qrCodeImage.Width,
            qrCodeImage.Height),
            0, 0, qrCodeImage.Width, qrCodeImage.Height, GraphicsUnit.Pixel);
            //画微信昵称
            g.DrawString("小马快跑", font, new SolidBrush(Color.Red), new Rectangle(image.Width - qrCodeImage.Width - 200,
            image.Height - qrCodeImage.Height - 300,
            qrCodeImage.Width + 100,
            50));

            MemoryStream ms = new MemoryStream();

            //输出方法一：将文件生成并保存到C盘
            string path = "D:\\test\\" + picname + ".png";
            bitmap.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);


            //输出方法二，显示在网页中，保存为Jpg类型
            //bitmap.Save(ms, ImageFormat.Jpeg);
            //Response.Clear();
            //Response.ContentType = "image/jpeg";
            //Response.BinaryWrite(ms.ToArray());

            g.Dispose();
            bitmap.Dispose();
            image.Dispose();
        }
        /// <summary>
        /// 生成带二维码的专属推广图片
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static string Draw(Image qrCodeImages)
        {
            //背景图片
            string path = HttpContext.Current.Server.MapPath("/Content/images/time.jpg");
            string path2 = HttpContext.Current.Server.MapPath("/Content/images/112.png");
            System.Drawing.Image imgSrc = System.Drawing.Image.FromFile(path);

            //处理二维码图片大小 240*240px
            System.Drawing.Image qrCodeImage = ReduceImage(qrCodeImages, 240, 240);
            //Image img=Image.
            //处理头像图片大小 100*100px
            Image titleImage = ReduceImage(path2, 710, 710);

            using (Graphics g = Graphics.FromImage(imgSrc))
            {
                //g.DrawRectangle(new Pen(new SolidBrush(Color.Red)), new Rectangle(0, 0, 750, 750));

                //画专属推广二维码
                g.DrawImage(qrCodeImage, new Rectangle(imgSrc.Width - qrCodeImage.Width - 50,
                imgSrc.Height - qrCodeImage.Height - 40,
                qrCodeImage.Width,
                qrCodeImage.Height),
                0, 0, qrCodeImage.Width, qrCodeImage.Height, GraphicsUnit.Pixel);

                g.DrawImage(titleImage, 20, 20, titleImage.Width, titleImage.Height);
                //画头像
                //g.DrawImage(titleImage, 8, 8, titleImage.Width, titleImage.Height);
                Font font = new Font("宋体", 30, FontStyle.Bold);
                g.DrawString("1111", font, new SolidBrush(Color.Red), 110, 10);
            }
            string newpath = HttpContext.Current.Server.MapPath(@"/Content/images/newtg_" + Guid.NewGuid().ToString() + ".jpg");
            imgSrc.Save(newpath, System.Drawing.Imaging.ImageFormat.Jpeg);
            return newpath;
        }
        /// <summary>
        /// 缩小/放大图片
        /// </summary>
        /// <param name="url">图片网络地址</param>
        /// <param name="toWidth">缩小/放大宽度</param>
        /// <param name="toHeight">缩小/放大高度</param>
        /// <returns></returns>
        public static Image ReduceImage(string url, int toWidth, int toHeight)
        {
            Image originalImage = Image.FromFile(url);
            if (toWidth <= 0 && toHeight <= 0)
            {
                return originalImage;
            }
            else if (toWidth > 0 && toHeight > 0)
            {
                if (originalImage.Width < toWidth && originalImage.Height < toHeight)
                    return originalImage;
            }
            else if (toWidth <= 0 && toHeight > 0)
            {
                if (originalImage.Height < toHeight)
                    return originalImage;
                toWidth = originalImage.Width * toHeight / originalImage.Height;
            }
            else if (toHeight <= 0 && toWidth > 0)
            {
                if (originalImage.Width < toWidth)
                    return originalImage;
                toHeight = originalImage.Height * toWidth / originalImage.Width;
            }
            Image toBitmap = new Bitmap(toWidth, toHeight);
            using (Graphics g = Graphics.FromImage(toBitmap))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.Clear(Color.Transparent);
                g.DrawImage(originalImage,
                            new Rectangle(0, 0, toWidth, toHeight),
                            new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                            GraphicsUnit.Pixel);
                originalImage.Dispose();
                return toBitmap;
            }
        }
        public static Image ReduceImage(Image originalImage, int toWidth, int toHeight)
        {
            if (toWidth <= 0 && toHeight <= 0)
            {
                return originalImage;
            }
            else if (toWidth > 0 && toHeight > 0)
            {
                if (originalImage.Width < toWidth && originalImage.Height < toHeight)
                    return originalImage;
            }
            else if (toWidth <= 0 && toHeight > 0)
            {
                if (originalImage.Height < toHeight)
                    return originalImage;
                toWidth = originalImage.Width * toHeight / originalImage.Height;
            }
            else if (toHeight <= 0 && toWidth > 0)
            {
                if (originalImage.Width < toWidth)
                    return originalImage;
                toHeight = originalImage.Height * toWidth / originalImage.Width;
            }
            Image toBitmap = new Bitmap(toWidth, toHeight);
            using (Graphics g = Graphics.FromImage(toBitmap))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.Clear(Color.Transparent);
                g.DrawImage(originalImage,
                            new Rectangle(0, 0, toWidth, toHeight),
                            new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                            GraphicsUnit.Pixel);
                originalImage.Dispose();
                return toBitmap;
            }
        }

        /// <summary>    
        /// 取得HTML中所有图片的 URL。    
        /// </summary>    
        /// <param name="sHtmlText">HTML代码</param>    
        /// <returns>图片的URL列表</returns>    
        public static string[] GetHtmlImgUrlList(string sHtmlText)
        {
            // 定义正则表达式用来匹配 img 标签    
            Regex regImg = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);

            // 搜索匹配的字符串    
            MatchCollection matches = regImg.Matches(sHtmlText);
            int i = 0;
            string[] sUrlList = new string[matches.Count];

            // 取得匹配项列表    
            foreach (Match match in matches)
            {
                sUrlList[i++] = match.Groups["imgUrl"].Value;
            }
            return sUrlList;
        }
        #region base64转图片
        /// <summary>
        /// 图片上传 Base64解码
        /// </summary>
        /// <param name="dataURL">Base64数据</param>
        /// <param name="imgName">所要保存的相对路径及名字</param>
        /// <returns>返回一个相对路径</returns>
        public static string decodeBase64ToImage(string dataURL, string filename)
        {

            //string filename = "";//声明一个string类型的相对路径

            String base64 = dataURL.Substring(dataURL.IndexOf(",") + 1);      //将‘，’以前的多余字符串删除
            System.Drawing.Bitmap bitmap = null;//定义一个Bitmap对象，接收转换完成的图片

            try//会有异常抛出，try，catch一下
            {

                byte[] arr = Convert.FromBase64String(base64);//将纯净资源Base64转换成等效的8位无符号整形数组

                System.IO.MemoryStream ms = new System.IO.MemoryStream(arr);//转换成无法调整大小的MemoryStream对象
                bitmap = new System.Drawing.Bitmap(ms);//将MemoryStream对象转换成Bitmap对象

                //filename = imgName;//所要保存的相对路径及名字
                //string url = HttpRuntime.AppDomainAppPath.ToString();
                string tmpRootDir = System.Web.HttpContext.Current.Server.MapPath(filename); //获取程序根目录 
                //string imagesurl2 = tmpRootDir + filename; //转换成绝对路径 
                bitmap.Save(tmpRootDir, System.Drawing.Imaging.ImageFormat.Png);//保存到服务器路径
                //bitmap.Save(filePath + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                //bitmap.Save(filePath + ".gif", System.Drawing.Imaging.ImageFormat.Gif);
                //bitmap.Save(filePath + ".png", System.Drawing.Imaging.ImageFormat.Png);
                ms.Close();//关闭当前流，并释放所有与之关联的资源
                bitmap.Dispose();
            }
            catch (Exception e)
            {
                string massage = e.Message;
            }
            return filename;//返回相对路径
        }
        #endregion

        #region 图片转base64
        /// <summary>
        /// 图片转base64
        /// </summary>
        /// <param name="path">图片路径</param><br>        
        ///  <returns>返回一个base64字符串</returns>
        public static string decodeImageToBase64(string path)
        {

            string base64str = "";

            //站点文件目录
            string fileDir = HttpContext.Current.Server.MapPath(path);
            string[] arrfileDir = fileDir.Split('\\');
            fileDir = arrfileDir[0] + "\\" + arrfileDir[1] + "\\" + arrfileDir[2];
            try
            {
                //读图片转为Base64String
                Bitmap bmp = new Bitmap(path);
                //System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(path);
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, ImageFormat.Jpeg);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                bmp.Dispose();
                base64str = Convert.ToBase64String(arr);
            }
            catch (Exception e)
            {
                string mss = e.Message;
            }
            return "data:image/jpg;base64," + base64str;
        }
        /// <summary>
        /// Image 转成 base64
        /// </summary>
        /// <param name="path">文件路径</param>
        public static string ImageToBase64(string path)
        {
            try
            {
                string dumpPath = HttpContext.Current.Server.MapPath(path);
                FileStream file = new FileStream(dumpPath, FileMode.Open);
                BinaryReader br = new BinaryReader(file);
                byte[] imgBytesIn = br.ReadBytes((int)file.Length); //将流读入到字节数组中
                file.Close();
                //Bitmap bmp = new Bitmap(dumpPath);
                //MemoryStream ms = new MemoryStream();
                //var suffix = dumpPath.Substring(dumpPath.LastIndexOf('.') + 1,
                //    dumpPath.Length - dumpPath.LastIndexOf('.') - 1).ToLower();
                //var suffixName = suffix == "png"
                //    ? ImageFormat.Png
                //    : suffix == "jpg" || suffix == "jpeg"
                //        ? ImageFormat.Jpeg
                //        : suffix == "bmp"
                //            ? ImageFormat.Bmp
                //            : suffix == "gif"
                //                ? ImageFormat.Gif
                //                : ImageFormat.Jpeg;

                //bmp.Save(ms, suffixName);
                //byte[] arr = new byte[ms.Length];
                //ms.Position = 0;
                //ms.Read(arr, 0, (int)ms.Length);
                //ms.Close();
                //bmp.Dispose();
         
                return Convert.ToBase64String(imgBytesIn);
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion
        /// <summary>
        /// 获取文件MD5值
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns>MD5值</returns>
        public static string GetMD5HashFromFile(string path)
        {
            try
            {
                string dumpPath = HttpContext.Current.Server.MapPath(path);
                FileStream file = new FileStream(dumpPath, FileMode.Open);
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);
                file.Close();

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("GetMD5HashFromFile() fail,error:" + ex.Message);
            }
        }

    }
}
