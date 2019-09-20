using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter6_Strings
{
    public static class Strings_09_RomanToInteger
    {
        public static int RomanToInteger(string s)
        {
            var T = new Dictionary<char, int> {
                {'I', 1 },
                {'V', 5 },
                {'X', 10 },
                {'L', 50 },
                {'C', 100 },
                {'D', 500 },
                {'M', 1000 }
            };
            var sum = T[s[s.Length - 1]];
            for(var i = s.Length - 2; i >= 0; i--)
            {
                var v1 = T[s[i]];
                var v2 = T[s[i + 1]];
                if(v2 > v1)
                {
                    sum -= v1;
                }
                else
                {
                    sum += v1;
                }
            }
            return sum;
        }
        public static void Test()
        {
            var tests = new List<Tuple<string, int>> {
                new Tuple<string, int>("XLVII", 47),
                new Tuple<string, int>("CXXIII", 123),
                new Tuple<string, int>("MCMXCVIII", 1998),
                new Tuple<string, int>("MMCCCXLV", 2345)
            };
            var i = 1;
            foreach(var test in tests)
            {
                Console.WriteLine($"test {i} input: {test.Item1}  expected: {test.Item2}");
                var result = RomanToInteger(test.Item1);
                var testResult = result == test.Item2 ? "passed" : "failed";
                Console.WriteLine($"result: {result}  test {testResult}");
            }
        }
    }
}
