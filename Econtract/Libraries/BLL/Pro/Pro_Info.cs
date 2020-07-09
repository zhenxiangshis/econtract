using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using DALFactory;
using IDAL.Pro;
using Model;
using Utility;
using System.IO;
using System.Configuration;
using System.Web;

namespace BLL.Pro
{
    public class Pro_Info
    {
        // Fields
        private readonly IPro_Info dal;

        // Methods
        public Pro_Info()
        {
            this.dal = DataAccess.CreatePro_Info();
        }

        public int AddProInfo(Model.Pro.Pro_Info model)
        {
            int result = this.dal.AddProInfo(model);
            if (result > 0)
            {
                try
                {
                    this.CreateHtml(result);
                }
                catch
                {
                }
            }
            return result;
        }

        public void CreateHtml(int ProID)
        {
            try
            {
                string filePath = ConfigurationManager.AppSettings["ProTempPath"];
                filePath = HttpContext.Current.Server.MapPath(filePath);
                string fileContent = string.Empty;
                using (var reader = new StreamReader(filePath))
                {
                    fileContent = reader.ReadToEnd();
                }
                string sHtmlTemp = fileContent;
                Model.Pro.Pro_Info model = this.GetProInfoModel(ProID);
                Temp.Temp_Info Tempbll = new Temp.Temp_Info();
                string sProPath = ConfigurationManager.AppSettings["ProPath"];
                //string sHtmlTemp = Tempbll.GetTempInfoModel(28).Content;
                var classname="";
                BLL.Pro.Pro_Class probll = new Pro_Class();
                classname = probll.GetProClassModel(model.ClassID).ClassName;
                //var procla = probll.GetProClassModel(model.ClassID);
                //classname = GetParentClassName(classname, probll, procla);
                string sProID = model.ProID.ToString();
                string sClassID = model.ClassID.ToString();
                string sClassName = model.ClassName.ToString();
                string sTitle = model.Title.ToString();
                string sRemark = HttpUtility.HtmlDecode(model.Remark.ToString() + model.Method.ToString()).ToString();
                string sPrice = model.Price.ToString();
                string sContent = model.Content.ToString();
                string sProPic = model.PicPath.ToString() + model.PicName.ToString();
                string sAddTime = model.AddTime.ToString();
                string sElement = model.Element.ToString();
                sHtmlTemp = sHtmlTemp.Replace("$ClassName$", classname).Replace("$HTMLTitle$",StringHelper.NoHtml(sTitle)).Replace("$Title$", sTitle).Replace("$PicPath$", sProPic).Replace("$Content$", sContent).Replace("$Price$", sPrice).Replace("$Remark$", sRemark).Replace("$Element$", sElement);
                if (model.ClassID == 23)
                {
                    sHtmlTemp = sHtmlTemp.Replace("主要成分", "颜色");

                }
                sProPath = string.Concat(new object[] { sProPath, "/", StringHelper.DateToYear(model.AddTime.ToString()), "/", model.ProID, ".html" });
                FileHelper.CreateFile(sProPath);
                using (StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath(sProPath).ToString(), false, Encoding.GetEncoding("utf-8")))
                {
                    sw.WriteLine(sHtmlTemp);
                    sw.Flush();
                    sw.Close();
                }
                //this.ProHotHtml(0, 3, "VouchTime", " AND IsVouch=1 ");
            }
            catch
            {
            }
        }

