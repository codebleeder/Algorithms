using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EPI.Chapter12_HashTables;

namespace EPI.Chapter12_HashTables
{
    public static class HashTables_08_FindSmallestSequentiallyCoveringSubset
    {
        public static Subarray FindSmallestSequentiallyCoveringSubset(List<string> paragraph, List<string> keywords)
        {
            var keywordsQueue = FillQueue(keywords);
            var start = 0;
            var end = 0;
            Subarray res = null;
            while (end < paragraph.Count && start <= end)
            {
                // move start to first keyword
                var firstKeyword = keywordsQueue.Dequeue();
                while (start < paragraph.Count && paragraph[start] != firstKeyword)
                {
                    start++;
                }
                // move end until all keywords are covered in sequence
                end = start + 1;
                while (end < paragraph.Count && keywordsQueue.Count > 0)
                {
                    var keyword = keywordsQueue.Peek();
                    if (paragraph[end] == keyword)
                    {
                        keywordsQueue.Dequeue();
                    }
                    if (keywordsQueue.Count > 0)
                    {
                        end++;
                    }
                }
                if (res == null)
                {
                    res = new Subarray(start, end);
                }
                else if (end - start < res.Length() && keywordsQueue.Count == 0)
                {                    
                    res.Start = start;
                    res.End = end;                    
                }
                // next iteration 
                keywordsQueue = FillQueue(keywords);
                start += 1;                
            }
            return res;
        }
        public static Queue<string> FillQueue(List<string> keywords)
        {
            var res = new Queue<string>();
            foreach(var k in keywords)
            {
                res.Enqueue(k);
            }
            return res;
        }
        public static void Test()
        {
            var paragraph = @"my paramount object in this struggle is to save the union and is not either to save or to destroy slavery if i could save the union without freeing any slave i would do it and if i could save it by freeing all the slaves i would do it and if i could save it by freeing some and leaving others alone i would also do it";
            var keywords = new List<string> { "union", "save" };
            var res = FindSmallestSequentiallyCoveringSubset(paragraph.Split().ToList(), keywords);
            Console.WriteLine(res.ToString());
        }
    }
}
