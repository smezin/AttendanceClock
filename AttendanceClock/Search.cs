using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceClock
{
    class Search
    {
        DateTime? from { get; set; }
        DateTime? upTo { get; set; }
        string userName { get; }

        public Search (DateTime? from, DateTime? upTo, string userName)
        {
            this.from = from;
            this.upTo = upTo;
            this.userName = userName;
        }
    }
}
