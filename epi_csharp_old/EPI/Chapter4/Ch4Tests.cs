using System;
using System.Collections.Generic;
using System.Text;
using EPI.Chapter4;

namespace EPI.Chapter4
{
    public static class Ch4Tests
    {
        public static void TestParity()
        {
            System.Console.WriteLine("parity 4 = " + Ch4_primitive_types.Parity(4));
            System.Console.WriteLine("parity 5 = " + Ch4_primitive_types.Parity(5));
        }
        public static void TestParity2()
        {
            System.Console.WriteLine("parity 4 = " + Ch4_primitive_types.Parity2(4));
            System.Console.WriteLine("parity 5 = " + Ch4_primitive_types.Parity2(5));
        }
        public static void TestParity3()
        {
            var res = Ch4_primitive_types.Parity3(10000); // 0010 0111 0001 0000
            Console.WriteLine($"expected parity of 10000 = 1    result = {res}");
            res = Ch4_primitive_types.Parity3(10001); // 0010 0111 0001 0001
            Console.WriteLine($"expected parity of 10001 = 0    result = {res}");
        }
        public static void TestParity4()
        {
            var res = Ch4_primitive_types.Parity4(10000);
            Console.WriteLine($"expected parity of 10000 = 1    result = {res}");
            res = Ch4_primitive_types.Parity4(10001);
            Console.WriteLine($"expected parity of 10001 = 0    result = {res}");
        }

        public static void TestFlipBits()
        {
            var res1 = Ch4_primitive_types.SwapBits(12, 2, 0);
            Console.WriteLine($"Flipping bits 0 & 2 for 12 = 9    result = {res1}");
            var res2 = Ch4_primitive_types.SwapBits(12, 2, 3);
            Console.WriteLine($"Flipping bits 3 & 2 for 12 = 12    result = {res2}");
        }
        public static void TestReverseBits()
        {
            var res = Ch4_primitive_types.ReverseBits(10000);
            Console.WriteLine($"Reversing 10k. Expected = 2276     Result = {res}");
        }
        public static void TestClosestSameBitCount()
        {
            var res = Ch4_primitive_types.ClosestSameBitCount(4);
            Console.WriteLine($"Closest number with same weight as 4: Expected=2    Result={res}");
            res = Ch4_primitive_types.ClosestSameBitCount(11);
            Console.WriteLine($"Closest number with same weight as 11: Expected=13    Result={res}");
        }
        public static void TestAdd()
        {
            var res = Ch4_primitive_types.Add(2, 3);
            Console.WriteLine($"sum of 2 and 3: expected = 5    result = {res}");
            res = Ch4_primitive_types.Add(1937, 647533);
            Console.WriteLine($"sum of 1937 and 647533: expected = {647533+1937}    result = {res}");
        }
        public static void TestMultiply()
        {
            var res = Ch4_primitive_types.Multiply(2, 3);
            Console.WriteLine($"multiply 2 by 3: expected = {2*3}    result = {res}");
            Console.WriteLine($"multiply 34 by 89: expected = {34 * 89}    result = {Ch4_primitive_types.Multiply(34, 89)}");
        }
        public static void TestDivide()
        {
            Console.WriteLine($"divide 21 by 7: expected = {21/7}    result = {Ch4_primitive_types.Divide(21, 7)}");
            Console.WriteLine($"divide 121 by 11: expected = {121 / 11}    result = {Ch4_primitive_types.Divide(121, 11)}");
        }
        public static void TestPower()
        {
            Console.WriteLine($"1.1 raised to 10 is: expected = {Math.Pow(1.1, 10)}    result={Ch4_primitive_types.Power(1.1, 10)}");
        }
        public static void TestReverseDigits()
        {
            Console.WriteLine($"Reverse 123: expected = 321    result = {Ch4_primitive_types.ReverseDigits(123)}");
            Console.WriteLine($"Reverse 1237: expected = 7321    result = {Ch4_primitive_types.ReverseDigits(1237)}");
        }
        public static void TestIsPalindromeNumber()
        {
            Console.WriteLine($"Testing 100: expected = False    result = {Ch4_primitive_types.IsPalindromeNumber(100)}");
            Console.WriteLine($"Testing 121: expected = True    result = {Ch4_primitive_types.IsPalindromeNumber(121)}");
            Console.WriteLine($"Testing 123321: expected = True    result = {Ch4_primitive_types.IsPalindromeNumber(123321)}");
        }
        public static void TestUniformRandom()
        {
            Console.WriteLine($"{Ch4_primitive_types.UniformRandom(1, 6)}");
        }
        public static void TestIntersectRectangle()
        {
            var r1 = new Rectangle(1, 1, 4, 2);
            Console.WriteLine($"Rectangle1: {r1.ToString()}");
            var r2 = new Rectangle(3, 0, 1, 4);
            Console.WriteLine($"Rectangle2: {r2.ToString()}");
            var intersectRect = Ch4_primitive_types.IntersectRectangle(r1, r2);
            var expectedIntersect = new Rectangle(3, 1, 1, 2);
            Console.WriteLine($"Intersected rectangle: expected: {expectedIntersect.ToString()}    result: {intersectRect.ToString()}");

            r2 = new Rectangle(7, 1, 3, 5);
            intersectRect = Ch4_primitive_types.IntersectRectangle(r1, r2);
            expectedIntersect = new Rectangle(0, 0, -1, -1);
            Console.WriteLine($"Intersected rectangle: expected: {expectedIntersect.ToString()}    result: {intersectRect.ToString()}");
        }
    }
}
