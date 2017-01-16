using NUnit.Framework;
using RomanCalculator.Converter;

namespace RomanCalculator.Tests.Converter
{
    [TestFixture]
    public class RomanConverterTests
    {
        [TestCase("I", 1)]
        [TestCase("II", 2)]
        [TestCase("III", 3)]
        [TestCase("IV", 4)]
        [TestCase("IX", 9)]
        public void ConvertToDecimal_GivenZerothPowerDigits_ShouldReturnArabic(string input, int expected)
        {
            //---------------Set up test pack-------------------
            var converter = CreateConverter();
            //---------------Execute Test ----------------------
            var arabic = converter.ConvertToArabic(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, arabic);
        }

        [TestCase("XI", 11)]
        [TestCase("XXXIV", 34)]
        [TestCase("XLIX", 49)]
        [TestCase("XCIV", 94)]
        public void ConvertToDecimal_GivenFirstPowerDigits_ShouldReturnArabic(string input, int expected)
        {
            //---------------Set up test pack-------------------
            var converter = CreateConverter();
            //---------------Execute Test ----------------------
            var arabic = converter.ConvertToArabic(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, arabic);
        }

        [TestCase("CCXX", 220)]
        [TestCase("CDLXV", 465)]
        [TestCase("CMIII", 903)]
        public void ConvertToDecimal_GivenSecondPowerDigits_ShouldReturnArabic(string input, int expected)
        {
            //---------------Set up test pack-------------------
            var converter = CreateConverter();
            //---------------Execute Test ----------------------
            var arabic = converter.ConvertToArabic(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, arabic);
        }

        [TestCase("MM", 2000)]
        [TestCase("MDCLXVI", 1666)]
        public void ConvertToDecimal_GivenThirdPowerDigits_ShouldArabic(string input, int expected)
        {
            //---------------Set up test pack-------------------
            var converter = CreateConverter();
            //---------------Execute Test ----------------------
            var arabic = converter.ConvertToArabic(input);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, arabic);
        }
        
        [TestCase(1, "I")]
        [TestCase(3, "III")]
        [TestCase(5, "V")]
        [TestCase(6, "VI")]
        [TestCase(7, "VII")]
        [TestCase(7, "VII")]
        [TestCase(666, "DCLXVI")]
        public void ConvertToRoman_GivenSimpleCases_ShouldReturnArabic(int input, string expected)
        {
            //-----------Set up test ------------
            var converter = CreateConverter();
            //-----------Execute test -----------
            var roman = converter.ConvertToRoman(input);
            //-----------Test result ------------
            Assert.AreEqual(expected, roman);
        }


        [TestCase(4, "IV")]
        [TestCase(40, "XL")]
        [TestCase(400, "CD")]
        [TestCase(1444, "MCDXLIV")]
        public void ConvertToRoman_GivenNumeralsContaining4_ShouldReturnArabic(int input, string expected)
        {
            //-----------Set up test ------------
            var converter = CreateConverter();
            //-----------Execute test -----------
            var roman = converter.ConvertToRoman(input);
            //-----------Test result ------------
            Assert.AreEqual(expected, roman);
        }

        [TestCase(9, "IX")]
        [TestCase(90, "XC")]
        [TestCase(900, "CM")]
        [TestCase(1999, "MCMXCIX")]
        public void ConvertToRoman_GivenNumeralsContaining9_ShouldReturnArabic(int input, string expected)
        {
            //-----------Set up test ------------
            var converter = CreateConverter();
            //-----------Execute test -----------
            var roman = converter.ConvertToRoman(input);
            //-----------Test result ------------
            Assert.AreEqual(expected, roman);
        }

        private RomanConverter CreateConverter()
        {
            return new RomanConverter();
        }
    }
}
