using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database = CodingTracker.JJHH17.Database;

namespace CodingTracker.JJHH17
{
    public class CodingSession
    {
        public long Id { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Duration { get; set; }

        public CodingSession()
        {

        }

        public CodingSession(string startTime, string endTime)
        {
            this.StartTime = startTime;
            this.EndTime = endTime;
        }

        public CodingSession(string startTime, string endTime, string duration)
        {
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.Duration = duration;
        }

        // Calculate duration of session
        public void CalculateDuration()
        {
            DateTime start = DateTime.Parse(StartTime);
            DateTime end = DateTime.Parse(EndTime);
            TimeSpan duration = end - start;
            this.Duration = duration.ToString();
        }
    }
}
