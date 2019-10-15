using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter10_Heaps
{
    public class Heaps_02_SortIncreasingDecreasingArray
    {
        private enum Mode { INCREASING, DECREASING };
        public static List<int> SortIncreasingDecreasingArray(List<int> increasingDecreasingArr)
        {
            var sortedLists = new List<List<int>>();                        
            var startIndex = 0;
            
            var i = startIndex;
            var currMode = Mode.INCREASING;
            while (i < increasingDecreasingArr.Count)
            {
                if (startIndex != i && increasingDecreasingArr[i] < increasingDecreasingArr[i-1])
                {
                    // decreasing
                    if (currMode == Mode.INCREASING)
                    {
                        sortedLists.Add(increasingDecreasingArr.GetRange(startIndex, i - startIndex));
                        startIndex = i;
                        currMode = Mode.DECREASING;
                    }
                }
                else if (startIndex != i && increasingDecreasingArr[i] > increasingDecreasingArr[i-1])
                {
                    // increasing
                    if (currMode == Mode.DECREASING)
                    {
                        Reverse(startIndex, i - 1, increasingDecreasingArr);
                        sortedLists.Add(increasingDecreasingArr.GetRange(startIndex, i - startIndex));
                        startIndex = i;
                        currMode = Mode.INCREASING;
                    }
                }
                i++;
            }
            if (currMode == Mode.DECREASING)
            {
                Reverse(startIndex, i - 1, increasingDecreasingArr);                
            }            
            sortedLists.Add(increasingDecreasingArr.GetRange(startIndex, i - startIndex));
            return Heaps_01_MergeSortedArrays.MergeSortedArrays2(sortedLists);
        }
        public static void Reverse(int start, int end, List<int> arr)
        {
            var i = start;
            var j = end;
            while (i < j)
            {
                Exchange(i, j, arr);
                i++;
                j--;
            }
        }
        public static void Exchange(int i, int j, List<int> arr)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        // book solution: 
        public static List<int> SortIncreasingDecreasingArray2(List<int> arr)
        {
            var sortedSubarrays = new List<List<int>>();
            var mode = Mode.INCREASING;
            var startIndex = 0;
            for (var i = 1; i <= arr.Count; ++i)
            {
                if(i == arr.Count || 
                    arr[i-1] < arr[i] && mode == Mode.DECREASING ||
                    arr[i-1] > arr[i] && mode == Mode.INCREASING)
                {
                    var subList = arr.GetRange(startIndex, i-startIndex);
                    if (mode == Mode.DECREASING)
                    {
                        Reverse(0, subList.Count-1, subList);
                    }
                    sortedSubarrays.Add(subList);
                    startIndex = i;
                    mode = mode == Mode.INCREASING ? Mode.DECREASING : Mode.INCREASING;
                }
            }
            return Heaps_01_MergeSortedArrays.MergeSortedArrays2(sortedSubarrays);
        }
        public static void Test()
        {
            var arr = new List<int> { 57, 131, 493, 294, 221, 339, 418, 452, 442, 190 };
            var res = SortIncreasingDecreasingArray2(arr);
            Utilities.PrintList(res);
        }
    }
}
