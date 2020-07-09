using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using DALFactory;
using IDAL.Link;
using Model;
using Utility;
using System.IO;
using System.Configuration;
using System.Web;
namespace BLL.Link
{
    public class Link_Info
    {
        // Fields
        private readonly ILink_Info dal;

        // Methods
        public Link_Info()
        {
            this.dal = DataAccess.CreateLink_Info();
        }
        public int AddLinkInfo(Model.Link.Link_Info model)
        {
            int result = this.dal.AddLinkInfo(model);
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

        public void ClientInfoHtml(int strClassID, int strTop, string strOrder, string strWhere)
        {
            try
            {
                string sLinkPath = ConfigurationManager.AppSettings["LinkPath"];
                string sFilePath = "";
                DataSet ds = new DataSet();
                DataTable tb = this.GetLinkList(strClassID, strTop, strOrder, strWhere).Tables[0];
                string sHtml = "";
                foreach (DataRow db in tb.Rows)
                {
                    sHtml = "<ul><li><img src='" + db["LinkPath"].ToString() + db["LinkName"].ToString() + "'  border='0' alt='" + db["Title"].ToString() + "' /></li>" + Environment.NewLine;
                    sHtml = sHtml + "<li><a href=" + db["LinkUrl"].ToString() + " target=_blank title='" + db["Title"].ToString() + "'>" + db["Remark"].ToString() + "</a></li></ul>";
                    sFilePath = sLinkPath + "/ClientInfo_" + db["Importance"].ToString() + ".Html";
                    if (File.Exists(sFilePath))
                    {
                        FileHelper.DeleteFile(sFilePath);
                    }
                    FileHelper.CreateFile(sFilePath);
                    using (StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath(sFilePath).ToString(), false, Encoding.GetEncoding("gb2312")))
                    {
                        sw.WriteLine(sHtml);
                        sw.Flush();
                        sw.Close();
                    }
                    sFilePath = "";
                }
            }
            catch
            {
            }
        }

        public void CreateHtml(int LinkID)
        {
            try
            {
                this.LinkListHtml(0, 20, "Importance", "and ClassID<>3");
                this.LinkPicHtml(0, 20, "Importance", " AND LinkPath <> '' and ClassID<>3 ");
                this.LinkListHtml(1, 20, "Importance", " and ClassID<>3 ");
                this.LinkListHtml(2, 20, "Importance", " and ClassID<>3 ");
                this.ClientInfoHtml(3, 5, "AddTime", " and ClassID=3 and IsIndex = 1 and Importance < 6 ");
            }
            catch
            {
            }
        }
        public void DeleteLinkInfo(int LinkID)
        {
            this.dal.DeleteLinkInfo(LinkID);
        }
        public void DeleteLinkInfo(string LinkID)
        {
            this.dal.DeleteLinkInfo(LinkID);
        }
        public bool Exists(int LinkID)
        {
            return this.dal.Exists(LinkID);
        }
        public ArrayList GetLinkIDList(string strWhere)
        {
            return this.dal.GetLinkIDList(strWhere);
        }

        public DataSet GetLinkInfoList(int PageSize, int PageIndex, string OrderfldName, int OrderType, ref int IsReCount, string strWhere)
        {
            return this.dal.GetLinkInfoList(PageSize, PageIndex, OrderfldName, OrderType, ref IsReCount, strWhere);
        }
        public Model.Link.Link_Info GetLinkInfoModel(int LinkID)
        {
            return this.dal.GetLinkInfoModel(LinkID);
        }
        public DataSet GetLinkList(int strClassID, int strTop, string strOrder, string strWhere)
        {
            return this.dal.GetLinkList(strClassID, strTop, strOrder, strWhere);
        }
        public int GetMaxId()
        {
            return this.dal.GetMaxId();
        }
        public void LinkListHtml(int strClassID, int strTop, string strOrder, string strWhere)
        {
            try
            {
                string sLinkPath = ConfigurationManager.AppSettings["LinkPath"];
                DataSet ds = new DataSet();
                DataTable tb = this.GetLinkList(strClassID, strTop, strOrder, strWhere).Tables[0];
                string sHtml = "<ul>" + Environment.NewLine;
                foreach (DataRow db in tb.Rows)
                {
                    sHtml = sHtml + "<li><a href=" + db["LinkUrl"].ToString() + " target=_blank>" + db["Title"].ToString() + "</a></li>" + Environment.NewLine;
                }
                sHtml = sHtml + "</ul>" + Environment.NewLine;
                sLinkPath = string.Concat(new object[] { sLinkPath, "/Link_", strClassID, ".Html" });
                FileHelper.CreateFile(sLinkPath);
                using (StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath(sLinkPath).ToString(), false, Encoding.GetEncoding("gb2312")))
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

        public void LinkPicHtml(int strClassID, int strTop, string strOrder, string strWhere)
        {
            try
            {
                string sLinkPath = ConfigurationManager.AppSettings["LinkPath"];
                DataSet ds = new DataSet();
                DataTable tb = this.GetLinkList(strClassID, strTop, strOrder, strWhere).Tables[0];
                string sHtml = "<ul>" + Environment.NewLine;
                foreach (DataRow db in tb.Rows)
                {
                    sHtml = sHtml + "<li><a href=" + db["LinkUrl"].ToString() + " target=_blank title='" + db["Title"].ToString() + "'><img src='" + db["LinkPath"].ToString() + db["LinkName"].ToString() + "' width='88' height='31' border='0' /></a></li>" + Environment.NewLine;
                }
                sHtml = sHtml + "</ul>" + Environment.NewLine;
                sLinkPath = string.Concat(new object[] { sLinkPath, "/LinkPic_", strClassID, ".Html" });
                FileHelper.CreateFile(sLinkPath);
                using (StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath(sLinkPath).ToString(), false, Encoding.GetEncoding("gb2312")))
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

        public int UpdateLinkInfo(Model.Link.Link_Info model)
        {
            int result = this.dal.UpdateLinkInfo(model);
            if (result > 0)
            {
                try
                {
                    this.CreateHtml(model.LinkID);
                }
                catch
                {
                }
            }
            return result;
        }

        public void UpLinkInfo(string LinkID, string Act, string YesNo)
        {
            this.dal.UpLinkInfo(LinkID, Act, YesNo);
        }

        public int VisitLinkInfo(int LinkID)
        {
            return this.dal.VisitLinkInfo(LinkID);
        }

    }

 

}
