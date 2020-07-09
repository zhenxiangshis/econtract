using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Configuration;
using IDAL;

namespace DALFactory
{
    public sealed class DataAccess
    {
        // Fields
        private static readonly string path;

        // Methods
        static DataAccess()
        {
            path = ConfigurationManager.AppSettings["DAL"];
        }

        public DataAccess() { }
        public static IDAL.Account.IAccounts_Users CreateAccounts_Users()
        {
            string CacheKey = path + ".Account.Accounts_Users";
            return (IDAL.Account.IAccounts_Users)CreateObject(path, CacheKey);
        }
        public static IDAL.IAccounts_Department CreateAccounts_Department()
        {
            string CacheKey = path + ".Accounts_Department";
            return (IDAL.IAccounts_Department)CreateObject(path, CacheKey);
        }
        public static IDAL.IAccounts_UserLoginInfo CreateAccounts_UserLoginInfo()
        {
            string CacheKey = path + ".Accounts_UserLoginInfo";
            return (IDAL.IAccounts_UserLoginInfo)CreateObject(path, CacheKey);
        }
        public static IDAL.Article.IArticle_Class CreateArticle_Class()
        {
            string CacheKey = path + ".Article.Article_Class";
            return (IDAL.Article.IArticle_Class)CreateObject(path, CacheKey);
        }

        public static IDAL.Article.IArtilce_Comment CreateArtilce_Comment()
        {
            string CacheKey = path + ".Article.Artilce_Comment";
            return (IDAL.Article.IArtilce_Comment)CreateObject(path, CacheKey);
        }

        public static IDAL.Article.IArticle_Info CreateArticle_Info()
        {
            string CacheKey = path + ".Article.Article_Info";
            return (IDAL.Article.IArticle_Info)CreateObject(path, CacheKey);
        }
        public static IDAL.Book.IBook_Info CreateBook_Info()
        {
            string CacheKey = path + ".Book.Book_Info";
            return (IDAL.Book.IBook_Info)CreateObject(path, CacheKey);
        }

        public static IDAL.Book.IBook_Re CreateBook_Re()
        {
            string CacheKey = path + ".Book.Book_Re";
            return (IDAL.Book.IBook_Re)CreateObject(path, CacheKey);
        }

        public static IDAL.User.IH_User CreateH_User()
        {
            string CacheKey = path + ".User.H_User";
            return (IDAL.User.IH_User)CreateObject(path, CacheKey);
        }

        public static IDAL.Job.IJob_Info CreateJob_Info()
        {
            string CacheKey = path + ".Job.Job_Info";
            return (IDAL.Job.IJob_Info)CreateObject(path, CacheKey);
        }

        public static IDAL.Job.IJob_Resume CreateJob_Resume()
        {
            string CacheKey = path + ".Job.Job_Resume";
            return (IDAL.Job.IJob_Resume)CreateObject(path, CacheKey);
        }

        public static IDAL.Link.ILink_Class CreateLink_Class()
        {
            string CacheKey = path + ".Link.Link_Class";
            return (IDAL.Link.ILink_Class)CreateObject(path, CacheKey);
        }

        public static IDAL.Link.ILink_Info CreateLink_Info()
        {
            string CacheKey = path + ".Link.Link_Info";
            return (IDAL.Link.ILink_Info)CreateObject(path, CacheKey);
        }

