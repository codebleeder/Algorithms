using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter12_HashTables
{
    public static class HashTables_00_StringHash
    {
        public static int StringHash(string s, int modulus)
        {
            var kMult = 997;
            var val = 0;
            for(var i = 0; i < s.Length; i++)
            {
                val = (val * kMult + s[i]) % modulus;
            }
            return val;
        }
        public static void Test()
        {
            var tests = new List<Tuple<string, int>>
            {
                new Tuple<string, int>("tree", 4),
                new Tuple<string, int>("free", 4),
                new Tuple<string, int>("tree", 5),
                new Tuple<string, int>("tres", 5),
            };
            for(var i = 0; i < tests.Count; i++)
            {
                var res = StringHash(tests[i].Item1, tests[i].Item2);
                Console.WriteLine($"string: {tests[i].Item1}  mod: {tests[i].Item2}  res: {res}");
            }
        }
    }
}
