using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter11_Searching
{
    public static class Searching_08_FindKthLargest
    {

        public static int FindKthLargest(List<int> arr, int k)
        {
            var left = 0;
            var right = arr.Count - 1;
            var r = new Random(0);
            while (left <= right)
            {
                var pivotIndex = r.Next(left, right);
                var newPivotIndex = PartitionAroundPivot(left, right, pivotIndex, arr);
                if (newPivotIndex == k - 1)
                {
                    return arr[newPivotIndex];
                }
                else if (newPivotIndex > k - 1)
                {
                    right = newPivotIndex - 1;
                }
                else
                {
                    left = newPivotIndex + 1;
                }
            }
            return -1;
        }

        private static int PartitionAroundPivot(int left, int right, int pivotIndex, List<int> arr)
        {
            var pivot = arr[pivotIndex];
            var newPivotIndex = left;
            Utilities.Swap(arr, pivotIndex, right);
            for (var i = left; i < right; i++)
            {
                if (arr[i] > pivot)
                {
                    Utilities.Swap(arr, i, newPivotIndex++);
                }
            }
            Utilities.Swap(arr, right, newPivotIndex);
            return newPivotIndex;
        }
        public static void Test()
        {
            var arr = new List<int> { 3, 2, 1, 5, 4 };
            var sortedByLargest = new List<int> { 5, 4, 3, 2, 1 };
            for (var i = 0; i < arr.Count; i++)
            {
                var res = FindKthLargest(arr, i+1);
                var expected = sortedByLargest[i];
                Console.WriteLine($"k: {i+1}  res: {res}  expected: {expected}");
            }
        }
    }
}
