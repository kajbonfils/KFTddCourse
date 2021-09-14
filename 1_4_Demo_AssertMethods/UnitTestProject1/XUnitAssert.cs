using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Xunit;

namespace UnitTestProject1
{
    public class AssertMethods
    {
        [Fact]
        public void SimpleEqual()
        {
            // AreEqual on simple types
            Assert.Equal(1, 1);
        }

        [Fact]
        public void ComplexEqual()
        {
            Person p1 = new Person();
            p1.Name = "Foo";

            Person p2 = new Person();
            p2.Name = "Foo";
            Assert.Equal(p1, p2);
        }

        [Fact]
        public void AreSame()
        {
            Person p1 = new Person();
            // AreSame
            Person p3 = p1;
            Assert.Same(p1, p3);

            Person p2 = new Person();
            Assert.Same(p1, p2);
            
        }

        [Fact]
        public void Fail()
        {
            Assert.True(false);
        }

        [Fact]
        public void Inconclusive()
        {
            Console.WriteLine("I dont know what i do... so Xunit prevents me from doing something stupid.");
        }

        [Fact(Skip="Being skipped")]
        public void IsFalse()
        {
            var actual = (2 + 2 == 3);

            Assert.False(actual);
        }


        [Fact]
        public void IsTrue()
        {
            var actual = (2 + 2 == 4);

            Assert.True(actual);
        }

        [Fact]
        public void IsAssignableFrom()
        {
            var p = new Elev();
            Assert.IsAssignableFrom<Person>(p);
        }

        [Fact]
        public void IsType()
        {
            Assert.IsType<Person>(new Person());
            Assert.IsType<Person>(new Elev());
        }

        [Fact]
        public void IsNotType()
        {
            var p = new Person();
            Assert.IsNotType<Exception>(p);
        }

        [Fact]
        public void IsNull()
        {
            Person p = null;
            Assert.Null(p);
        }


        [Fact]
        public void IsNotNull()
        {
            Person p = new Person();
            Assert.NotNull(p);
        }

        [Fact]
        public void CollectionAll()
        {
            var a = new List<string>{"a", "b", "c"};
            var b = new List<string>{"a", "b", "c"};

            Assert.All(a, s => Assert.Equal(1, s.Length) );

        }

        [Fact]
        public void CollectionEqual()
        {
            var a = new List<string> { "a", "b", "c" };
            var b = new List<string> { "a", "b", "c" };

            Assert.Equal(a, b); // order is important
        }

        [Fact]
        public void ExpectedException()
        {
            void someMethod() => throw new Exception("FOO");

            var exception = Assert.Throws<Exception>(()=>someMethod());

            Assert.Equal("FOO", exception.Message);
        }

        [Fact]
        public void Contains()
        {
            Assert.True("kaj is testing".Contains("is"));
            
            Assert.Contains("kaj is testing", "is");
        }

        [Fact]
        public void EndsWith()
        {
            Assert.EndsWith("kaj is testing", "testing");
            Assert.EndsWith("kaj is testing", "TESTING");
        }

        [Fact]
        public void StartsWith()
        {
            Assert.StartsWith("Kaj", "Kaj Is Testing");
        }

        [Fact]
        public void Match()
        {
            Assert.Matches(new Regex($"\\w[Kaj]"), "Kaj is testing");
        }
    }
}
