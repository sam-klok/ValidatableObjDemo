using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidatableObjDemo
{
    public interface ITimeZoneInfoProvider
    {
        TimeZoneInfo FindSystemTimeZoneById(string systemTimeZoneId);
    }

    public class TimeZoneInfoProvider : ITimeZoneInfoProvider
    {
        public TimeZoneInfo FindSystemTimeZoneById(string systemTimeZoneId)
        {
            return TimeZoneInfo.FindSystemTimeZoneById(systemTimeZoneId);
        }
    }

    public class TimeZoneDemo
    {
        private ITimeZoneInfoProvider timeZoneInfoProvider;

        public TimeZoneDemo()
        {
            this.timeZoneInfoProvider = new TimeZoneInfoProvider();
        }

        public TimeZoneDemo(ITimeZoneInfoProvider timeZoneInfoProvider)
        {
            this.timeZoneInfoProvider = timeZoneInfoProvider;
        }

        public string DoSomething(string text)
        {
            TimeZoneInfo timeZoneInfo;

            try
            {
                timeZoneInfo = timeZoneInfoProvider.FindSystemTimeZoneById("Eastern Standard Time");
            }
            catch
            {
                timeZoneInfo = timeZoneInfoProvider.FindSystemTimeZoneById("US/Eastern");
            }

            return text + " " + timeZoneInfo.ToString();
        }
    }
}
