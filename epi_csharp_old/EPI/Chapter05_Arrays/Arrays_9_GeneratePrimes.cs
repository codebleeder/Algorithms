using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter5_Arrays
{
    public static class Arrays_9_GeneratePrimes
    {
        public static List<int> GeneratePrimes(int n)
        {
            var primeTracker = new List<bool>();
            var result = new List<int>();
            for(var i=0; i<n+1; i++)
            {
                if(i==0 || i==1)
                {
                    primeTracker.Add(false);
                }
                else
                {
                    primeTracker.Add(true);
                }
            }
            for(var i=0; i<=n; i++)
            {
                if(primeTracker[i] == true)
                {
                    // add to result list 
                    result.Add(i);
                    // mark multiples of this number in primeTracker as false
                    var product = 0; 
                    for(var j=2; j*i<=n; j++)
                    {
                        primeTracker[i * j] = false;
                    }
                }
            }
            return result;
        }

        public static void TestGeneratePrimes()
        {
            Console.WriteLine("Generating primes till 50: ");
            Utilities.PrintList(GeneratePrimes(50));
        }
    }
}
