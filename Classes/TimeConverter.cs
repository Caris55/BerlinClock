using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string convertTime(string aTime)
        {
            var berlinClock = new Classes.BerlinClock(aTime);

            return berlinClock.ToString();
        }
    }
}
