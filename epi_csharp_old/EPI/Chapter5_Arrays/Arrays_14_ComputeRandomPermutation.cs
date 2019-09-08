using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter5_Arrays
{
    public static class Arrays_14_ComputeRandomPermutation
    {
        // design an algorithm that creates uniformly random permutations of 
        // {0, 1..., n-1}. You are given a random number generator that returns
        // integers in the set {0,1,..,n-1} with equal probability; Use
        // as few calls to it as possible 
        public static List<int> ComputeRandomPermutation(int n)
        {
            var result = new List<int>();
            for(var i = 0; i < n; i++)
            {
                result.Add(i);
            }
            return Arrays_12_RandomSampling.RandomSampling(result, n);
        }
        public static void TestComputeRandomPermutation()
        {
            Console.WriteLine("generating random permutation for n = 5: ");
            Utilities.PrintList(ComputeRandomPermutation(5));
        }
    }
}
