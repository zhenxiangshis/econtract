<%@ WebHandler Language="C#" Class="Product" %>

using System;
using System.Web;
using System.Text;
using BLL.Article;
using System.Data;
using System.Data.SqlClient;
using DBUtility;

public class Product : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "application/Json";

        var type = context.Request.QueryString["type"];

        StringBuilder dataJson = new StringBuilder();
        StringBuilder data = new StringBuilder();

        if (type != null)
        {
            switch (type)
            {
                case "time":
                    {
                        DataSet ds = DbHelperSQL.Query("SELECT top 4 * FROM [tb_hourStat] order by id desc", "ds");
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            data.AppendFormat(",{25} \"name\": \"{24}\", \"data\":[{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23}] {26}", dr["hour0"].ToString(), dr["hour1"].ToString(), dr["hour2"].ToString(), dr["hour3"].ToString(), dr["hour4"].ToString(), dr["hour5"].ToString(), dr["hour6"].ToString(), dr["hour7"].ToString(), dr["hour8"].ToString(), dr["hour9"].ToString(), dr["hour10"].ToString(), dr["hour11"].ToString(), dr["hour12"].ToString(), dr["hour13"].ToString(), dr["hour14"].ToString(), dr["hour15"].ToString(), dr["hour16"].ToString(), dr["hour17"].ToString(), dr["hour18"].ToString(), dr["hour19"].ToString(), dr["hour20"].ToString(), dr["hour21"].ToString(), dr["hour22"].ToString(), dr["hour23"].ToString(), DateTime.Parse(dr["date"].ToString()).ToShortDateString(), "{", "}");
                        }
                        dataJson.AppendFormat("{0} {1} {2}", "[", data.Length != 0 ? data.ToString().Substring(1, data.Length - 1) : "", "]");

                        break;
                    }
                case "date":
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            DateTime dt = DateTime.Now.AddMonths(-i);
                            DataSet ds = DbHelperSQL.Query("SELECT [sumNum],[days] FROM [tb_hourStat] where [years] = " + dt.Year + " and [months] = " + dt.Month + " order by days", "ds");
                            data.AppendFormat(",{0}\"name\":\"{1}\",\"data\":[", "{", dt.Year.ToString() + "年" + dt.Month.ToString() + "月");
                            for (int k = 1; k <= 31; k++)
                            {
                                data.AppendFormat("{0}{1}", (k != 1 ? "," : ""), ds.Tables[0].Select("days=" + k).Length != 0 ? ds.Tables[0].Select("days=" + k)[0]["sumNum"].ToString() : "0");
                            }
                            data.Append("]}");
                        }
                        dataJson.AppendFormat("{0} {1} {2}", "[", data.Length != 0 ? data.ToString().Substring(1, data.Length - 1) : "", "]");
                        break;
                    }
                case "Search":
                    {
                        string dateStart = context.Request.QueryString["sdate"].ToString();
                        string dateEnd = context.Request.QueryString["edate"].ToString();
                        StringBuilder data2 = new StringBuilder();

                        DataSet ds = DbHelperSQL.Query("SELECT [sumNum],[date] FROM [tb_hourStat] where date >'" + dateStart + "' and date <'" + dateEnd + "' order by date", "ds");
                        data.AppendFormat("{0}\"name\":\"{1}\",\"data\":[", "{", dateStart + "到" + dateEnd);
                        int count = 0;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            data.AppendFormat("{0}{1}", count != 0 ? "," : "", dr["sumNum"].ToString());
                            data2.AppendFormat("{0}\"{1}\"", count != 0 ? "," : "", DateTime.Parse(dr["date"].ToString()).ToString("yyyy年MM月dd日"));
                            count++;
                        }
                        data.Append("]}");

                        dataJson.AppendFormat("{0} \"categories\":[{2}],\"series\":[ {3} ] ,\"Count\":{4} {1}", "{", "}", data2.Length != 0 ? data2.ToString() : "", data.Length != 0 ? data.ToString() : "", ds.Tables[0].Compute("SUM(sumNum)","true").ToString());
                        break;
                    }
                default:
                    {
                        DataSet ds = DbHelperSQL.Query("SELECT [" + type + "] a ,count([" + type + "]) b FROM [tb_dayStat] group by [" + type + "] order by b desc", "ds");
                        double _count = System.Convert.ToInt32(DbHelperSQL.ExecuteSqlGet("SELECT count(*) FROM [tb_dayStat]", ""));
                        double _other = 0; 
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            double _db = double.Parse(dr["b"].ToString()) / _count * 100;
                            if (_db < 1){
                                _other += _db;
                            }else{
                                data.AppendFormat(",[\"{0}\",{1}]", dr["a"].ToString(), _db);
                            }
                        }
                        data.AppendFormat(",[\"{0}\",{1}]", "其他", _other);
                        dataJson.AppendFormat("{0} \"data\" : [{1}]{2}", "{", data.Length != 0 ? data.ToString().Substring(1, data.Length - 1) : "", "}");
                        break;
                    }
            }

        }
        else
        {
            int iTotalRecords = System.Convert.ToInt32(DbHelperSQL.ExecuteSqlGet("SELECT count(*) FROM [tb_dayStat]", ""));
            int iDisplayStart = 1;
            int iDisplayLength = int.Parse(context.Request.QueryString["iDisplayLength"].ToString());

            string sEcho = context.Request.QueryString["sEcho"].ToString();
            int IsReCount = 0;
            // 分页       
            if (context.Request.QueryString["iDisplayStart"] != null && context.Request.QueryString["iDisplayLength"] != "-1")
            {
                iDisplayLength = int.Parse(context.Request.QueryString["iDisplayLength"].ToString());
                iDisplayStart = int.Parse(context.Request.QueryString["iDisplayStart"].ToString()) / iDisplayLength + 1;
            }

            DataSet set = new DataSet();
            set = GetList(iDisplayLength, iDisplayStart, ref IsReCount);

            foreach (DataRow row in set.Tables[0].Rows)
            {
                data.AppendFormat(",[\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\"]", row["id"].ToString(), row["vcome"].ToString(), row["vpage"].ToString(), row["ip"].ToString(), row["system"].ToString(), row["browser"].ToString(), row["source"].ToString(), row["resolution"].ToString(), DateTime.Parse(row["date"].ToString()).ToShortDateString(), row["sumNum"].ToString());
            }

            dataJson.AppendFormat("{4}\"sEcho\": {0},\"iTotalRecords\": {1},\"iTotalDisplayRecords\": {2},\"aaData\": [{3}]{5}", sEcho, iTotalRecords, IsReCount, data.Length != 0 ? data.ToString().Substring(1, data.Length - 1) : "", "{", "}");

        }


        context.Response.Write(dataJson.ToString());
    }

    public DataSet GetList(int PageSize, int PageIndex, ref int IsReCount)
    {

        SqlParameter[] parameters = {
                     new SqlParameter("@PageSize", SqlDbType.Int),
                     new SqlParameter("@PageIndex",SqlDbType.Int),
                     new SqlParameter("@rowCount",SqlDbType.Int)};
        parameters[0].Value = PageSize;
        parameters[1].Value = PageIndex;
        parameters[2].Direction = ParameterDirection.Output;
        DataSet dr = DbHelperSQL.RunProcedure("selectCountClear", parameters, "ds");
        IsReCount = int.Parse(parameters[2].Value.ToString());
        return dr;

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}