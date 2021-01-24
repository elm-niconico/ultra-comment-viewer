using System;
using System.Collections.Generic;
using System.Text;

namespace ultra_comment_viewer.src.commons
{
    public class LiveDateManager
    {
        private DateTime _beforeTime;

        public LiveDateManager()
        {
            this._beforeTime = DateTime.Now;
        }

        public bool HasTimePassed(int second)
        {
            var now = DateTime.Now;
            var timeSpan = now - _beforeTime;

            if (timeSpan.TotalSeconds < second) return false;

            this._beforeTime = now;
            return true;
            
        }

        public DateTime FromString(string date)
        {
            try
            {
                return DateTime.ParseExact(date, "yyyy-MM-dd HH:mm:ss", null);
            }
            catch
            {
                return DateTime.Today;
            }    
        }

        public DateTime FromUnixTime(long unixTime)
        {
            return DateTimeOffset.FromUnixTimeSeconds(unixTime).LocalDateTime;
        }

        public string ExtractPassStringTime(DateTime time)
        {
            var span = ExtractPassTime(time);
            return $"{span.Hours}:{span.Minutes}:{span.Seconds} 経過"; 
        }


        public TimeSpan ExtractPassTime(DateTime time)
        {
            var now = DateTime.Now.ToLocalTime();
            return now - time;
        }


    }
}
