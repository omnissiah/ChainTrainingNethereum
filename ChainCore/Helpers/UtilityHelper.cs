using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ChainCore.Helpers
{
    public static class UtilityHelper
    {
        public static DateTime ConvertTicksToDate(long ticks)
        {
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return start.AddSeconds(ticks).ToLocalTime();
        }

        public static bool IsPassedNow(long ticks)
        {
            if (ConvertTicksToDate(ticks) > DateTime.Now)
                return false;
            return true;
        }

        /// <summary>
        /// returns remaining time or how much time has passed as a string
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string GetRemainingTime(long ticks)
        {
            TimeSpan difference = DateTime.Now - ConvertTicksToDate(ticks);
            double remainder = difference.TotalDays;
            string remainderString = null;

            if (remainder > 0)
            {
                if (remainder < 1)
                {
                    remainder = difference.TotalHours;
                    if (remainder < 1)
                    {
                        remainder = difference.TotalMinutes;
                        if (remainder < 1)
                        {
                            remainder = difference.TotalSeconds;
                            remainderString += Math.Round(remainder, MidpointRounding.ToEven) + " Seconds";
                        }
                        else
                            remainderString += Math.Round(remainder, MidpointRounding.ToEven) + " Minutes";
                    }
                    else
                        remainderString += Math.Round(remainder, MidpointRounding.ToEven) + " Hours";
                }
                else
                    remainderString += Math.Round(remainder, MidpointRounding.ToEven) + " Days";
            }
            else
            {
                if (remainder > -1)
                {
                    remainder = difference.TotalHours;
                    if (remainder > -1)
                    {
                        remainder = difference.TotalMinutes;
                        if (remainder > -1)
                        {
                            remainder = difference.TotalSeconds;
                            remainderString += Math.Round(remainder, MidpointRounding.ToEven) + " Seconds";
                        }
                        else
                            remainderString += Math.Round(remainder, MidpointRounding.ToEven) + " Minutes";
                    }
                    else
                        remainderString += Math.Round(remainder, MidpointRounding.ToEven) + " Hours";
                }
                else
                    remainderString += Math.Round(remainder, MidpointRounding.ToEven) + " Days";
            }



            if (!IsPassedNow(ticks))
                remainderString += " remaining";
            else
                remainderString += " ago";

            if (remainderString.Contains('-'))
                return remainderString.Remove(remainderString.IndexOf('-'), 1);
            else
                return remainderString;
        }
        public static string Dump(Object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }

    }
}
