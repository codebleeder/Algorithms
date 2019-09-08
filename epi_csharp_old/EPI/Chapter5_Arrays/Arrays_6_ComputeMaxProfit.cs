using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter5_Arrays
{
    public static class Arrays_6_ComputeMaxProfit
    {
        // Write a program that takes an array denoting the daily stock price,
        // and returns the maximum profit that could be made by buying and then selling
        // one share of that stock. There is no need to buy if no profit is possible. 
        public static double ComputeMaxProfit(double[] x)
        {
            var minValue = Double.MaxValue; // initial value so that it takes up first value of array
            var maxProfit = 0.0;
            foreach(var v in x)
            {
                minValue = Math.Min(minValue, v);
                maxProfit = Math.Max(maxProfit, v - minValue);
            }
            return maxProfit;
        }
        public static void TestComputeMaxProfit()
        {
            double[] x = { 310,315,275,295,260,270,290,230,255,250 };
            Console.WriteLine($"expected: 30  result: {ComputeMaxProfit(x)}");            
        }
        
    }
}
