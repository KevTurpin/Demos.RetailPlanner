using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demos.RetailPlanner.Domain
{
    /// <summary>
    /// Rules: Requires 13 weeks
    ///        A week starts on a Monday
    ///        We're using ISO week date  https://en.wikipedia.org/wiki/ISO_week_date   
    /// </summary>
    public class Quarter
    {
        public Quarter(List<Week> weeks)
        {
            Month1 = new Month(weeks.Take(4));
            Month2 = new Month(weeks.Skip(4).Take(4));
            Month3 = new Month(weeks.Skip(8));
        }

        public Month Month1 { get; }
        public Month Month2 { get; }
        public Month Month3 { get; }

    }
}
