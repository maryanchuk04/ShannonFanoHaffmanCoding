using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koduvannya
{
    class CodeInformationCellFano : IComparable<CodeInformationCellFano>
    {
        char symbol;
        double frequency;
        String codeWord;

        public CodeInformationCellFano(char symbol, double frequency, String codeWord)
        {
            this.symbol = symbol;
            this.frequency = frequency;
            this.codeWord = codeWord;
        }

        public Char Symbol => symbol;
        public double Frequency => frequency;
        public String CodeWord => codeWord;
        public Int32 LenghtCode => codeWord.Length;

        public override string ToString()
        {
            return String.Format("{0,5} : {1:f5} : {2,10} : {3,5}", Symbol, Frequency, CodeWord, LenghtCode);
        }
        //порівняння
        public Int32 CompareTo(CodeInformationCellFano informationCell)
        {
            return this.Symbol.CompareTo(informationCell.Symbol);
        }

        // вивід
        public static String ListToString(List<CodeInformationCellFano> list)
        {
            String output = String.Empty;
            list.Sort();
            output += "Symbol: Frequency: Code: Code Length" + Environment.NewLine + Environment.NewLine;

            foreach (var o in list)
                output += o.ToString() + Environment.NewLine;
            return output;
        }

        // середня довжина коду
        public static  double MedLenghtList(List<CodeInformationCellFano> list)
        {
            double medLenght = list.Select(c => c.LenghtCode * c.Frequency).Sum();
            return medLenght;
        }
       

    }

}
