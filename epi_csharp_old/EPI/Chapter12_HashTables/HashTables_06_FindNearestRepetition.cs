using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPI.Chapter12_HashTables
{
    public static class HashTables_06_FindNearestRepetition
    {
        public static Tuple<string, int> FindNearestRepetition(List<string> paragraph)
        {
            var indices = new Dictionary<string, int>();
            var resWord = "";
            var resDistance = int.MaxValue;            
            for (var i = 0; i < paragraph.Count; i++)
            {
                if (indices.ContainsKey(paragraph[i]))
                {
                    var distance = i - indices[paragraph[i]];
                    if (resDistance > distance)
                    {
                        resWord = paragraph[i];
                        resDistance = distance;
                    }
                }
                indices[paragraph[i]] = i;
            }
            return new Tuple<string, int>(resWord, resDistance);
        }
        public static void Test()
        {
            var paragraphStr = "all work and no play makes for no work no fun and no results";
            var res = FindNearestRepetition(paragraphStr.Split().ToList());
            Console.WriteLine($"word: {res.Item1}  distance: {res.Item2}");
        }
    }
}
