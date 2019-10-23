using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter11_Searching
{
    public static class Searching_05_SquareRoot
    {
        private enum Ordering { SMALLER, EQUAL, LARGER };

        public static double SquareRoot(double k)
        {
            double left = 0;
            double right;
            if (k < 1.0)
            {
                left = 0;
                right = 1.0; 
            }
            else
            {
                left = 1.0;
                right = k;
            }
            while (Compare(left, right) != Ordering.EQUAL)
            {
                var m = left + (right - left) / 2.0;
                var mSquared = m * m;
                if (Compare(mSquared, k) == Ordering.LARGER)
                {
                    right = m;
                }
                else
                {
                    left = m;
                }
            }
            return left;
        }
        public static void Test()
        {
            var tests = new List<double> { 3, 0.87, 10, 25 };
            for (var i = 0; i < tests.Count; i++)
            {
                var res = SquareRoot(tests[i]);
                var expected = Math.Sqrt(tests[i]);
                Console.WriteLine($"input: {tests[i]}  res: {res}  expected: {expected}");
            }
        }
        private static Ordering Compare(double a, double b)
        {
            const double EPSILON = 0.00001;
            var diff = (a - b) / b;
            return diff < -EPSILON ? Ordering.SMALLER : (diff > EPSILON ? Ordering.LARGER : Ordering.EQUAL); 
        }
    }
}
