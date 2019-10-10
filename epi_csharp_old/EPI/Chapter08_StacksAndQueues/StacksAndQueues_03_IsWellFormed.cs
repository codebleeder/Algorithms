using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter8_StacksAndQueues
{
    public static class StacksAndQueues_03_IsWellFormed
    {
        public static bool IsWellFormed(string s)
        {
            var openBraces = new Stack<char>();
            var braceMatches = new Dictionary<char, char>
            {
                { '}', '{' },
                { ']', '[' },
                { ')', '(' },
            };
            foreach(var c in s)
            {
                if (IsOpeningBrace(c))
                {
                    openBraces.Push(c);
                }
                if (IsClosingBrace(c))
                {
                    if (openBraces.Count == 0)
                    {
                        return false;
                    }
                    var openBrace = openBraces.Pop();
                    if (openBrace != braceMatches[c])
                    {
                        return false;
                    }
                }
            }
            if (openBraces.Count != 0)
            {
                return false;
            }
            return true;
        }
        public static void Test()
        {
            var tests = new List<Tuple<string, bool>>
            {
                new Tuple<string, bool>("([]){()}", true),
                new Tuple<string, bool>("[()[]{()()}]", true),
                new Tuple<string, bool>("{)", false),
                new Tuple<string, bool>("[()[]{()()", false),
            };
            var i = 1;
            foreach (var test in tests)
            {
                var res = IsWellFormed(test.Item1);
                Console.WriteLine($"case {i} input: {test.Item1}  expected: {test.Item2}");
                Console.WriteLine($"result: {res}  test result: {res == test.Item2}");
                Console.WriteLine("");
                i++;
            }
        }
        public static bool IsOpeningBrace(char c)
        {
            return c == '{' || c == '[' || c == '(';
        }
        public static bool IsClosingBrace(char c)
        {
            return c == '}' || c == ']' || c == ')';
        }
    }
}
