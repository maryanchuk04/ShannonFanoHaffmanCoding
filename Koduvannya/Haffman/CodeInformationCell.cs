using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koduvannya
{
    class CodeInformationCell
    {
        char symbol;
        double frequency;
        String codeWord;
        int lenghtCodeWord;

        public CodeInformationCell() { }

        public CodeInformationCell(char symbol, double frequency, String codeWord, int lenghtCodeWord)
        {
            this.symbol = symbol;
            this.frequency = frequency;
            this.codeWord = codeWord;
            this.lenghtCodeWord = lenghtCodeWord;
        }

        public override string ToString()
        {
            String output = String.Format("{0} : {1} :: {2} :: {3};", symbol, frequency, codeWord, lenghtCodeWord);
            return output;
        }

        // вивід
        public static String ListToString(List<CodeInformationCell> list)
        {
            String output = String.Empty;

            foreach (var o in list)
                output += o.ToString() + Environment.NewLine;

            return output;
        }

        // середня довжина коду
        public static double MedLenghtList(List<CodeInformationCell> list)
        {
            double sumLenght = 0;

            foreach (var c in list)
                sumLenght += c.frequency*c.lenghtCodeWord;
            return sumLenght;
        }
    }
       
}

