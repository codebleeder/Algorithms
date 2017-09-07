using System;
using System.Collections.Generic;
using System.Text;

namespace EPI_in_CSharp
{
    public class Ch4_primitive_types
    {
        public static int countBits(int x)
        {
            int count = 0; 
            while (x != 0)
            {
                count += (x & 1);
                x = x >> 1; 
            }
            return count; 
        }
        
        public static bool parity(int x)
        {
            bool result = false; 
            while (x != 0)
            {
                result ^= Convert.ToBoolean(x & 1);
                x = x >> 1;
            }
            return result; 
        }

        public static void testParity()
        {
            System.Console.WriteLine("parity 4 = " + parity(4));
            System.Console.WriteLine("parity 5 = " + parity(5));
        }

        public static bool parity2(int x)
        {
            
            bool result = false; 
            while (x != 0)
            {
                result ^= true;
                x = x & (x - 1);
            }
            return result; 
        }

        public static void testParity2()
        {
            System.Console.WriteLine("parity 4 = " + parity2(4));
            System.Console.WriteLine("parity 5 = " + parity2(5));
        }
    }
}
