using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;

namespace Utility
{
    public class JavaScriptHelper
    {
        // Methods
        public JavaScriptHelper()
        {
        }
        public static void Alert(object message)
        {
            string js = "<Script language='JavaScript'>\r\n alert('{0}');  \r\n</Script>";
            HttpContext.Current.Response.Write(string.Format(js, message.ToString()));
        }
        public static void Alert(string message)
        {
            message = message.Trim();
            string js = "<Script language='JavaScript'>\r\n alert('" + message + "');</Script>";
            HttpContext.Current.Response.Write(js);
        }
        public static void AlertAndRedirect(string message, string toURL)
        {
            string js = "<script language=javascript>alert('{0}');window.location.replace('{1}')";
            HttpContext.Current.Response.Write(string.Format(js, message, toURL));
        }
        public static void CloseOpenerWindow()
        {
            string js = "<Script language='JavaScript'>\r\nwindow.opener.close();\r\n</Script>";
            HttpContext.Current.Response.Write(js);
        }
        public static void CloseParentWindow()
        {
            string js = "<Script language='JavaScript'>\r\n   window.parent.close();  \r\n </Script>";
            HttpContext.Current.Response.Write(js);
        }
        public static void CloseWindow()
        {
            string js = "<Script language='JavaScript'>\r\n  window.close();  \r\n </Script>";
            HttpContext.Current.Response.Write(js);
            HttpContext.Current.Response.End();
        }
        public static void GoHistory(int value)
        {
            string js = "<Script language='JavaScript'>\r\n    history.go({0});  \r\n  </Script>";
            HttpContext.Current.Response.Write(string.Format(js, value));
        }

        public static void GotoParentWindow(string parentWindowUrl)
        {
            string js = "<Script language='JavaScript'>\r\n  this.parent.location.replace('" + parentWindowUrl + "');</Script>";
            HttpContext.Current.Response.Write(js);
        }
        public static void JavaScriptFrameHref(string FrameName, string url)
        {
            string js = "<Script language='JavaScript'>\r\n\r\n                    @obj.location.replace(\"{0}\";\r\n                  </Script>";
            js = string.Format(js.Replace("@obj", FrameName), url);
            HttpContext.Current.Response.Write(js);
        }

        public static void JavaScriptLocationHref(string url)
        {
            string js = "<Script language='JavaScript'>\r\n                    window.location.replace('{0}');\r\n                  </Script>";
            js = string.Format(js, url);
            HttpContext.Current.Response.Write(js);
        }

        public static void JavaScriptResetPage(string strRows)
        {
            string js = "<Script language='JavaScript'>\r\n                    window.parent.CenterFrame.rows='" + strRows + "';</Script>";
            HttpContext.Current.Response.Write(js);
        }
        public static void JavaScriptSetCookie(string strName, string strValue)
        {
            string js = "<script language=Javascript>\r\nvar the_cookie = '" + strName + "=" + strValue + "'\r\nvar dateexpire = 'Tuesday, 01-Dec-2020 12:00:00 GMT';\r\n//document.cookie = the_cookie;//–¥»ÎCookie<BR>} <BR>\r\ndocument.cookie = the_cookie + '; expires='+dateexpire; \r\n";
            HttpContext.Current.Response.Write(js);
        }
        public static void JscriptSender(Page page)
        {
            page.ClientScript.RegisterHiddenField("__EVENTTARGET", "");
            page.ClientScript.RegisterHiddenField("__EVENTARGUMENT", "");
            string s = " \r\n<script language=Javascript>\r\n      function KendoPostBack(eventTarget, eventArgument) \r\n      {\r\nvar theform = document.forms[0];\r\ntheform.__EVENTTARGET.value = eventTarget;\r\ntheform.__EVENTARGUMENT.value = eventArgument;\r\ntheform.submit();\r\n}\r\n";
            page.ClientScript.RegisterHiddenField("sds", s);
        }
        public static string JSStringFormat(string s)
        {
            return s.Replace("\r", @"\r").Replace("\n", @"\n").Replace("'", @"\'").Replace("\"", "\\\"");
        }
        public static void OpenWebForm(string url)
        {
            string js = "<Script language='JavaScript'>\r\n//window.open('" + url + "');\r\nwindow.open('" + url + "',','height=0,width=0,top=0,left=0,location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');\r\n</Script>";
            HttpContext.Current.Response.Write(js);
        }
        public static void OpenWebForm(string url, bool isFullScreen)
        {
            string js = "<Script language='JavaScript'>";
            if (isFullScreen)
            {
                js = (((js + "var iWidth = 0;") + "var iHeight = 0;" + "iWidth=window.screen.availWidth-10;") + "iHeight=window.screen.availHeight-50;" + "var szFeatures ='width=' + iWidth + ',height=' + iHeight + ',top=0,left=0,location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no';") + "window.open('" + url + "',',szFeatures);";
            }
            else
            {
                js = js + "window.open('" + url + "',','height=0,width=0,top=0,left=0,location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');";
            }
            js = js + "</Script>";
            HttpContext.Current.Response.Write(js);
        }

