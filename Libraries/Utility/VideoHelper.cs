using System.Configuration;
using System.IO;
using System.Web;
namespace Utility
{
    public class VideoHelper
    {
        public VideoHelper()
        {

        }
        //文件路径
        public static string ffmpegtool = ConfigurationManager.AppSettings["ffmpeg"];
        public static string upFile = ConfigurationManager.AppSettings["upfile"];
        public static string imgFile = ConfigurationManager.AppSettings["imgfile"] + "/";
        //文件图片大小
        public static string sizeOfImg = ConfigurationManager.AppSettings["CatchFlvImgSize"];
        //文件大小

        //获取文件的名字
        public static string GetFileName(string fileName)
        {
            int i = fileName.LastIndexOf("\\") + 1;
            string Name = fileName.Substring(i);
            return Name;
        }
        //获取文件扩展名
        public static string GetExtension(string fileName)
        {
            int i = fileName.LastIndexOf(".") + 1;
            string Name = fileName.Substring(i);
            return Name;
        }
        //

        #region
        //运行FFMpeg的视频解码，(这里是绝对路径)
        /// <summary>
        /// 转换文件并保存在指定文件夹下面(这里是绝对路径)
        /// </summary>
        /// <param name="fileName">上传视频文件的路径（绝对路径）</param>
        /// <returns>成功:返回图片地址;失败:返回空字符串</returns>
        public static string CatchImg(string fileName)
        {
            //
            string ffmpeg = HttpContext.Current.Server.MapPath(ffmpegtool);
            //
            string flv_img = Path.ChangeExtension(fileName, "jpg");
            //
            string FlvImgSize = sizeOfImg;
            //
            System.Diagnostics.ProcessStartInfo ImgstartInfo = new System.Diagnostics.ProcessStartInfo(ffmpeg);
            ImgstartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //
            ImgstartInfo.Arguments = "  -i  " + fileName + "  -y  -f  image2  -ss 2 -vframes 1  -s  " + FlvImgSize + " " + flv_img;
            try
            {
                System.Diagnostics.Process.Start(ImgstartInfo);
            }
            catch
            {
                return "";
            }
            //
            if (System.IO.File.Exists(flv_img))
            {
                return flv_img;
            }

            return "";
        }
        #endregion
        #region
        //运行FFMpeg的视频解码，(这里是绝对路径)
        /// <summary>
        /// 截取一段时长视频
        /// </summary>
        /// <param name="fileName">上传视频文件的路径（原文件）</param>
        /// <param name="startTime">截取开始位置（00:00:00形式）</param>
        /// <param name="Length">截取的时长（00:00:00）</param>
        /// <param name="outFileName">保存截取的视频</param>
        /// <returns></returns>
        public static string CatchVideo(string fileName, string startTime, string Length, string outFileName)
        {
            //
            string ffmpeg = HttpContext.Current.Server.MapPath(ffmpegtool);
            //
            string FlvImgSize = sizeOfImg;
            //
            System.Diagnostics.ProcessStartInfo ImgstartInfo = new System.Diagnostics.ProcessStartInfo(ffmpeg);
            ImgstartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            //

            ImgstartInfo.Arguments = "-ss" + startTime + " -i " + fileName + " -acodec copy -vcodec copy -t " + Length + " " + outFileName;
            try
            {
                System.Diagnostics.Process.Start(ImgstartInfo);
            }
            catch
            {
                return "";
            }

            return "";
        }
        #endregion
        //
    }
}
