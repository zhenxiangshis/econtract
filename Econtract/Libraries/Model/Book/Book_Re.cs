using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Book
{
    public class Book_Re
    {
        // Fields
        private DateTime _addtime;
        private int _bookid;
        private string _content;
        private string _ip;
        private int _reid;
        private string _rename;
        private int _userid;


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
        public int BookID
        {
            get
            {
                return this._bookid;
            }
            set
            {
                this._bookid = value;
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
        public int ReID
        {
            get
            {
                return this._reid;
            }
            set
            {
                this._reid = value;
            }
        }
        public string ReName
        {
            get
            {
                return this._rename;
            }
            set
            {
                this._rename = value;
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

    }
}
