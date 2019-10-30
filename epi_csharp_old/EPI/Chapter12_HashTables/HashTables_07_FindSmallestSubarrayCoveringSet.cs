using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPI.Chapter12_HashTables
{
    // This code is less complex than the code in the book
    public class HashTables_07_FindSmallestSubarrayCoveringSet
    {
        public static Subarray FindSmallestSubarrayCoveringSet(List<string> paragraph, HashSet<string> keywords)
        {
            var coveredKeywords = new HashSet<string>();
            var start = 0;
            var end = 0;
            var shortestSubarray = new Subarray(0, paragraph.Count - 1);

            while (end < paragraph.Count && start <= end)
            {
                // move the end until all keywords are covered
                MoveEndUntilAllCovered(paragraph, keywords, coveredKeywords, ref start, ref end);                
                // shorten the sub-array even further by moving start
                ShortenFromStart(paragraph, coveredKeywords, ref start, ref end);
                if(end - start < shortestSubarray.Length())
                {
                    shortestSubarray.Start = start;
                    shortestSubarray.End = end;
                }
                // next iteration
                keywords.Add(paragraph[start]);
                coveredKeywords.Remove(paragraph[start]);
                start++;
            }
            return shortestSubarray;
        }
        public static void MoveEndUntilAllCovered
            (
            List<string> paragraph, 
            HashSet<string> keywords, 
            HashSet<string> coveredKeywords,
            ref int start, 
            ref int end
            )
        {
            while (keywords.Count > 0 && end < paragraph.Count)
            {                
                var word = paragraph[end];
                if (keywords.Contains(word))
                {
                    coveredKeywords.Add(word);
                    keywords.Remove(word);
                }
                if (keywords.Count > 0)
                {
                    end++;
                }                
            }
        }
        public static void ShortenFromStart(List<string> paragraph, HashSet<string> covered, ref int start, ref int end)
        {
            while(start < end)
            {
                var word = paragraph[start];
                if (covered.Contains(word))
                {
                    break;  
                }
                start++;
            }
        }
        public static void Test()
        {
            var paragraph = "apple banana apple apple dog cat apple dog banana apple cat dog";
            var res = FindSmallestSubarrayCoveringSet(paragraph.Split().ToList(), new HashSet<string> { "banana", "cat" });
            Console.WriteLine(res.ToString());
        }
    }
    public class Subarray
    {
        public int Start { get; set; }
        public int End { get; set; }
        public Subarray(int start, int end)
        {
            Start = start;
            End = end;
        }
        public int Length()
        {
            return End - Start + 1;
        }
        public override string ToString()
        {
            return $"start: {Start}  end: {End}  length: {Length()}";
        }
    }
}
