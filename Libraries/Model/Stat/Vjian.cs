using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Stat
{
    public class Vjian
    {
        // Fields
        private float _today;
        private float _yesterday;
        private DateTime _vdate;
        private float _vtop;
        private DateTime _starttime;

        // Properties
        public float Today
        {
            get
            {
                return this._today;
            }
            set
            {
                this._today = value;
            }
        }
        public float Yesterday
        {
            get
            {
                return this._yesterday;
            }
            set
            {
                this._yesterday = value;
            }
        }
        public DateTime Vdate
        {
            get
            {
                return this._vdate;
            }
            set
            {
                this._vdate = value;
            }
        }
        public float Vtop
        {
            get
            {
                return this._vtop;
            }
            set
            {
                this._vtop = value;
            }
        }
        public DateTime Starttime
        {
            get
            {
                return this._starttime;
            }
            set
            {
                this._starttime = value;
            }
        }
    }
}
