using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter6_Strings
{
    public static class Strings_01_InterconvertStringsAndInts
    {
        // int to string 
        public static string IntToString(int n)
        {
            var num = Math.Abs(n);
            var isNegative = n < 0;
            var sb = new StringBuilder();
            var charList = new List<char>();
            if(isNegative)
            {
                sb.Append('-');
            }
            while (num >= 1)
            {
                var remainder = num % 10;
                var s = (char)(remainder + '0');
                charList.Add(s);
                num = num / 10; 
            }
            // read from last and append to string builder
            var count = charList.Count; 
            for(var i = count-1; i >= 0; i--)
            {
                sb.Append(charList[i]);
            }
            return sb.ToString();
        }
        // string to int 
        public static int StringToInt(string s)
        {
            var isNegative = false;
            var startIndex = 0; 
            if(s[0] == '-')
            {
                isNegative = true;
                startIndex = 1; 
            }
            var res = 0;
            for(var i = startIndex; i < s.Length; i++)
            {
                var digit = s[i] - '0';
                res = res * 10 + digit;
            }
            return isNegative ? -1 * res : res;
        }        
        public static void TestIntToString()
        {
            var int1 = -2345;
            Console.WriteLine($"converting {int1} to string: result: {IntToString(int1)}");
            var int2 = 1294;
            Console.WriteLine($"converting {int2} to string: result: {IntToString(int2)}");
        }
        public static void TestStringToInt()
        {
            var tests = new List<string> { "-34232", "48372" };
            for(var i = 0; i < tests.Count; i++)
            {
                Console.WriteLine($"converting string {tests[i]}   result: {StringToInt(tests[i])}");
            }
        }
    }
}
