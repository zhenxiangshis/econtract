using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace qihang.admin.Student
{
    public partial class Student_Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "POST")
            {
                try
                {
                    BLL.Student_Info bllStudent = new BLL.Student_Info();
                    Model.Student_Info model = new Model.Student_Info();
                    model.Name = Request.Form["txtUserName"].Trim().ToString();
                    model.UserID = int.Parse(this.Session["UserId"].ToString());
                    var sex = "";
                    model.Birthday = GetBirthdayAndSex(Request.Form["txtIDCard"].Trim().ToString(), out sex);
                    model.Sex = sex;
                    model.Education = Request.Form["txtEducation"].Trim().ToString();
                    model.EduType = Request.Form["txtEduType"].Trim().ToString();
                    model.GraduationTime = Request.Form["txtGraTime"].Trim().ToString();
                    model.Major = Request.Form["txtMajor"].Trim().ToString();
                    model.Address = Request.Form["txtAddress"].Trim().ToString();
                    model.IDCard = Request.Form["txtIDCard"].Trim().ToString();
                    model.Phone = Request.Form["txtPhone"].Trim().ToString();
                    model.Email = Request.Form["txtEmail"].Trim().ToString();
                    model.QQ = Request.Form["txtQQ"].Trim().ToString();
                    model.LinkName = Request.Form["txtLinkName"].Trim().ToString();
                    model.LinkPhone = Request.Form["txtLinkPhone"].Trim().ToString();
                    model.Money =Convert.ToDecimal( Request.Form["txtMoney"].Trim().ToString());
                    model.PayMethod = Request.Form["txtPayMethod"].Trim().ToString();
                    model.ClassName = Request.Form["listClass"].Trim().ToString();

                    bllStudent.Add(model);
                    setCookie("success", model.Name + "添加成功!");

                    base.Response.Redirect("Student_List.aspx", false);


                }
                catch (Exception ex)
                {
                    setCookie("error", ex.Message);
                }

            }
        }
        /// <summary>
        /// 根据身份证号获取出生日期和性别
        /// </summary>
        /// <param name="identityCard">输入的身份证号码</param>
        /// <returns>出身日期</returns>

        public static string GetBirthdayAndSex(string identityCard, out string sex)
        {
            string birthday = "";
            sex = "";
            if (string.IsNullOrEmpty(identityCard))
            {
                return birthday;
            }
            else
            {
                if (identityCard.Length != 15 && identityCard.Length != 18)//身份证号码只能为15位或18位其它不合法
                {
                    return birthday;
                }
            }
            if (identityCard.Length == 18)//处理18位的身份证号码从号码中得到生日和性别代码
            {
                birthday = identityCard.Substring(6, 4) + "-" + identityCard.Substring(10, 2) + "-" + identityCard.Substring(12, 2);
                sex = identityCard.Substring(14, 3);
            }
            if (identityCard.Length == 15)
            {
                birthday = "19" + identityCard.Substring(6, 2) + "-" + identityCard.Substring(8, 2) + "-" + identityCard.Substring(10, 2);
                sex = identityCard.Substring(12, 3);
            }
            if (int.Parse(sex) % 2 == 0)//性别代码为偶数是女性，奇数为男性
            {
                sex = "女";
            }
            else
            {
                sex = "男";
            }
            return birthday;
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