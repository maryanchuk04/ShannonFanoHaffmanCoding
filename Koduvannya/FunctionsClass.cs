using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koduvannya
{
    static class FunctionsClass
    {
        static Dictionary<char, double> frequency = new Dictionary<char, double>(); // словник символ * частота
        //завантаження частот
        public static void LoadFrequency(String inputText)
        {
            frequency.Clear();
            String redactText = inputText;
            int countSymbols = 0;

            foreach (var c in redactText)
            {
                if (Char.IsLetter(c))
                {
                    if (frequency.Keys.Contains(c))
                        frequency[c]++;
                    else
                        frequency.Add(c, 1.0);
                    countSymbols++;
                }
            }

            var keys = frequency.Keys.ToList();

            for (int i = 0; i < keys.Count; i++)
                frequency[keys[i]] /= countSymbols;
        }

       //сортування
        public static Dictionary<char, double> DictionaryFerquencySort<T>(Func<KeyValuePair<char, double>, T> func, SortParametr sortParametr)
        {
            var sortList = frequency.OrderByDescending(func).Select(d => new { Symbol = d.Key, Frequency = d.Value });
            if (sortParametr == SortParametr.Ascending)
                sortList.Reverse();
            var sortDict = new Dictionary<char, double>();

            foreach (var c in sortList)
                sortDict.Add(c.Symbol, c.Frequency);

            return sortDict;
        }

       
        public static String BinaryBaseValue(double f, int lenght)
        {
            String answer = String.Empty;
            double temp = f;

            for (int i = 1; i <= lenght; i++)
            {
                temp *= 2;
                answer += ((int)temp).ToString();
                temp = temp - (int)temp;
            }

            return answer;
        }

        // пошук ентропії
        public static double Entropy()
        {
            double entropy = 0.0;

            foreach (var c in frequency.Keys)
                entropy -= frequency[c] * Math.Log(frequency[c], 2);

            return entropy;
        }
    }

    enum SortParametr
    {
        Ascending,
        Descending
    }
}
