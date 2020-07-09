using PdfiumViewer;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace Utility
{
    public static class PdfHelper
    {
        /// <summary>
        /// 清晰度，值越大越清晰
        /// </summary>
        public enum Definition
        {
            One = 1, Two = 2, Three = 3, Four = 4, Five = 5, Six = 6, Seven = 7, Eight = 8, Nine = 9, Ten = 10
        }
        /// <summary>
        /// 将PDF转换为图片(PdfiumViewer方法，需安装ImageResizer.Plugins.PdfiumRenderer.Pdfium.Dll和PdfiumViewer。)
        /// </summary>
        /// <param name="pdfPath">pdf文件位置</param>
        /// <param name="pageNumber">pdf文件张数</param>
        /// <param name="size">pdf文件尺寸</param>
        /// <param name="outputPath">输出图片位置与名称</param>
        public static void RenderPage(string pdfPath, int pageNumber, Size size, string outputPath, int dpi = 300)
        {
            #region 调用方法
            //转一页的话直接调用RenderPage
            //转整个文档调用
            //var pdf = PdfDocument.Load(@"d://20190514174209.pdf");
            //var pdfpage = pdf.PageCount;
            //var pagesizes = pdf.PageSizes;

            //for (int i = 1; i <= pdfpage; i++)
            //{
            //    Size size = new Size();
            //    size.Height = (int)pagesizes[(i - 1)].Height + 265;
            //    size.Width = (int)pagesizes[(i - 1)].Width + 405;
            //    PDFHelp.RenderPage(@"d://20190514174209.pdf", i, size, @"d://" + i + @".jpg");
            //}
            #endregion
            using (var document = PdfDocument.Load(pdfPath))
            using (var stream = new FileStream(outputPath, FileMode.Create))
            using (var image = GetPageImage(pageNumber, size, document, dpi))
            {
                image.Save(stream, ImageFormat.Jpeg);
            }
        }
        /// <summary>
        /// 将PDF转换为图片(PdfiumViewer方法，需安装ImageResizer.Plugins.PdfiumRenderer.Pdfium.Dll和PdfiumViewer。)
        /// </summary>
        /// <param name="pdfPath">pdf文件位置</param>
        /// <param name="outPath"></param>
        /// <param name="dpi"></param>
        public static void ConvertToImage(string pdfPath, string outPath, ImageFormat imageFormat, int startPageNum = 0, int endPageNum = 0, int dpi = 300)
        {
            var pdf = PdfDocument.Load(pdfPath);
            var pdfpage = pdf.PageCount;
            var pagesizes = pdf.PageSizes;
            if (!Directory.Exists(outPath))
            {
                Directory.CreateDirectory(outPath);
            }
            // validate pageNum
            if (startPageNum <= 0)
            {
                startPageNum = 1;
            }
            if (endPageNum > pdf.PageCount || endPageNum <= 0)
            {
                endPageNum = pdf.PageCount;
            }
            if (startPageNum > endPageNum)
            {
                int tempPageNum = startPageNum;
                startPageNum = endPageNum;
                endPageNum = startPageNum;
            }
            for (int i = startPageNum; i <= endPageNum; i++)
            {
                Size size = new Size(1190,1682);
                //size.Height = (int)pagesizes[(i - 1)].Height * 2;
                //size.Width = (int)pagesizes[(i - 1)].Width * 2;
                using (var stream = new FileStream(outPath + i + "."+ imageFormat.ToString(), FileMode.Create))
                using (var image = GetPageImage(i, size, pdf, dpi))
                {
                    image.Save(stream, imageFormat);
                }
                //RenderPage(@"d://20190514174209.pdf", i, size, @"d://" + i + @".jpg");
            }
        }
        private static Image GetPageImage(int pageNumber, Size size, PdfDocument document, int dpi)
        {
            return document.Render(pageNumber - 1, size.Width, size.Height, dpi, dpi, PdfRenderFlags.Annotations);
        }

    }
}
