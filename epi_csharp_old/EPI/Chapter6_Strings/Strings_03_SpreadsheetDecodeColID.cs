using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter6_Strings
{
    public static class Strings_03_SpreadsheetDecodeColID
    {
        public static int DecodeColID(string colId)
        {
            var result = 0;
            var power = 1;
            for(var i = colId.Length - 1; i >= 0; i--)
            {
                result += (colId[i] - 'A' + 1) * (int) Math.Pow(26, i);
                power += 1; 
            }
            return result; 
        }
        public static void Test()
        {
            var tests = new List<Tuple<string, int>>();
            tests.Add(new Tuple<string, int>("A", 1));
            tests.Add(new Tuple<string, int>("ZZ", 702));
            
            foreach(var test in tests)
            {
                Console.WriteLine($"decoding {test.Item1}  expected: {test.Item2}  result: {DecodeColID(test.Item1)}");
            }
        }
    }
}
