using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace DALFactory
{
    public class DataCache
    {
        // Methods
        public DataCache() { }
        public static object GetCache(string CacheKey)
        {
            return HttpRuntime.Cache[CacheKey];
        }

        public static void SetCache(string CacheKey, object objObject)
        {
            HttpRuntime.Cache.Insert(CacheKey, objObject);
        }


    }
}
