using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter11_Searching
{
    public static class Searching_01_SearchFirstOfK
    {
        public static int SearchFirstOfK(List<int> arr, int k)
        {
            var l = 0;
            var u = arr.Count - 1;
            var res = -1;
            while (l <= u)
            {
                var m = l + (u - l) / 2;
                if (arr[m] == k)
                {
                    res = m;
                    u = m - 1;
                }
                else if (arr[m] < k)
                {
                    l = m + 1;
                }
                else
                {
                    u = m - 1;
                }
            }
            return res;
        }
        public static void Test()
        {
            var arr = new List<int> { -14, -10, 2, 108, 108, 243, 285, 285, 285, 401 };
            Utilities.PrintList(arr);
            var res = SearchFirstOfK(arr, 108);
            Console.WriteLine($"first index for 108: {res}");
            res = SearchFirstOfK(arr, 285);
            Console.WriteLine($"first index for 285: {res}");
        }
    }
}
