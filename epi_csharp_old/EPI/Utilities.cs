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
        public static void PrintArray<T>(T[] a)
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
        public static void PrintMatrix(List<List<int>> matrix)
        {
            for(var i=0; i<matrix.Count; i++)
            {
                PrintList(matrix[i]);
            }
        }
        public static void PrintLinkedList<T>(LinkedList<T> l)
        {
            Console.WriteLine("");
            var current = l.First;
            while (current != null)
            {
                Console.Write($"{current.Value} -> ");
                current = current.Next;
            }
        }
    }
}
