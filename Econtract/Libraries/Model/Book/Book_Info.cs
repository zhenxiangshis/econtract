using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Book
{
    public class Book_Info
    {
        // Fields
        private DateTime _addtime;
        private int _aud;
        private int _bookid;
        private string _content;
        private string _email;
        private string _froms;
        private string _mobile;
        private string _qq;
        private string _sex;
        private string _telephone;
        private string _title;
        private string _username;
        private DateTime _vtime;


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
        public int Aud
        {
            get
            {
                return this._aud;
            }
            set
            {
                this._aud = value;
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
        public string Email
        {
            get
            {
                return this._email;
            }
            set
            {
                this._email = value;
            }
        }
        public string Froms
        {
            get
            {
                return this._froms;
            }
            set
            {
                this._froms = value;
            }
        }
        public string Mobile
        {
            get
            {
                return this._mobile;
            }
            set
            {
                this._mobile = value;
            }
        }
        public string QQ
        {
            get
            {
                return this._qq;
            }
            set
            {
                this._qq = value;
            }
        }
        public string Sex
        {
            get
            {
                return this._sex;
            }
            set
            {
                this._sex = value;
            }
        }
        public string Telephone
        {
            get
            {
                return this._telephone;
            }
            set
            {
                this._telephone = value;
            }
        }
        public string Title
        {
            get
            {
                return this._title;
            }
            set
            {
                this._title = value;
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
        public DateTime VTime
        {
            get
            {
                return this._vtime;
            }
            set
            {
                this._vtime = value;
            }
        }

    }
}
