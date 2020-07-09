using System;
using System.Collections.Generic;
using System.Text;

namespace Utility
{
    public class DateHelper
    {
        // Methods
        public DateHelper() { }
        public static string ConvertDateToString(DateTime oDateTime, string strFormat)
        {
            try
            {
                switch (strFormat.ToUpper())
                {
                    case "SHORTDATE":
                        return oDateTime.ToShortDateString();

                    case "LONGDATE":
                        return oDateTime.ToLongDateString();
                }
                return oDateTime.ToString(strFormat);
            }
            catch (Exception)
            {
                return oDateTime.ToShortDateString();
            }
        }
        public static DateTime ConvertStringToDate(string strInput)
        {
            try
            {
                return DateTime.Parse(strInput);
            }
            catch (Exception)
            {
                return DateTime.Today;
            }
        }
        public static int DiffDays(DateTime dtfrm, DateTime dtto)
        {
            return 0;
        }
        public static DateTime GetDayBegin(DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);
        }
        public static DateTime GetDayEnd(DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, 0x17, 0x3b, 0x3b);
        }
        public static int GetDaysOfMonth(DateTime dt)
        {
            int year = dt.Year;
            switch (dt.Month)
            {
                case 1:
                    return 0x1f;

                case 2:
                    if (!IsRuYear(year))
                    {
                        return 0x1c;
                    }
                    return 0x1d;

                case 3:
                    return 0x1f;

                case 4:
                    return 30;

                case 5:
                    return 0x1f;

                case 6:
                    return 30;

                case 7:
                    return 0x1f;

                case 8:
                    return 0x1f;

                case 9:
                    return 30;

                case 10:
                    return 0x1f;

                case 11:
                    return 30;

                case 12:
                    return 0x1f;
            }
            return 0;
        }
        public static int GetDaysOfMonth(int iYear, int Month)
        {
            switch (Month)
            {
                case 1:
                    return 0x1f;

                case 2:
                    if (!IsRuYear(iYear))
                    {
                        return 0x1c;
                    }
                    return 0x1d;

                case 3:
                    return 0x1f;

                case 4:
                    return 30;

                case 5:
                    return 0x1f;

                case 6:
                    return 30;

                case 7:
                    return 0x1f;

                case 8:
                    return 0x1f;

                case 9:
                    return 30;

                case 10:
                    return 0x1f;

                case 11:
                    return 30;

                case 12:
                    return 0x1f;
            }
            return 0;
        }
        public static int GetDaysOfYear(DateTime idt)
        {
            if (IsRuYear(idt.Year))
            {
                return 0x16e;
            }
            return 0x16d;
        }
        public static int GetDaysOfYear(int iYear)
        {
            if (IsRuYear(iYear))
            {
                return 0x16e;
            }
            return 0x16d;
        }
        public static DateTime GetMonthBegin(DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, 1, 0, 0, 0);
        }
        public static DateTime GetMonthBegin(int year, int month)
        {
            return new DateTime(year, month, 1, 0, 0, 0);
        }
        public static DateTime GetMonthEnd(DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, DateTime.DaysInMonth(dt.Year, dt.Month), 0, 0, 0);
        }
        public static DateTime GetMonthEnd(int year, int month)
        {
            return new DateTime(year, month, DateTime.DaysInMonth(year, month), 0, 0, 0);
        }
        public static string GetWeekNameOfDay(DateTime idt)
        {
            switch (idt.DayOfWeek.ToString())
            {
                case "Mondy":
                    return "星期一";

                case "Tuesday":
                    return "星期二";

                case "Wednesday":
                    return "星期三";

                case "Thursday":
                    return "星期四";

                case "Friday":
                    return "星期五";

                case "Saturday":
                    return "星期六";

                case "Sunday":
                    return "星期日";
            }
            return "";
        }
        public static string GetWeekNumberOfDay(DateTime idt)
        {
            switch (idt.DayOfWeek.ToString())
            {
                case "Mondy":
                    return "1";

                case "Tuesday":
                    return "2";

                case "Wednesday":
                    return "3";

                case "Thursday":
                    return "4";

                case "Friday":
                    return "5";

                case "Saturday":
                    return "6";

                case "Sunday":
                    return "7";
            }
            return "";
        }
        public static bool IsDateTime(string strDate)
        {
            try
            {
                return (DateTime.Parse(strDate).CompareTo(DateTime.Parse("1800-1-1")) > 0);
            }
            catch (Exception)
            {
                return false;
            }
        }
        private static bool IsRuYear(DateTime idt)
        {
            int n = idt.Year;
            return (((n % 400) == 0) || (((n % 4) == 0) && ((n % 100) != 0)));
        }
        private static bool IsRuYear(int iYear)
        {
            int n = iYear;
            return (((n % 400) == 0) || (((n % 4) == 0) && ((n % 100) != 0)));
        }

    }
}
