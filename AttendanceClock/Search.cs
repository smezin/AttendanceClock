using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceClock
{
    class Search
    {
        DateTime from { get; set; }
        DateTime to { get; set; }
        string userName { get; }

        public bool isValidSearch ()
        {
            return (from != null && to != null && userName != null);
        }
    }
}
