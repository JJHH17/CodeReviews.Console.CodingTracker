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

        private DateTime? stopwatchStartTime;
        private DateTime? stopwatchEndTime;

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
                var previousMonth = end.AddMonths(-1);
                days += DateTime.DaysInMonth(previousMonth.Year, previousMonth.Month);
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            TimeSpan timeSpan = end - start;

            int totalDays = (int)timeSpan.TotalDays;
            int totalHours = (int)timeSpan.TotalHours;
            int hours = (int)(timeSpan.TotalHours % 24);
            int minutes = timeSpan.Minutes;
            int seconds = timeSpan.Seconds;

            this.Duration = $"{years} years, {months} months, {days} days, {hours} hours, {minutes} minutes, {seconds} seconds";
        }

        public void StartStopwatch()
        {
            stopwatchStartTime = DateTime.Now;
            Console.WriteLine($"Stopwatch started at {stopwatchStartTime}");
        }

        public void StopStopwatch()
        {
            if (stopwatchStartTime == null)
            {
                Console.WriteLine("Stopwatch has not been started.");
                return;
            }

            stopwatchEndTime = DateTime.Now;
            Console.WriteLine($"Stopwatch stopped at {stopwatchEndTime}");

            StartTime = stopwatchStartTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            EndTime = stopwatchEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss");

            CalculateDuration();

            stopwatchStartTime = null;
            stopwatchEndTime = null;
        }
    }
}
