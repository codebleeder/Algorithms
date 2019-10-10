using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter5_Arrays
{
    public static class Arrays_12_RandomSampling
    {
        public static List<int> RandomSampling(List<int> x, int size)
        {            
            var rnd = new Random();
            for (var i = 0; i < size; i++)
            {
                var randomNum = rnd.Next(i, x.Count);
                Utilities.Swap(x, i, randomNum);
            }
            
            return x.GetRange(0, size);
        }
        public static void TestRandomSampling()
        {
            var x = new List<int> { 1, 3, 5, 6, 7, 8 };
            Console.WriteLine("getting random sampling of {1,3,5,6,7,8} size: 2");
            Utilities.PrintList(RandomSampling(x, 2));
            Console.WriteLine("getting random sampling of {1,3,5,6,7,8} size: 5");
            Utilities.PrintList(RandomSampling(x, 5));
            Console.WriteLine("getting random sampling of {1,3,5,6,7,8} size: 6");
            Utilities.PrintList(RandomSampling(x, 6));
        }
    }
}
