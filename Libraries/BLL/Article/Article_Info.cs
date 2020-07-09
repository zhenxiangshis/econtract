using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using DALFactory;
using IDAL.Article;
using Model;
using Utility;
using System.IO;
using System.Configuration;
using System.Web;
using System.Text.RegularExpressions;
using System.Net;

namespace BLL.Article
{
    public class Article_Info
    {
        // Fields
        private readonly IArticle_Info dal;

        // Methods
        public Article_Info()
        {
            this.dal = DataAccess.CreateArticle_Info();
        }

        public int AddArticleInfo(Model.Article.Article_Info model)
        {
            int result = this.dal.AddArticleInfo(model);
            if (result > 0)
            {
                try
                {
                    //this.CreateHtml(result);
                }
                catch
                {
                }
            }
            return result;
        }
        /// <summary>    
        /// 替换HTML中所有图片的 URL。    
        /// </summary>    
        /// <param name="sHtmlText">HTML代码</param>    
        /// <returns>替换后的Html</returns>    
        public string ReplaceImageUrl(string sHtmlText)
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
                var _picUrl = match.Groups["imgUrl"].Value;
                //扩展名
                var _ext = _picUrl.Substring(_picUrl.LastIndexOf('=') + 1);
                //保存的相对路径
                var _time = DateTime.Now;
                var _virpath = "/upload/media/news/" + _time.ToString("yyyyMM") + "/" + _time.ToFileTime() + "." + _ext.Replace("e", "");
                sHtmlText = sHtmlText.Replace(_picUrl, _picUrl + "\" src=\"" + _virpath);
                string savePath = HttpContext.Current.Server.MapPath(_virpath);
                DownloadPicture(_picUrl, savePath, -1);
            }
            return sHtmlText;
        }
        /// <summary>
        /// 下载图片
        /// </summary>
        /// <param name="picUrl">图片Http地址</param>
        /// <param name="savePath">保存路径</param>
        /// <param name="timeOut">Request最大请求时间，如果为-1则无限制</param>
        /// <returns></returns>
        public static bool DownloadPicture(string picUrl, string savePath, int timeOut)
        {
            bool value = false;
            WebResponse response = null;
            Stream stream = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(picUrl);
                if (timeOut != -1)
                {
                    request.Timeout = timeOut;
                }
                response = request.GetResponse();
                stream = response.GetResponseStream();
                if (!response.ContentType.ToLower().StartsWith("text/"))
                {
                    value = SaveBinaryFile(response, savePath);
                }
            }
            finally
            {
                if (stream != null) stream.Close();
                if (response != null) response.Close();
            }
            return value;
        }
        private static bool SaveBinaryFile(WebResponse response, string savePath)
        {
            bool value = false;
            byte[] buffer = new byte[1024];
            Stream outStream = null;
            Stream inStream = null;
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(savePath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(savePath));

                }
                if (File.Exists(savePath))
                {
                    File.Delete(savePath);
                }
                outStream = System.IO.File.Create(savePath);
                inStream = response.GetResponseStream();
                int l;
                do
                {
                    l = inStream.Read(buffer, 0, buffer.Length);
                    if (l > 0) outStream.Write(buffer, 0, l);
                } while (l > 0);
                value = true;
            }
            finally
            {
                if (outStream != null) outStream.Close();
                if (inStream != null) inStream.Close();
            }
            return value;
        }
        public void ArticleAboutHtml(int strClassID, int strTop, string strOrder, string strWhere)
        {
            try
            {
                string sNewPath = ConfigurationManager.AppSettings["NewsPath"];
                DataSet ds = new DataSet();
                DataTable tb = this.GetArticleList(strClassID, strTop, strOrder, strWhere).Tables[0];
                string sHtml = "<table width=100% border=0 cellspacing=0 cellpadding=0>" + Environment.NewLine;
                foreach (DataRow db in tb.Rows)
                {
                    sHtml = sHtml + "  <tr>" + Environment.NewLine;
                    sHtml = sHtml + "    <td width=10 height=22 align=center scope=row></td>" + Environment.NewLine;
                    sHtml = sHtml + "    <td width=243 align=left><a href=" + sNewPath + "/" + StringHelper.DateToYear(db["AddTime"].ToString()) + "/" + db["ArticleID"].ToString() + ".sHtml title=" + db["Title"].ToString() + ">" + StringHelper.GetFirstString(db["Title"].ToString(), 30) + "</a></td>" + Environment.NewLine;
                    sHtml = sHtml + "  </tr>" + Environment.NewLine;
                }
                sHtml = sHtml + "</table>";
                sNewPath = string.Concat(new object[] { sNewPath, "/About_", strClassID, ".html" });
                FileHelper.CreateFile(sNewPath);
                using (StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath(sNewPath).ToString(), false, Encoding.GetEncoding("utf-8")))
                {
                    sw.WriteLine(sHtml);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch
            {
            }
        }

        public void ArticleAnnounceHtml(int strClassID, int strTop, string strOrder, string strWhere)
        {
            try
            {
                string sNewPath = ConfigurationManager.AppSettings["NewsPath"];
                DataSet ds = new DataSet();
                DataTable tb = this.GetArticleList(strClassID, strTop, strOrder, strWhere).Tables[0];
                string sHtml = "";
                foreach (DataRow db in tb.Rows)
                {
                    sHtml = "<marquee scrollamount=1 scrollDelay=5 direction=up width='128' height='110' onMouseover=this.stop() onMouseout=this.start()><a href=" + sNewPath + "/" + StringHelper.DateToYear(db["AddTime"].ToString()) + "/" + db["ArticleID"].ToString() + ".sHtml target=_blank class=wA>" + db["Title"].ToString() + "<br><br>" + HttpUtility.HtmlDecode(db["Content"].ToString()) + "</a></marquee>" + Environment.NewLine;
                }
                sNewPath = sNewPath + "/Announce.Html";
                FileHelper.CreateFile(sNewPath);
                using (StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath(sNewPath).ToString(), false, Encoding.GetEncoding("utf-8")))
                {
                    sw.WriteLine(sHtml);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch
            {
            }
        }
        public void ArticleLTopHtml(int strClassID, int strTop, string strOrder, string strWhere)
        {
            try
            {
                string sNewPath = ConfigurationManager.AppSettings["NewsPath"];
                string sPageUrl = "";
                DataSet ds = new DataSet();
                DataTable tb = this.GetArticleList(strClassID, strTop, strOrder, strWhere).Tables[0];
                string sHtml = "";
                foreach (DataRow db in tb.Rows)
                {
                    if (db["GoUrl"].ToString() != "")
                    {
                        sPageUrl = db["GoUrl"].ToString();
                    }
                    else
                    {
                        sPageUrl = sNewPath + "/" + StringHelper.DateToYear(db["AddTime"].ToString()) + "/" + db["ArticleID"].ToString() + ".sHtml";
                    }
                    sHtml = "<img src=" + db["PicUrl"].ToString().Substring(0, db["PicUrl"].ToString().LastIndexOf("/") + 1) + "189X121" + db["PicUrl"].ToString().Substring(db["PicUrl"].ToString().LastIndexOf("/") + 1) + " class='image' width=189 height=121>" + Environment.NewLine;
                    sHtml = sHtml + "<h2><a href=" + sPageUrl + " target=_blank>" + StringHelper.GetFirstString(db["Title"].ToString(), 40) + "</a></h2>" + Environment.NewLine;
                    sHtml = sHtml + "<p>" + StringHelper.GetFirstString(db["Tag"].ToString(), 210) + " [<a href=" + sPageUrl + " target=_blank>详细</a>]</p>" + Environment.NewLine;
                }
                sNewPath = string.Concat(new object[] { sNewPath, "/LTop_", strClassID, ".Html" });
                FileHelper.CreateFile(sNewPath);
                using (StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath(sNewPath).ToString(), false, Encoding.GetEncoding("utf-8")))
                {
                    sw.WriteLine(sHtml);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch
            {
            }
        }

        public void ArticleNewHtml(int strClassID, int strTop, string strOrder, string strWhere)
        {
            try
            {
                TimeSpan Diff;
                string sNewPath = ConfigurationManager.AppSettings["NewsPath"];
                DataSet ds = new DataSet();
                DataTable tb = this.GetArticleList(strClassID, strTop, strOrder, strWhere).Tables[0];
                string sHtml = "";
                string sPageUrl = "";
                if ((strClassID == 0x24) || (strClassID == 0x2c))
                {
                    sHtml = "<ul style=\"list-style:none; margin:0px;\">";
                    foreach (DataRow db in tb.Rows)
                    {
                        string Chtml;
                        Diff = (TimeSpan)(DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(db["AddTime"].ToString()));
                        if (db["GoUrl"].ToString() != "")
                        {
                            sPageUrl = db["GoUrl"].ToString();
                        }
                        else
                        {
                            sPageUrl = sNewPath + "/" + StringHelper.DateToYear(db["AddTime"].ToString()) + "/" + db["ArticleID"].ToString() + ".sHtml";
                        }
                        if (int.Parse(Diff.Days.ToString()) <= 6)
                        {
                            Chtml = sHtml;
                            sHtml = Chtml + "<li style=\"height:23px\"><img src=\"/ceyh/images/ce-ico.jpg\" width=\"8\" height=\"8\">&nbsp;<a href=\"" + sPageUrl + "\" target=\"_blank\" class=\"l1\">" + StringHelper.GetFirstString(db["Title"].ToString(), 0x1a) + "</a>&nbsp;<img src=/images/i_new.gif width=18 height=7 alt=最新></li>";
                        }
                        else
                        {
                            Chtml = sHtml;
                            sHtml = Chtml + "<li style=\"height:23px\"><img src=\"/ceyh/images/ce-ico.jpg\" width=\"8\" height=\"8\">&nbsp;<a href=\"" + sPageUrl + "\" target=\"_blank\" class=\"l1\">" + StringHelper.GetFirstString(db["Title"].ToString(), 0x1a) + "</a></li>";
                        }
                    }
                    sHtml = sHtml + "</ul>";
                    if (strClassID == 0x24)
                    {
                        sNewPath = sNewPath + "/ceyh.Html";
                    }
                    else
                    {
                        sNewPath = sNewPath + "/axkx.Html";
                    }
                }
                else
                {
                    sHtml = "<ul>" + Environment.NewLine;
                    if (strClassID == 6)
                    {
                        foreach (DataRow db in tb.Rows)
                        {
                            Diff = (TimeSpan)(DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(db["AddTime"].ToString()));
                            if (int.Parse(Diff.Days.ToString()) <= 6)
                            {
                                sHtml = sHtml + "<li><a href=" + sNewPath + "/" + StringHelper.DateToYear(db["AddTime"].ToString()) + "/" + db["ArticleID"].ToString() + ".sHtml target=_blank title=" + StringHelper.GetFirstString(db["Title"].ToString(), 80) + ">" + StringHelper.GetFirstString(db["Title"].ToString(), 0x10) + "</a>&nbsp;<img src=/images/i_new.gif width=18 height=7 alt=最新></li>" + Environment.NewLine;
                            }
                            else
                            {
                                sHtml = sHtml + "<li><a href=" + sNewPath + "/" + StringHelper.DateToYear(db["AddTime"].ToString()) + "/" + db["ArticleID"].ToString() + ".sHtml target=_blank title=" + StringHelper.GetFirstString(db["Title"].ToString(), 80) + ">" + StringHelper.GetFirstString(db["Title"].ToString(), 0x10) + "</a></li>" + Environment.NewLine;
                            }
                        }
                    }
                    else
                    {
                        foreach (DataRow db in tb.Rows)
                        {
                            Diff = (TimeSpan)(DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(db["AddTime"].ToString()));
                            if (int.Parse(Diff.Days.ToString()) <= 6)
                            {
                                sHtml = sHtml + "<li><img src=images/index_rytb.jpg width=9 height=9 class=list_img><a href=" + sNewPath + "/" + StringHelper.DateToYear(db["AddTime"].ToString()) + "/" + db["ArticleID"].ToString() + ".sHtml target=_blank title=" + StringHelper.GetFirstString(db["Title"].ToString(), 80) + ">" + StringHelper.GetFirstString(db["Title"].ToString(), 0x10) + "</a>&nbsp;<img src=/images/i_new.gif width=18 height=7 alt=最新>&nbsp;[" + Convert.ToDateTime(db["AddTime"].ToString()).ToString("yyyy/MM/dd") + "]</li>" + Environment.NewLine;
                            }
                            else
                            {
                                sHtml = sHtml + "<li><img src=images/index_rytb.jpg width=9 height=9 class=list_img><a href=" + sNewPath + "/" + StringHelper.DateToYear(db["AddTime"].ToString()) + "/" + db["ArticleID"].ToString() + ".sHtml target=_blank title=" + StringHelper.GetFirstString(db["Title"].ToString(), 80) + ">" + StringHelper.GetFirstString(db["Title"].ToString(), 0x12) + "</a>&nbsp;[" + Convert.ToDateTime(db["AddTime"].ToString()).ToString("yyyy/MM/dd") + "]</li>" + Environment.NewLine;
                            }
                        }
                    }
                    sHtml = sHtml + "</ul>";
                    sNewPath = string.Concat(new object[] { sNewPath, "/New_", strClassID, ".Html" });
                }
                if (File.Exists(sNewPath))
                {
                    FileHelper.DeleteFile(sNewPath);
                }
                FileHelper.CreateFile(sNewPath);
                using (StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath(sNewPath).ToString(), false, Encoding.GetEncoding("utf-8")))
                {
                    sw.WriteLine(sHtml);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch
            {
            }
        }

        public void ArticlePicHtml(int strClassID, int strTop, string strOrder, string strWhere)
        {
            try
            {
                string sNewPath = ConfigurationManager.AppSettings["NewsPath"];
                DataSet ds = new DataSet();
                DataTable tb = this.GetArticleList(strClassID, strTop, strOrder, strWhere).Tables[0];
                string sHtml = "";
                foreach (DataRow db in tb.Rows)
                {
                    sHtml = "<div  align=left id=newxn3><a href=" + sNewPath + "/" + StringHelper.DateToYear(db["AddTime"].ToString()) + "/" + db["ArticleID"].ToString() + ".sHtml target=_blank><img src=" + db["PicUrl"].ToString().Substring(0, db["PicUrl"].ToString().LastIndexOf("/") + 1) + "104X98" + db["PicUrl"].ToString().Substring(db["PicUrl"].ToString().LastIndexOf("/") + 1) + " border=0></a></div>" + Environment.NewLine;
                    sHtml = sHtml + "<div align=center id=newxn2><a href=" + sNewPath + "/" + StringHelper.DateToYear(db["AddTime"].ToString()) + "/" + db["ArticleID"].ToString() + ".sHtml target=_blank>" + StringHelper.GetFirstString(db["Title"].ToString(), 12) + "</a></div>" + Environment.NewLine;
                }
                sNewPath = sNewPath + "/Pic_1.Html";
                FileHelper.CreateFile(sNewPath);
                using (StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath(sNewPath).ToString(), false, Encoding.GetEncoding("utf-8")))
                {
                    sw.WriteLine(sHtml);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch
            {
            }
        }

        public void ArticleTopHtml(int strClassID, int strTop, string strOrder, string strWhere)
        {
            try
            {
                string sNewPath = ConfigurationManager.AppSettings["NewsPath"];
                DataSet ds = new DataSet();
                DataTable tb = this.GetArticleList(strClassID, strTop, strOrder, strWhere).Tables[0];
                string sHtml = "";
                string sPageUrl = "";
                if (strClassID == 1)
                {
                    foreach (DataRow db in tb.Rows)
                    {
                        if (db["GoUrl"].ToString() != "")
                        {
                            sPageUrl = db["GoUrl"].ToString();
                        }
                        else
                        {
                            sPageUrl = sNewPath + "/" + StringHelper.DateToYear(db["AddTime"].ToString()) + "/" + db["ArticleID"].ToString() + ".sHtml";
                        }
                        sHtml = "<img src=" + db["PicUrl"].ToString().Substring(0, db["PicUrl"].ToString().LastIndexOf("/") + 1) + db["PicUrl"].ToString().Substring(db["PicUrl"].ToString().LastIndexOf("/") + 1) + " class='image' width=145 height=97>" + Environment.NewLine;
                        sHtml = sHtml + "<h2><a href=" + sPageUrl + " target=_blank>" + StringHelper.GetFirstString(db["Title"].ToString(), 0x17) + "</a>&nbsp;<img src=/images/i_new.gif width=18 height=7 alt=最新></h2>" + Environment.NewLine;
                        sHtml = sHtml + "<p>" + StringHelper.GetFirstString(db["Tag"].ToString(), 0x80) + " [<a href=" + sPageUrl + " target=_blank>详细</a>]</p>" + Environment.NewLine;
                    }
                }
                else if (strClassID == 3)
                {
                    foreach (DataRow db in tb.Rows)
                    {
                        if (db["GoUrl"].ToString() != "")
                        {
                            sPageUrl = db["GoUrl"].ToString();
                        }
                        else
                        {
                            sPageUrl = sNewPath + "/" + StringHelper.DateToYear(db["AddTime"].ToString()) + "/" + db["ArticleID"].ToString() + ".sHtml";
                        }
                        sHtml = "<img src=" + db["PicUrl"].ToString().Substring(0, db["PicUrl"].ToString().LastIndexOf("/") + 1) + db["PicUrl"].ToString().Substring(db["PicUrl"].ToString().LastIndexOf("/") + 1) + " class='Mimage' width=92 height=72 border=0>" + Environment.NewLine;
                        sHtml = sHtml + "<p><a href=" + sPageUrl + " target=_blank>" + StringHelper.GetFirstString(db["Tag"].ToString(), 50) + "</a></p>" + Environment.NewLine;
                    }
                }
                else if (strClassID == 4)
                {
                    foreach (DataRow db in tb.Rows)
                    {
                        if (db["GoUrl"].ToString() != "")
                        {
                            sPageUrl = db["GoUrl"].ToString();
                        }
                        else
                        {
                            sPageUrl = sNewPath + "/" + StringHelper.DateToYear(db["AddTime"].ToString()) + "/" + db["ArticleID"].ToString() + ".sHtml";
                        }
                        sHtml = "<img src=" + db["PicUrl"].ToString().Substring(0, db["PicUrl"].ToString().LastIndexOf("/") + 1) + db["PicUrl"].ToString().Substring(db["PicUrl"].ToString().LastIndexOf("/") + 1) + " class='Timage' width=104 height=76 border=0>" + Environment.NewLine;
                        sHtml = sHtml + "<h2><a href=" + sPageUrl + " target=_blank>" + StringHelper.GetFirstString(db["Title"].ToString(), 0x12) + "</a></h2>" + Environment.NewLine;
                        sHtml = sHtml + "<p>" + StringHelper.GetFirstString(db["Tag"].ToString(), 0x3e) + "</p>" + Environment.NewLine;
                    }
                }
                else if (strClassID == 0x2c)
                {
                    foreach (DataRow db in tb.Rows)
                    {
                        if (db["GoUrl"].ToString() != "")
                        {
                            sPageUrl = db["GoUrl"].ToString();
                        }
                        else
                        {
                            sPageUrl = sNewPath + "/" + StringHelper.DateToYear(db["AddTime"].ToString()) + "/" + db["ArticleID"].ToString() + ".sHtml";
                        }
                        sHtml = "<img src=" + db["PicUrl"].ToString().Substring(0, db["PicUrl"].ToString().LastIndexOf("/") + 1) + db["PicUrl"].ToString().Substring(db["PicUrl"].ToString().LastIndexOf("/") + 1) + " class='Timage' width=151 height=100 border=0>" + Environment.NewLine;
                    }
                }
                else
                {
                    foreach (DataRow db in tb.Rows)
                    {
                        TimeSpan Diff = (TimeSpan)(DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(db["AddTime"].ToString()));
                        if (db["GoUrl"].ToString() != "")
                        {
                            sPageUrl = db["GoUrl"].ToString();
                        }
                        else
                        {
                            sPageUrl = sNewPath + "/" + StringHelper.DateToYear(db["AddTime"].ToString()) + "/" + db["ArticleID"].ToString() + ".sHtml";
                        }
                        sHtml = "<img src=" + db["PicUrl"].ToString().Substring(0, db["PicUrl"].ToString().LastIndexOf("/") + 1) + db["PicUrl"].ToString().Substring(db["PicUrl"].ToString().LastIndexOf("/") + 1) + " class='Timage' width=109 height=75>" + Environment.NewLine;
                        if (int.Parse(Diff.Days.ToString()) <= 6)
                        {
                            sHtml = sHtml + "<h2>[<a href=" + sPageUrl + " target=_blank>" + StringHelper.GetFirstString(db["Title"].ToString(), 0x1c) + "</a>]&nbsp;<img src=/images/i_new.gif width=18 height=7 alt=最新></h2>" + Environment.NewLine;
                        }
                        else
                        {
                            sHtml = sHtml + "<h2>[<a href=" + sPageUrl + " target=_blank>" + StringHelper.GetFirstString(db["Title"].ToString(), 30) + "</a>]</h2>" + Environment.NewLine;
                        }
                        sHtml = sHtml + "<p>" + StringHelper.GetFirstString(db["Tag"].ToString(), 0x3e) + "[<a href=" + sPageUrl + " target=_blank>详细</a>]</p>" + Environment.NewLine;
                    }
                }
                sNewPath = string.Concat(new object[] { sNewPath, "/Top_", strClassID, ".Html" });
                FileHelper.CreateFile(sNewPath);
                using (StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath(sNewPath).ToString(), false, Encoding.GetEncoding("utf-8")))
                {
                    sw.WriteLine(sHtml);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch
            {
            }
        }

        public void ArticleVouchHtml(int strClassID, int strTop, string strOrder, string strWhere)
        {
            try
            {
                string sNewPath = ConfigurationManager.AppSettings["NewsPath"];
                DataSet ds = new DataSet();
                DataTable tb = this.GetArticleList(strClassID, strTop, strOrder, strWhere).Tables[0];
                string sHtml = "<table width=100% border=0 cellspacing=0 cellpadding=0>" + Environment.NewLine;
                foreach (DataRow db in tb.Rows)
                {
                    sHtml = sHtml + "  <tr>" + Environment.NewLine;
                    sHtml = sHtml + "    <td height=20 scope=row><a href=" + sNewPath + "/" + StringHelper.DateToYear(db["AddTime"].ToString()) + "/" + db["ArticleID"].ToString() + ".sHtml target=_blank>" + StringHelper.GetFirstString(db["Title"].ToString(), 0x10) + "</a></td>" + Environment.NewLine;
                    sHtml = sHtml + "  </tr>" + Environment.NewLine;
                }
                sHtml = sHtml + "</table>";
                sNewPath = sNewPath + "/Vouch_5.Html";
                FileHelper.CreateFile(sNewPath);
                using (StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath(sNewPath).ToString(), false, Encoding.GetEncoding("utf-8")))
                {
                    sw.WriteLine(sHtml);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch
            {
            }
        }

        public void CreateHtml(int ArticleID)
        {
            try
            {
                Model.Article.Article_Info model = this.GetArticleInfoModel(ArticleID);
                Temp.Temp_Info Tempbll = new Temp.Temp_Info();
                string sNewPath = ConfigurationManager.AppSettings["NewsPath"],
                    sHtmlTemp = Tempbll.GetTempInfoModel(model.DemoID).Content,
                    sArticleID = model.ArticleID.ToString(),
                    sClassID = model.ClassID.ToString(),
                    sClassName = model.ClassName.ToString(),
                    sTitle = model.Title.ToString(),
                    sBTitle = sTitle,
                    sSubTitle = model.SubTitle.ToString(),
                    sContent = HttpUtility.HtmlDecode(model.Content.ToString().Replace("http://www.5dgz.com/", "/").Replace("/Upload/", "http://www.5dgz.com/Upload/").Replace("/upload/", "http://www.5dgz.com/Upload/")).ToString(),
                    sAddTime = model.AddTime.ToString(),
                    sUrl = string.Concat(new object[] { "http://www.5dgz.com", sNewPath, "/", StringHelper.DateToYear(model.AddTime.ToString()), "/", model.ArticleID, ".html" });

                //V3sNewPath = ConfigurationManager.AppSettings["V3NewsPath"],
                //V3sHtmlTemp = Tempbll.GetTempInfoModel(30).Content,
                //V3sUrl = string.Concat(new object[] { "http://www.5dgz.com",V3sNewPath,"/",StringHelper.DateToYear(model.AddTime.ToString()),"/",model.ArticleID,".html" });

                //string sCommHtmlTemp = Tempbll.GetTempInfoModel(2).Content;
                //string strComm = "";
                //Article_Comm Commbll = new Article_Comm();
                //DataSet ds = new DataSet();
                //DataTable tb = Commbll.GetArticleCommList(int.Parse(sArticleID)).Tables[0];
                //foreach (DataRow db in tb.Rows)
                //{
                //    string nHtmlTemp = sCommHtmlTemp;
                //    nHtmlTemp = nHtmlTemp.Replace("$commid$", db["CommID"].ToString()).Replace("$userid$", db["UserID"].ToString()).Replace("$username$", db["UserName"].ToString()).Replace("$articleid$", db["ArticleID"].ToString()).Replace("$content$", HttpUtility.HtmlDecode(db["Content"].ToString())).Replace("$ip$", db["Ip"].ToString()).Replace("$addtime$", db["AddTime"].ToString()).Replace("$fen$", db["Fen"].ToString());
                //    strComm = strComm + Environment.NewLine + nHtmlTemp;
                //}                
                sTitle = "<h1>" + sTitle + "</h1>" + Environment.NewLine;
                if (sSubTitle != "")
                {
                    sTitle = sTitle + "<h2>——" + sSubTitle + "</h2>" + Environment.NewLine;
                }

                //var s = GetStringList("_ueditor_page_break_tag_",sContent);

                //var s =Regex.Split(sContent,"_ueditor_page_break_tag_",RegexOptions.IgnoreCase);
                //var i = 1;
                //foreach(var _s in s)
                //{

                //    var _sHtmlTemp = sHtmlTemp.Replace("$articleid$",sArticleID).Replace("$classid$",sClassID).Replace("$classname$",sClassName).Replace("$title$",sTitle).Replace("$content$",_s).Replace("$addtime$",sAddTime).Replace("$btitle$",sBTitle);
                //    var _sNewPath = string.Concat(new object[] { sNewPath,"/",StringHelper.DateToYear(model.AddTime.ToString()),"/",model.ArticleID,"-",i,".html" });
                //    FileHelper.CreateFile(_sNewPath);
                //    using(StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath(_sNewPath).ToString(),false,Encoding.GetEncoding("utf-8")))
                //    {
                //        sw.WriteLine(_sHtmlTemp);
                //        sw.Flush();
                //        sw.Close();
                //    }
                //    i++;
                //}
                sHtmlTemp = sHtmlTemp.Replace("$articleid$", sArticleID).Replace("$classid$", sClassID).Replace("$classname$", sClassName).Replace("$title$", sTitle).Replace("$hits$", model.VisitCount.ToString()).Replace("$content$", sContent).Replace("$addtime$", sAddTime).Replace("$btitle$", sBTitle);

                //V3sHtmlTemp = V3sHtmlTemp.Replace("$articleid$",sArticleID).Replace("$classid$",sClassID).Replace("$classname$",sClassName).Replace("$title$",sTitle).Replace("$hits$",model.VisitCount.ToString()).Replace("$content$",sContent).Replace("$addtime$",sAddTime).Replace("$btitle$",sBTitle);

                //2013-10-29 添加区域动态
                // if (sClassID == "8" || sClassID == "96")
                // {

                sContent = Regex.Replace(sContent, @"</span>|<span.*?>", "").Replace('＄', '$').Replace("</p>", "").Replace("<p>", "<br />");   //去除所有标签

                string[] _pics = GetStringList("/UpLoad/[^\"']*.jpg", sContent),
                    _titles = GetStringList(@"\$([\s\S][^$]*)\$", sContent);
                StringBuilder josn = new StringBuilder();
                josn.Append("{\"img\":[");

                josn.Append(string.Join(",", _pics));
                josn.Append("],\"title\":[");
                josn.Append(string.Join(",", _titles));
                josn.Append("]}");
                sHtmlTemp = sHtmlTemp.Replace("$contentjson$", josn.ToString());
                // }

                sNewPath = string.Concat(new object[] { sNewPath, "/", StringHelper.DateToYear(model.AddTime.ToString()), "/", model.ArticleID, ".html" });
                FileHelper.CreateFile(sNewPath);
                using (StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath(sNewPath).ToString(), false, Encoding.GetEncoding("utf-8")))
                {
                    sw.WriteLine(sHtmlTemp);
                    sw.Flush();
                    sw.Close();
                }

                //V3sNewPath = string.Concat(new object[] { V3sNewPath,"/",StringHelper.DateToYear(model.AddTime.ToString()),"/",model.ArticleID,".html" });
                //FileHelper.CreateFile(V3sNewPath);
                //using(StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath(V3sNewPath).ToString(),false,Encoding.GetEncoding("utf-8")))
                //{
                //    sw.WriteLine(V3sHtmlTemp);
                //    sw.Flush();
                //    sw.Close();
                //}

            }
            catch
            {
            }
        }

        /// <summary>   
        /// 取得HTML中所有图片的 URL。   
        /// </summary>   
        /// <param name="sHtmlText">HTML代码</param>   
        /// <returns>图片的URL列表</returns>   
        public string[] GetStringList(string reg, string sHtmlText)
        {
            // 定义正则表达式用来匹配 img 标签   
            Regex regImg = new Regex(reg, RegexOptions.IgnoreCase);

            // 搜索匹配的字符串   
            MatchCollection matches = regImg.Matches(sHtmlText);
            int i = 0;
            string[] sUrlList = new string[matches.Count];

            // 取得匹配项列表   
            foreach (Match match in matches)
                sUrlList[i++] = ("\"" + match.Value + "\"").Replace("$", "");
            return sUrlList;
        }

        public void DeleteArticleInfo(int ArticleID)
        {
            Model.Article.Article_Info model = this.GetArticleInfoModel(ArticleID);
            string sNewPath = ConfigurationManager.AppSettings["NewsPath"];
            sNewPath = string.Concat(new object[] { sNewPath, "/", StringHelper.DateToYear(model.AddTime.ToString()), "/", model.ArticleID, ".sHtml" });
            if (File.Exists(sNewPath))
            {
                try
                {
                    File.Delete(sNewPath);
                }
                catch
                {
                }
            }
            this.dal.DeleteArticleInfo(ArticleID);
        }
        public void DeleteArticleInfo(string ArticleID)
        {
            this.dal.DeleteArticleInfo(ArticleID);
        }

        public bool Exists(int ArticleID)
        {
            return this.dal.Exists(ArticleID);
        }
        public ArrayList GetArticleIDList(string strWhere)
        {
            return this.dal.GetArticleIDList(strWhere);
        }

        public DataSet GetArticleInfoList(int PageSize, int PageIndex, string OrderfldName, int OrderType, ref int IsReCount, string strWhere)
        {
            return this.dal.GetArticleInfoList(PageSize, PageIndex, OrderfldName, OrderType, ref IsReCount, strWhere);
        }
        public Model.Article.Article_Info GetArticleInfoModel(int ArticleID)
        {
            return this.dal.GetArticleInfoModel(ArticleID);
        }
        public Model.Article.Article_Info GetTopArticleInfoModel(int ClassID, int IsTop)
        {
            return this.dal.GetTopArticleInfoModel(ClassID, IsTop);
        }
        public DataSet GetArticleList(int strClassID, int strTop, string strOrder, string strWhere)
        {
            return this.dal.GetArticleList(strClassID, strTop, strOrder, strWhere);
        }

        public int GetMaxId()
        {
            return this.dal.GetMaxId();
        }

        public void MesNewHtml(int strClassID, int strTop, string strOrder, string strWhere)
        {
            try
            {
                TimeSpan Diff;
                string sNewPath = ConfigurationManager.AppSettings["NewsPath"];
                DataSet ds = new DataSet();
                DataTable tb = this.GetArticleList(strClassID, strTop, strOrder, strWhere).Tables[0];
                string sHtml = "";
                string sPageUrl = "";
                if (strClassID == 3)
                {
                    sHtml = "<ul>" + Environment.NewLine;
                    foreach (DataRow db in tb.Rows)
                    {
                        if (db["GoUrl"].ToString() != "")
                        {
                            sPageUrl = db["GoUrl"].ToString();
                        }
                        else
                        {
                            sPageUrl = sNewPath + "/" + StringHelper.DateToYear(db["AddTime"].ToString()) + "/" + db["ArticleID"].ToString() + ".sHtml";
                        }
                        Diff = (TimeSpan)(DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(db["AddTime"].ToString()));
                        if (int.Parse(Diff.Days.ToString()) <= 6)
                        {
                            sHtml = sHtml + "<li><img src=images/index_arrow1.gif width=6 height=6 class=list_img1><a href=" + sPageUrl + " target=_blank title=" + StringHelper.GetFirstString(db["Title"].ToString(), 80) + ">" + StringHelper.GetFirstString(db["Title"].ToString(), 0x16) + "</a>&nbsp;<img src=/images/i_new.gif width=18 height=7 alt=最新></li>" + Environment.NewLine;
                        }
                        else
                        {
                            sHtml = sHtml + "<li><img src=images/index_arrow1.gif width=6 height=6 class=list_img1><a href=" + sPageUrl + " target=_blank title=" + StringHelper.GetFirstString(db["Title"].ToString(), 80) + ">" + StringHelper.GetFirstString(db["Title"].ToString(), 0x16) + "</a></li>" + Environment.NewLine;
                        }
                    }
                    sHtml = sHtml + "</ul>";
                }
                else if (strClassID == 7)
                {
                    sHtml = "<ul>" + Environment.NewLine;
                    foreach (DataRow db in tb.Rows)
                    {
                        if (db["GoUrl"].ToString() != "")
                        {
                            sPageUrl = db["GoUrl"].ToString();
                        }
                        else
                        {
                            sPageUrl = sNewPath + "/" + StringHelper.DateToYear(db["AddTime"].ToString()) + "/" + db["ArticleID"].ToString() + ".shtml";
                        }
                        Diff = (TimeSpan)(DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(db["AddTime"].ToString()));
                        if (int.Parse(Diff.Days.ToString()) <= 6)
                        {
                            sHtml = sHtml + "<li><img src=images/index_arrow1.gif width=6 height=6 class=list_img><a href=" + sPageUrl + " target=_blank title=" + StringHelper.GetFirstString(db["Title"].ToString(), 80) + ">" + StringHelper.GetFirstString(db["Title"].ToString(), 0x18) + "</a>&nbsp;<img src=/images/i_new.gif width=18 height=7 alt=最新>[" + Convert.ToDateTime(db["AddTime"].ToString()).ToString("yyyy/MM/dd") + "]</li>" + Environment.NewLine;
                        }
                        else
                        {
                            sHtml = sHtml + "<li><img src=images/index_arrow1.gif width=6 height=6 class=list_img><a href=" + sPageUrl + " target=_blank title=" + StringHelper.GetFirstString(db["Title"].ToString(), 80) + ">" + StringHelper.GetFirstString(db["Title"].ToString(), 0x18) + "</a>&nbsp;[" + Convert.ToDateTime(db["AddTime"].ToString()).ToString("yyyy/MM/dd") + "]</li>" + Environment.NewLine;
                        }
                    }
                    sHtml = sHtml + "</ul>";
                }
                sNewPath = string.Concat(new object[] { sNewPath, "/Mes_", strClassID, ".Html" });
                if (File.Exists(sNewPath))
                {
                    FileHelper.DeleteFile(sNewPath);
                }
                FileHelper.CreateFile(sNewPath);
                using (StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath(sNewPath).ToString(), false, Encoding.GetEncoding("utf-8")))
                {
                    sw.WriteLine(sHtml);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch
            {
            }
        }

        public void UpArticleInfo(string ArticleID, string Act, string YesNo, string ClassID)
        {
            this.dal.UpArticleInfo(ArticleID, Act, YesNo, ClassID);
        }

        public int UpdateArticleInfo(Model.Article.Article_Info model)
        {
            int result = this.dal.UpdateArticleInfo(model);
            if (result > 0)
            {
                try
                {
                    //this.CreateHtml(model.ArticleID);
                }
                catch
                {
                }
            }
            return result;
        }

        public int VisitArticleInfo(int ArticleID)
        {
            return this.dal.VisitArticleInfo(ArticleID);
        }
        /// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.Article.Article_Info> GetModelList(int strClassID, int strTop, string strOrder, string strWhere)
        {
            DataSet ds = dal.GetArticleList(strClassID, strTop, strOrder, strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Article.Article_Info> DataTableToList(DataTable dt)
        {
            List<Model.Article.Article_Info> modelList = new List<Model.Article.Article_Info>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.Article.Article_Info model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
    }



}
