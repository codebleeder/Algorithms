using System;
using System.Collections.Generic;
using System.Text;
using static EPI.Chapter5_Arrays.Arrays;

namespace EPI.Chapter5_Arrays
{
    public static class ArraysTests
    {
        public static void TestEvenOdd()
        {
            int[] a = { 1, 2, 3, 4, 5, 6 };
            Arrays.EvenOdd(a);
            Utilities.PrintArray(a);
            int[] b = { 2, 3, 5, 7 };
            Arrays.EvenOdd(b);
            Utilities.PrintArray(b);
            Console.WriteLine("EvenOdd2(): ");
            int[] c = { 1, 2, 3, 4, 5, 6 };
            Arrays.EvenOdd2(c);
            Utilities.PrintArray(c);
            int[] d = { 2, 3, 5, 7 };
            Arrays.EvenOdd2(d);
            Utilities.PrintArray(d);
        }
        
        public static void TestDutchFlagPartition()
        {
            List<int> a = new List<int> { 0, 1, 2, 0, 2, 1, 1 };
            DutchFlagPartition2(3, a);
            Console.WriteLine("pivot=3 value=0 expected array={0,0,1,2,2,1,1}");
            Utilities.PrintList(a);
        }
        public static void TestDutchFlagPartition4()
        {
            int[] a =  { 0, 1, 2, 0, 2, 1, 1 };
            DutchPartition4(3, a);
            Console.WriteLine("pivot=3 value=0 expected array={0,0,1,2,2,1,1}");
            Utilities.PrintArray(a);
            int[] b = { 0, 1, 2, 0, 2, 1, 1 };
            DutchPartition4(1, b);
            Console.WriteLine("pivot=1 value=1 expected array={0,0,1,1,1,2,2}");
            Utilities.PrintArray(b);
        }
        public static void TestPlusOne()
        {
            List<int> a = new List<int> { 1, 2, 3 };
            Console.WriteLine("add 1 to {1, 2, 3}");
            Utilities.PrintList(Arrays.PlusOne(a));

            Console.WriteLine("add 1 to {1, 2, 9}");
            Utilities.PrintList(Arrays.PlusOne(new List<int> { 1, 2, 9 }));

            Console.WriteLine("add 1 to {9, 9, 9}");
            Utilities.PrintList(Arrays.PlusOne(new List<int> { 9, 9, 9 }));
        }
        public static void TestMultiply()
        {
            List<int> a = new List<int> { 1, 2, 3 };
            List<int> b = new List<int> { 4, 5, 6 };
            Console.WriteLine("multiply {1, 2, 3} and {4, 5, 6}");
            Console.WriteLine("expected result: {5,6,0,8,8}");
            Utilities.PrintList(Arrays.Multiply(a, b));
        }
        public static void TestCanReachEnd()
        {
            var a = new List<int> { 3, 3, 1, 0, 2, 0, 1 };
            var b = new List<int> { 2, 4, 1, 1, 0, 2, 3 };
            var c = new List<int> { 0, 0, 2, 0, 0 };
            Console.WriteLine($"Testing a: expected = true {Arrays.CanReachEnd(a)}");
            Console.WriteLine($"Testing b: expected = true {Arrays.CanReachEnd(b)}");
            Console.WriteLine($"Testing c: expected = false CanReachEnd(): {Arrays.CanReachEnd(c)}");
            Console.WriteLine($"Testing c: expected = false CanReachEnd2(): {Arrays.CanReachEnd2(c)}");
        }
        public static void TestRemoveDuplicates()
        {
            int[] a = { 2, 3, 5, 5, 7, 11, 11, 11, 13 };
            Console.WriteLine("removing duplicates for: ");
            Utilities.PrintArray(a);
            Console.WriteLine("expected: {2,3,5,7,11,13,0,0,0}");
            Arrays.RemoveDuplicates(a);
            Utilities.PrintArray(a);
        }
        public static void TestRemoveDuplicates2()
        {
            int[] a = { 2, 3, 5, 5, 7, 11, 11, 11, 13 };
            Console.WriteLine("removing duplicates for: ");
            Utilities.PrintArray(a);
            Console.WriteLine("expected: {2,3,5,7,11,13,0,0,0}");
            Console.WriteLine($"no of valid entries = {Arrays.RemoveDuplicates2(a)}"); 
            Utilities.PrintArray(a);
        }
    }
}
