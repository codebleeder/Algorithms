using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter6_Strings
{
    public static class Strings_00_Palindrome
    {
        public static bool IsPalindrome(string s)
        {
            var j = s.Length - 1; 
            for(var i = 0; i < j; i++)
            {
                if(s[i] != s[j])
                {
                    return false; 
                }
                j -= 1; 
            }
            return true; 
        }
        public static void Test()
        {
            var s1 = "abccba";
            Console.WriteLine($"testing even-length palindrome: {s1}");
            Console.WriteLine($"expected: true  result: {IsPalindrome(s1)}");

            var s2 = "abcdcba";
            Console.WriteLine($"testing odd-length palindrome: {s2}");
            Console.WriteLine($"expected: true  result: {IsPalindrome(s2)}");

            var s3 = "arcdcba";
            Console.WriteLine($"testing non palindrome: {s3}");
            Console.WriteLine($"expected: false  result: {IsPalindrome(s3)}");
        }
    }
}
