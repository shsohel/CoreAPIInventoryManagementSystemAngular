using System;
using System.Collections.Generic;
using System.Text;

namespace CommonBLL.Helper
{
    public class Formater
    {
        public static string FormatTime12Hour(TimeSpan timeSpan)
        {
            if (timeSpan != null)
            {
                int minute = timeSpan.Minutes;
                string minutePart = "";
                if (minute < 10)
                {
                    minutePart = "0" + minute.ToString();
                }
                else
                {
                    minutePart = minute.ToString();
                }
                if (timeSpan.Hours >= 12)
                {
                    if (timeSpan.Hours == 12)
                    {
                        return timeSpan.Hours.ToString() + ':' + minutePart + " PM";
                    }
                    else
                    {
                        return '0' + (timeSpan.Hours - 12).ToString() + ":" + minutePart + " PM";
                    }
                }
                else
                {
                    if (timeSpan.Hours < 10)
                    {
                        return '0' + timeSpan.Hours.ToString() + ":" + minutePart + " AM";
                    }
                    return timeSpan.Hours.ToString() + ":" + minutePart + " AM";
                }
            }
            else
            {
                return null;
            }
        }
        public static string FormatDateddMMyyyy(DateTime dateTime)
        {
            if (dateTime != null)
            {
                string yearPart = dateTime.Year.ToString();
                string monthPart = dateTime.Month.ToString();
                string daysPart = dateTime.Day.ToString();
                if (Convert.ToInt32(daysPart) < 10)
                {
                    daysPart = '0' + daysPart;
                }
                if (Convert.ToInt32(monthPart) < 10)
                {
                    monthPart = '0' + monthPart;
                }
                if (Convert.ToInt32(yearPart) < 10)
                {
                    yearPart = '0' + yearPart;
                }
                return daysPart + '/' + monthPart + '/' + yearPart;
            }
            else
            {
                return null;
            }
        }
        public static string FormatDateTimeddMMyyyyHHMMSSmm(DateTime dateTime)
        {
            if (dateTime != null)
            {
                string datePart = FormatDateddMMyyyy(dateTime);
                TimeSpan timeSpan = dateTime.TimeOfDay;
                string timePart = FormatTime12Hour(timeSpan);
                return datePart + " " + timePart;
            }
            else
            {
                return null;
            }
        }
    }
}
