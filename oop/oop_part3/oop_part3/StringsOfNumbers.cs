using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_part3
{
    public class StringsOfNumbers
    {
        protected string[] Tens;
        protected string[] Teens;
        protected string[] Digits;

        public StringsOfNumbers() 
        {
            Tens = new string[] 
            { "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

            Teens = new string[] 
            { "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen",
                "Sixteen", "Seventeen", "Eighteen", "Nineteen" };

            Digits = new string[]{"One", "Two", "Three", "Four", "Five",
                "Six", "Seven", "Eight", "Nine"};

        }
    }
}
