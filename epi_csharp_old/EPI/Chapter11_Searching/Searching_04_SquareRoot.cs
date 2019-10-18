using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter11_Searching
{
    public static class Searching_04_SquareRoot
    {
        public static int SquareRoot(int k)
        {
            var left = 0;
            var right = k;
            while (left <= right)
            {
                var m = left + (right - left) / 2;
                var square = m * m;
                if (square == k)
                {
                    return m;
                }
                else if (square > k)
                {
                    right = m - 1;
                }
                else
                {
                    left = m + 1;
                }
            }
            return left - 1;
        }
        public static void Test()
        {
            var tests = new List<int> { 4, 9, 21, 100 };
            var expected = new List<int> { 2, 3, 4, 10 };
            for (var i = 0; i < tests.Count; i++)
            {
                var res = SquareRoot(tests[i]);
                Console.WriteLine($"input: {tests[i]}  result: {res}  expected: {expected[i]}");
            }
        }
    }
}
