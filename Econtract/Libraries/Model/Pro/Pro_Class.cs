using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Pro
{
    public class Pro_Class
    {
        // Fields
        private int _classdepth;
        private int _classid;
        private string _classintro;
        private string _classname;
        private int _classorder;
        private string _classpath;
        private int _parentid;

        // Properties
        public int ClassDepth
        {
            get
            {
                return this._classdepth;
            }
            set
            {
                this._classdepth = value;
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
        public string ClassIntro
        {
            get
            {
                return this._classintro;
            }
            set
            {
                this._classintro = value;
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
        public int ClassOrder
        {
            get
            {
                return this._classorder;
            }
            set
            {
                this._classorder = value;
            }
        }
        public string ClassPath
        {
            get
            {
                return this._classpath;
            }
            set
            {
                this._classpath = value;
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

    }
}
