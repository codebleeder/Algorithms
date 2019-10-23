using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter11_Searching
{
    public static class Searching_09_FindMissingElement
    {
        private const int NUM_BUCKET = 1 << 16; // 2^16
        public static int FindMissingElement(List<int> sequence)
        {
            var counter = new int[NUM_BUCKET];
            foreach(var v in sequence)
            {
                var index = v >> 16;
                counter[index]++;
            }
            for(var i = 0; i < counter.Length; i++)
            {
                if(counter[i] < NUM_BUCKET)
                {
                    var bitArr = new BitArray(NUM_BUCKET);
                    foreach(var v in sequence)
                    {
                        if (i == (v >> 16))
                        {
                            bitArr.Set((NUM_BUCKET - 1) & v, true);
                        }
                    }
                    for (var j = 0; j < NUM_BUCKET; j++)
                    {
                        if (bitArr[j] == false)
                        {
                            return (i << 16) | j;
                        }
                    }
                }
            }
            return -1;
        }
        
        public static void Test()
        {
            var smallList = new List<int> { 213, 2342, 1123, 1321, 5464, 2322, 0 };
            var res = FindMissingElement(smallList);
            Console.WriteLine(res);
        }
    }
}
