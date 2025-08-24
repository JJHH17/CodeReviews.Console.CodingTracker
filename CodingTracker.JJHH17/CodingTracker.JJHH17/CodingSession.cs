using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker.JJHH17
{
    internal class CodingSession
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }


        public CodingSession(string startTime, string endTime)
        {
            this.StartTime = startTime;
            this.EndTime = endTime;
        }

        // To add... calculate duration
    }
}
