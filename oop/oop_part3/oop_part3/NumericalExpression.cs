using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_part3
{
    public class NumericalExpression: StringsOfNumbers
    {
        private long Number;
        
        public NumericalExpression(long number) 
        {
            Number = number;
        }    

        public override string ToString() 
        {
            if (Number == 0)
                return "zero";

            string threeDigitedExpression = GetThreeDigitedExpression(Number % 1000);
            string thousand = GetExpression((Number / 1000) % 1000 , "thousand");
            string million = GetExpression((Number / 1000000) % 1000, "milllion");
            string trillion = GetExpression(Number / 1000000000, "trillion");

            return $"{trillion} {million} {thousand} {threeDigitedExpression}".Trim();
            
        }

        public string GetThreeDigitedExpression(long number)
        {
            long digit = number % 10;
            long tens = number / 10 % 10;
            long hundreds = number / 100 ;
            string output;

            if(digit == 0  && tens == 0) 
            {
                output = "";
            }
            else if (digit == 0 && tens != 0)
            {
                output = Tens[tens - 1];
            }
            else if(digit != 0 && tens == 0)
            {
                output = Digits[digit - 1];
            }
            else if(tens == 1)
            {
                output = Teens[digit - 1];
            }
            else
            {
                output = $"{Tens[tens-1]} {Digits[digit - 1]}";
            }

            if (hundreds != 0)
            {
                return $"{Digits[hundreds - 1]} hundred {output}";
            }
            return output ; 

        }
        public string GetExpression(long number, string size)
        {
            if (number != 0)
            {
                return $"{GetThreeDigitedExpression(number)} {size}";
            }
            return "";
        }

        public long GetValue() 
        { 
            return Number; 
        }

        public static int SumLetters(long number)
        {
            int sum = 0;
            for (long i = 0; i < number; i++)
            {
                NumericalExpression numericalExpression = new NumericalExpression(i);
                sum += numericalExpression.ToString().Trim().Length;
            }
            return sum;
        }
        //העקרון בתכנות מונחה עצמים שבא לידי ביטוי הוא עקרון הרב צורתיות 
        public static int SumLetters(NumericalExpression inputNumericalExpression)
        {
            long number = inputNumericalExpression.GetValue();
            return SumLetters(number);        
        }

    }
}
