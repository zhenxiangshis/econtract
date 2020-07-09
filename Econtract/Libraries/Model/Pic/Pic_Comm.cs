using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Pic
{
    public class Pic_Comm
    {
        // Fields
        private DateTime _addtime;
        private int _commid;
        private string _content;
        private int _fen;
        private string _ip;
        private int _Picid;
        private string _pictime;
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
        public int PicID
        {
            get
            {
                return this._Picid;
            }
            set
            {
                this._Picid = value;
            }
        }
        public string PicTime
        {
            get
            {
                return this._pictime;
            }
            set
            {
                this._pictime = value;
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