        private static object CreateObject(string path, string CacheKey)
        {
            object objType = DataCache.GetCache(CacheKey);
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(path).CreateInstance(CacheKey);
                    DataCache.SetCache(CacheKey, objType);
                }
                catch (Exception ex)
                {
                }
            }
            return objType;
        }

        private static object CreateObjectNoCache(string path, string CacheKey)
        {
            try
            {
                return Assembly.Load(path).CreateInstance(CacheKey);
            }
            catch
            {
                return null;
            }
        }

        public static IDAL.Pic.IPic_Class CreatePic_Class()
        {
            string CacheKey = path + ".Pic.Pic_Class";
            return (IDAL.Pic.IPic_Class)CreateObject(path, CacheKey);
        }

        public static IDAL.Pic.IPic_Comm CreatePic_Comm()
        {
            string CacheKey = path + ".Pic.Pic_Comm";
            return (IDAL.Pic.IPic_Comm)CreateObject(path, CacheKey);
        }

        public static IDAL.Pic.IPic_Info CreatePic_Info()
        {
            string CacheKey = path + ".Pic.Pic_Info";
            return (IDAL.Pic.IPic_Info)CreateObject(path, CacheKey);
        }

        public static IDAL.Pro.IPro_Class CreatePro_Class()
        {
            string CacheKey = path + ".Pro.Pro_Class";
            return (IDAL.Pro.IPro_Class)CreateObject(path, CacheKey);
        }
        public static IDAL.Pro.IPro_Info CreatePro_Info()
        {
            string CacheKey = path + ".Pro.Pro_Info";
            return (IDAL.Pro.IPro_Info)CreateObject(path, CacheKey);
        }

        public static IDAL.ISysManage CreateSysManage()
        {
            string CacheKey = path + ".SysManage";
            return (IDAL.ISysManage)CreateObject(path, CacheKey);
        }

        public static IDAL.Temp.ITemp_Info CreateTemp_Info()
        {
            string CacheKey = path + ".Temp.Temp_Info";
            return (IDAL.Temp.ITemp_Info)CreateObject(path, CacheKey);
        }

        public static IDAL.Stat.IVjian CreateVjian()
        {
            string CacheKey = path + ".Stat.Vjian";
            return (IDAL.Stat.IVjian)CreateObject(path, CacheKey);
        }
        public static IDAL.Stat.ITempView CreateTempView()
        {
            string CacheKey = path + ".Stat.TempView";
            return (IDAL.Stat.ITempView)CreateObject(path, CacheKey);
        }
        public static IDAL.Stat.IRpt_Daycount CreateRpt_Daycount()
        {
            string CacheKey = path + ".Stat.Rpt_Daycount";
            return (IDAL.Stat.IRpt_Daycount)CreateObject(path, CacheKey);
        }
        public static IDAL.Stat.IView CreateView()
        {
            string CacheKey = path + ".Stat.View";
            return (IDAL.Stat.IView)CreateObject(path, CacheKey);
        }
        public static IDAL.Stat.IStat_Search CreateStat_Search()
        {
            string CacheKey = path + ".Stat.Stat_Search";
            return (IDAL.Stat.IStat_Search)CreateObject(path, CacheKey);
        }
        public static IDAL.Stat.IgetIP CreategetIP()
        {
            string CacheKey = path + ".Stat.getIP";
            return (IDAL.Stat.IgetIP)CreateObject(path, CacheKey);
        }
        
        /// <summary>
        /// 创建UserType数据层接口。
        /// </summary>
        public static IDAL.IUserType CreateUserType()
        {

            string ClassNamespace = path + ".UserType";
            object objType = CreateObject(path, ClassNamespace);
            return (IDAL.IUserType)objType;
        }


        
        /// <summary>
        /// 创建Login_Info数据层接口。
        /// </summary>
        public static IDAL.ILogin_Info CreateLogin_Info()
        {

            string ClassNamespace = path + ".Login_Info";
            object objType = CreateObject(path, ClassNamespace);
            return (IDAL.ILogin_Info)objType;
        }


        /// <summary>
        /// 创建Download_Info数据层接口。
        /// </summary>
        public static IDAL.IDownload_Info CreateDownload_Info()
        {

            string ClassNamespace = path + ".Download_Info";
            object objType = CreateObject(path, ClassNamespace);
            return (IDAL.IDownload_Info)objType;
        }


        /// <summary>
        /// 创建Download数据层接口。
        /// </summary>
        public static IDAL.IDownload CreateDownload()
        {

            string ClassNamespace = path + ".Download";
            object objType = CreateObject(path, ClassNamespace);
            return (IDAL.IDownload)objType;
        }
        
        /// <summary>
		/// 创建Topic_InfoDAL数据层接口。
		/// </summary>
		public static IDAL.ITopic_Info CreateTopic_InfoDAL()
        {

            string ClassNamespace = path + ".Topic_Info";
            object objType = CreateObject(path, ClassNamespace);
            return (IDAL.ITopic_Info)objType;
        }
        
        /// <summary>
		/// 创建Student_Class数据层接口。
		/// </summary>
		public static IDAL.IStudent_Class CreateStudent_Class()
        {

            string ClassNamespace = path + ".Student_Class";
            object objType = CreateObject(path, ClassNamespace);
            return (IDAL.IStudent_Class)objType;
        }


        /// <summary>
        /// 创建Student_Contract数据层接口。
        /// </summary>
        public static IDAL.IStudent_Contract CreateStudent_Contract()
        {

            string ClassNamespace = path + ".Student_Contract";
            object objType = CreateObject(path, ClassNamespace);
            return (IDAL.IStudent_Contract)objType;
        }


        /// <summary>
        /// 创建Student_Info数据层接口。
        /// </summary>
        public static IDAL.IStudent_Info CreateStudent_Info()
        {

            string ClassNamespace = path + ".Student_Info";
            object objType = CreateObject(path, ClassNamespace);
            return (IDAL.IStudent_Info)objType;
        }
        /// <summary>
		/// 创建Contract_Temp数据层接口。
		/// </summary>
		public static IDAL.IContract_Temp CreateContract_Temp()
        {

            string ClassNamespace = path + ".Contract_Temp";
            object objType = CreateObject(path, ClassNamespace);
            return (IDAL.IContract_Temp)objType;
        }


        /// <summary>
        /// 创建Contract_Info数据层接口。
        /// </summary>
        public static IDAL.IContract_Info CreateContract_Info()
        {

            string ClassNamespace = path + ".Contract_Info";
            object objType = CreateObject(path, ClassNamespace);
            return (IDAL.IContract_Info)objType;
        }
        
        /// <summary>
        /// 创建surveyInfo数据层接口。
        /// </summary>
        public static IDAL.IsurveyInfo CreatesurveyInfo()
        {

            string ClassNamespace = path + ".surveyInfo";
            object objType = CreateObject(path, ClassNamespace);
            return (IDAL.IsurveyInfo)objType;
        }
        /// <summary>
		/// 创建dt_job数据层接口。
		/// </summary>
		public static IDAL.Idt_job Createdt_job()
        {

            string ClassNamespace = path + ".dt_job";
            object objType = CreateObject(path, ClassNamespace);
            return (IDAL.Idt_job)objType;
        }
    }
}
