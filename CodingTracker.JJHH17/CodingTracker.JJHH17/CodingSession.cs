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
            
            int years = end.Year - start.Year;
            int months = end.Month - start.Month;
            int days = end.Day - start.Day;

            if (days < 0)
            {
                months--;
                days += DateTime.DaysInMonth(start.Year, start.Month);
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            TimeSpan timeSpan = end - start;
            int hours = timeSpan.Hours;
            int minutes = timeSpan.Minutes;
            int seconds = timeSpan.Seconds;

            Duration = $"{years} years, {months} months, {days} days, {hours} hours, {minutes} minutes, {seconds} seconds";
        }
    }
}
