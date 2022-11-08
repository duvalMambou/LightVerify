namespace LightVerifyAPI.Other
{
    public class SetDateTime
    {
        static string Date { get; }

        static string Time { get; }

        public string GetDate()
        {
            string day = "";

            string fullDate = DateTime.Today.ToString();
            if (fullDate.Length > 10)
                fullDate = fullDate.Substring(0, 10);

            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    day = "Mon";
                    break;

                case DayOfWeek.Tuesday:
                    day = "Tue";
                    break;

                case DayOfWeek.Wednesday:
                    day = "Wed";
                    break;

                case DayOfWeek.Thursday:
                    day = "Thu";
                    break;

                case DayOfWeek.Friday:
                    day = "Fri";
                    break;

                case DayOfWeek.Saturday:
                    day = "Sat";
                    break;

                case DayOfWeek.Sunday:
                    day = "Sun";
                    break;
            }

            return day + fullDate;
        }

        public string GetTime()
        {
            string hour = DateTime.Now.TimeOfDay.ToString();
            if (hour.Length > 8)
                hour = hour.Substring(0, 8);

            return hour;
        }
    }
}
