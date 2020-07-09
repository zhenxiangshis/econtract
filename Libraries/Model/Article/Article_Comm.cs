using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Article
{
    public class Article_Comm
    {
        // Fields
        private DateTime _addtime;
        private int _articleid;
        private string _articletime;
        private int _commid;
        private string _content;
        private int _fen;
        private string _ip;
        private int _userid;
        private string _username;


        // Properties
        public DateTime AddTime
        {
            get
            {
                return this._addtime;
            }
            set
            {
                this._addtime = value;
            }
        }
        public int ArticleID
        {
            get
            {
                return this._articleid;
            }
            set
            {
                this._articleid = value;
            }
        }
        public string ArticleTime
        {
            get
            {
                return this._articletime;
            }
            set
            {
                this._articletime = value;
            }
        }

        public int CommID
        {
            get
            {
                return this._commid;
            }
            set
            {
                this._commid = value;
            }
        }
        public string Content
        {
            get
            {
                return this._content;
            }
            set
            {
                this._content = value;
            }
        }
        public int Fen
        {
            get
            {
                return this._fen;
            }
            set
            {
                this._fen = value;
            }
        }
        public string Ip
        {
            get
            {
                return this._ip;
            }
            set
            {
                this._ip = value;
            }
        }
        public int UserID
        {
            get
            {
                return this._userid;
            }
            set
            {
                this._userid = value;
            }
        }
        public string UserName
        {
            get
            {
                return this._username;
            }
            set
            {
                this._username = value;
            }
        }

    }
}
