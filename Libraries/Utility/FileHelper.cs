using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;

namespace Utility
{
    public class FileHelper
    {
        // Methods
        private FileHelper() { }
        public static DirectoryInfo checkValidSessionPath(string FilePathName)
         {
            DirectoryInfo CS;
             try
            {
                 DirectoryInfo MainDir = new DirectoryInfo(HttpContext.Current.Server.MapPath(FilePathName));
                 CS = MainDir;
             }
            catch
            {
                 throw;
             }
              return CS;
         }

        public static void CreateFile(string FilePathName)
        {
            try
            {
                string[] strPath = FilePathName.Split(new char[] { '/' });
                CreateFolder(FilePathName.Replace("/" + strPath[strPath.Length - 1].ToString(), ""));
               // CreateFolder(FilePathName);
                FileInfo CreateFile = new FileInfo(HttpContext.Current.Server.MapPath(FilePathName).ToString());
                if (!CreateFile.Exists)
                {
                    CreateFile.Create().Close();
                }
            }
            catch
            {
            }
        }
        public static void CreateFolder(string FolderPathName)
        {
            if (FolderPathName.Trim().Length > 0)
            {
                try
                {
                    string CreatePath = HttpContext.Current.Server.MapPath(FolderPathName).ToString();
                    if (!Directory.Exists(CreatePath))
                    {
                        Directory.CreateDirectory(CreatePath);
                    }
                }
                catch
                {
                    throw;
                }
            }
        }
        public static void DeleParentFolder(string FolderPathName)
        {
            try
            {
                DirectoryInfo DelFolder = new DirectoryInfo(HttpContext.Current.Server.MapPath(FolderPathName).ToString());
                if (DelFolder.Exists)
                {
                    DelFolder.Delete();
                }
            }
            catch
            {
            }
        }
        public static void DeleteChildFolder(string FolderPathName)
        {
            if (FolderPathName.Trim().Length > 0)
            {
                try
                {
                    string CreatePath = HttpContext.Current.Server.MapPath(FolderPathName).ToString();
                    if (Directory.Exists(CreatePath))
                    {
                        Directory.Delete(CreatePath, true);
                    }
                }
                catch
                {
                    throw;
                }
            }
        }
        public static void DeleteFile(string FilePathName)
        {
            try
            {
                new FileInfo(HttpContext.Current.Server.MapPath(FilePathName).ToString()).Delete();
            }
            catch
            {
            }
        }
        public static string ReaderFileData(string FilePathName)
        {
            string CS;
            try
            {
             FileStream FileRead = new FileStream(HttpContext.Current.Server.MapPath(FilePathName).ToString(), FileMode.Open, FileAccess.Read);
             StreamReader FileReadWord = new StreamReader(FileRead, Encoding.Default);
             string TxtString = FileReadWord.ReadToEnd().ToString();
             FileReadWord.Close();
             FileRead.Close();
             CS = TxtString;
            }
            catch
            {
             throw;
            }
            return CS;
         }
        public static void ReWriteReadinnerText(string FilePathName, string WriteWord)
        {
            try
            {
                CreateFile(FilePathName);
                FileStream FileRead = new FileStream(HttpContext.Current.Server.MapPath(FilePathName).ToString(), FileMode.Open, FileAccess.ReadWrite);
                StreamReader FileReadWord = new StreamReader(FileRead, Encoding.Default);
                string OldString = FileReadWord.ReadToEnd().ToString() + WriteWord;
                StreamWriter FileWrite = new StreamWriter(FileRead, Encoding.Default);
                FileWrite.Write(WriteWord);
                FileWrite.Close();
                FileReadWord.Close();
                FileRead.Close();
            }
            catch
            {
            }
        }


    }
}
