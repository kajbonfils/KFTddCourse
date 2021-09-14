using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FragileTest
{
    [TestClass]
    public class FragileTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var sut = new DataManager();
            var actual = sut.GetValue();

            Assert.IsTrue(actual < 50);
        }
    }
}
