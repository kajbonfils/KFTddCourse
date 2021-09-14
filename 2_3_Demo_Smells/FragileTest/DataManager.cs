using System;

namespace FragileTest
{
    public class DataManager
    {
        public double GetValue()
        {
            var rnd = new Random();
            return rnd.Next(100);
        }
    }
}