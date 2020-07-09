using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace Utility
{
    /// <summary>
    /// 企业微信机器人接口
    /// </summary>
    public static class QYWechatBotApi
    {
        //微信机器人Key
        //public static string KEY = "6ce9d42d-0130-43bb-8b37-9687f4eed748";
        /// <summary>
        /// 机器人key
        /// </summary>
        public static string key = ConfigurationManager.AppSettings["wxRobot"];

        /// <summary>
        /// 文本类型
        /// </summary>
        /// <param name="content">文本内容，最长不超过2048个字节，必须是utf8编码</param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string SendText(string content,List < string> mentioned_list=null, List<string> mentioned_mobile_list=null)
        {
            var Data = new
            {
                msgtype = "text",
                text = new
                {
                    content = content,
                    mentioned_list= mentioned_list,
                    mentioned_mobile_list= mentioned_mobile_list
                }
            };
            var url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/webhook/send?key={0}", key);
            return HttpHelper.PostWebRequest(url, JsonConvert.SerializeObject(Data), Encoding.UTF8);
        }
        /// <summary>
        /// markdown类型
        /// </summary>
        /// <param name="content">markdown内容，最长不超过4096个字节，必须是utf8编码</param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string SendMarkdown(string content)
        {
            var Data = new
            {
                msgtype = "markdown",
                markdown = new
                {
                    content = content
                }
            };
            var url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/webhook/send?key={0}", key);
            return HttpHelper.PostWebRequest(url, JsonConvert.SerializeObject(Data), Encoding.UTF8);
        }
        /// <summary>
        /// 图片类型
        /// </summary>
        /// <param name="path">图片路径  图片（base64编码前）最大不能超过2M，支持JPG,PNG格式</param>
        /// <returns></returns>
        public static string SendImage(string path)
        {
            var base64 = PicHelper.ImageToBase64(path);
            var md5 = PicHelper.GetMD5HashFromFile(path);
            var Data = new
            {
                msgtype = "image",
                image = new
                {
                    base64 = base64,
                    md5 = md5
                }
            };
            var url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/webhook/send?key={0}", key);
            return HttpHelper.PostWebRequest(url, JsonConvert.SerializeObject(Data), Encoding.UTF8);
        }
        /// <summary>
        /// 图文类型
        /// </summary>
        /// <param name="articles">图文消息，一个图文消息支持1到8条图文</param>
        /// <param name="key">机器人key</param>
        /// <returns></returns>
        public static string SendNews(List<ArticleItem> articles)
        {
            var Data = new
            {
                msgtype = "news",
                news = new
                {
                    articles = articles
                }
            };
            var url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/webhook/send?key={0}", key);
            return HttpHelper.PostWebRequest(url, JsonConvert.SerializeObject(Data), Encoding.UTF8);
        }
        /// <summary>
        /// 文件类型
        /// </summary>
        /// <param name="media_id">文件id，通过下文的文件上传接口获取</param>
        /// <param name="key">机器人key</param>
        /// <returns></returns>
        public static string SendFile(string media_id)
        {
            var Data = new
            {
                msgtype = "file",
                file = new
                {
                    media_id = media_id,
                }
            };
            var url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/webhook/send?key={0}", key);
            return HttpHelper.PostWebRequest(url, JsonConvert.SerializeObject(Data), Encoding.UTF8);
        }
        /// <summary>
        /// 文件上传 得到media_id，该media_id仅三天内有效
        /// </summary>
        /// <param name="path">文件路径(文件大小在5B~20M之间)</param>
        /// <returns></returns>
        public static string UploadFiles(string path)
        {
            string responseContent = string.Empty;
            try
            {
                string dumpPath = HttpContext.Current.Server.MapPath(path);
                var filestream = File.Open(dumpPath, FileMode.Open);

                var file = new UploadFile
                {
                    Name = "file",
                    Filename = Path.GetFileName(dumpPath),
                    ContentType = "text/plain",
                    Stream = filestream
                };
                var values = new NameValueCollection{
                { "client", "abcd" }};

                var url = string.Format("https://qyapi.weixin.qq.com/cgi-bin/webhook/upload_media?key={0}&type={1}", key, "file");
                string boundary = "----------------------------" + DateTime.Now.Ticks.ToString("x");
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.ContentType = "multipart/form-data; boundary=" + boundary;
                request.Method = "POST";
                request.KeepAlive = true;
                request.Credentials = CredentialCache.DefaultCredentials;

                MemoryStream stream = new MemoryStream();

                byte[] line = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

                //提交文本字段
                if (values != null)
                {
                    string format = "\r\n--" + boundary + "\r\nContent-Disposition: form-data; name=\"{0}\";\r\n\r\n{1}";
                    foreach (string key in values.Keys)
                    {
                        string ss = string.Format(format, key, values[key]);
                        byte[] datas = Encoding.UTF8.GetBytes(ss);
                        stream.Write(datas, 0, datas.Length);
                    }
                    stream.Write(line, 0, line.Length);
                }
                string fformat = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\n Content-Type: application/octet-stream\r\n\r\n";
                string s = string.Format(fformat, file.Name, file.Filename);
                byte[] data = Encoding.UTF8.GetBytes(s);
                stream.Write(data, 0, data.Length);
                file.Stream.CopyTo(stream);
                stream.Write(line, 0, line.Length);
                request.ContentLength = stream.Length;
                Stream requestStream = request.GetRequestStream();

                stream.Position = 0L;
                stream.CopyTo(requestStream);
                stream.Close();

                requestStream.Close();

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    //在这里对接收到的页面内容进行处理
                    using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.Default))
                    {
                        responseContent = sr.ReadToEnd().ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return responseContent;

        }
    }
    /// <summary>
    /// 上传文件
    /// </summary>
    public class UploadFile
    {
        public UploadFile()
        {
            ContentType = "application/octet-stream";
        }
        public string Name { get; set; }
        public string Filename { get; set; }
        public string ContentType { get; set; }
        public Stream Stream { get; set; }

    }
    /// <summary>
    /// 图文消息，一个图文消息支持1到8条图文
    /// </summary>
    public class ArticleItem
    {
        /// <summary>
        /// 标题，不超过128个字节，超过会自动截断
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 描述，不超过512个字节，超过会自动截断
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 点击后跳转的链接。
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 图文消息的图片链接，支持JPG、PNG格式，较好的效果为大图 1068*455，小图150*150。
        /// </summary>
        public string picurl { get; set; }
    }
}
