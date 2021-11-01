using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Koduvannya.FunctionsClass;


namespace Koduvannya

{
    static class FanoCoding
    {
        public static List<CodeInformationCellFano> Code()
        {
            var sortDict = DictionaryFerquencySort<double>(keyPair => keyPair.Value, SortParametr.Descending);
            List<CodeInformationCellFano> listOut = Method(sortDict);
            return listOut;
        }
        //шукаємо медіану
        static int Med(int startIndex, int endIndex, Dictionary<char, double> fdq)
        {
            double sumL = 0.0;

            for (int i = startIndex; i <= endIndex - 1; i++)
                sumL += fdq.ValueDict(i).Value;

            double sumR = fdq.ValueDict(endIndex).Value;

            int med = endIndex;

            while (sumL >= sumR)
            {
                med = med - 1;
                sumL = sumL - fdq.ValueDict(med).Value;
                sumR = sumR + fdq.ValueDict(med).Value;
            }

            return med;
        }

       //тут шукаємо код
        static void Fano(int startIndex, int endIndex, Dictionary<char, double> d, String[] listCodes)
        {
            if (startIndex < endIndex)
            {
                int med = Med(startIndex, endIndex, d);
                for (int i = startIndex; i <= endIndex; i++)
                {
                    if (i <= med)
                        listCodes[i] += '0';
                    else
                        listCodes[i] += '1';

                }
                Fano(startIndex, med, d, listCodes);
                Fano(med + 1, endIndex, d, listCodes);
            }
            if (listCodes.Length == 1)
            {
                listCodes[0] = "0";
            }
        }

        static List<CodeInformationCellFano> Method(Dictionary<char, double> sortDict)
        {
            int lenght = sortDict.Keys.Count;
            String[] codeWords = new String[lenght];

            Fano(0, lenght - 1, sortDict, codeWords);

            List<CodeInformationCellFano> listOut = new List<CodeInformationCellFano>();

            int index = 0;

            foreach (var c in sortDict)
            {
                listOut.Add(new CodeInformationCellFano(c.Key, c.Value, codeWords[index]));
                index++;
            }
            return listOut;
        }
        public static string Informations(List<CodeInformationCellFano> list)
        {
            string answer = String.Empty;
            answer += Environment.NewLine + "Ентропія = " + FunctionsClass.Entropy().ToString();
            answer += Environment.NewLine + "Середня довжина = " + CodeInformationCellFano.MedLenghtList(list);
            answer += Environment.NewLine + "Ефективність = " + FunctionsClass.Entropy() / CodeInformationCellFano.MedLenghtList(list);
            return answer;
        }
        public static String ListToString(List<CodeInformationCellFano> list)
        {
            String output = String.Empty;
            list.Sort();
            output += "Symbol: Ferquency: Cod: Length Code" + Environment.NewLine + Environment.NewLine;

            foreach (var o in list)
                output += o.ToString() + Environment.NewLine;

            return output;
        }
    }

    // розширення словника

    static class DictExt
    {
        // вертає ключ значення по індексу
        public static KeyValuePair<char, double> ValueDict(this Dictionary<char, double> d, int index)
        {
            var count = 0;
            foreach (var c in d)
            {
                if (index == count)
                    return c;
                count++;
            }

            throw new IndexOutOfRangeException("Указанный индекс за пределами возможных занчения!!!");
        }
    }
   
}
