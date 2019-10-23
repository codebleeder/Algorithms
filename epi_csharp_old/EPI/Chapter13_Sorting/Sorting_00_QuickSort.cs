using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter13_Sorting
{
    public static class Sorting_00_QuickSort
    {

        public static void QuickSort(List<int> arr, int low, int high)
        {
            if (low < high)
            {
                var pi = Partition(arr, low, high);
                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        }
        public static void QuickSortHoare(List<int> arr, int low, int high)
        {
            if (low < high)
            {
                var pi = Partition4(arr, low, high);
                QuickSort(arr, low, pi);
                QuickSort(arr, pi + 1, high);
            }
        }
        // pivot is at high index
        private static int Partition(List<int> arr, int low, int high)
        {
            var pivot = arr[high];
            var iSorted = low;
            for(var i = low; i < high; i++)
            {
                if(arr[i] < pivot)
                {                    
                    Utilities.Swap(arr, iSorted, i);
                    iSorted++;
                }
            }
            Utilities.Swap(arr, high, iSorted);
            return iSorted;
        }
        
        // pivot is at low index
        private static int Partition2(List<int> arr, int low, int high)
        {
            var pivot = arr[low];
            var iSorted = high + 1;
            for (var i = high; i > low; i--)
            {
                if (arr[i] > pivot)
                {
                    iSorted--;
                    Utilities.Swap(arr, iSorted, i);
                }
            }
            Utilities.Swap(arr, low, iSorted - 1);
            return iSorted - 1;
        }
        
        // pivot is chosen randomly; Lomuto partitioning 
        private static int Partition3(List<int> arr, int low, int high)
        {
            var random = new Random();
            var randomPivotIndex = random.Next(low, high);
            Utilities.Swap(arr, randomPivotIndex, high);
            return Partition(arr, low, high);
        }
        // Hoare partitioning
        private static int Partition4(List<int> arr, int low, int high)
        {
            var random = new Random();
            var randomPivotIndex = random.Next(low, high);
            Utilities.Swap(arr, randomPivotIndex, low);
            return Partition5(arr, low, high);
        }
        private static int Partition5(List<int> arr, int low, int high)
        {
            var pivot = arr[low];
            var left = low - 1;
            var right = high + 1;
            while (true)
            {
                do
                {
                    left++;
                }
                while (pivot > arr[left]);
                do
                {
                    right--;
                }
                while (pivot < arr[right]);
                if (left >= right)
                {
                    return right;
                }
                Utilities.Swap(arr, left, right);
            }
        }
        public static void Test()
        {
            var arr = new List<int> { 2, 9, 3, 7, 5, 8 };
            QuickSort(arr, 0, arr.Count - 1);
            Utilities.PrintList(arr);
        }
    }
}
