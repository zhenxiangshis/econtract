using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Caching;
using System.Web;

namespace Utility
{
    public class CacheHelper
    {
        // Methods
        public CacheHelper() { }
        public static bool ExistIdentify(string strIdentify)
        {
            return (HttpContext.Current.Cache[strIdentify] != null);
        }
        public static bool InsertCommonInf(string strIdentify, StorageInfType enumInfType, object objValue)
        {
            if ((((strIdentify != null) && (strIdentify != "")) && (strIdentify.Length != 0)) && (objValue != null))
            {
                CacheItemRemovedCallback callBack = new CacheItemRemovedCallback(CacheHelper.onRemove);
                if (enumInfType == StorageInfType.UserInf)
                {
                    HttpContext.Current.Cache.Insert(strIdentify + StorageInfType.UserInf.ToString(), objValue, null, DateTime.Now.AddSeconds(18000.0), Cache.NoSlidingExpiration, CacheItemPriority.Normal, callBack);
                }
                if (enumInfType == StorageInfType.PageInf)
                {
                    HttpContext.Current.Cache.Insert(strIdentify + StorageInfType.PageInf.ToString(), objValue, null, DateTime.Now.AddSeconds(18000.0), Cache.NoSlidingExpiration, CacheItemPriority.Normal, callBack);
                }
                if (enumInfType == StorageInfType.SysInf)
                {
                    HttpContext.Current.Cache.Insert(strIdentify + StorageInfType.SysInf.ToString(), objValue, null, DateTime.Now.AddSeconds(18000.0), Cache.NoSlidingExpiration, CacheItemPriority.Normal, callBack);
                }
                return true;
            }
            return false;
        }
        private static void onRemove(string strIdentify, object userInfo, CacheItemRemovedReason reason){ }

        // Nested Types
        public enum StorageInfType
        {
            UserInf,
            PageInf,
            SysInf
        }

    }
}
