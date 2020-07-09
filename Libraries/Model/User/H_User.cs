using System;
using System.Collections.Generic;
using System.Text;

namespace Model.User
{
    public class H_User
    {
        // Fields
        private DateTime _birday;
        private string _city;
        private string _county;
        private DateTime _createtime;
        private string _dep;
        private string _email;
        private int _id;
        private int _lock;
        private DateTime _locktime;
        private int _logcount;
        private string _loginid;
        private string _logip;
        private DateTime _logtime;
        private string _nickname;
        private string _password;
        private string _provin;
        private int _rank;
        private string _sex;
        private int _types;
        private string _vis;

        // Properties
        public DateTime BirDay
        {
            get
            {
                return this._birday;
            }
            set
            {
                this._birday = value;
            }
        }
        public string City
        {
            get
            {
                return this._city;
            }
            set
            {
                this._city = value;
            }
        }
        public string County
        {
            get
            {
                return this._county;
            }
            set
            {
                this._county = value;
            }
        }
        public DateTime CreateTime
        {
            get
            {
                return this._createtime;
            }
            set
            {
                this._createtime = value;
            }
        }
        public string Dep
        {
            get
            {
                return this._dep;
            }
            set
            {
                this._dep = value;
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
        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }
        public int Lock
        {
            get
            {
                return this._lock;
            }
            set
            {
                this._lock = value;
            }
        }
        public DateTime LockTime
        {
            get
            {
                return this._locktime;
            }
            set
            {
                this._locktime = value;
            }
        }
        public int LogCount
        {
            get
            {
                return this._logcount;
            }
            set
            {
                this._logcount = value;
            }
        }
        public string LoginId
        {
            get
            {
                return this._loginid;
            }
            set
            {
                this._loginid = value;
            }
        }
        public string LogIp
        {
            get
            {
                return this._logip;
            }
            set
            {
                this._logip = value;
            }
        }
        public DateTime LogTime
        {
            get
            {
                return this._logtime;
            }
            set
            {
                this._logtime = value;
            }
        }
        public string NickName
        {
            get
            {
                return this._nickname;
            }
            set
            {
                this._nickname = value;
            }
        }
        public string PassWord
        {
            get
            {
                return this._password;
            }
            set
            {
                this._password = value;
            }
        }
        public string Provin
        {
            get
            {
                return this._provin;
            }
            set
            {
                this._provin = value;
            }
        }
        public int Rank
        {
            get
            {
                return this._rank;
            }
            set
            {
                this._rank = value;
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
        public int Types
        {
            get
            {
                return this._types;
            }
            set
            {
                this._types = value;
            }
        }
        public string Vis
        {
            get
            {
                return this._vis;
            }
            set
            {
                this._vis = value;
            }
        }

    }
}
