using System;
using System.Linq;
using System.Collections.Generic;


namespace Demos.RetailPlanner.Domain
{
    public sealed class FiscalYear 
    {
        public FiscalYear(int year)
        {
            Year = year;
            var weeks = GetWeeksInYear(year);
            Q1 = new Quarter(weeks.Take(13).ToList());
            Q2 = new Quarter(weeks.Skip(13).Take(13).ToList());
            Q3 = new Quarter(weeks.Skip(26).Take(13).ToList());
            Q4 = new Quarter(weeks.Skip(39).ToList());
        }

        public int Year { get; }
        public Month[] Months
            => new[]
            {
                Q1.Month1, Q1.Month2, Q1.Month3,
                Q2.Month1, Q2.Month2, Q2.Month3,
                Q3.Month1, Q3.Month2, Q3.Month3,
                Q4.Month1, Q4.Month2, Q4.Month3,
            };
        
        private Quarter Q1 { get; }
        private Quarter Q2 { get; }
        private Quarter Q3 { get; }
        private Quarter Q4 { get; }

        private DateTime GetFirstMonday(int year)
        {
            var dt = new DateTime(year, 1, 1);

            if ((int)dt.DayOfWeek > 0 && (int)dt.DayOfWeek <= 4)
            {
                while (dt.DayOfWeek != DayOfWeek.Monday)
                {
                    dt = dt.AddDays(-1);
                }
                return dt;
            }

            while (dt.DayOfWeek != DayOfWeek.Monday)
            {
                dt = dt.AddDays(1);
            }
            return dt;
        }

        private List<Week> GetWeeksInYear(int year)
        {
            var weeks = new List<Week>();

            int startWeekNo = 1;
            var firstMonday = GetFirstMonday(year);
            while (firstMonday.Year <= year)
            {
                weeks.Add(new Week(firstMonday, startWeekNo));
                firstMonday = firstMonday.AddDays(7);
                startWeekNo += 1;
            }
            return weeks;
        }
    }

}
