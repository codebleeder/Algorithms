using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter11_Searching
{
    public class Searching_07_FindMinMax
    {
        public static Tuple<int, int> FindMinMax(List<int> arr)
        {
            if(arr.Count < 2)
            {
                return null;
            }
            var min = Math.Min(arr[0], arr[1]);
            var max = Math.Max(arr[0], arr[1]);
            for (var i = 2; i < arr.Count; i++)
            {
                var val = arr[i];
                if (val > max)
                {
                    max = val;
                }
                else if (val < min)
                {
                    min = val;
                }
            }
            return new Tuple<int, int>(min, max);
        }
        public static void Test()
        {
            var arr = new List<int> { 3, 2, 5, 1, 2, 4 };
            var res = FindMinMax(arr);
            Utilities.PrintList(arr);
            Console.WriteLine($"min: {res.Item1}  max: {res.Item2}");
        }
    }
}
