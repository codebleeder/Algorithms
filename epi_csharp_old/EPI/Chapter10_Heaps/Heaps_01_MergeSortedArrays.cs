using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter10_Heaps
{
    public static class Heaps_01_MergeSortedArrays
    {
        public static List<int> MergeSortedArrays(List<List<int>> sortedArrays)
        {
            var minPQ = new MinPriorityQueue<int>();
            var res = new List<int>();
            while(sortedArrays.Count > 0)
            {
                // read first entries of each list and put in minPQ
                for (var i = 0; i < sortedArrays.Count; i++)
                {
                    if (sortedArrays[i].Count > 0)
                    {
                        minPQ.Enqueue(sortedArrays[i][0]);
                        sortedArrays[i].RemoveAt(0);
                    }
                }
                // remove any empty lists 
                var j = 0;
                while (j < sortedArrays.Count)
                {
                    if (sortedArrays[j].Count == 0)
                    {
                        sortedArrays.RemoveAt(j);
                    }
                    else
                    {
                        j++;
                    }
                }                
            }
            // dequeue from minPQ and add to res
            while (minPQ.Count > 0)
            {
                res.Add(minPQ.Dequeue());
            }
            return res;
        }
        // book solution: 
        public static List<int> MergeSortedArrays2(List<List<int>> sortedArrays)
        {
            var iters = new List<IEnumerator<int>>();
            for(var i = 0; i < sortedArrays.Count; i++)
            {
                iters.Add(sortedArrays[i].GetEnumerator());
            }
            var minPQ = new MinPriorityQueue<ArrayEntry>();
            for (var i = 0; i < iters.Count; i++)
            {
                var iter = iters[i];
                if(iter.MoveNext())
                {
                    minPQ.Enqueue(new ArrayEntry(iter.Current, i));
                }                
            }
            var res = new List<int>();
            while (minPQ.Count > 0)
            {
                var headEntry = minPQ.Dequeue();
                res.Add(headEntry.Value);
                var iter = iters[headEntry.Id];
                if (iter.MoveNext())
                {
                    minPQ.Enqueue(new ArrayEntry(iter.Current, headEntry.Id));
                }
            }
            return res;
        }
        public static void Test()
        {
            var sortedArr = new List<List<int>>
            {
                new List<int>{1000, 2000},
                new List<int>{1, 2, 3, 4},
                new List<int>{100, 200, 300, 400 },
                new List<int>{10, 20, 30, 40 },
                
                
            };
            var res = MergeSortedArrays2(sortedArr);
            Utilities.PrintList(res);
        }
    }
    public class ArrayEntry: IComparable<ArrayEntry>
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public ArrayEntry(int value, int id)
        {
            Value = value;
            Id = id;
        }
        public int CompareTo(ArrayEntry arrayEntry)
        {
            return this.Value.CompareTo(arrayEntry.Value);
        }
    }
}
