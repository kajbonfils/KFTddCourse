using System;

namespace AlarmClock
{
    public class Clock
    {
        public bool IsAlarmRinging()
        {
            if (DateTime.Now.Hour == 12) // Alarm is ringing from [12:00 - 13:00[
            {
                return true;
            }

            return false;
        }

        public DateTime WhatTimeIsIt()
        {
            return DateTime.Now;
        }

    }
}
