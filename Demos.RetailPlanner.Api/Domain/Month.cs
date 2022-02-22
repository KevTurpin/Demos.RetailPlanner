using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace Demos.RetailPlanner.Domain
{
    public class Month
    {
        public Month(IEnumerable<Week> weeks)
        {
            Weeks = weeks.ToList();
            var monthNumber = Weeks.GroupBy(p => p.MonthNumber)
                                   .OrderByDescending(grp => grp.Count())
                                   .Select(p => p.Key)
                                   .First();

            FiscalMonth = CultureInfo.CurrentCulture
                                     .DateTimeFormat
                                     .GetMonthName(monthNumber);
        }

        public string FiscalMonth { get; }
        public int NumberOfWeeks => Weeks.Count;
        public List<Week> Weeks {get; }
        
    }
}