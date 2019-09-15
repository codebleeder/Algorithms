using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter6_Strings
{
    public static class Strings_04_ReplaceAndRemove
    {
        public static int ReplaceAndRemove(char[] s, int size)
        {
            // first pass - remove b's and count a's
            var iWrite = 0;
            var aCount = 0;
            for(var i = 0; i < size; i++)
            {
                if (s[i] != 'b')
                {
                    s[iWrite] = s[i];
                    iWrite += 1;
                }
                if (s[i] == 'a')
                {
                    aCount += 1;
                }
            }

            // second pass from back 
            var resultCount = iWrite + aCount;
            var j = iWrite - 1;
            iWrite = resultCount - 1;
            
            while(j >= 0)
            {
                if(s[j] != 'a')
                {
                    s[iWrite] = s[j];
                }
                else
                {
                    s[iWrite] = 'd';
                    s[iWrite - 1] = 'd';
                    iWrite -= 1;
                }
                iWrite -= 1;
                j -= 1;
            }
            return resultCount; 
        }
        public static void Test()
        {
            var tests = new List<Tuple<char[], int>>();
            tests.Add(
                new Tuple<char[], int>(
                    new char[] {'b', 'b', 'b', 'a', 'b', 'c', 'd', 'd', 'c', 'e', 't'},
                    7
                    )
                );
            tests.Add(
                new Tuple<char[], int>(
                    new char[] { 'b', 'c', 'a', 'd', 'a', 'c', 'a', 'b', 'a', 'c', 'c', 'd', 'c'},
                    9
                    )
                );
            var expected = new List<Tuple<char[], int>>();
            expected.Add(
                new Tuple<char[], int>(
                    new char[] {'d', 'd', 'c', 'd'},
                    4
                    )
                );
            expected.Add(
                new Tuple<char[], int>(
                    new char[] { 'c', 'd', 'd', 'd', 'd', 'd', 'c', 'd', 'd', 'd', 'd' },
                    11
                    )
                );
            for(var i = 0; i < tests.Count; i++)
            {
                Console.WriteLine($"----------test {i}-----------------------------");
                Console.WriteLine($"count given: {tests[i].Item2}   original array:");
                Utilities.PrintArray(tests[i].Item1);
                var result = ReplaceAndRemove(tests[i].Item1, tests[i].Item2);
                var resultMismatch = false;
               
                if (result != expected[i].Item2)
                {
                    Console.WriteLine($"length mismatch: expected: {expected[i].Item2}    result: {result}");
                    resultMismatch = true; 
                }
                else
                {
                    Console.WriteLine("lengths match. Now testing arrays");
                    for (var j = 0; j < result; j++)
                    {
                        if ((tests[i].Item1)[j] != expected[i].Item1[j])
                        {
                            
                            Console.WriteLine($"element {j} mismatch");
                            resultMismatch = true; 
                            break;
                        }
                    }
                }
                if (resultMismatch)
                {
                    
                    Console.WriteLine($"expected: ");
                    Utilities.PrintArray(expected[i].Item1);
                    Console.WriteLine("result: ");
                    Utilities.PrintArray(tests[i].Item1);
                }
            }
        }
    }
}
