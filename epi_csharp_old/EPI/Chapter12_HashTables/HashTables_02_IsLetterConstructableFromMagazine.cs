using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter12_HashTables
{
    public static class HashTables_02_IsLetterConstructableFromMagazine
    {
        public static bool IsLetterConstructableFromMagazine(string letter, string magazine)
        {
            var letterMap = new Dictionary<string, int>();
            var letterWords = letter.Split(new char[] { ' ', '.', ',', });
            foreach(var w in letterWords)
            {
                if (letterMap.ContainsKey(w))
                {
                    letterMap[w]++;
                }
                else
                {
                    letterMap[w] = 1;
                }
            }
            var magazineWords = magazine.Split(new char[] { ' ', '.', ',', });
            foreach(var w in magazineWords)
            {
                if (letterMap.ContainsKey(w))
                {
                    letterMap[w]--;
                    if (letterMap[w] < 1)
                    {
                        letterMap.Remove(w);
                    }
                }
            }
            return letterMap.Count == 0;
        }
        public static void Test()
        {
            var letter = "jack and jill went up the hill.";
            var magazines = new List<string>
            {
                "jack was caught stealing. jill was caught robbing. and they lived up a hill. the police went to ther place and arrested them",
                "jack was caught stealing up the hill",
            };
            for (var i = 0; i < magazines.Count; i++)
            {
                var res = IsLetterConstructableFromMagazine(letter, magazines[i]);
                Console.WriteLine(res);
            }
        }
    }
}