        public static void OpenWebForm(string url, string formName)
        {
            string js = "<Script language='JavaScript'>\r\n//window.open('" + url + "','" + formName + "');\r\nwindow.open('" + url + "','" + formName + "','height=0,width=0,top=0,left=0,location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');\r\n</Script>";
            HttpContext.Current.Response.Write(js);
        }

        public static void OpenWebForm(string url, string name, string future)
        {
            string js = "<Script language='JavaScript'>\r\n                     window.open('" + url + "','" + name + "','" + future + "')\r\n                  </Script>";
            HttpContext.Current.Response.Write(js);
        }

        public static void RefreshOpener()
        {
            string js = "<Script language='JavaScript'>\r\n                    opener.location.reload();\r\n                  </Script>";
            HttpContext.Current.Response.Write(js);
        }

        public static void RefreshParent()
        {
            string js = "<Script language='JavaScript'>\r\n                    parent.location.reload();\r\n                  </Script>";
            HttpContext.Current.Response.Write(js);
        }
        public static void ReplaceOpenerParentFrame(string frameName, string frameWindowUrl)
        {
            string js = "<Script language='JavaScript'>\r\n                    window.opener.parent." + frameName + ".location.replace('" + frameWindowUrl + "');</Script>";
            HttpContext.Current.Response.Write(js);
        }

        public static void ReplaceOpenerParentWindow(string openerParentWindowUrl)
        {
            string js = "<Script language='JavaScript'>\r\n                    window.opener.parent.location.replace('" + openerParentWindowUrl + "');</Script>";
            HttpContext.Current.Response.Write(js);
        }

        public static void ReplaceOpenerWindow(string openerWindowUrl)
        {
            string js = "<Script language='JavaScript'>\r\n                    window.opener.location.replace('" + openerWindowUrl + "');</Script>";
            HttpContext.Current.Response.Write(js);
        }

        public static void ReplaceParentWindow(string parentWindowUrl, string caption, string future)
        {
            string js = "";
            if ((future != null) && (future.Trim() != ""))
            {
                js = "<script language=javascript>this.parent.location.replace('" + parentWindowUrl + "','" + caption + "','" + future + "');";
            }
            else
            {
                js = "<script language=javascript>var iWidth = 0 ;var iHeight = 0 ;iWidth=window.screen.availWidth-10;iHeight=window.screen.availHeight-50;\r\nvar szFeatures = 'dialogWidth:'+iWidth+';dialogHeight:'+iHeight+';dialogLeft:0px;dialogTop:0px;center:yes;help=no;resizable:on;status:on;scroll=yes';this.parent.location.replace('" + parentWindowUrl + "','" + caption + "',szFeatures);";
            }
            HttpContext.Current.Response.Write(js);
        }

        public static void RtnRltMsgbox(object message, string strWinCtrl)
        {
            string js = "<Script language='JavaScript'>\r\n strWinCtrl = true;\r\n                     strWinCtrl = if(!confirm('" + message + "'))return false;</Script>";
            HttpContext.Current.Response.Write(string.Format(js, message.ToString()));
        }

        public static void SetHtmlElementValue(string formName, string elementName, string elementValue)
        {
            string js = "<Script language='JavaScript'>if(document." + formName + "." + elementName + "!=null){document." + formName + "." + elementName + ".value =" + elementValue + ";}</Script>";
            HttpContext.Current.Response.Write(js);
        }

        public static string ShowModalDialogJavascript(string webFormUrl)
        {
            return ("<script language=javascript>\r\nvar iWidth = 0 ;\r\nvar iHeight = 0 ;\r\niWidth=window.screen.availWidth-10;\r\niHeight=window.screen.availHeight-50;\r\nvar szFeatures = 'dialogWidth:'+iWidth+';dialogHeight:'+iHeight+';dialogLeft:0px;dialogTop:0px;center:yes;help=no;resizable:on;status:on;scroll=yes';\r\nshowModalDialog('" + webFormUrl + "',',szFeatures);");
        }

        public static string ShowModalDialogJavascript(string webFormUrl, string features)
        {
            return ("<script language=javascript> \r\nshowModalDialog('" + webFormUrl + "',','" + features + "');");
        }

        public static void ShowModalDialogWindow(string webFormUrl)
        {
            string js = ShowModalDialogJavascript(webFormUrl);
            HttpContext.Current.Response.Write(js);
        }

        public static void ShowModalDialogWindow(string webFormUrl, string features)
        {
            string js = ShowModalDialogJavascript(webFormUrl, features);
            HttpContext.Current.Response.Write(js);
        }

        public static void ShowModalDialogWindow(string webFormUrl, int width, int height, int top, int left)
        {
            string features = "dialogWidth:" + width.ToString() + "px;dialogHeight:" + height.ToString() + "px;dialogLeft:" + left.ToString() + "px;dialogTop:" + top.ToString() + "px;center:yes;help=no;resizable:no;status:no;scroll=no";
            ShowModalDialogWindow(webFormUrl, features);
        }
    }
}
