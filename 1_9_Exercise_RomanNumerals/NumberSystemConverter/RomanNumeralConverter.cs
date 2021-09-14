using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumberSystemConverter
{
    public class RomanNumeralConverter
    {
        private readonly List<RomanNumeralPair> _romanNumeralList;

        public RomanNumeralConverter()
        {
            _romanNumeralList = new List<RomanNumeralPair>()
            {
                new RomanNumeralPair("M", 1000),
                new RomanNumeralPair("CM", 900),
                new RomanNumeralPair("D", 500),
                new RomanNumeralPair("CD", 400),
                new RomanNumeralPair("C", 100),
                new RomanNumeralPair("XC", 90),
                new RomanNumeralPair("L", 50),
                new RomanNumeralPair("XL", 40),
                new RomanNumeralPair("X", 10),
                new RomanNumeralPair("IX", 9),
                new RomanNumeralPair("V", 5),
                new RomanNumeralPair("IV", 4),
                new RomanNumeralPair("I", 1),
            };
        }

        public string ConvertRomanNumeral(int number)
        {
            if (number < 1 || number > 3999)
            {
                throw new ArgumentOutOfRangeException("The number supplied is out of the expected range (1 - 3999).");
            }

            var builder = new StringBuilder();

            //iterate through the list, starting with the highest value
            foreach (var currentPair in _romanNumeralList.OrderByDescending(p=>p.NumericValue))
            {
                while (number >= currentPair.NumericValue)
                {//...number is greater than or equal to the current value so store the roman numeral and decrement it's value 
                    builder.Append(currentPair.RomanNumeralRepresentation);
                    number -= currentPair.NumericValue;
                }
            }

            return builder.ToString();
        }
    }
}
