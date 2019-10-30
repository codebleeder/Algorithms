using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter12_HashTables
{
    public static class HashTables_01_CanFormPalindrome
    {
        public static bool CanFormPalindrome(string s)
        {
            var countMap = new Dictionary<char, int>();
            foreach(var c in s)
            {
                if (countMap.ContainsKey(c))
                {
                    countMap[c]++;
                }
                else
                {
                    countMap[c] = 1;
                }
            }
            var countOne = 0;
            foreach(KeyValuePair<char, int> kv in countMap)
            {
                if (kv.Value == 1 && countOne > 0)
                {
                    return false;
                }
                else if (kv.Value == 1 && countOne == 0)
                {
                    countOne++;
                }
                else if (kv.Value % 2 != 0)
                {
                    return false;
                }
            }
            return true;
        }
        // book solution: 
        public static bool CanFormPalindrome2(string s)
        {
            var set = new HashSet<char>();
            foreach(var c in s)
            {
                if (set.Contains(c))
                {
                    set.Remove(c);
                }
                else
                {
                    set.Add(c);
                }
            }
            return set.Count <= 1;
        }
        public static void Test()
        {
            var tests = new List<Tuple<string, bool>>
            {
                new Tuple<string, bool>("edified", true),
                new Tuple<string, bool>("vleel", true),
                new Tuple<string, bool>("vvlele", true),
                new Tuple<string, bool>("dke", false),
                new Tuple<string, bool>("dkee", false),
            };
            for(var i = 0; i < tests.Count; i++)
            {
                var res = CanFormPalindrome2(tests[i].Item1);
                var resDisplay = res == tests[i].Item2 ? "pass" : "fail";
                Console.WriteLine($"{tests[i].Item1} res: {res}  expected: {tests[i].Item2}  {resDisplay}");
            }
        }
    }
}
