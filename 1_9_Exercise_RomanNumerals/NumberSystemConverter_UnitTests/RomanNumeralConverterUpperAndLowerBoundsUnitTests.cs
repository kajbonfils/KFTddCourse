using System;
using NumberSystemConverter;
using Xunit;

namespace NumberSystemConverter_UnitTests
{
    public class RomanNumeralConverterTest
    {
        private RomanNumeralConverter sut;

        public RomanNumeralConverterTest()
        {
            sut = new RomanNumeralConverter();
        }

        [Fact]
        public void ConvertRomanNumeral_NumberGreaterThanFourThousand_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws< ArgumentOutOfRangeException>(() =>sut.ConvertRomanNumeral(4000));
        }

        [Fact]
        public void ConvertRomanNumeral_NumberLessThanOne_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.ConvertRomanNumeral(-1));
        }

        [Fact]
        public void ConvertRomanNumeral_NumberEqualOne_ExpectedResult()
        {
            var actual = sut.ConvertRomanNumeral(1);

            Assert.Equal("I", actual);
        }

        [Fact]
        public void ConvertRomanNumeral_NumberEqualThreeThousand_ExpectedResult()
        {
            var actual = sut.ConvertRomanNumeral(3000);

            Assert.Equal("MMM", actual);
        }

        [Fact]
        public void ConvertRomanNumeral_NumberEqualFour_ExpectedResult()
        {
            var actual = sut.ConvertRomanNumeral(4);

            Assert.Equal("IV", actual);
        }

        [Fact]
        public void ConvertRomanNumeral_NumberEqualSix_ExpectedResult()
        {
            var actual = sut.ConvertRomanNumeral(6);

            Assert.Equal("VI", actual);
        }


        [Fact]
        public void ConvertRomanNumeral_NumberEqual55_ExpectedResultLV()
        {
            var result = sut.ConvertRomanNumeral(55);

            Assert.Equal("LV", result);
        }

        [Fact]
        public void ConvertRomanNumeral_NumberEqual100_ExpectedResultC()
        {
            var actual = sut.ConvertRomanNumeral(100);

            Assert.Equal("C", actual);
        }

        [Fact]
        public void ConvertRomanNumeral_NumberEqual500_ExpectedResultD()
        {
            var actual = sut.ConvertRomanNumeral(500);
            Assert.Equal("D", actual);
        }

        [Fact]
        public void ConvertRomanNumeral_NumberEqual599_ExpecteResultDxcix()
        {
            var actual = sut.ConvertRomanNumeral(599);
            Assert.Equal("DXCIX", actual);
        }

        [Fact]
        public void ConvertRomanNumeral_NumberEqual2013_ExpectedResultMMXIII()
        {
            var actual = sut.ConvertRomanNumeral(2013);
            Assert.Equal("MMXIII", actual);
        }

        [Theory]
        [InlineData(1, "I")]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        [InlineData(4, "IV")]
        [InlineData(5, "V")]
        [InlineData(39, "XXXIX")]
        [InlineData(246, "CCXLVI")]
        [InlineData(789, "DCCLXXXIX")]
        [InlineData(2421, "MMCDXXI")]
        [InlineData(160, "CLX")]
        [InlineData(207, "CCVII")]
        [InlineData(1009, "MIX")]
        [InlineData(1066, "MLXVI")]
        [InlineData(1776, "MDCCLXXVI")]
        [InlineData(1918, "MCMXVIII")]
        [InlineData(1954, "MCMLIV")]
        [InlineData(2014, "MMXIV")]
        [InlineData(3999, "MMMCMXCIX")]
        public void ConvertRomanNumeral(int number, string expected)
        {
            var actual = sut.ConvertRomanNumeral(number);
            Assert.Equal(expected, actual);
        }
    }
}