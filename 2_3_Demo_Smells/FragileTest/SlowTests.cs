using System.Threading;
using Xunit;

namespace FragileTest
{
    public class SlowTests
    {
        [Fact]
        public void StopWatch_StopsRingingAfterElapsedTime()
        {
            var stopWatch = new Watch();
            stopWatch.Run(3);
            Assert.True(stopWatch.IsRunning);
            Thread.Sleep(3001);
            Assert.False(stopWatch.IsRunning);
        }


        [Fact]
        public void MultipleAsserts()
        {
            // Arrange
            // Act
            var actual = "Kaj";

            Assert.Equal("Kaj", actual);
            Assert.Equal(3, actual.Length);
            Assert.True(actual.StartsWith("K"));
            Assert.True(actual.Contains("X"), "ContainsX");
        }
    }

    public class Watch
    {
        public bool IsRunning { get; set; }

        public void Run(int i)
        {
            IsRunning = true;
            System.Timers.Timer t = new System.Timers.Timer(i*1000);
            t.Enabled = true;
            t.Elapsed += (sender, args) =>
            {
                IsRunning = false;
                t.Enabled = false;
            };
        }
    }

}
