using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace EPI.Chapter12_HashTables
{
    // This code is less complex than the code in the book
    public class HashTables_07_FindSmallestSubarrayCoveringSet_BookSolution
    {
        public static Subarray FindSmallestSubarrayCoveringSet(List<string> paragraph, HashSet<string> keywords)
        {
            var dict = new OrderedDictionary();
            foreach(var k in keywords)
            {
                dict.Add(k, null);
            }
            var numStringsFromQueryStringsSeenSoFar = 0;
            var res = new Subarray(-1, -1);
            var idx = 0; 
            while (idx < paragraph.Count)
            {
                var s = paragraph[idx];
                if (dict.Contains(s))
                {
                    var it = dict[s];
                    if (it == null)
                    {
                        numStringsFromQueryStringsSeenSoFar++;
                    }
                    dict.Remove(s);
                    dict[s] = idx;
                }
                if (numStringsFromQueryStringsSeenSoFar == keywords.Count)
                {
                    if ((res.Start == -1 && res.End == -1) || 
                        idx - (int) dict[0] < res.Length())
                    {
                        res.Start = (int)dict[0];
                        res.End = idx;
                    }
                }
                ++idx;
            }
            return res; 
        }

        public static void Test()
        {
            var paragraph = "apple banana apple apple dog cat apple dog banana apple cat dog";
            var res = FindSmallestSubarrayCoveringSet(paragraph.Split().ToList(), new HashSet<string> { "banana", "cat" });
            Console.WriteLine(res.ToString());
        }
    }
    
}
