using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter5_Arrays
{
    public static class Arrays_8_Rearrange
    {
        // Computing an alternation:
        // Write a program that takes an array A of n numbers and rearranges A's elements
        // to get a new array B having property: B[0]<=B[1]>=B[2]<=B[3]...
        public static void Rearrange(int[] x)
        {
            for(var i=1; i<x.Length-1; i++)
            {
                if((i%2==0 && x[i-1]<x[i]) || (i%2 != 0 && x[i-1]>x[i]))
                {
                    var temp = x[i];
                    x[i] = x[i - 1];
                    x[i - 1] = temp;
                }
            }
        }
        public static void TestRearrange()
        {
            int[] x = {2,7,1,19,45,23,33,44,55,23,13 };
            Console.WriteLine("rearranging: ");
            Utilities.PrintArray(x);
            Rearrange(x);
            Console.WriteLine("rearranged: ");
            Utilities.PrintArray(x);
        }
    }
}
