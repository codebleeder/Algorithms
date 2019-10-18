using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter11_Searching
{
    public static class Searching_02_SearchEntryEqualToItsIndex
    {
        public static List<int> SearchEntryEqualToItsIndex(List<int> arr)
        {
            var l = 0;
            var u = arr.Count - 1;
            var res = new List<int>();
            Helper(l, u, arr, res);
            return res;
        }
        public static void Helper(int start, int end, List<int> arr, List<int> res)
        {
            if (end < start)
            {
                return;
            }
            var m = start + (end - start) / 2;
            if (m == arr[m])
            {
                res.Add(m);
                Helper(start, m - 1, arr, res);
                Helper(m + 1, end, arr, res);
            }
            else if (m > arr[m])
            {
                Helper(start, arr[m], arr, res);
                Helper(m + 1, end, arr, res);
            }
            else
            {
                Helper(arr[m], end, arr, res);
                Helper(start, m - 1, arr, res);
            }
        }
        // book solution: 
        public static int SearchEntryEqualToItsIndex2(List<int> arr)
        {
            var res = new List<int>();
            var left = 0;
            var right = arr.Count - 1; 
            while (left <= right)
            {
                var m = left + (right - left) / 2;
                var diff = arr[m] - m;
                if (diff == 0)
                {
                    return m;
                }
                else if (diff > 0)
                {
                    right = m - 1;
                }
                else
                {
                    left = m + 1;
                }
            }
            return -1; 
        }
        public static void Test()
        {
            var arr = new List<int> { -2, 0, 2, 3, 6, 7, 9 };
            var res = SearchEntryEqualToItsIndex(arr);
            Utilities.PrintList(res);

            var res2 = SearchEntryEqualToItsIndex2(arr);
            Console.WriteLine(res2);
        }
    }
}
