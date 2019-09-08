using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter5_Arrays
{
    public static class Arrays_10_ApplyPermutation
    {
        public static void ApplyPermutation(List<int> permutations, List<string> x)
        {
            for(var i=0; i<x.Count; i++)
            {
                var next = i;
                while(permutations[next] >= 0)
                {
                    // swap i and next in x
                    var temp = x[next];
                    x[next] = x[i];
                    x[i] = temp;

                    var temp2 = permutations[next];
                    permutations[next] = next - permutations.Count;
                    next = temp2; 
                }
            }

            for(var i=0; i<permutations.Count; i++)
            {
                permutations[i] = permutations[i] + permutations.Count;
            }
        }
        public static void TestApplyPermutation()
        {
            var x = new List<string> { "a", "b", "c", "d" };
            var perm = new List<int> { 1,2,3,0 };
            Console.WriteLine("apply permutation to list: ");
            Utilities.PrintList(x);
            Console.WriteLine("permutation: ");
            Utilities.PrintList(perm);
            Console.WriteLine("result: ");
            ApplyPermutation3(perm, x);
            Utilities.PrintList(x);
            Console.WriteLine("expected: {d, a, b, c}");
        }
        public static void ApplyPermutation2(List<int> perm, List<string> x)
        {
           for(var i=0; i<x.Count; i++)
            {
                var next = i;
                while(perm[next] >= 0)
                {
                    if(i != next)
                    {
                        // swap
                        var tmp = x[i];
                        x[i] = x[next];
                        x[next] = tmp;
                    }
                    

                    // mark perm 
                    var tmp2 = perm[next];
                    perm[next] = perm[next] - perm.Count;
                    next = tmp2;
                }
            }
        }
        public static void ApplyPermutation3(List<int> perm, List<string> x)
        {
            for(var i=0; i<x.Count; i++)
            {
                var isMin = true;
                var j = perm[i];
                while(j != i)
                {
                    if(j < i)
                    {
                        isMin = false;
                        break;
                    }
                    j = perm[j];
                }
                if(isMin)
                {
                    CyclicPermutation(i, perm, x);
                }
            }
        }

        private static void CyclicPermutation(int start, List<int> perm, List<string> x)
        {
            var i = start;
            var temp = x[start];
            do
            {
                var nextI = perm[i];
                var nextTemp = x[nextI];
                x[nextI] = temp;
                i = nextI;
                temp = nextTemp;
            }
            while (i != start);
        }
    }
}
