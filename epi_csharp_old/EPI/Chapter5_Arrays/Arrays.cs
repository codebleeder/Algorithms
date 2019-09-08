using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter5_Arrays
{
    public static class Arrays
    {
        // Re-arrange array such that even elements appear first
        public static void EvenOdd(int[] x)
        {
            var j = 1; 
            for(var i=0; i<x.Length;i++)
            {
                if(x[i]%2 != 0)
                {
                    ExchangeWithEven(x, i);
                }
            }
        }

        private static void ExchangeWithEven(int[] x, int i)
        {            
            for(var j=i+1; j<x.Length; j++)
            {
                if(x[j]%2 == 0)
                {
                    var oddNum = x[i];
                    x[i] = x[j];
                    x[j] = oddNum;
                    return;
                }
            }
        }
        public static void EvenOdd2(int[] a)
        {
            var nextEven = 0;
            var nextOdd = a.Length - 1;
            while(nextEven < nextOdd)
            {
                if(a[nextEven]%2 == 0)
                {
                    nextEven += 1;
                }
                else
                {
                    var temp = a[nextEven];
                    a[nextEven] = a[nextOdd];
                    a[nextOdd--] = temp;
                }
            }
        }
        public enum Color { RED, WHITE, BLUE };
        public static void DutchFlagPartition(int pivotIndex, List<Color> a)
        {
            var pivot = a[pivotIndex];
            // first pass: group elements smaller than pivot
            for(int i=0; i<a.Count; i++)
            {
                for(int j=0; j<a.Count; j++)
                {
                    if(a[j] < pivot)
                    {
                        // swap i and j elements
                        var tmp = a[i];
                        a[i] = a[j];
                        a[j] = tmp;
                        break;
                    }
                }
            }

            // second pass: group elements larger than pivot 
            for(int i=a.Count-1; i>= 0 && a[i] >= pivot; --i)
            {
                // look for a larger element. Stop when we reach an element less
                // than pivot, since first pass has moved them to the start of a 
                for(int j=i-1; j>= 0 && a[j] >= pivot; --j)
                {
                    if(a[j] > pivot)
                    {
                        // swap i and j elements
                        var tmp = a[i];
                        a[i] = a[j];
                        a[j] = tmp;
                        break;
                    }
                }
            }
        }
        public static void DutchFlagPartition2(int pivotIndex, List<int> a)
        {
            var pivot = a[pivotIndex];
            // first pass: group elements smaller than pivot
            for (int i = 0; i < a.Count; i++)
            {
                for (int j = 0; j < a.Count; j++)
                {
                    if (a[j] < pivot)
                    {
                        // swap i and j elements
                        var tmp = a[i];
                        a[i] = a[j];
                        a[j] = tmp;
                        break;
                    }
                }
            }

            // second pass: group elements larger than pivot 
            for (int i = a.Count - 1; i >= 0 && a[i] >= pivot; --i)
            {
                // look for a larger element. Stop when we reach an element less
                // than pivot, since first pass has moved them to the start of a 
                for (int j = i - 1; j >= 0 && a[j] >= pivot; --j)
                {
                    if (a[j] > pivot)
                    {
                        // swap i and j elements
                        var tmp = a[i];
                        a[i] = a[j];
                        a[j] = tmp;
                        break;
                    }
                }
            }
        }

        // time complexity = O(n)
        public static void DutchPartition3(int pivotIndex, int[] a)
        {
            var pivot = a[pivotIndex];
            // move elements smaller than pivot to the beginning // of the array 
            var j = 0;
            for (var i = 0; i < a.Length; i++)
            {
                if (a[i] < pivot)
                {
                    // exchange it to pointer and increment pointer 
                    var tmp = a[i];
                    a[i] = a[j];
                    a[j] = tmp;
                    j++;
                }
            }

            j = a.Length - 1;
            for (var i = a.Length - 1; i >= 0; i--)
            {
                if (a[i] > pivot)
                {
                    // exchange it to pointer and decrement pointer 
                    var tmp = a[i];
                    a[i] = a[j];
                    a[j] = tmp;
                    j--;
                }
            }
        }
        public static void DutchPartition4(int pivotIndex, int[] a)
        {
            int smaller = 0;
            int equal = 0;
            int larger = a.Length;
            var pivot = a[pivotIndex];
            while (equal < larger)
            {
                if(a[equal] < pivot)
                {
                    Swap(a, smaller++, equal++);                    
                }
                else if(a[equal] == pivot)
                {
                    ++equal; 
                }
                else
                {                    
                    Swap(a, equal, --larger);                    
                }
            }
        }
        public static List<int> PlusOne(List<int> a)
        {
            int n = a.Count - 1;
            a[n] = a[n] + 1; 
            for(var i=n; i>0 && a[i]>=10; i--)
            {
                a[i] = 0;
                a[i - 1] = a[i - 1] + 1;
            }
            if(a[0] >= 10)
            {
                a[0] = 1;
                a.Add(0);
            }
            return a; 
        }
        
        public static List<int> Multiply(List<int> a, List<int> b)
        {
            var sign = a[0] < 0 ^ b[0] < 0 ? -1 : 1;
            a[0] = Math.Abs(a[0]);
            b[0] = Math.Abs(b[0]);
            var result = new List<int>();
            for (var i = 0; i < a.Count + b.Count; i++)
            {
                result.Add(0);
            }
            for (var i=a.Count-1; i>=0; --i)
            {
                for(var j=b.Count-1; j>=0; --j)
                {
                    result[i + j + 1] += a[i] * b[j];
                    result[i + j] += result[i + j + 1] / 10;
                    result[i + j + 1] = result[i + j + 1] % 10;
                }
            }
            // remove leading zeroes
            var firstNonZero = 0;
            while(firstNonZero < result.Count && result[firstNonZero] == 0)
            {
                ++firstNonZero;
            }
            result = result.GetRange(firstNonZero, result.Count-firstNonZero);
            // set sign 
            result[0] = sign * result[0];
            return result;
        }
        private static void Swap(int[] a, int v1, int v2)
        {
            var tmp = a[v1];
            a[v1] = a[v2];
            a[v2] = tmp; 
        }
        public static bool CanReachEnd(List<int> x)
        {
            var maxStepsReached = 0;
            var lastIndex = x.Count - 1;
            var i = 0; 
            while(maxStepsReached < lastIndex && i <= maxStepsReached)
            {
                maxStepsReached = Math.Max(maxStepsReached, i + x[i]);
                i++;
            }
            return maxStepsReached >= lastIndex;
        }
        public static bool CanReachEnd2(List<int> x)
        {
            var maxStepsReached = 0;
            var lastIndex = x.Count - 1;
            for(var i=0; i<=maxStepsReached && maxStepsReached < lastIndex; ++i)
            {
                maxStepsReached = Math.Max(maxStepsReached, i + x[i]);
            }
            return maxStepsReached >= lastIndex;
        }
        public static void RemoveDuplicates(int[] x)
        {            
            var j = 1;
            for(var i=0; i<x.Length-1; i++)
            {
               if(x[i] == x[i+1])
                {
                    // find next unique
                    x[i + 1] = FindNextUnique(x, i + 2);
                }
               else if(x[i] > x[i+1])
                {
                    ResetArrayFromHere(x, i + 1);
                }
            }

        }

        private static void ResetArrayFromHere(int[] x, int v)
        {
            for(var i=v; i<x.Length; i++)
            {
                x[i] = 0;
            }
        }

        public static int FindNextUnique(int[] x, int fromIndex)
        {
            if(fromIndex >= x.Length)
            {
                return 0;
            }
            var val = x[fromIndex - 1];
            for(var i=fromIndex; i<x.Length; i++)
            {
                if(val != x[i])
                {
                    return x[i];
                }
            }
            return 0;
        }
        public static int RemoveDuplicates2(int[] x)
        {
            if(x.Length == 0)
            {
                return 0;
            }
            var writeIndex = 1;
            for(int i=1; i< x.Length; i++)
            {
                if(x[i] != x[i-1])
                {
                    Console.WriteLine($"writing x[{writeIndex}] = x[{i}]  x[writeIndex]={x[writeIndex]}  x[i]={x[i]}");
                    x[writeIndex++] = x[i];
                    
                }
            }
            return writeIndex;
        }
        // Write a program that takes 
    }
}
