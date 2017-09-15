using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ctci_csharp
{
    class Ch1_arrays_and_strings
    {
        public static bool p1_1_unique_chars(string s)
        {
            bool[] bArr = new bool[256];
            for(int i=0; i<bArr.Length; i++)
            {
                bArr[i] = false;
            }

            foreach(char c in s)
            {
                if (bArr[c] == true)
                {
                    return false;
                }
                bArr[c] = true; 
            }
            return true; 
        }

        public static bool p1_1_unique_chars2(string s)
        {
            BitArray bArr = new BitArray(256, false);
            foreach(char c in s)
            {
                if(bArr[c] == true)
                {
                    return false; 
                }
                bArr[c] = true; 
            }
            return true; 
        }

        public static void p1_1_test()
        {
            System.Console.WriteLine("method1 sharad = " + p1_1_unique_chars("sharad").ToString());
            System.Console.WriteLine("method1 shard = " + p1_1_unique_chars("shard").ToString());
            System.Console.WriteLine("method2 sharad = " + p1_1_unique_chars2("sharad").ToString());
            System.Console.WriteLine("method2 sharad = " + p1_1_unique_chars2("shard").ToString());
        }

        public static string p1_2_reverse_string(string s)
        {                        
            int lastIndex = s.Length - 1;            
            StringBuilder sb = new StringBuilder();
            for(int i=lastIndex; i>=0; i--)
            {
                sb.Append(s[i]);
            }
            return sb.ToString();
        }

        public static void p1_2_test()
        {
            System.Console.WriteLine("sharad = " + p1_2_reverse_string("sharad"));
        }

        public static bool p1_3_is_permutation(string s1, string s2)
        {
            if (s1.Length != s2.Length)
            {
                return false; 
            }
            char[] c1 = s1.ToArray<char>();
            Array.Sort(c1);
            char[] c2 = s2.ToArray<char>();
            Array.Sort(c2);
            
            for(int i=0;i<c1.Length;i++)
            {
                if (c1[i] != c2[i])
                {
                    return false;
                }
            }
            return true; 
        }

        public static bool p1_3_is_permutation2(string s1, string s2)
        {
            if (s1.Length != s2.Length)
            {
                return false; 
            }
            int[] iArr = new int[256];

            foreach(char c in s1)
            {
                iArr[c] += 1;
            }

            foreach(char c2 in s2)
            {
                iArr[c2] -= 1;
                if (iArr[c2] < 0)
                {
                    return false; 
                }
            }

            return true; 
        }        

        public static void p1_3_test()
        {
            System.Console.WriteLine("sharad, darahs = (true) " + p1_3_is_permutation2("sharad", "darahs"));
            System.Console.WriteLine("sharad, daraxs = (false) " + p1_3_is_permutation2("sharad", "darass"));
            System.Console.WriteLine("sharad, daraxs = (false) " + p1_3_is_permutation2("sharad", "das"));
        }

        public static string p1_4(string s)
        {
            
        }
    }
}
