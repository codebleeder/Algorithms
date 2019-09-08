using EPI.Chapter4;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPI
{
    public class Ch4_primitive_types
    {
        public static int CountBits(int x)
        {
            int count = 0; 
            while (x != 0)
            {
                count += (x & 1);
                x = x >> 1; 
            }
            return count; 
        }
        
        public static short Parity(long x)
        {
            short res = 0;           
            while (x != 0)
            {               
                res ^= Convert.ToInt16(x & 1);
                x = x >> 1;
            }
            return res; 
        }


        public static short Parity2(int x)
        {
            short res = 0;
            while (x != 0)
            {
                res ^= 1;
                x = x & (x - 1);
            }
            return res; 
        }

        static short[] PrecomputedParity = { 0,1,1,0,1,0,1,1,0,0,1,0,1,1,0 };
        public static short Parity3(short x)
        {
            short res = 0;
            const int MASK_SIZE = 4;
            const int BIT_MASK = 0xF;
            res = (short)(PrecomputedParity[(x >> (3 * MASK_SIZE)) & BIT_MASK] ^
                PrecomputedParity[(x >> (2 * MASK_SIZE)) & BIT_MASK] ^
                PrecomputedParity[(x >> (1 * MASK_SIZE)) & BIT_MASK] ^
                PrecomputedParity[x  & BIT_MASK]);
            return res;
        }

        public static short Parity4(long x)
        {
            x ^= x >> 32;
            x ^= x >> 16;
            x ^= x >> 8;
            x ^= x >> 4;
            x ^= x >> 2;
            x ^= x >> 1;
            x &= 0x1;
            return (short)x;
        }

        public static long SwapBits(long x, int i, int j)
        {
            if (((x >> i) & 1) != ((x >> j) & 1))
            {
                long bitMask = (1L << i) | (1L << j);
                x ^= bitMask;
            }
            return x;
        }

        static short[] PrecomputedReverse = { 0,8,4,12,2,10,6,14,1,9,5,13,3,11,7,15 };
        public static short ReverseBits(short x)
        {
            const short BIT_MASK = 0xF;
            const int MASK_SIZE = 4;
            var res = (PrecomputedReverse[x & BIT_MASK] << (3 * MASK_SIZE))
                      | (PrecomputedReverse[(x >> MASK_SIZE) & BIT_MASK] << (2 * MASK_SIZE))
                      | (PrecomputedReverse[(x >> (2 * MASK_SIZE)) & BIT_MASK] << MASK_SIZE)
                      | (PrecomputedReverse[(x >> (3 * MASK_SIZE)) & BIT_MASK]);
            return (short)res;
        }

        public static long ClosestSameBitCount(long x)
        {
            const int NUM_BITS = 63;
            for(var i=0; i<NUM_BITS-1;i++)
            {
                var firstBit = (x >> i) & 0x1;
                var secondBit = (x >> (i + 1)) & 0x1;
                if(firstBit != secondBit)
                {
                    // flip the bits 
                    x ^= (1L << i) | (1L << (i + 1));
                    return x;
                }
            }
            throw new ArgumentException("all bits are same");
        }
        public static long ClosestSmallBitCount2(long x)
        {
            if(x == 0)
            {
                throw new ArgumentException("all bits are same");
            }
            var closestSetBit = x & (x - 1);
            var wordToSwapBits = 0L;
            if (closestSetBit == 1L)
            {
                wordToSwapBits = 1L | (1L << 1);
            }
            else
            {
                wordToSwapBits = closestSetBit | (closestSetBit >> 1);
            }
            return x ^ wordToSwapBits;
        }
        public static long Multiply(long a, long b) //not using arithmetic operators
        {
            var i = 0;
            long sum = 0;
            var tempA = a;
            while(tempA != 0)
            {
                var x = tempA & 1L;
                if (x == 1)
                {
                    sum = Add(sum, b << i);
                }
                i += 1;
                tempA >>= 1;
            }
            return sum;
        }

        public static long Add(long a, long b)
        {
            var k = 1;
            long carryIn = 0;
            long sum = 0;
            long tempA = a;
            long tempB = b;
            while (tempA != 0 || tempB != 0 || carryIn != 0)
            {
                var ak = a & k;
                var bk = b & k;
                sum |= ak ^ bk ^ carryIn;
                long carryOut = (ak & bk) | (ak & carryIn) | (bk & carryIn);
                carryIn  = carryOut << 1;
                k <<= 1;
                tempA >>= 1;
                tempB >>= 1;
            }
            return sum;
        }
        public static long Divide(long x, long y)
        {
            long result = 0;
            int power = 32;
            long yPower = y << power; 
            while( x >= y)
            {
                while(yPower > x)
                {
                    yPower >>= 1;
                    power -= 1;
                }
                result += 1L << power;
                x -= yPower;
            }
            return result; 
        }
        public static double Power(double x, int y)
        {
            double result = 1.0;
            long power = y; 
            if (y < 0)
            {
                power = -power;
                x = 1.0 / x;
            }
            while(power != 0)
            {
                if((power & 1) != 0)
                {
                    result *= x;
                }
                x *= x;
                power >>= 1;
            }
            return result;
        }
        public static int ReverseDigits(int x)
        {
            var y = x;
            var result = 0;
            while (y != 0)
            {
                result = (result * 10) + (y % 10);
                y = y / 10;
            }
            return result;
        }
        public static bool IsPalindromeNumber(int x)
        {
            if (x <= 0)
            {
                return x == 0;
            }
            var numDigits = Math.Floor(Math.Log10(x)) + 1;
            var msdMask = Math.Pow(10, numDigits - 1);
            for(var i=0; i<(numDigits/2); i++)
            {
                if((int)(x/msdMask) != (int) (x%10))
                {
                    return false;
                }
                x %= (int)msdMask; // remove most significant digit 
                x /= 10; // remove least significant digit 
                msdMask /= 100;
                
            }
            return true; 
        }
        public static int UniformRandom(int lowerBound, int upperBound)
        {
            var numberOfOutcomes = upperBound - lowerBound + 1;
            int result;
            var r = new Random();
            do
            {
                result = 0;
                for(var i=0; (1<<i) < numberOfOutcomes; ++i)
                {
                    result = (result << 1) | r.Next();
                }
            }
            while (result >= numberOfOutcomes);
            return result;
        }
        public static Rectangle IntersectRectangle(Rectangle r1, Rectangle r2)
        {
            // check if they intersect 
            if(!IsIntersect(r1, r2))
            {
                return new Rectangle(0, 0, -1, -1);
            }
            return new Rectangle(
                Math.Max(r1.X, r2.X),
                Math.Max(r1.Y, r2.Y),
                Math.Min(r1.X+r1.Width, r2.X+r2.Width)- Math.Max(r1.X, r2.X),
                Math.Min(r1.Y+r1.Height, r2.Y+r2.Height) - Math.Max(r1.Y, r2.Y)
                );
        }
        public static bool IsIntersect(Rectangle r1, Rectangle r2)
        {
            return r1.X <= r2.X + r2.Width &&
                r2.X <= r1.X + r1.Width &&
                r1.Y <= r2.Y + r2.Height &&
                r2.Y <= r1.Y + r1.Height;
        }
    }
}
