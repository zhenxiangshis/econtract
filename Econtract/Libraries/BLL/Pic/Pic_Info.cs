using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using DALFactory;
using IDAL.Pic;
using Model;
using Utility;
using System.IO;
using System.Configuration;
using System.Web;

namespace BLL.Pic
{
    public class Pic_Info
    {
        // Fields
        private readonly IPic_Info dal;

        // Methods
        public Pic_Info()
        {
            this.dal = DataAccess.CreatePic_Info();
        }
        public int AddPicInfo(Model.Pic.Pic_Info model)
        {
            int result = this.dal.AddPicInfo(model);
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

        public void CreateHtml(int PicID)
        {
            try
            {
                Model.Pic.Pic_Info model = this.GetPicInfoModel(PicID);
                Temp.Temp_Info Tempbll = new Temp.Temp_Info();
                string sPicPath = ConfigurationManager.AppSettings["PicPath"];
                string sHtmlTemp = Tempbll.GetTempInfoModel(7).Content;
                string sPicID = model.PicID.ToString();
                string sClassID = model.ClassID.ToString();
                string sClassName = model.ClassName.ToString();
                string sTitle = model.Title.ToString();
                string sRemark = HttpUtility.HtmlDecode(model.Remark.ToString()).ToString();
                string sContent = model.PicPath.ToString() + model.PicName.ToString();
                string sCreateShop = model.CreateShop.ToString();
                string sShoper = model.Shoper.ToString();
                string sAddress = model.Address.ToString();
                sHtmlTemp = sHtmlTemp.Replace("$Title$", sTitle).Replace("$Remark$", sRemark).Replace("$PicPath$", sContent).Replace("$Shoper$", sShoper).Replace("$Address$", sAddress);
                sPicPath = string.Concat(new object[] { sPicPath, "/", StringHelper.DateToYear(model.AddTime.ToString()), "/", model.PicID, ".sHtml" });
                FileHelper.CreateFile(sPicPath);
                using (StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath(sPicPath).ToString(), false, Encoding.GetEncoding("GB2312")))
                {
                    sw.WriteLine(sHtmlTemp);
                    sw.Flush();
                    sw.Close();
                }
                this.PicHotHtml(0, 1, "TopTime", " And IsTop=1 ");
                this.PicVouchHtml(12, 3, "AddTime", "");
            }
            catch
            {
            }
        }

        public void DeletePicInfo(int PicID)
        {
            this.dal.DeletePicInfo(PicID);
        }

        public void DeletePicInfo(string PicID)
        {
            this.dal.DeletePicInfo(PicID);
        }
        public bool Exists(int PicID)
        {
            return this.dal.Exists(PicID);
        }
        public int GetMaxId()
        {
            return this.dal.GetMaxId();
        }

        public ArrayList GetPicIDList(string strWhere)
        {
            return this.dal.GetPicIDList(strWhere);
        }
        public DataSet GetPicInfoList(int PageSize, int PageIndex, string OrderfldName, int OrderType, ref int IsReCount, string strWhere)
        {
            return this.dal.GetPicInfoList(PageSize, PageIndex, OrderfldName, OrderType, ref IsReCount, strWhere);
        }

