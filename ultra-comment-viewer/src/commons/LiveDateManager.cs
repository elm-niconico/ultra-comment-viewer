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

        public DateTime FromUnixTime(long unixTime)
        {
            return DateTimeOffset.FromUnixTimeSeconds(unixTime).LocalDateTime;
        }


    }
}
