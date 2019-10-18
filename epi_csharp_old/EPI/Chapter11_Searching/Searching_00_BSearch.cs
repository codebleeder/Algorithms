using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter11_Searching
{
    public static class Searching_00_BSearch
    {
        public static int BSearch(int t, List<int> arr)
        {
            var l = 0;
            var u = arr.Count - 1;
            while (l <= u)
            {
                var m = l + (u - l) / 2;
                if(arr[m] == t)
                {
                    return m;
                }
                else if (arr[m] < t)
                {
                    l = m + 1;
                }
                else
                {
                    u = m - 1;
                }
            }
            return -1;
        }
        public static int BSearchRecursive(int t, List<int> arr)
        {
            return RecursiveHelper(0, arr.Count - 1, t, arr);
        }
        public static int RecursiveHelper(int first, int last, int t, List<int> arr)
        {
            var m = first + (last - first) / 2;
            if (arr[m] == t)
            {
                return m;
            }
            else if(arr[m] > t)
            {
                return RecursiveHelper(first, m - 1, t, arr);
            }
            else
            {
                return RecursiveHelper(m + 1, last, t, arr);
            }
        }
        public static void Test()
        {
            var arr = new List<int> { 0, 2, 6, 23, 29, 45, 65, 83, 86, 88, 92 }; 
            for (var i = 0; i < arr.Count; i++)
            {
                var res = BSearch(arr[i], arr);
                var testRes = res == i ? "pass" : "fail";
                Console.WriteLine(testRes);
            }
        }
    }
}
