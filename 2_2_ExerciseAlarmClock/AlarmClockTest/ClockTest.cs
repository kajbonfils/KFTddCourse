using AlarmClock;
using Xunit;

namespace AlarmClockTest
{
    public class ClockTest
    {
        [Fact]
        public void IsAlarmRinging()
        {
            var target = CreateTarget();
            Assert.True(target.IsAlarmRinging());
        }

        private Clock CreateTarget()
        {
            return new Clock();
        }
    }
}
