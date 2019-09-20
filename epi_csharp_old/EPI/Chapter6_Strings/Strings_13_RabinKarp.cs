using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter6_Strings
{
    public static class Strings_13_RabinKarp
    {
        public static int RabinKarp(string t, string s)
        {
            if (s.Length > t.Length)
            {
                return -1;
            }
            var hashT = 0;
            var hashS = 0;
            var res = -1;
            // calculate hash of s and first s.Length of t 
            for (var i = 0; i < s.Length; i++)
            {
                hashS = hashS * 10 + (s[i] + 0);
                hashT = hashT * 10 + (t[i] + 0);
            }

            // iterate thro' text and compare hash values
            for (var i = s.Length - 1; i < t.Length; i++)
            {
                if (i >= s.Length)
                {
                    // calculate new hashT
                    var valToRemove = (t[i - s.Length] + 0) * (Math.Pow(10, s.Length - 1));
                    var valToAdd = t[i] + 0;
                    hashT = ((hashT - (int)valToRemove) * 10) + valToAdd;
                }

                if (hashS == hashT)
                {
                    // check char by char 
                    var k = s.Length - 1;
                    var allAreIdentical = true;
                    for (var j = i; j > i - s.Length; j--)
                    {
                        if (s[k] != t[j])
                        {
                            allAreIdentical = false;
                            break;
                        }
                        k--;
                    }
                    if (allAreIdentical)
                    {
                        return i - s.Length + 1;
                    }
                }
            }
            return res;
        }
        public static void Test()
        {
            var text = "atgcgcgcttaagatccactg";
            var tests = new List<Tuple<string, int>>
            {
                new Tuple<string, int>("gctt", 6)
            };
            var i = 1;
            foreach (var test in tests)
            {
                var res = RabinKarp(text, test.Item1);
                var testRes = res == test.Item2 ? "pass" : "fail";
                Console.WriteLine($"test {i} search : {test.Item1}  expected: {test.Item2}  result: {res}  test result: {testRes}");
                i++;
            }
        }
    }
}
