using System;
using System.Text.RegularExpressions;

namespace BerlinClock.Classes
{
    /// <summary>
    /// Class representing a time.
    /// </summary>
    public class Time
    {
        /// <summary>
        /// The hours of the time.
        /// </summary>
        public int Hours { get; private set; }

        /// <summary>
        /// The minutes of the time.
        /// </summary>
        public int Minutes { get; private set; }

        /// <summary>
        /// The seconds of the time.
        /// </summary>
        public int Seconds { get; private set; }

        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="time"></param>
        public Time(string time)
        {
            Regex regex = new Regex(@"[0-2]?[0-9]:[0-5]?[0-9]:[0-5]?[0-9]");

            if (!regex.IsMatch(time))
            {
                throw new ArgumentException("Invalid time specified");
            }

            var timeParts = time.Split(':');
            this.Hours = int.Parse(timeParts[0]);
            this.Minutes = int.Parse(timeParts[1]);
            this.Seconds = int.Parse(timeParts[2]);

            // Note: a real time representing class shouldn't allow 24:00:00.
            if (!(Hours == 24 && Minutes == 0 && Seconds == 0) && (Hours > 23 || Minutes > 59 || Seconds > 59))
            {
                throw new ArgumentException("Invalid time specified");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// The string representation of the time.
        /// </returns>
        public override string ToString() => $"{this.Hours:00}:{this.Minutes:00}:{this.Seconds:00}";
    }
}
