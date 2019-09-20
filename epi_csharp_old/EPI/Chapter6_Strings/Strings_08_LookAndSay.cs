using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter6_Strings
{
    public static class Strings_08_LookAndSay
    {
        public static string LookAndSay(int n)
        {
            var res = "1";
            for (var i = 0; i < n-1; i++)
            {
                res = Next(res);
            }
            return res; 
        }
        public static string Next(string sequence)
        {
            var res = "";
            var i = 0; 
            while(i < sequence.Length)
            {
                // count until you hit a different number
                var num = sequence[i];
                var count = 1;
                while(i < sequence.Length - 1 && sequence[i] == sequence[i+1])
                {
                    i += 1;
                    count += 1;
                }
                res = String.Concat(res, count, sequence[i]);
                i += 1;
            }
            return res; 
        }
        
        // book version: 
        private static string Next2(string sequence)
        {
            var result = new StringBuilder();
            for (var i = 0; i < sequence.Length; i++)
            {
                var count = 1;
                while (i + 1 < sequence.Length && sequence[i] == sequence[i+1])
                {
                    ++i;
                    ++count;
                }
                result.Append(count);
                result.Append(sequence[i]);
            }
            return result.ToString();
        }
        public static void TestNext()
        {
            var tests = new List<Tuple<string, string>> {
                new Tuple<string, string>("1211", "111221"),
                new Tuple<string, string>("111221", "312211"),
                new Tuple<string, string>("1", "11")
            };
            var i = 1; 
            foreach(var test in tests)
            {
                Console.WriteLine($"test {i} seq: {test.Item1}  expected: {test.Item2}");
                var res = Next(test.Item1);
                if (res != test.Item2)
                {
                    Console.WriteLine($"test {i} failed; result: {res}");
                }
                else
                {
                    Console.WriteLine($"test {i} passed; result: {res}");
                }
                i += 1;
            }                       
        }
        public static void Test()
        {
            var tests = new List<Tuple<int, string>> {
                new Tuple<int, string>(1, "1"),
                new Tuple<int, string>(6, "312211"),
            };
            var i = 1;
            foreach (var test in tests)
            {
                Console.WriteLine($"test {i} seq: {test.Item1}  expected: {test.Item2}");
                var res = LookAndSay(test.Item1);
                if (res != test.Item2)
                {
                    Console.WriteLine($"test {i} failed; result: {res}");
                }
                else
                {
                    Console.WriteLine($"test {i} passed; result: {res}");
                }
                i += 1;
            }
        }
    }
}
