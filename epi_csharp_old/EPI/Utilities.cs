using System;
using System.Collections.Generic;
using System.Text;

namespace EPI
{
    public static class Utilities
    {
        public static void PrintArray(int[] a)
        {
            //Console.WriteLine("");
            foreach (var e in a)
            {
                Console.Write($"{e}, ");
            }
            Console.WriteLine("");
        }
        public static void PrintList(List<int> a)
        {
            //Console.WriteLine("");
            foreach (var e in a)
            {
                Console.Write($"{e}, ");
            }
            Console.WriteLine("");
        }
        public static void PrintList(List<string> a)
        {
            //Console.WriteLine("");
            foreach (var e in a)
            {
                Console.Write($"{e}, ");
            }
            Console.WriteLine("");
        }
        public static void Swap(List<int> x, int index1, int index2)
        {
            var temp = x[index1];
            x[index1] = x[index2];
            x[index2] = temp; 
        }
        public static void Swap(int[] x, int index1, int index2)
        {
            var temp = x[index1];
            x[index1] = x[index2];
            x[index2] = temp;
        }
    }
}
