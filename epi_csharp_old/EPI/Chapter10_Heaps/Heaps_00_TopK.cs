using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EPI.Chapter10_Heaps
{
    public static class Heaps_00_TopK
    {
        public class StreamString : IComparable<StreamString>
        {
            public string S { get; set; }
            public StreamString(string s)
            {
                S = s;
            }
            public int CompareTo(StreamString other)
            {
                return S.Length.CompareTo(other.S.Length);
            }
        }
        public static List<string> TopK(int k, IEnumerator<string> iter)
        {
            var minPQ = new MinPriorityQueue<StreamString>();
            while (iter.MoveNext())
            {
                var streamString = new StreamString(iter.Current);
                minPQ.Enqueue(streamString);
                if (minPQ.Count > k)
                {
                    minPQ.Dequeue();
                }
            }
            return minPQ.GetData().Select(x => x.S).ToList<string>();
        }
        public static void Test()
        {
            var lengths = new List<int> { 4, 7, 13, 1, 10, 12, 3, 8 };
            var stream = new List<string>
            {
                "xafa", // 4
                "asdfafa", // 7
                "aaaaaaaaaaaaa", // 
                "b",
                "jfjjfjfjfj",
                "uuuuuuuururu",
                "afd",
                "aflasfls"
            };
            var iter = stream.GetEnumerator();
            var res = TopK(4, iter);
            Utilities.PrintList(res);
        }
    }
}
