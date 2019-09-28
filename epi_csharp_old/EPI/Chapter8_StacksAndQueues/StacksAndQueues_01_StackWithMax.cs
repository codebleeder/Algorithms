using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter8_StacksAndQueues
{
    public static class StacksAndQueues_01_StackWithMax
    {
        private class ElementWithCachedMax
        {
            public int Element { get; set; }
            public int Max { get; set; }
            public ElementWithCachedMax(int element, int max)
            {
                Element = element;
                Max = max;
            }
        }
        public class StackWithMax
        {
            private LinkedList<ElementWithCachedMax> Elements { get; set; }
            public StackWithMax()
            {
                Elements = new LinkedList<ElementWithCachedMax>();
            }
            public void Push(int x)
            {
                var latestMax = Math.Max(x, Elements.Count == 0 ? x : Max());
                Elements.AddFirst(new ElementWithCachedMax(x, latestMax));
            }
            public int Pop()
            {
                if (Elements.Count == 0)
                {
                    throw new InvalidOperationException("Pop(): empty stack");
                }
                var first = Elements.First.Value.Element;
                Elements.RemoveFirst();
                return first;
            }
            public int Max()
            {
                if (Elements.Count == 0)
                {
                    throw new InvalidOperationException("Max(): empty stack");
                }
                var max = Elements.First.Value.Max;                
                return max;
            }
            public int Peek()
            {
                if (Elements.Count == 0)
                {
                    throw new InvalidOperationException("Max(): empty stack");
                }
                var first = Elements.First.Value.Element;
                return first;
            }
        }
        private class MaxWithCount
        {
            public int Max { get; set; }
            public int Count { get; set; }
            public MaxWithCount(int max, int count)
            {
                Max = max;
                Count = count;
            }
        }
        public class StackWithMax2
        {
            private Stack<MaxWithCount> MaxWithCounts { get; set; }
            private Stack<int> Elements { get; set; }
            public StackWithMax2()
            {
                MaxWithCounts = new Stack<MaxWithCount>();
                Elements = new Stack<int>();
            }
            public void Push(int x)
            {
                Elements.Push(x);
                if (MaxWithCounts.Count == 0)
                {
                    MaxWithCounts.Push(new MaxWithCount(x, 1));
                    return; 
                }
                var maxWithCountLatest = MaxWithCounts.Peek();
                if (maxWithCountLatest.Max < x)
                {
                    MaxWithCounts.Push(new MaxWithCount(x, 1));
                }
                else if (maxWithCountLatest.Max == x)
                {
                    MaxWithCounts.Peek().Count += 1;                    
                }

            }
            public int Pop()
            {
                if (Elements.Count == 0)
                {
                    throw new InvalidOperationException("Pop(): empty stack");
                }
                var topMax = MaxWithCounts.Peek();
                var topElement = Elements.Peek();
                if (topElement == topMax.Max && topMax.Count == 1)
                {
                    MaxWithCounts.Pop();
                }
                else if (topElement == topMax.Max && topMax.Count > 1)
                {
                    var topMax2 = MaxWithCounts.Pop();
                    topMax2.Count -= 1;
                    MaxWithCounts.Push(topMax2);
                }
                return Elements.Pop();
            }
            public int Max()
            {
                if (Elements.Count == 0)
                {
                    throw new InvalidOperationException("Max(): empty stack");
                }
                return MaxWithCounts.Peek().Max;
            }
        }
        public static void Test()
        {
            var tests = new List<Tuple<int[], int>>
            {
                new Tuple<int[], int>(new int[] { 1, 2, 3, 4, 2, 1, 5, 2, }, 5),
                new Tuple<int[], int>(new int[] { 10, 2, 3, 4, 10, 1, 5, 2, }, 10),
            };
            var testStack1 = new StackWithMax2(); // change class here to test StackWithMax and StackWithMax2
            var i = 1;
            foreach (var test in tests)
            {
                Console.WriteLine($"case {i}; stack: ");
                Utilities.PrintArray(test.Item1);
                var sb = new StringBuilder();
                foreach (var e in test.Item1)
                {
                    testStack1.Push(e);                    
                }
                foreach (var e in test.Item1)
                {
                    var max = testStack1.Max();                    
                    var el = testStack1.Pop();
                    sb.Append($"(el: {el} max: {max}) ");
                }
                Console.WriteLine(sb.ToString());
                i++;
            }
        }
    }
}
