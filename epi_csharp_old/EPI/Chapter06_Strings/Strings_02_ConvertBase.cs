using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter6_Strings
{
    public static class Strings_02_ConvertBase
    {
        public static string ConvertToBase(string num, int base1, int base2)
        {
            // convert num to base 10 
            var base10 = 0;
            var isNegative = num[0] == '-';
            for(var i = num.Length - 1; i >= (isNegative ? 1 : 0); i--)
            {
                base10 += (
                    (Char.IsDigit(num[i]) ? num[i] - '0' : num[i] - 'A' + 10) * (int) (Math.Pow(base1, (num.Length - 1 - i))
                    ));
            }

            // convert base10 to base2 
            var sb = new StringBuilder();
            var charArr = new List<char>(); 
            while(base10 != 0)
            {
                var remainder = base10 % base2;
                var remainderChar = remainder >= 10 ? (char)('A' + remainder - 10) : (char)('0' + remainder);                
                charArr.Add(remainderChar);
                base10 = base10 / base2; 
            }
            if(isNegative)
            {
                sb.Append('-');
            }
            for(var i = charArr.Count-1; i>=0; i--)
            {
                sb.Append(charArr[i]);
            }
            return sb.ToString();
        }
        public static string ConvertToBase2(string numAsString, int base1, int base2)
        {
            var isNegative = numAsString.StartsWith("-");
            var numAsInt = 0; 
            
            for (var i = numAsString.Length - 1; i >= (isNegative ? 1 : 0); i--)
            {
                numAsInt += (
                    (Char.IsDigit(numAsString[i]) ? numAsString[i] - '0' : numAsString[i] - 'A' + 10) * (int)(Math.Pow(base1, (numAsString.Length - 1 - i))
                    ));
            }
            return (isNegative ? "-" : "") + (numAsInt == 0 ? "0" : ConstructFromBase(numAsInt, base2));
        }

        private static string ConstructFromBase(int numAsInt, int base2)
        {
            
            return numAsInt == 0
                ? ""
                : ConstructFromBase(numAsInt / base2, base2) + (char)(numAsInt % base2 >= 10 ? 'A' + numAsInt % base2 - 10
                : '0' + numAsInt % base2);
        }

        public static void Test()
        {
            var tests = new List<Tuple<string, int, int>>();
            var expectedResults = new List<string>();
            tests.Add(new Tuple<string, int, int>("615", 7, 13));
            expectedResults.Add("1A7");
            tests.Add(new Tuple<string, int, int>("12", 10, 2));
            expectedResults.Add("1100");
            tests.Add(new Tuple<string, int, int>("F1", 16, 10));
            expectedResults.Add("241");
            for(var i = 0; i < expectedResults.Count; i++)
            {
                Console.WriteLine($"test1 num = {tests[i].Item1} base1 = {tests[i].Item2} base2 = {tests[i].Item3}");
                var result = ConvertToBase2(tests[i].Item1, tests[i].Item2, tests[i].Item3);
                Console.WriteLine($"expected = {expectedResults[i]}    result = {result}");
            }
        }
    }
}
