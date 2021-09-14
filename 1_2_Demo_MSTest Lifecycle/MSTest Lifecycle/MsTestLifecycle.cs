using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest_Lifecycle
{
    [TestClass]
    public class MsTestLifecycle
    {
       
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            Debug.WriteLine("Class Initialize");
        }

        [TestInitialize]
        public void TestInit()
        {
            Debug.WriteLine("TestInitialize");
        }

        [TestMethod]
        public void TestMethod1()
        {
            Debug.WriteLine("TestMethod1");
        }

        [TestMethod]
        public void TestMethod2()
        {
            Debug.WriteLine("TestMethod2");
        }

        [TestMethod]
        public void TestMethod3()
        {
            Debug.WriteLine("TestMethod3");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Debug.WriteLine("Test Cleanup");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            Debug.WriteLine("Class Cleanup");
        }
    }
}
