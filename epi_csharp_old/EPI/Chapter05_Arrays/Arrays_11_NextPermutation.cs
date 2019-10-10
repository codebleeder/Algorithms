using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter5_Arrays
{
    public static class Arrays_11_NextPermutation
    {
        public static void NextPermutation(List<int> perm)
        {
            // find k such that perm[k] < perm[k+1]
            var k = perm.Count-2;
            while(k >= 0 && perm[k] > perm[k+1])
            {
                k--;
            }
            if(k == -1)
            {
                return; // this is the last permutation
            }
            // swap perm[k] with smallest possible number greater than perm[k] within suffix
            for(var i = perm.Count-1; i > k; i--)
            {
                if(perm[i] > perm[k])
                {
                    // swap with perm[k]                    
                    Utilities.Swap(perm, k, i);
                    break; 
                }
            }
            // sort the suffix by reversing it 
            // suffix is from perm[k+1] to perm[n-1]
            var j = k + 1;
            var reverseIndexLimit = k + 1 + ((perm.Count - (k + 1)) / 2);
            for (var i = perm.Count-1; i >= reverseIndexLimit; i--)
            {
                Utilities.Swap(perm, j, i);                 
                j++;
            }
            
        }
        public static void TestNextPermutation()
        {
            var perm = new List<int> { 6,2,1,5,4,3,0 };
            Console.WriteLine("permutation: ");
            Utilities.PrintList(perm);
            Console.WriteLine("expected next permutation: {6,2,3,0,1,4,5}");
            NextPermutation(perm);
            Utilities.PrintList(perm);
            var perm2 = new List<int> { 6, 5, 4, 3, 2, 1, 0 };
            Console.WriteLine("permutation 2: ");
            Utilities.PrintList(perm2);
            Console.WriteLine("there is no next permutation. It should be unchanged");
            NextPermutation(perm2);
            Utilities.PrintList(perm2);
            var perm3 = new List<int> { 2, 1, 6, 5, 4, 3, 0 };
            Console.WriteLine("case 3: ");
            Utilities.PrintList(perm3);
            Console.WriteLine("expected: {2,3,0,1,4,5,6}");
            NextPermutation(perm3);
            Utilities.PrintList(perm3);
        }
    }
}
