using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace EPI.Chapter12_HashTables
{
    public static class HashTables_03_LRUCache
    {
        public static void Test()
        {
            
            const int CAPACITY = 2;
            LRUCache c = new LRUCache(CAPACITY);
            Console.WriteLine("c.Insert(1, 1)");
            c.Insert(1, 1);
           Console.WriteLine("c.Insert(1, 10)");
            c.Insert(1, 10);
            Console.WriteLine("c.Lookup(2, val)");
            Assert(null == c.Lookup(2));
            Console.WriteLine("c.Lookup(1, val)");
            Assert(c.Lookup(1) == 1);
            c.Erase(1);
            Assert(null == c.Lookup(1));


            // test capacity constraints honored, also FIFO ordering
            Console.WriteLine();
            Console.WriteLine("test capacity constraints honored, also FIFO ordering");
            c = new LRUCache(CAPACITY);
            c.Insert(1, 1);
            c.Insert(2, 1);
            c.Insert(3, 1);
            c.Insert(4, 1);
            Assert(null == c.Lookup(1));
            Assert(null == c.Lookup(2));
            Assert(1 == c.Lookup(3));
            Assert(1 == c.Lookup(4));

            // test retrieval moves to front
            Console.WriteLine();
            Console.WriteLine("test retrieval moves to front");
            c = new LRUCache(CAPACITY);
            c.Insert(1, 1);
            c.Insert(2, 1);
            c.Insert(3, 1);
            c.Lookup(2);
            c.Insert(4, 1);
            Assert(null == c.Lookup(1));
            Assert(1 == c.Lookup(2));
            Assert(null == c.Lookup(3));
            Assert(1 == c.Lookup(4));

            // test update moves to front
            Console.WriteLine();
            Console.WriteLine("test update moves to front");
            c = new LRUCache(CAPACITY);
            c.Insert(1, 1);
            c.Insert(2, 1);
            c.Insert(3, 1);
            c.Insert(2, 2);
            c.Insert(4, 1);
            Assert(null == c.Lookup(1));
            Assert(1 == c.Lookup(2));
            Assert(null == c.Lookup(3));
            Assert(1 == c.Lookup(4));

            // test erase
            Console.WriteLine();
            Console.WriteLine("test erase");
            c = new LRUCache(CAPACITY);
            c.Insert(1, 1);
            c.Insert(2, 1);
            c.Erase(2);
            c.Insert(3, 3);
            Assert(1 == c.Lookup(1));
            Assert(null == c.Lookup(2));
            Assert(3 == c.Lookup(3));
        }

        private static void Assert(bool v)
        {
            var res = v == true ? "pass" : "fail";
            Console.WriteLine(res);
        }
    }
    public class LRUCache
    {
        public OrderedDictionary IsbnToPrice { get; set; }
        public int Capacity { get; private set; }
        public LRUCache(int capacity)
        {
            IsbnToPrice = new OrderedDictionary(capacity);
            Capacity = capacity;
        }
        public int? Lookup(int key)
        {
            var keyStr = key.ToString();
            if(!IsbnToPrice.Contains(keyStr))
            {
                return null;
            }
            var res = (int)IsbnToPrice[keyStr];
            // move it to the first index 
            IsbnToPrice.Remove(keyStr);
            IsbnToPrice.Insert(0, keyStr, res);            
            return res;
        }
        public void Insert(int key, int val)
        {
            // only add new values. No updating existing values
            if (!IsbnToPrice.Contains(key.ToString()))
            {
                if (IsbnToPrice.Count == Capacity)
                {
                    IsbnToPrice.RemoveAt(IsbnToPrice.Count - 1);
                }
                IsbnToPrice.Insert(0, key.ToString(), val);
            }
            else
            {
                // if it exists, move it to top i.e., at index 0
                var oldVal = IsbnToPrice[key.ToString()];
                IsbnToPrice.Remove(key.ToString());
                IsbnToPrice.Insert(0, key.ToString(), oldVal);
            }
        }
        public bool Erase(int key)
        {
            var keyStr = key.ToString();
            if(IsbnToPrice.Contains(keyStr))
            {
                IsbnToPrice.Remove(keyStr);
                return true;
            }
            return false;
        }
    }
}
