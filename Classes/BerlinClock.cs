namespace BerlinClock.Classes
{
    using System.Text;

    /// <summary>
    /// Class representing a Berlin clock.
    /// </summary>
    public class BerlinClock
    {
        /// <summary>
        /// The time on the clock.
        /// </summary>
        private Time Time { get; set; }

        /// <summary>
        /// The lamp representing the second.
        /// </summary>
        /// <remarks>
        /// On the top of the clock there is a yellow lamp that blinks on/off every two seconds. 
        /// </remarks>
        private string Seconds => Time.Seconds % 2 == 0 ? "Y" : "O";

        /// <summary>
        /// The top hours row of the clock.
        /// </summary>
        /// <remarks>
        /// It has four red lamps and and 1 red lamp is lit for every 5 hours. (eg. RROO)
        /// </remarks>
        private string TopHoursRow => LightLamps(Time.Hours, 5, "RRRR");

        /// <summary>
        /// The bottom hours of the clock.
        /// </summary>
        /// <remarks>
        /// In the lower row of red lamps every lamp represents 1 hour.
        /// </remarks>
        private string BottomHoursRow => LightLamps(Time.Hours % 5, 1, "RRRR");

        /// <summary>
        /// The top minutes row of the clock.
        /// </summary>
        /// <remarks>
        /// In the first row every lamp represents 5 minutes. 
        /// In this first row the 3rd, 6th and 9th lamp are red and indicate the first quarter, half and last quarter of an hour. 
        /// The other lamps are yellow.
        /// </remarks>
        public string TopMinutesRow => LightLamps(Time.Minutes, 5, "YYRYYRYYRYY");

        /// <summary>
        /// The bottom minutes row of the clock
        /// </summary>
        /// <remarks>
        /// In the lower row of red lamps every lamp represents 1 minute.
        /// </remarks>
        public string BottomMinutesRow => LightLamps(Time.Minutes % 5, 1, "YYYY");

        /// <summary>
        /// Constructor of the BerlinClock class.
        /// </summary>
        /// <param name="time"></param>
        public BerlinClock(string time) => this.Time = new Time(time);

        /// <summary>
        /// An override of the default ToString() method.
        /// </summary>
        /// <returns>The string representation of the clock.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(this.Seconds);
            sb.AppendLine();
            sb.Append(this.TopHoursRow);
            sb.AppendLine();
            sb.Append(this.BottomHoursRow);
            sb.AppendLine();
            sb.Append(this.TopMinutesRow);
            sb.AppendLine();
            sb.Append(this.BottomMinutesRow);

            return sb.ToString();
        }

        /// <summary>
        /// Calculates the number of lit lamps.
        /// </summary>
        /// <param name="value">The value of the row to be calculated.</param>
        /// <param name="steps">The steps of the row to be calculated.</param>
        /// <param name="lamps">String representing the color of the lamps of the row.</param>
        /// <returns>A string representing the lamps of the row.</returns>
        private static string LightLamps(int value, int steps, string lamps)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < lamps.Length; i++)
            {
                sb.Append((value >= steps * (i + 1)) ? lamps[i] : 'O');
            }

            return sb.ToString();
        }
    }
}
