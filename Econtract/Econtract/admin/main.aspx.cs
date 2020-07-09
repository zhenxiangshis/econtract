using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBUtility;
using System.Data.SqlClient;
using System.Data;

public partial class admin_main : System.Web.UI.Page
{

    public string _newsNumber = "";
    public string _productsNumber = "";
    public string _dataNumber = "";
    public string _statNumber = "";
    public string _roleId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        _roleId = DbHelperSQL.ExecuteSqlGet("SELECT [RoleID] FROM Accounts_UserRoles where [UserID] = " + this.Session["UserId"].ToString(), "").ToString();

        //Response.Write(_roleId);
        
        if (_roleId == "1")
        {
            _newsNumber = DbHelperSQL.ExecuteSqlGet("SELECT count(*) FROM Article_Info", "").ToString();
            _productsNumber = DbHelperSQL.ExecuteSqlGet("SELECT count(*) FROM Student_Info", "").ToString();
            _dataNumber = DbHelperSQL.ExecuteSqlGet("SELECT count(*) FROM Article_Info where ClassID=57", "").ToString();
            _statNumber = selectCount(4).ToString();
        }

    }

    /// <summary>
    /// 总体统计访问量统计 type 1.总体2.年3.月4.日5.昨日
    /// </summary>
    /// <returns>返回bool</returns>
    public string selectCount(int type)
    {
        SqlParameter[] parameters = {
                new SqlParameter("@type",SqlDbType.Int),
                new SqlParameter("@rowcount",SqlDbType.Int)};
        parameters[0].Value = type;
        parameters[1].Direction = ParameterDirection.Output;
        DbHelperSQL.RunProcedure("selectcount", parameters);
        return parameters[1].Value.ToString();
    }
}