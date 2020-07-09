using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Configuration;
using System.IO;
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
