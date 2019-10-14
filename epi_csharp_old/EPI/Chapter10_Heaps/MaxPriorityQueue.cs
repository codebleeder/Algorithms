using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter10_Heaps
{
    public class MaxPriorityQueue<T> : PriorityQueue<T> where T : IComparable<T>
    {
        //private List<T> Data { get; set; }
        //public int Count
        //{
        //    get
        //    {
        //        return Data.Count >= 2 ? Data.Count - 1 : 0;
        //    }
        //}
        public MaxPriorityQueue()
        {
            Data = new List<T>();
        }
        public override List<T> GetData()
        {
            return Data.GetRange(1, Data.Count - 1);
        }
        public override void Enqueue(T item)
        {
            if (Data.Count == 0)
            {
                Data.Add(item); // add a dummy item at the beginning; List starts from index 1
            }
            Data.Add(item);
            Swim(Data.Count - 1);
        }
        public override T Dequeue()
        {
            var keyMax = Data[1];
            Data[1] = Data[Data.Count - 1];
            Data.RemoveAt(Data.Count - 1);
            Sink(1);
            return keyMax;
        }
        private bool Less(int i, int j)
        {
            if (i > j && i >= Data.Count)
            {
                return true;
            }
            if (j > i && j >= Data.Count)
            {
                return false;
            }
            return Data[i].CompareTo(Data[j]) < 0;
        }
        private void Exchange(int i, int j)
        {
            var temp = Data[i];
            Data[i] = Data[j];
            Data[j] = temp;
        }
        private void Swim(int k)
        {
            while (k > 1 && Less(k / 2, k))
            {
                Exchange(k / 2, k);
                k = k / 2;
            }
        }
        private void Sink(int k)
        {
            while (2 * k < Data.Count)
            {
                // get greater from 2 children: 2k and 2k+1 
                var j = 2 * k < Data.Count && Less(2 * k, 2 * k + 1) ? 2 * k + 1 : 2 * k;
                if (!Less(k, j))
                {
                    break;
                }
                Exchange(k, j);
                k = j;
            }
        }
    }
}
