using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter6_Strings
{
    public static class Strings_06_ReverseWords
    {
        public static void ReverseWords(char[] s)
        {
            // first pass - reverse words 
            var iStart = 0;
            var iEnd = 0;
            while (iEnd < s.Length)
            {
                // find next last character of word or sentence
                while(iEnd < s.Length && s[iEnd] != ' ')
                {
                    iEnd += 1;
                }
                iEnd -= 1;
                Reverse(s, iStart, iEnd);

                if(iEnd == s.Length - 1)
                {
                    break;
                }
                else
                {
                    iEnd += 2;
                    iStart = iEnd;
                }
            }

            // second pass - reverse array
            Reverse(s, 0, s.Length - 1);
        }
        public static void Reverse(char[] s, int iStart, int iEnd)
        {            
            var j = iEnd; 
            for (var i = iStart; i < j; i++)
            {
                var temp = s[i];
                s[i] = s[j];
                s[j] = temp; 
                j--;
            }
        }
        public static void Test()
        {
            var tests = new List<Tuple<string, string>> {
                new Tuple<string, string>("Bob likes Alice", "Alice likes Bob"),
                new Tuple<string, string>("ram is costly", "costly is ram")
            };
            var i = 1;
            foreach(var test in tests)
            {
                var input = test.Item1.ToCharArray();
                ReverseWords(input);
                var res = new string(input);
                if(!res.Equals(test.Item2))
                {
                    Console.WriteLine($"test {i} failed; expected: {test.Item2} result: {res}");
                }
                else
                {
                    Console.WriteLine($"test {i} pass");
                }
                i++;
            }
        }
    }
}
