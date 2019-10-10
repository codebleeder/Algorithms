using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter6_Strings
{
    public static class Strings_11_SnakeString
    {
        public static string SnakeString(string s)
        {
            var sb = new StringBuilder();           
            for (var i = 1; i < s.Length; i += 4)
            {
                sb.Append(s[i]);
            }
            for (var i = 0; i < s.Length; i += 2)
            {
                sb.Append(s[i]);
            }
            for (var i = 3; i < s.Length; i += 4)
            {
                sb.Append(s[i]);
            }
            return sb.ToString();
        }
        public static void Test()
        {
            var res = SnakeString("hello world");
            var expected = "e lhlowrdlo";
            Console.WriteLine($"result: {res}  expected: {expected}");
        }
    }
    
}
