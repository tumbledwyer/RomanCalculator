namespace RomanCalculator.Converter
{
    public interface IRomanConverter
    {
        int ConvertToArabic(string input);
        string ConvertToRoman(int input);
    }
}