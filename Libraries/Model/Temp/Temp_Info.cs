using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Temp
{
    public class Temp_Info
    {
        // Fields
        private string _content;
        private int _sort;
        private int _tempid;
        private string _title;

        // Properties
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
        public int Sort
        {
            get
            {
                return this._sort;
            }
            set
            {
                this._sort = value;
            }
        }
        public int TempID
        {
            get
            {
                return this._tempid;
            }
            set
            {
                this._tempid = value;
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

    }
}
