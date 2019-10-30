using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter12_HashTables
{
    public static class HashTables_10_LongestContainedRange
    {
        public static Subarray LongestContainedRange(List<int> arr)
        {
            var set = new HashSet<int>();
            var res = new Subarray(-1, -1);
            foreach(var v in arr)
            {
                set.Add(v);
            }
            foreach(var v in arr)
            {
                if (set.Contains(v))
                {
                    // look for increasing values
                    var max = v;
                    while (set.Contains(max))
                    {
                        set.Remove(max);
                        max++;
                    }
                    max--;
                    // look for decreasing values 
                    var min = v - 1;
                    while (set.Contains(min))
                    {
                        set.Remove(min);
                        min--;
                    }
                    min++;
                    if (max - min + 1 > res.Length())
                    {
                        res.Start = min;
                        res.End = max;
                    }
                }
                
            }
            return res;
        }
        public static void Test()
        {
            var arr = new List<int> { 3, -2, 7, 9, 8, 1, 2, 0, -1, 5, 8 };
            var res = LongestContainedRange(arr);
            Console.WriteLine(res.ToString());
        }
    }
    public class MaxMinSubarray
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public MaxMinSubarray(int min, int max)
        {
            Min = min;
            Max = max; 
        }
        public int Length()
        {
            return Math.Abs(Min) + Math.Abs(Max);
        }
    }
}
