using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter5_Arrays
{
    public static class Arrays_13_OnlineRandomSample
    {
        // design a program that takes as input a size k, and reads packets, continuously
        // maintaining a uniform random subset of size k of the read packets 
        public static List<int> OnlineRandomSample(List<int> sequence, int k)
        {
            var sampleResult = new List<int>();
            for(var i=0; i<k; i++)
            {
                sampleResult.Add(sequence[i]);
            }
            var random = new Random();
            var upperLimit = k+1;            
            for(var i = k; i < sequence.Count; i++)
            {
                upperLimit++;
                var indexToReplace = random.Next(upperLimit);
                if (indexToReplace < k)
                {
                    sampleResult[indexToReplace] = sequence[i];
                }
            }            
            return sampleResult;
        }
        public static void TestOnlineRandomSample()
        {
            var seq = new List<int> { 1, 3, 34, 56, 32, 86, 64 };
            Console.WriteLine("sequence: ");
            Utilities.PrintList(seq);
            Console.WriteLine("sample result for k = 2: ");
            Utilities.PrintList(OnlineRandomSample(seq, 2));
            Console.WriteLine("sample result for k = 4: ");
            Utilities.PrintList(OnlineRandomSample(seq, 4));
        }
    }
}
