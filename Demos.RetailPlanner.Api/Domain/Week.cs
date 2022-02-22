using System;
using System.Collections.Generic;
using System.Linq;

namespace Demos.RetailPlanner.Domain
{
    public class Week
    {
        public Week(DateTime startDay, int weekNumber)
        {
            WeekNumber = weekNumber;

            var days = new List<DateTime>();
            for (int i = 0; i < 7; i++)
            {
                days.Add(startDay.AddDays(i));
            }

            Days = days.Select(p => p.ToShortDateString())
                       .ToList();

            MonthNumber = days.GroupBy(p => p.Month)
                              .OrderByDescending(grp => grp.Count())
                              .Select(p => p.Key)
                              .First();
        }
        public int WeekNumber { get; }
        public List<string> Days { get; }
        public int MonthNumber { get; }        
    }
}