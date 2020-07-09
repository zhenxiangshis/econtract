using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Stat
{
    public class Rpt_Daycount
    {
        // Fields
        private int _vyear;
        private int _vmonth;
        private int _vday;
        private DateTime _vtime;
        private int _scount;
        private int _vcount;

        // Properties
        public int Vyear
        {
            get
            {
                return this._vyear;
            }
            set
            {
                this._vyear = value;
            }
        }
        public int Vmonth
        {
            get
            {
                return this._vmonth;
            }
            set
            {
                this._vmonth = value;
            }
        }
        public int Vday
        {
            get
            {
                return this._vday;
            }
            set
            {
                this._vday = value;
            }
        }
        public DateTime Vtime
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
        public int Scount
        {
            get
            {
                return this._scount;
            }
            set
            {
                this._scount = value;
            }
        }
        public int Vcount
        {
            get
            {
                return this._vcount;
            }
            set
            {
                this._vcount = value;
            }
        }
        
    }
}
