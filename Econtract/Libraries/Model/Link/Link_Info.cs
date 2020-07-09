using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Link
{
    public class Link_Info
    {
        // Fields
        private DateTime _addtime;
        private int _aud;
        private int _classid;
        private string _classname;
        private int _commflag;
        private string _importance;
        private int _isdelete;
        private int _istop;
        private int _isvouch;
        private int _linkid;
        private string _linkname;
        private string _linkpath;
        private string _linkurl;
        private string _remark;
        private string _tag;
        private string _title;
        private DateTime _toptime;
        private int _userid;
        private string _username;
        private int _visitcount;
        private DateTime _vouchtime;

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
        public int ClassID
        {
            get
            {
                return this._classid;
            }
            set
            {
                this._classid = value;
            }
        }
        public string ClassName
        {
            get
            {
                return this._classname;
            }
            set
            {
                this._classname = value;
            }
        }
        public int CommFlag
        {
            get
            {
                return this._commflag;
            }
            set
            {
                this._commflag = value;
            }
        }
        public string Importance
        {
            get
            {
                return this._importance;
            }
            set
            {
                this._importance = value;
            }
        }
        public int IsDelete
        {
            get
            {
                return this._isdelete;
            }
            set
            {
                this._isdelete = value;
            }
        }
        public int IsTop
        {
            get
            {
                return this._istop;
            }
            set
            {
                this._istop = value;
            }
        }
        public int IsVouch
        {
            get
            {
                return this._isvouch;
            }
            set
            {
                this._isvouch = value;
            }
        }
        public int LinkID
        {
            get
            {
                return this._linkid;
            }
            set
            {
                this._linkid = value;
            }
        }
        public string LinkName
        {
            get
            {
                return this._linkname;
            }
            set
            {
                this._linkname = value;
            }
        }
        public string LinkPath
        {
            get
            {
                return this._linkpath;
            }
            set
            {
                this._linkpath = value;
            }
        }
        public string LinkUrl
        {
            get
            {
                return this._linkurl;
            }
            set
            {
                this._linkurl = value;
            }
        }
        public string Remark
        {
            get
            {
                return this._remark;
            }
            set
            {
                this._remark = value;
            }
        }
        public string Tag
        {
            get
            {
                return this._tag;
            }
            set
            {
                this._tag = value;
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
        public DateTime TopTime
        {
            get
            {
                return this._toptime;
            }
            set
            {
                this._toptime = value;
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
        public int VisitCount
        {
            get
            {
                return this._visitcount;
            }
            set
            {
                this._visitcount = value;
            }
        }
        public DateTime VouchTime
        {
            get
            {
                return this._vouchtime;
            }
            set
            {
                this._vouchtime = value;
            }
        }

    }
}
