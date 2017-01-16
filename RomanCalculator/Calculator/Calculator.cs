using System;
using System.Linq;
using RomanCalculator.Converter;
using RomanCalculator.DataConstants;

namespace RomanCalculator.Calculator
{
    public class Calculator
    {
        private readonly IRomanConverter _converter;

        public Calculator(IRomanConverter converter)
        {
            _converter = converter;
        }

        public string Add(string firstNumeral, string secondNumeral)
        {
            CheckInput(firstNumeral, secondNumeral);

            var firstArabic = _converter.ConvertToArabic(firstNumeral);
            var secondArabic = _converter.ConvertToArabic(secondNumeral);

            return _converter.ConvertToRoman(firstArabic + secondArabic);
        }

        private void CheckInput(string firstNumeral, string secondNumeral)
        {
            var allCharacters = $"{firstNumeral}{secondNumeral}";
            if (allCharacters.Any(c => !RomanDictionary.Numerals.ContainsKey(c.ToString())))
            {
                throw new Exception("Invalid characters");
            }
        }
    }
}
