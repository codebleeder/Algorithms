using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter11_Searching
{
    public static class Searching_03_SearchSmallest
    {
        public static int SearchSmallest(List<int> arr)
        {
            var left = 0;
            var right = arr.Count - 1;
            while (left < right)
            {
                var m = left + (right - left) / 2;
                if (arr[m] > arr[right])
                {
                    left = m + 1;
                }
                else
                {
                    right = m;
                }
            }
            return left;
        }
        public static void Test()
        {
            var arr = new List<int> { 378, 478, 550, 631, 103, 203, 220, 234, 279, 368 };
            var res = SearchSmallest(arr);
            Utilities.PrintList(arr);
            Console.WriteLine($"result: {res}  expected: 4 (103)");
        }
    }
}
