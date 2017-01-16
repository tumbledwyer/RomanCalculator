using System;
using NUnit.Framework;
using RomanCalculator.Converter;

namespace RomanCalculator.Tests.Calculator
{
    [TestFixture]
    public class CalculatorTests
    {
        [TestCase("mcmiv", "MXI")]
        [TestCase("MDLX", "CPXI")]
        [TestCase("M XL", "II")]
        public void Add_GivenIllegalCharacters_ShouldThrowException(string firstNumeral, string secondNumeral)
        {
            //---------------Set up test pack-------------------
            var calculator = CreateCalculator();
            //---------------Execute Test ----------------------
            Assert.Throws<Exception>(() => calculator.Add(firstNumeral, secondNumeral));
        }
       
        [Category("Integration Test")]
        [TestCase("CXI", "XCIX", "CCX")]
        [TestCase("MXV", "III", "MXVIII")]
        [TestCase("XIV", "CCXLI", "CCLV")]
        [TestCase("DXII", "MMCMLIX", "MMMCDLXXI")]
        public void Add_GivenTwoNumerals_ShouldReturnTheirSumInRomanNumerals(string firstNumeral, string secondNumeral, string expected)
        {
            //---------------Set up test pack-------------------
            var calculator = CreateCalculator();
            //---------------Execute Test ----------------------
            var sum = calculator.Add(firstNumeral, secondNumeral);
            //---------------Test Result -----------------------
            Assert.AreEqual(expected, sum);
        }
        
        private static RomanCalculator.Calculator.Calculator CreateCalculator()
        {
            var romanConverter = CreateRomanConverter();
            return new RomanCalculator.Calculator.Calculator(romanConverter);
        }

        private static RomanConverter CreateRomanConverter()
        {
            return new RomanConverter();
        }
    }
}
