using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter6_Strings
{
    public static class Strings_10_GetValidIPAddress
    {
        // assuming length of input is equal to or greater than 4 
        public static List<string> GetValidIPAddress(string s)
        {
            var result = new List<string>();
            for (var i1 = 0; i1 < s.Length && i1 < 3; i1++)
            {
                var res1 = s.Substring(0, i1 + 1);
                if (IsValid(res1))
                {
                    for (var i2 = i1 + 1; i2 < s.Length && i2 <= i1 + 3; i2++)
                    {
                        var res2 = s.Substring(i1+1, i2 - i1);
                        if (IsValid(res2))
                        {
                            for (var i3 = i2 + 1; i3 < s.Length && i3 <= i2 + 3; i3++)
                            {
                                var res3 = s.Substring(i2 + 1, i3 - i2);
                                var res4 = s.Substring(i3 + 1);
                                if (IsValid(res3) && IsValid(res4))
                                {
                                    result.Add($"{res1}.{res2}.{res3}.{res4}");
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }
        public static bool IsValid(string s)
        {
            if (s.Length == 0)
            {
                return false;
            }
            if (s.Length > 3)
            {
                return false; 
            }
            if (s.StartsWith("0") && s.Length > 1)
            {
                return false; 
            }
            var val = int.Parse(s);
            return val <= 255 && val > 0;
        }
        public static void Test()
        {
            var tests = new List<string>
            {
                "19216811", "1234"
            };
            foreach(var test in tests)
            {
                var result = GetValidIPAddress(test);
                Console.WriteLine($"valid IP addresses for {test} are: (total {result.Count})");
                Utilities.PrintList(result);
            }
        }
    }
}
