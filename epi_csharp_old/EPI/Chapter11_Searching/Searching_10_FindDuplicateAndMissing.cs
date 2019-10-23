using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter11_Searching
{
    public static class Searching_10_FindDuplicateAndMissing
    {
        public static Tuple<int, int> FindDuplicateAndMissing(List<int> arr)
        {
            var missXorDup = 0;
            for(var i = 0; i < arr.Count; i++)
            {
                missXorDup ^= (i ^ arr[i]);
            }
            var differBit = missXorDup & (~(missXorDup - 1));
            var newMissXorDup = 0;
            for (var i = 0; i < arr.Count; i++)
            {
                if ((i & differBit) != 0)
                {
                    newMissXorDup ^= i;
                }
                if ((arr[i] & differBit) != 0)
                {
                    newMissXorDup ^= arr[i];
                }
            }
            for (var i = 0; i < arr.Count; i++)
            {
                if (newMissXorDup == arr[i])
                {
                    return new Tuple<int, int>(newMissXorDup, newMissXorDup ^ missXorDup);
                }
            }
            return new Tuple<int, int>(newMissXorDup ^ missXorDup, newMissXorDup);
        }
        public static void Test()
        {            
            var arr = new List<int> { 5, 3, 0, 3, 1, 2 };
            var res = FindDuplicateAndMissing(arr);
            Console.WriteLine($"duplicate: {res.Item1}  missing: {res.Item2}");
        }
    }
}
