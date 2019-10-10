using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter6_Strings
{
    public static class Strings_05_IsPalindrome
    {
        public static bool IsPalindrome(string s)
        {
            var j = s.Length - 1;
            var i = 0; 
            while(i < j)
            {
                // get the next valid s[i]
                while(!Char.IsLetter(s[i]))
                {
                    i += 1;
                }
                // get the next valid s[j]
                while(!Char.IsLetter(s[j]))
                {
                    j -= 1;
                }
                // toLowerCase and compare
                if(!(Char.ToLower(s[i]) == Char.ToLower(s[j])))
                {
                    return false; 
                }
                i++;
                j--;
            }
            return true;            
        }
        public static void Test()
        {
            var tests = new List<Tuple<string, bool>>();
            tests.Add(new Tuple<string, bool>("A man, a plan, a canal, Panama", true));
            tests.Add(new Tuple<string, bool>("Able was I, ere I saw Elba!", true));
            tests.Add(new Tuple<string, bool>("Ray a Ray", false));
            var i = 1;
            foreach(var test in tests)
            {
                var res = IsPalindrome(test.Item1);
                if(test.Item2 != res)
                {
                    Console.WriteLine($"test {i} failed");
                    Console.WriteLine($"{test.Item1}  expected = {test.Item2} result = {res}");
                }
                else
                {
                    Console.WriteLine($"test {i} pass");
                    
                }
                i += 1;
            }
        }
    }
}
