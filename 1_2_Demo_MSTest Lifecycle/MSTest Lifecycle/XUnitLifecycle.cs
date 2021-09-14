using System;
using Xunit;
using Xunit.Abstractions;

namespace MSTest_Lifecycle
{

    public class Fixture : IDisposable
    {
        public Fixture()
        {
            Console.WriteLine("Fixture ctor");
        }

        public void Dispose()
        {
            Console.WriteLine("Fixture destructor");
        }
    }

    public class XUnitLifecycle : IDisposable, IClassFixture<Fixture>
    {

        public XUnitLifecycle(ITestOutputHelper testOutputHelper)
        {
            Console.WriteLine("Class Ctor");
        }

        [Fact]
        public void TestMethod1()
        {
            Console.WriteLine("TestMethod1");
        }

        [Fact]
        public void TestMethod2()
        {
            Console.WriteLine("TestMethod2");
        }
        [Fact]
        public void TestMethod3()
        {
            Console.WriteLine("TestMethod3");
        }


        public void Dispose()
        {
            Console.WriteLine("Class  Dispose");
        }
    }
}
