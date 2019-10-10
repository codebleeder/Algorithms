using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter6_Strings
{
    public static class Strings_12_RunLengthEncoding
    {
        public static string Encoding(string s)
        {
            var sb = new StringBuilder();
            if (s.Length == 1)
            {
                return $"1{s[0]}";
            }
            var i = 1;
            var c = s[0];
            var count = 1;
            while (i < s.Length)
            {
                // increment until next non-repeating character
                if (s[i-1] != s[i])
                {
                    sb.Append($"{count}{s[i - 1]}");
                    count = 1;                    
                }
                else
                {
                    count++;
                }
                i++;
            }
            sb.Append($"{count}{s[i - 1]}");
            return sb.ToString();
        }
        public static void Test()
        {
            var tests = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("aaaabcccaa", "4a1b3c2a"),
                new Tuple<string, string>("a", "1a")
            };
            var i = 1;
            // encodings
            foreach (var test in tests)
            {
                var res = Encoding(test.Item1);
                Console.WriteLine($"test {i} result: {res}  expected: {test.Item2}  test res: {res == test.Item2}");
                i++;
            }

            // decodings
            i = 1;
            foreach (var test in tests)
            {
                var res = Decoding(test.Item2);
                Console.WriteLine($"test {i} result: {res}  expected: {test.Item1}  test res: {res == test.Item1}");
                i++;
            }
        }
        public static string Decoding(string s)
        {
            var sb = new StringBuilder();
            var i = 0;
            while (i < s.Length)
            {
                var count = int.Parse(s[i].ToString());
                for (var j = 0; j < count; j++)
                {
                    sb.Append(s[i + 1]);
                }
                i += 2;
            }
            return sb.ToString();
        }
    }
}
