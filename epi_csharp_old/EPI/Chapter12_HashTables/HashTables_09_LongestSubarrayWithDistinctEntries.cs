using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace EPI.Chapter12_HashTables
{
    public static class HashTables_09_LongestSubarrayWithDistinctEntries
    {
        public static Subarray LongestSubarrayWithDistinctEntries(List<int> arr)
        {
            var res = new Subarray(-1, -1);
            var latestOccurence = new Dictionary<int, int>();
            var nextStart = 0;
            for(var i = 0; i < arr.Count; i++)
            {
                var a = arr[i];
                if (latestOccurence.ContainsKey(a))
                {
                    if (i - nextStart > res.Length())
                    {
                        res.Start = nextStart;
                        res.End = i - 1;
                    }
                    nextStart = latestOccurence[a] + 1;
                }
                
                latestOccurence[a] = i;
            }
            
            return res; 
        }
        public static void Test()
        {
            var arr = new List<int> { 6, 19, 6, 5, 20, 23, 5, 14, 23, 5 };
            var res = LongestSubarrayWithDistinctEntries(arr);
            Console.WriteLine(res.ToString());
            var resArr = arr.GetRange(res.Start, res.Length() + 1);
            Utilities.PrintList(resArr);
        }
    }
}
