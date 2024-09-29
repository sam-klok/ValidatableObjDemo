using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidatableObjDemo;
using Moq;

namespace xUnitTestProject
{
    public class TimeZoneUnitTests
    {

        [Fact]
        public void DoSomething_ReturnText()
        {
            var timeZoneDemo = new TimeZoneDemo();
            var s = timeZoneDemo.DoSomething("Test");
            Assert.Contains("Test", s);
        }

        [Fact]
        public void DoSomething_Should_ThrowException()
        {
            var timeZoneEST = "Eastern Standard Time";
            var mockTimeZoneProvider = new Mock<ITimeZoneInfoProvider>();
            mockTimeZoneProvider.Setup(i=>i.FindSystemTimeZoneById(timeZoneEST))
                .Throws(new TimeZoneNotFoundException());

            var timeZoneDemo = new TimeZoneDemo(mockTimeZoneProvider.Object);

            Assert.Throws<NullReferenceException>(() => timeZoneDemo.DoSomething("Test"));
        }

        [Fact]
        public void DoSomething_Should_CauseNoException()
        {
            var mockTimeZoneProvider = new Mock<ITimeZoneInfoProvider>();

            var timeZoneUSEastern = "US/Eastern";
            mockTimeZoneProvider.Setup(i => i.FindSystemTimeZoneById(timeZoneUSEastern))
                .Throws(new TimeZoneNotFoundException());

            var timeZoneEST = "Eastern Standard Time";
            mockTimeZoneProvider.Setup(i => i.FindSystemTimeZoneById(timeZoneEST))
                .Returns(TimeZoneInfo.FindSystemTimeZoneById(timeZoneEST));

            var timeZoneDemo = new TimeZoneDemo(mockTimeZoneProvider.Object);
            var s = timeZoneDemo.DoSomething("Test");
            Assert.Contains("Test", s);
        }

        
    }
}