        private static string GetParentClassName(string classname, BLL.Pro.Pro_Class probll, Model.Pro.Pro_Class procla)
        {
            if (procla.ParentID != 0)
            {
                classname += "-" + probll.GetProClassModel(procla.ParentID).ClassName;
                procla = probll.GetProClassModel(procla.ParentID);
                GetParentClassName(classname, probll, procla);
            }
            return classname;
        }
        public void DeleteProInfo(int ProID)
        {
            this.dal.DeleteProInfo(ProID);
        }
        public void DeleteProInfo(string ProID)
        {
            this.dal.DeleteProInfo(ProID);
        }
        public bool Exists(int ProID)
        {
            return this.dal.Exists(ProID);
        }
        public int GetMaxId()
        {
            return this.dal.GetMaxId();
        }
        public ArrayList GetProIDList(string strWhere)
        {
            return this.dal.GetProIDList(strWhere);
        }
        public DataSet GetProInfoList(int PageSize, int PageIndex, string OrderfldName, int OrderType, ref int IsReCount, string strWhere)
        {
            return this.dal.GetProInfoList(PageSize, PageIndex, OrderfldName, OrderType, ref IsReCount, strWhere);
        }
        public Model.Pro.Pro_Info GetProInfoModel(int ProID)
        {
            return this.dal.GetProInfoModel(ProID);
        }
        public DataSet GetProList(int strClassID, int strTop, string strOrder, string strWhere)
        {
            return this.dal.GetProList(strClassID, strTop, strOrder, strWhere);
        }
        public void ProAboutHtml(int strClassID, int strTop, string strOrder, string strWhere)
        {
            try
            {
                string sProPath = ConfigurationManager.AppSettings["ProPath"];
                DataSet ds = new DataSet();
                DataTable tb = this.GetProList(strClassID, strTop, strOrder, strWhere).Tables[0];
                string sHtml = "<table width=263 border=0 cellspacing=0 cellpadding=0>" + Environment.NewLine;
                foreach (DataRow db in tb.Rows)
                {
                    sHtml = sHtml + "  <tr>" + Environment.NewLine;
                    sHtml = sHtml + "    <td width=10 height=22 align=center scope=row></td>" + Environment.NewLine;
                    sHtml = sHtml + "    <td width=243 align=left><a href=" + sProPath + "/" + StringHelper.DateToYear(db["AddTime"].ToString()) + "/" + db["ProID"].ToString() + ".sHtml>" + StringHelper.GetFirstString(db["Title"].ToString(), 30) + "</a></td>" + Environment.NewLine;
                    sHtml = sHtml + "  </tr>" + Environment.NewLine;
                }
                sHtml = sHtml + "</table>";
                sProPath = string.Concat(new object[] { sProPath, "/About_", strClassID, ".html" });
                FileHelper.CreateFile(sProPath);
                using (StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath(sProPath).ToString(), false, Encoding.GetEncoding("utf-8")))
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

        public void ProHotHtml(int strClassID, int strTop, string strOrder, string strWhere)
        {
            try
            {
                string sProPath = ConfigurationManager.AppSettings["ProPath"];
                DataSet ds = new DataSet();
                DataTable tb = this.GetProList(strClassID, strTop, strOrder, strWhere).Tables[0];
                string sHtml = Environment.NewLine ?? "";
                foreach (DataRow db in tb.Rows)
                {
                    sHtml = sHtml + "<div class=\"TEOne\">" + Environment.NewLine;
                    sHtml = sHtml + "<img src=" + db["PicPath"].ToString() + db["PicName"].ToString() + " class=\"TEimg\" title=" + db["Title"].ToString() + ">" + Environment.NewLine;
                    TimeSpan Diff = (TimeSpan)(DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(db["AddTime"].ToString()));
                    if ((int.Parse(Diff.Days.ToString()) <= 30) && (int.Parse(db["IsVouch"].ToString()) == 1))
                    {
                        sHtml = sHtml + "<div class=\"TEText\"><span class=\"zi4\">" + StringHelper.GetFirstString(db["Title"].ToString(), 0x10) + "&nbsp;<img src=/images/i_new.gif width=18 height=7 alt=最新><br>零售价：" + db["Price"].ToString() + "</span><br>" + Environment.NewLine;
                    }
                    else
                    {
                        sHtml = sHtml + "<div class=\"TEText\"><span class=\"zi4\">" + StringHelper.GetFirstString(db["Title"].ToString(), 0x10) + "&nbsp;<br>零售价：" + db["Price"].ToString() + "</span><br>" + Environment.NewLine;
                    }
                    if (db["SpecialUrl"].ToString() != "")
                    {
                        sHtml = sHtml + "<h1><a href=" + db["SpecialUrl"].ToString() + " target=_blank><img src=\"/images/chanpin-arrow.jpg\" width=57 height=16 title=查看详细 border=0></a></h1></div></div>" + Environment.NewLine;
                    }
                    else
                    {
                        sHtml = sHtml + "<h1><a href=" + sProPath + "/" + StringHelper.DateToYear(db["AddTime"].ToString()) + "/" + db["ProID"].ToString() + ".sHtml target=_blank><img src=\"/images/chanpin-arrow.jpg\" width=57 height=16 title=查看详细 border=0></a></h1></div></div>" + Environment.NewLine;
                    }
                }
                sProPath = string.Concat(new object[] { sProPath, "/Hot_", strClassID, ".html" });
                FileHelper.CreateFile(sProPath);
                using (StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath(sProPath).ToString(), false, Encoding.GetEncoding("utf-8")))
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

        public void ProVouchHtml(int strClassID, int strTop, string strOrder, string strWhere)
        {
            try
            {
                string sProPath = ConfigurationManager.AppSettings["ProPath"];
                DataSet ds = new DataSet();
                DataTable tb = this.GetProList(strClassID, strTop, strOrder, strWhere).Tables[0];
                string sHtml = ("<table width=100% border=0 cellspacing=0 cellpadding=0>" + Environment.NewLine) + " <tr>" + Environment.NewLine;
                int i = 0;
                foreach (DataRow db in tb.Rows)
                {
                    sHtml = sHtml + "   <td height=150 align=left scope=row><table width=162 border=0 cellspacing=0 cellpadding=0 class=newlist>" + Environment.NewLine;
                    sHtml = sHtml + " <tr>" + Environment.NewLine;
                    sHtml = sHtml + "   <td colspan=3 scope=row><img src=/images/picbgx1x.gif /></td>" + Environment.NewLine;
                    sHtml = sHtml + " </tr>" + Environment.NewLine;
                    sHtml = sHtml + " <tr>" + Environment.NewLine;
                    sHtml = sHtml + "   <td width=11 scope=row><img src=/images/picbgx2.gif /></td>" + Environment.NewLine;
                    sHtml = sHtml + "   <td width=137 height=100 scope=row align=center><a href=" + sProPath + "/" + StringHelper.DateToYear(db["AddTime"].ToString()) + "/" + db["ProID"].ToString() + ".sHtml><img src=" + db["PicPath"].ToString() + "135X100" + db["PicName"].ToString() + " border=0></a></td>" + Environment.NewLine;
                    sHtml = sHtml + "   <td width=14 scope=row><img src=/images/picbgx3.gif /></td>" + Environment.NewLine;
                    sHtml = sHtml + " </tr>" + Environment.NewLine;
                    sHtml = sHtml + " <tr>" + Environment.NewLine;
                    sHtml = sHtml + "   <td height=11 colspan=3 scope=row><img src=/images/picbgx4x.gif /></td>" + Environment.NewLine;
                    sHtml = sHtml + " </tr>" + Environment.NewLine;
                    sHtml = sHtml + " <tr>" + Environment.NewLine;
                    sHtml = sHtml + "   <td colspan=3 align=center class=tdx3 scope=row><a href=" + sProPath + "/" + StringHelper.DateToYear(db["AddTime"].ToString()) + "/" + db["ProID"].ToString() + ".sHtml target=_blank>" + StringHelper.GetFirstString(db["Title"].ToString(), 20) + "</a></td>" + Environment.NewLine;
                    sHtml = sHtml + " </tr>" + Environment.NewLine;
                    sHtml = sHtml + "</table></td>" + Environment.NewLine;
                    i++;
                    if ((i % 3) == 0)
                    {
                        sHtml = sHtml + " </tr>" + Environment.NewLine;
                        sHtml = sHtml + " <tr>" + Environment.NewLine;
                    }
                }
                sHtml = (sHtml + " </tr>" + Environment.NewLine) + "</table>" + Environment.NewLine;
                sProPath = string.Concat(new object[] { sProPath, "/Vouch_", strClassID, ".html" });
                FileHelper.CreateFile(sProPath);
                using (StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath(sProPath).ToString(), false, Encoding.GetEncoding("utf-8")))
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

        public int UpdateProInfo(Model.Pro.Pro_Info model)
        {
            int result = this.dal.UpdateProInfo(model);
            if (result > 0)
            {
                try
                {
                    this.CreateHtml(model.ProID);
                }
                catch
                {
                }
            }
            return result;
        }
        public void UpProInfo(string ProID, string Act, string YesNo)
        {
            this.dal.UpProInfo(ProID, Act, YesNo);
        }
        public int VisitProInfo(int ProID)
        {
            return this.dal.VisitProInfo(ProID);
        }

    }


}
