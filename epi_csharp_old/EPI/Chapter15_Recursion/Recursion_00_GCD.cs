using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter15_Recursion
{
    public static class Recursion00_GCD
    {
        public static long GCD(long x, long y)
        {
            return y == 0 ? x : GCD(y, x % y);
        }
        public static int Multiply(int x, int y)
        {
            if (y == 0)
            {
                return 0;
            }
            if (y == 1)
            {
                return x;
            }
            return x + Multiply(x, y-1);
        }
        public static void Test()
        {
            Console.WriteLine($"gcd of 30 and 24 = {GCD(30, 24)}");
            Console.WriteLine($"3 x 4 = {Multiply(3, 4)}");
        }
    }
}
