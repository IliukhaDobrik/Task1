using System.Text;

namespace Helpers;

public static class DataGenerator
{
    public static async Task<List<DateTime>> DateGenerate(int count)
    {
        var rnd = new Random();
        var now = DateTime.UtcNow;
        List<DateTime> dates = new List<DateTime>();

        for (int i = 0; i < count; i++)
        {
            int days = rnd.Next(0, 365 * 4 + 364);
            dates.Add(now.AddDays(-days));
        }

        return dates;
    }

    public static async Task<List<string>> StrGenerate(string language, int lenght, int count)
    {
        var rnd = new Random();
        const string ruChars = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        const string enChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        List<string> result = new List<string>();
        var sb = new StringBuilder();
        
        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < lenght; j++)
            {
                if (language == "en")
                {
                    sb.Append(enChars[rnd.Next(enChars.Length)]);
                }
                else
                {
                    sb.Append(ruChars[rnd.Next(ruChars.Length)]);
                }
            }
            
            result.Add(sb.ToString());
            sb.Clear();
        }

        return result;
    }

    public static async Task<List<int>> IntGenerate(int min, int max, int count)
    {
        var rnd = new Random();
        var result = Enumerable.Range(0, count).Select(x => rnd.Next(min, max+1)).ToList();

        return result;
    }

    public static async Task<List<double>> DoubleGenerate(int min, int max, int accuracy, int count)
    {
        var rnd = new Random();
        var result = new List<double>();

        for (int i = 0; i < count; i++)
        {
            var rndDouble = rnd.NextDouble() * (max - min) + min;
            result.Add(Math.Round(rndDouble, accuracy));
        }

        return result;
    }
}