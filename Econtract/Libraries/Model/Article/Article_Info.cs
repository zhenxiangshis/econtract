using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Article
{
    public class Article_Info
    {
        // Fields
        private DateTime _addtime;
        private int _articleid;
        private int _classid;
        private string _classname;
        private int _commflag;
        private string _content;
        private string _keyword;
        private int _demoid;
        private string _gourl;
        private int _importance;
        private int _isdelete;
        private int _istop;
        private int _isvouch;
        private int _picid;
        private string _picurl;
        private string _subtitle;
        private string _tag;
        private string _title;
        private DateTime _toptime;
        private int _userid;
        private int _visitcount;
        private DateTime _vouchtime;
        private string _flashurl;


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
        public string Keyword
        {
            get
            {
                return this._keyword;
            }
            set
            {
                this._keyword = value;
            }
        }
        public int DemoID
        {
            get
            {
                return this._demoid;
            }
            set
            {
                this._demoid = value;
            }
        }
        public string GoUrl
        {
            get
            {
                return this._gourl;
            }
            set
            {
                this._gourl = value;
            }
        }
        public int Importance
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
        public int PicID
        {
            get
            {
                return this._picid;
            }
            set
            {
                this._picid = value;
            }
        }
        public string PicUrl
        {
            get
            {
                return this._picurl;
            }
            set
            {
                this._picurl = value;
            }
        }
        public string SubTitle
        {
            get
            {
                return this._subtitle;
            }
            set
            {
                this._subtitle = value;
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
        public string FlashUrl
        {
            get
            {
                return this._flashurl;
            }
            set
            {
                this._flashurl = value;
            }
        }

    }
}
