using System;
using System.Collections.Generic;
using System.Text;
using EPI.Chapter10_Heaps;

namespace EPI.Chapter12_HashTables
{
    public static class HashTables_11_FindStudentWithHighestBestOfThreeScores
    {
        public static string FindStudentWithHighestBestOfThreeScores(List<Student> students)
        {
            var scores = new Dictionary<string, MinPriorityQueue<int>>();
            foreach(var s in students)
            {
                if (scores.ContainsKey(s.Name))
                {
                    var minHeap = scores[s.Name];
                    minHeap.Enqueue(s.Score);
                    if (minHeap.Count > 3)
                    {
                        minHeap.Dequeue();
                    }
                }
                else
                {
                    var newHeap = new MinPriorityQueue<int>();
                    newHeap.Enqueue(s.Score);
                    scores[s.Name] = newHeap;
                }
            }
            var highestSum = 0;
            var topStudent = "";
            foreach(var kv in scores)
            {
                var minHeap = kv.Value;
                // ignore students with fewer than 3 scores
                if (minHeap.Count > 2)
                {
                    var sum = AddNodes(minHeap);
                    if (highestSum < sum)
                    {
                        highestSum = sum;
                        topStudent = kv.Key;
                    }
                }                
            }
            return topStudent;
        }
        public static int AddNodes(MinPriorityQueue<int> minHeap)
        {
            var sum = 0;
            foreach (var n in minHeap.GetData())
            {
                sum += n;
            }
            return sum;
        }
        public static void Test()
        {
            var students = new List<Student>
            {
                new Student("a", 7),
                new Student("b", 6),
                new Student("c", 8),
                new Student("d", 9),
                new Student("a", 7),
                new Student("b", 6),
                new Student("c", 8),
                new Student("d", 9),
                new Student("a", 7),
                new Student("b", 6),
                new Student("c", 8),
            };
            var res = FindStudentWithHighestBestOfThreeScores(students);
            Console.WriteLine(res);
        }
    }
    public class Student
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public Student(string name, int score)
        {
            Name = name;
            Score = score;
        }
    }
}
