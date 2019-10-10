using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter5_Arrays
{
    public static class Arrays_16_NonUniformRandomNumberGeneration
    {
        public static int NonUniformRandomNumberGeneration(List<int> values, List<double> probabilities)
        {
            var prefixSumOfProbabilities = new List<double>();
            prefixSumOfProbabilities.Add(0.0);
            foreach(var prob in probabilities)
            {
                var lastEntry = prefixSumOfProbabilities[prefixSumOfProbabilities.Count - 1];
                prefixSumOfProbabilities.Add(lastEntry + prob);
            }
            var random = new Random();
            var randomNum = random.NextDouble();
            var index = prefixSumOfProbabilities.BinarySearch(randomNum);
            if(index < 0)
            {
                index = (Math.Abs(index) - 1) - 1;               
            }
            return values[index];
            
        }
        public static void TestNonUniformRandomNumberGeneration()
        {
            var values = new List<int> { 3, 5, 7, 11 };
            var probabilities = new List<double> { 0.5, 0.33, 0.111, 0.056 };
            for(var i=0; i<20; i++)
            {
                var x = NonUniformRandomNumberGeneration(values, probabilities);
                Console.WriteLine($"value generated: {x}");
            }            
        }
    }
}
