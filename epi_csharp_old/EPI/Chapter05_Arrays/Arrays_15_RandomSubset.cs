using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter5_Arrays
{
    public static class Arrays_15_RandomSubset
    {
        public static List<int> RandomSubset(int n, int k)
        {
            var random = new Random();
            var changedElements = new Dictionary<int, int>();

            for(var i = 0; i < n; i++)
            {
                var randomIndex = random.Next(i, n);
                var containsI = changedElements.ContainsKey(i);
                var containsRandomIndex = changedElements.ContainsKey(randomIndex);
                if(!containsI && !containsRandomIndex)
                {
                    changedElements[i] = randomIndex;
                    changedElements[randomIndex] = i; 
                }
                else if (!containsI && containsRandomIndex)
                {
                    changedElements[i] = changedElements[randomIndex];
                    changedElements[randomIndex] = i;
                }
                else if (containsI && !containsRandomIndex)
                {
                    changedElements[randomIndex] = changedElements[i];
                    changedElements[i] = randomIndex;
                }
                else 
                {
                    var temp = changedElements[randomIndex];
                    changedElements[randomIndex] = changedElements[i];
                    changedElements[i] = temp; 
                }
            }
            var result = new List<int>();
            for(var i = 0; i < k; i++)
            {
                result.Add(changedElements[i]);
            }
            return result;
        }
        public static void TestRandomSubset()
        {
            Console.WriteLine("random subset for n = 100, k = 5");
            for(var i = 0; i < 5; i++)
            {
                Utilities.PrintList(RandomSubset(100, 5));
            }            
        }
    }
}
