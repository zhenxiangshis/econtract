using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility
{
    using System;
    using System.Linq;
    using System.Web;
    using System.IO;
    using System.Text;

    /// <summary>
    /// ShortenUrl 的摘要说明
    /// </summary>
    public static class ShortUrlHelper
    {
        const string Seq = "s9LFkgy5RovixI1aOf8UhdY3r4DMplQZJXPqebE0WSjBn7wVzmN2Gc6THCAKut";

        private static string DataFile
        {
            get { return HttpContext.Current.Server.MapPath("/Url.db"); }
        }

        private static string IndexFile
        {
            get { return HttpContext.Current.Server.MapPath("/Url.idx"); }
        }

        /// <summary>
        /// 批量添加网址，按顺序返回Key。如果输入的一组网址中有不合法的元素，则返回数组的相同位置（下标）的元素将为null。
        /// </summary>
        /// <param name="Url"></param>    
        /// <returns></returns>
        public static string[] AddUrls(string[] Url)
        {
            FileStream Index = new FileStream(IndexFile, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            FileStream Data = new FileStream(DataFile, FileMode.Append, FileAccess.Write);
            Data.Position = Data.Length;
            DateTime Now = DateTime.Now;
            byte[] dt = BitConverter.GetBytes(Now.ToBinary());
            int _Hits = 0;
            byte[] Hits = BitConverter.GetBytes(_Hits);
            string[] ResultKey = new string[Url.Length];
            int seekSeek = unchecked((int)Now.Ticks);
            Random seekRand = new Random(seekSeek);
            string Host = HttpContext.Current.Request.Url.Host.ToLower();
            byte[] Status = BitConverter.GetBytes(true);
            //index: ID(8) + Begin(8) + Length(2) + Hits(4) + DateTime(8) = 30
            for (int i = 0; i < Url.Length && i < 1000; i++)
            {
                if (Url[i].ToLower().Contains(Host) || Url[i].Length == 0 || Url[i].Length > 4096) continue;
                long Begin = Data.Position;
                byte[] UrlData = Encoding.UTF8.GetBytes(Url[i]);
                Data.Write(UrlData, 0, UrlData.Length);
                byte[] buff = new byte[8];
                long Last;
                if (Index.Length >= 30) //读取上一条记录的ID
                {
                    Index.Position = Index.Length - 30;
                    Index.Read(buff, 0, 8);
                    Index.Position += 22;
                    Last = BitConverter.ToInt64(buff, 0);
                }
                else
                {
                    Last = 1000000; //起步ID，如果太小，生成的短网址会太短。
                    Index.Position = 0;
                }
                long RandKey = Last + (long)GetRnd(seekRand);
                byte[] BeginData = BitConverter.GetBytes(Begin);
                byte[] LengthData = BitConverter.GetBytes((Int16)(UrlData.Length));
                byte[] RandKeyData = BitConverter.GetBytes(RandKey);

                Index.Write(RandKeyData, 0, 8);
                Index.Write(BeginData, 0, 8);
                Index.Write(LengthData, 0, 2);
                Index.Write(Hits, 0, Hits.Length);
                Index.Write(dt, 0, dt.Length);
                ResultKey[i] = Mixup(RandKey);
            }
            Data.Close();
            Index.Close();
            return ResultKey;
        }
        public static string AddUrl(string Url)
        {
            FileStream Index = new FileStream(IndexFile, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            FileStream Data = new FileStream(DataFile, FileMode.Append, FileAccess.Write);
            Data.Position = Data.Length;
            DateTime Now = DateTime.Now;
            byte[] dt = BitConverter.GetBytes(Now.ToBinary());
            int _Hits = 0;
            byte[] Hits = BitConverter.GetBytes(_Hits);
            string ResultKey = "";
            int seekSeek = unchecked((int)Now.Ticks);
            Random seekRand = new Random(seekSeek);
            string Host = HttpContext.Current.Request.Url.Host.ToLower();
            byte[] Status = BitConverter.GetBytes(true);
            //index: ID(8) + Begin(8) + Length(2) + Hits(4) + DateTime(8) = 30

            if (Url.ToLower().Contains(Host) || Url.Length == 0 || Url.Length > 4096)
                return null;
            long Begin = Data.Position;
            byte[] UrlData = Encoding.UTF8.GetBytes(Url);
            Data.Write(UrlData, 0, UrlData.Length);
            byte[] buff = new byte[8];
            long Last;
            if (Index.Length >= 30) //读取上一条记录的ID
            {
                Index.Position = Index.Length - 30;
                Index.Read(buff, 0, 8);
                Index.Position += 22;
                Last = BitConverter.ToInt64(buff, 0);
            }
            else
            {
                Last = 1000000; //起步ID，如果太小，生成的短网址会太短。
                Index.Position = 0;
            }
            long RandKey = Last + (long)GetRnd(seekRand);
            byte[] BeginData = BitConverter.GetBytes(Begin);
            byte[] LengthData = BitConverter.GetBytes((Int16)(UrlData.Length));
            byte[] RandKeyData = BitConverter.GetBytes(RandKey);

            Index.Write(RandKeyData, 0, 8);
            Index.Write(BeginData, 0, 8);
            Index.Write(LengthData, 0, 2);
            Index.Write(Hits, 0, Hits.Length);
            Index.Write(dt, 0, dt.Length);
            ResultKey = Mixup(RandKey);

            Data.Close();
            Index.Close();
            return ResultKey;
        }
        /// <summary>
        /// 按顺序批量解析Key，返回一组长网址。
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public static string[] ParseUrls(string[] Key)
        {
            FileStream Index = new FileStream(IndexFile, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            FileStream Data = new FileStream(DataFile, FileMode.Open, FileAccess.Read);
            byte[] buff = new byte[8];
            long[] Ids = Key.Select(n => UnMixup(n)).ToArray();
            string[] Result = new string[Ids.Length];
            long _Right = (long)(Index.Length / 30) - 1;
            for (int j = 0; j < Ids.Length; j++)
            {
                long Id = Ids[j];
                long Left = 0;
                long Right = _Right;
                long Middle = -1;
                while (Left <= Right)
                {
                    Middle = (long)(Math.Floor((double)((Right + Left) / 2)));
                    if (Middle < 0) break;
                    Index.Position = Middle * 30;
                    Index.Read(buff, 0, 8);
                    long val = BitConverter.ToInt64(buff, 0);
                    if (val == Id) break;
                    if (val < Id)
                    {
                        Left = Middle + 1;
                    }
                    else
                    {
                        Right = Middle - 1;
                    }
                }
                string Url = null;
                if (Middle != -1)
                {
                    Index.Position = Middle * 30 + 8; //跳过ID           
                    Index.Read(buff, 0, buff.Length);
                    long Begin = BitConverter.ToInt64(buff, 0);
                    Index.Read(buff, 0, buff.Length);
                    Int16 Length = BitConverter.ToInt16(buff, 0);
                    byte[] UrlTxt = new byte[Length];
                    Data.Position = Begin;
                    Data.Read(UrlTxt, 0, UrlTxt.Length);
                    int Hits = BitConverter.ToInt32(buff, 2);//跳过2字节的Length
                    byte[] NewHits = BitConverter.GetBytes(Hits + 1);//解析次数递增, 4字节
                    Index.Position -= 6;//指针撤回到Length之后
                    Index.Write(NewHits, 0, NewHits.Length);//覆盖老的Hits
                    Url = Encoding.UTF8.GetString(UrlTxt);
                }
                Result[j] = Url;
            }
            Data.Close();
            Index.Close();
            return Result;
        }
        /// <summary>
        /// 按顺序批量解析Key，返回一组长网址。
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public static string ParseUrl(string Key)
        {
            FileStream Index = new FileStream(IndexFile, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            FileStream Data = new FileStream(DataFile, FileMode.Open, FileAccess.Read);
            byte[] buff = new byte[8];
            long Id = UnMixup(Key);
            string Result = "";
            long _Right = (long)(Index.Length / 30) - 1;

            long Left = 0;
            long Right = _Right;
            long Middle = -1;
            while (Left <= Right)
            {
                Middle = (long)(Math.Floor((double)((Right + Left) / 2)));
                if (Middle < 0) break;
                Index.Position = Middle * 30;
                Index.Read(buff, 0, 8);
                long val = BitConverter.ToInt64(buff, 0);
                if (val == Id) break;
                if (val < Id)
                {
                    Left = Middle + 1;
                }
                else
                {
                    Right = Middle - 1;
                }
            }
            string Url = null;
            if (Middle != -1)
            {
                Index.Position = Middle * 30 + 8; //跳过ID           
                Index.Read(buff, 0, buff.Length);
                long Begin = BitConverter.ToInt64(buff, 0);
                Index.Read(buff, 0, buff.Length);
                Int16 Length = BitConverter.ToInt16(buff, 0);
                byte[] UrlTxt = new byte[Length];
                Data.Position = Begin;
                Data.Read(UrlTxt, 0, UrlTxt.Length);
                int Hits = BitConverter.ToInt32(buff, 2);//跳过2字节的Length
                byte[] NewHits = BitConverter.GetBytes(Hits + 1);//解析次数递增, 4字节
                Index.Position -= 6;//指针撤回到Length之后
                Index.Write(NewHits, 0, NewHits.Length);//覆盖老的Hits
                Url = Encoding.UTF8.GetString(UrlTxt);
            }
            Result = Url;

            Data.Close();
            Index.Close();
            return Result;
        }
        /// <summary>
        /// 混淆id为字符串
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private static string Mixup(long id)
        {
            string Key = Convert(id);
            int s = 0;
            foreach (char c in Key)
            {
                s += (int)c;
            }
            int Len = Key.Length;
            int x = (s % Len);
            char[] arr = Key.ToCharArray();
            char[] newarr = new char[arr.Length];
            Array.Copy(arr, x, newarr, 0, Len - x);
            Array.Copy(arr, 0, newarr, Len - x, x);
            string NewKey = "";
            foreach (char c in newarr)
            {
                NewKey += c;
            }
            return NewKey;
        }

        /// <summary>
        /// 解开混淆字符串
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        private static long UnMixup(string Key)
        {
            int s = 0;
            foreach (char c in Key)
            {
                s += (int)c;
            }
            int Len = Key.Length;
            int x = (s % Len);
            x = Len - x;
            char[] arr = Key.ToCharArray();
            char[] newarr = new char[arr.Length];
            Array.Copy(arr, x, newarr, 0, Len - x);
            Array.Copy(arr, 0, newarr, Len - x, x);
            string NewKey = "";
            foreach (char c in newarr)
            {
                NewKey += c;
            }
            return Convert(NewKey);
        }

        /// <summary>
        /// 10进制转换为62进制
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private static string Convert(long id)
        {
            if (id < 62)
            {
                return Seq[(int)id].ToString();
            }
            int y = (int)(id % 62);
            long x = (long)(id / 62);

            return Convert(x) + Seq[y];
        }

        /// <summary>
        /// 将62进制转为10进制
        /// </summary>
        /// <param name="Num"></param>
        /// <returns></returns>
        private static long Convert(string Num)
        {
            long v = 0;
            int Len = Num.Length;
            for (int i = Len - 1; i >= 0; i--)
            {
                int t = Seq.IndexOf(Num[i]);
                double s = (Len - i) - 1;
                long m = (long)(Math.Pow(62, s) * t);
                v += m;
            }
            return v;
        }

        /// <summary>
        /// 生成随机的0-9a-zA-Z字符串
        /// </summary>
        /// <returns></returns>
        public static string GenerateKeys()
        {
            string[] Chars = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z".Split(',');
            int SeekSeek = unchecked((int)DateTime.Now.Ticks);
            Random SeekRand = new Random(SeekSeek);
            for (int i = 0; i < 100000; i++)
            {
                int r = SeekRand.Next(1, Chars.Length);
                string f = Chars[0];
                Chars[0] = Chars[r - 1];
                Chars[r - 1] = f;
            }
            return string.Join("", Chars);
        }

        /// <summary>
        /// 返回随机递增步长
        /// </summary>
        /// <param name="SeekRand"></param>
        /// <returns></returns>
        private static Int16 GetRnd(Random SeekRand)
        {
            Int16 Step = (Int16)SeekRand.Next(1, 11);
            return Step;
        }
    }
}
