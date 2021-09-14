using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class MsTestAssert
    {
        [TestMethod]
        public void SimpleEqual()
        {
            // AreEqual on simple types
            Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void ComplexEqual()
        {
            Person p1 = new Person();
            p1.Name = "Foo";

            Person p2 = new Person();
            p2.Name = "Foo";
            Assert.AreEqual(p1, p2);
        }

        [TestMethod]
        public void AreSame()
        {
            Person p1 = new Person();
            // AreSame
            Person p3 = p1;
            Assert.AreSame(p1, p3);

            Person p2 = new Person();
            Assert.AreSame(p1, p2, "1");
            
        }

        [TestMethod]
        public void Fail()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void Inconclusive()
        {
            Assert.Inconclusive("I dont know what i do");
        }

        [TestMethod, Ignore]
        public void IsFalse()
        {
            var actual = (2 + 2 == 3);

            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void IsTrue()
        {
            var actual = (2 + 2 == 4);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsInstanceOfType()
        {
            var p = new Elev();
            Assert.IsInstanceOfType(p, typeof(Person));
        }

        [TestMethod]
        public void NotInstanceOfType()
        {
            var p = new Person();
            Assert.IsNotInstanceOfType(p, typeof(TestContext));
        }

        [TestMethod]
        public void IsNull()
        {
            Person p = null;
            Assert.IsNull(p);
        }


        [TestMethod]
        public void IsNotNull()
        {
            Person p = new Person();
            Assert.IsNotNull(p);
        }

        [TestMethod]
        public void CollectionAreEquivalent()
        {
            //var a = new string[]{"a", "b", "c"};
            //var b = new string["a", "b", "c"];

            //CollectionAssert.AreEquivalent(a, b);

            //b = new int[4, 2, 3];
            //CollectionAssert.AreEquivalent(a, b);
        }

        [TestMethod]
        public void CollectionIsSubset()
        {
            var a = new[] { 1, 3, 4 };
            var b = new[] { 4, 1 };

            CollectionAssert.IsSubsetOf(b, a);
        }

        [TestMethod]
        public void CollectionContains()
        {
            var collection = new[] { 1, 4, 5 };
            int element = 5;
            CollectionAssert.Contains(collection, element);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void ExpectedException()
        {
            int dividend = 4;
            int divisor = 0;
            var actual = dividend/divisor;
        }

        [TestMethod]
        public void StringAssertContains()
        {
            Assert.IsTrue("kaj is testing".Contains("is"));

            StringAssert.Contains("kaj is testing", "is");
        }

        [TestMethod]
        public void StringAssertEndsWith()
        {
            StringAssert.EndsWith("kaj is testing", "testing");
            StringAssert.EndsWith("kaj is testing", "TESTING");
        }

        [TestMethod]
        public void StringAssertStartsWith()
        {
            StringAssert.StartsWith("Kaj Is Testing", "Kaj");
        }

        [TestMethod]
        public void StringAssertMatch()
        {
            StringAssert.Matches("Kaj is testing", new Regex($"\\w[Kaj]"));
        }
    }
}