        public Model.Pic.Pic_Info GetPicInfoModel(int PicID)
        {
            return this.dal.GetPicInfoModel(PicID);
        }
        public DataSet GetPicList(int strClassID, int strTop, string strOrder, string strWhere)
        {
            return this.dal.GetPicList(strClassID, strTop, strOrder, strWhere);
        }
        public DataSet GetPicPageList(string tableName, string tableId, string order, string where, int pageCurrent, int pageSize, ref int recordAmount, ref int pageAmount)
        {
            return this.dal.GetPicPageList(tableName, tableId, order, where, pageCurrent, pageSize, ref recordAmount, ref pageAmount);
        }
        public void PicAboutHtml(int strClassID, int strTop, string strOrder, string strWhere)
        {
            try
            {
                string sPicPath = ConfigurationManager.AppSettings["PicPath"];
                DataSet ds = new DataSet();
                DataTable tb = this.GetPicList(strClassID, strTop, strOrder, strWhere).Tables[0];
                string sHtml = "<table width=263 border=0 cellspacing=0 cellpadding=0>" + Environment.NewLine;
                foreach (DataRow db in tb.Rows)
                {
                    sHtml = sHtml + "  <tr>" + Environment.NewLine;
                    sHtml = sHtml + "    <td width=10 height=22 align=center scope=row></td>" + Environment.NewLine;
                    sHtml = sHtml + "    <td width=243 align=left><a href=" + sPicPath + "/" + StringHelper.DateToYear(db["AddTime"].ToString()) + "/" + db["PicID"].ToString() + ".sHtml>" + StringHelper.GetFirstString(db["Title"].ToString(), 30) + "</a></td>" + Environment.NewLine;
                    sHtml = sHtml + "  </tr>" + Environment.NewLine;
                }
                sHtml = sHtml + "</table>";
                sPicPath = string.Concat(new object[] { sPicPath, "/About_", strClassID, ".Html" });
                FileHelper.CreateFile(sPicPath);
                using (StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath(sPicPath).ToString(), false, Encoding.GetEncoding("gb2312")))
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
        public void PicHotHtml(int strClassID, int strTop, string strOrder, string strWhere)
        {
            try
            {
                string sPicPath = ConfigurationManager.AppSettings["PicPath"];
                DataSet ds = new DataSet();
                DataTable tb = this.GetPicList(strClassID, strTop, strOrder, strWhere).Tables[0];
                string sHtml = Environment.NewLine ?? "";
                foreach (DataRow db in tb.Rows)
                {
                    sHtml = "<img src=" + db["PicPath"].ToString() + db["PicName"].ToString() + " class='Aimage' width=109 height=75>" + Environment.NewLine;
                    sHtml = sHtml + "<h2>[<a href=" + sPicPath + "/" + StringHelper.DateToYear(db["AddTime"].ToString()) + "/" + db["PicID"].ToString() + ".sHtml target=_blank>" + StringHelper.GetFirstString(db["Title"].ToString(), 30) + "</a>]</h2>" + Environment.NewLine;
                    sHtml = sHtml + "<p>" + StringHelper.GetFirstString(db["Tag"].ToString(), 0x3e) + "[<a href=" + sPicPath + "/" + StringHelper.DateToYear(db["AddTime"].ToString()) + "/" + db["PicID"].ToString() + ".sHtml target=_blank>ÏêÏ¸</a>]</p>" + Environment.NewLine;
                }
                sPicPath = string.Concat(new object[] { sPicPath, "/Hot_", strClassID, ".Html" });
                FileHelper.CreateFile(sPicPath);
                using (StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath(sPicPath).ToString(), false, Encoding.GetEncoding("gb2312")))
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

        public void PicVouchHtml(int strClassID, int strTop, string strOrder, string strWhere)
        {
            try
            {
                string sPicPath = ConfigurationManager.AppSettings["PicPath"];
                DataSet ds = new DataSet();
                DataTable tb = this.GetPicList(strClassID, strTop, strOrder, strWhere).Tables[0];
                string sHtml = Environment.NewLine ?? "";
                foreach (DataRow db in tb.Rows)
                {
                    sHtml = sHtml + "   <td align=\"left\"><img src=\"" + db["PicPath"].ToString() + db["PicName"].ToString() + "\" width=\"149\" title=\"" + db["Title"].ToString() + "\" height=\"112\"></td>" + Environment.NewLine;
                }
                if (strClassID == 12)
                {
                    sPicPath = string.Concat(new object[] { sPicPath, "/Vouch_", strClassID, ".Html" });
                    FileHelper.CreateFile(sPicPath);
                    using (StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath(sPicPath).ToString(), false, Encoding.GetEncoding("gb2312")))
                    {
                        sw.WriteLine(sHtml);
                        sw.Flush();
                        sw.Close();
                    }
                }
            }
            catch
            {
            }
        }
        public int UpdatePicInfo(Model.Pic.Pic_Info model)
        {
            int result = this.dal.UpdatePicInfo(model);
            if (result > 0)
            {
                try
                {
                    this.CreateHtml(model.PicID);
                }
                catch
                {
                }
            }
            return result;
        }
        public void UpPicInfo(string PicID, string Act, string YesNo)
        {
            this.dal.UpPicInfo(PicID, Act, YesNo);
        }
        public int VisitPicInfo(int PicID)
        {
            return this.dal.VisitPicInfo(PicID);
        }
    }


}
