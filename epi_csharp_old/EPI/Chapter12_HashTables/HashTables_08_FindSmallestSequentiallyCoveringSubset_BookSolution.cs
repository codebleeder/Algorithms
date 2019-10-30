using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EPI.Chapter12_HashTables;

namespace EPI.Chapter12_HashTables
{
    public static class HashTables_08_FindSmallestSequentiallyCoveringSubset_BookSolution
    {
        public static Subarray FindSmallestSequentiallyCoveringSubset(List<string> paragraph, List<string> keywords)
        {
            var keywordToIdx = new Dictionary<string, int>();
            var latestOccurence = new List<int>();
            var shortestSubarrayLength = new List<int>();
            for (var i = 0; i < keywords.Count; i++)
            {
                latestOccurence.Add(-1);
                shortestSubarrayLength.Add(int.MaxValue);
                keywordToIdx[keywords[i]] = i;
            }
            var shortestDistance = int.MaxValue;
            var res = new Subarray(-1, -1);
            for (var i = 0; i < paragraph.Count; i++)
            {
                var keywordIdx = -1;
                if (keywordToIdx.ContainsKey(paragraph[i]))
                {
                    keywordIdx = keywordToIdx[paragraph[i]];
                    if (keywordIdx == 0) // first keyword
                    {
                        shortestSubarrayLength[0] = 1;
                    }
                    else if (shortestSubarrayLength[keywordIdx-1] != int.MaxValue)
                    {
                        var distanceToPreviousKeyword = i - latestOccurence[keywordIdx - 1];
                        shortestSubarrayLength[keywordIdx] = distanceToPreviousKeyword + shortestSubarrayLength[keywordIdx - 1];
                    }
                    latestOccurence[keywordIdx] = i;

                    // last keyword, look for improved subarray
                    if (keywordIdx == keywords.Count - 1 && 
                        shortestSubarrayLength[shortestSubarrayLength.Count - 1] < shortestDistance)
                    {
                        shortestDistance = shortestSubarrayLength[shortestSubarrayLength.Count - 1];
                        res.Start = i - shortestSubarrayLength[shortestSubarrayLength.Count - 1] + 1;
                        res.End = i;
                    }
                }
            }
            return res;
        }
        
        public static void Test()
        {
            var paragraph = @"my paramount object in this struggle is to save the union and is not either to save or to destroy slavery if i could save the union without freeing any slave i would do it and if i could save it by freeing all the slaves i would do it and if i could save it by freeing some and leaving others alone i would also do it";
            var keywords = new List<string> { "union", "save" };
            var res = FindSmallestSequentiallyCoveringSubset(paragraph.Split().ToList(), keywords);
            Console.WriteLine(res.ToString());
        }
    }
}
