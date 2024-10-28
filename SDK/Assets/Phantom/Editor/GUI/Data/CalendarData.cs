using System;
using System.Collections.Generic;

namespace PhantomEditor
{
    [Serializable]
    public class CalendarData
    {
        public int YearRange;
        public int Year;
        private string[] _years;
        
        public int Month;
        private string[] _months;
        
        public int Day;
        private string[] _days;
        
        
        public CalendarData()
        {
            YearRange = 100;
            
            DateTime now = DateTime.Now;
            Year = now.Year - (now.Year - YearRange);
            Month = now.Month - 1;
            Day = now.Day - 1;
        }
        
        public string[] GetYears()
        {
            if (_years == null || _years.Length != YearRange * 2)
            {
                var yearNow = DateTime.Now.Year;
                var years = new List<string>();
                for (var i = yearNow - YearRange; i <= yearNow + YearRange; i++)
                {
                    years.Add(i.ToString());
                }
                
                _years = years.ToArray();
            }

            return _years;
        }

        public string[] GetBirthYears()
        {
            if (_years == null || _years.Length != YearRange)
            {
                var yearNow = DateTime.Now.Year;
                var years = new List<string>();
                for (var i = yearNow - YearRange; i <= yearNow; i++)
                {
                    years.Add(i.ToString());
                }
                
                _years = years.ToArray();
            }

            return _years;
        }
        
        public string[] GetMonths()
        {
            if (_months == null)
            {
                var months = new List<string>();
                for (var i = 1; i <= 12; i++)
                {
                    months.Add(i.ToString());
                }
                
                _months = months.ToArray();
            }

            return _months;
        }

        public string[] GetDays()
        {
            var dayRange = DateTime.DaysInMonth(Year, Month);
            if (_days == null || _days.Length != dayRange)
            {
                var days = new List<string>();
                for (var i = 1; i <= dayRange; i++)
                {
                    days.Add(i.ToString());
                }
                
                _days = days.ToArray();
            }
            
            return _days;
        }
    }
}