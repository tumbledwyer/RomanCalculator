using System.Linq;
using RomanCalculator.DataConstants;

namespace RomanCalculator.Converter
{
    public class RomanConverter : IRomanConverter
    {
        public int ConvertToArabic(string input)
        {
            var output = 0;
            var previous = 0;
            foreach (var digit in input.Reverse())
            {
                var numeralValue = RomanDictionary.Numerals[digit.ToString()];
                output += numeralValue < previous ? - numeralValue : numeralValue;
                previous = numeralValue;
            }
            return output;
        }

        public string ConvertToRoman(int input)
        {
            return DoConversion(input, string.Empty);
        }

        private string DoConversion(int input, string numeralBuilder)
        {
            var index = 0;
            while (input > 0)
            {
                if (NextNumeralValueCanBeSubtracted(input, index))
                {
                    input = SubtractNextNumeralValue(input, index);
                    numeralBuilder = AppendNextNumeral(numeralBuilder, index);
                    return DoConversion(input, numeralBuilder);
                }
                index++;
            }
            return numeralBuilder;
        }

        private static string AppendNextNumeral(string numeralBuilder, int index)
        {
            return $"{numeralBuilder}{RomanDictionary.Numerals.Reverse().ElementAt(index).Key}";
        }

        private static int SubtractNextNumeralValue(int input, int index)
        {
            return input - RomanDictionary.Numerals.Reverse().ElementAt(index).Value;
        }

        private static bool NextNumeralValueCanBeSubtracted(int input, int index)
        {
            var numeralValue = RomanDictionary.Numerals.Reverse().ElementAt(index).Value;
            return numeralValue <= input;
        }
    }
}