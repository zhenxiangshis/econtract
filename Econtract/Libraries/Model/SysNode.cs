using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{

    public class SysNode
    {
        // Fields
        private string _comment;
        private string _imageurl;
        private int _keshidm;
        private string _keshipublic;
        private string _location;
        private int _moduleid;
        private int _nodeid;
        private int _orderid;
        private int _parentid;
        private int _permissionid;
        private string _text;
        private string _url;


        // Properties
        public string Comment
        {
            get
            {
                return this._comment;
            }
            set
            {
                this._comment = value;
            }

        }
        public string ImageUrl 
        {
            get
            {
                return this._imageurl;
            }
            set
            {
                this._imageurl = value;
            }

        }
        public int KeShiDM
        {
            get
            {
                return this._keshidm;
            }
            set
            {
                this._keshidm = value;
            }
        }
        public string KeshiPublic
        {
            get
            {
                return this._keshipublic;
            }
            set
            {
                this._keshipublic = value;
            }
        }
        public string Location
        {
            get
            {
                return this._location;
            }
            set
            {
                this._location = value;
            }
        }
        public int ModuleID
        {
            get
            {
                return this._moduleid;
            }
            set
            {
                this._moduleid = value;
            }
        }
        public int NodeID
        {
            get
            {
                return this._nodeid;
            }
            set
            {
                this._nodeid = value;
            }
        }
        public int OrderID
        {
            get
            {
                return this._orderid;
            }
            set
            {
                this._orderid = value;
            }
        }
        public int ParentID
        {
            get
            {
                return this._parentid;
            }
            set
            {
                this._parentid = value;
            }
        }
        public int PermissionID
        {
            get
            {
                return this._permissionid;
            }
            set
            {
                this._permissionid = value;
            }
        }
        public string Text
        {
            get
            {
                return this._text;
            }
            set
            {
                this._text = value;
            }
        }
        public string Url
        {
            get
            {
                return this._url;
            }
            set
            {
                this._url = value;
            }
        }


    }
}
