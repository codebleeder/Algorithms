using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter5_Arrays
{
    public static class Arrays_7_BuyAndSellStockTwice
    {
        // write a program that computes the max profit that can be 
        // made by buying and selling a share at most twice. The second
        // buy must be made on another date after the first sale. 
        public static double BuyAndSellStockTwice(double[] x)
        {
            var maxTotalProfit = 0.0;
            var firstBuySellProfits = new List<double>();
            var minPriceSoFar = Double.MaxValue;

            // forward phase. For each day, we record maximum profit 
            // if we sell on that day. 
            for(var i=0; i< x.Length; i++)
            {
                minPriceSoFar = Math.Min(minPriceSoFar, x[i]);
                maxTotalProfit = Math.Max(maxTotalProfit, x[i] - minPriceSoFar);
                firstBuySellProfits.Add(maxTotalProfit);
            }

            // Backward phase; 
            // for each day, find the max profit if we make the second buy
            // on that day
            var maxPriceSoFar = Double.MinValue;
            for(var i=x.Length-1; i>0; --i)
            {
                maxPriceSoFar = Math.Max(maxPriceSoFar, x[i]);
                maxTotalProfit = Math.Max(
                    maxTotalProfit,
                    maxPriceSoFar - x[i] + firstBuySellProfits[i - 1]
                    );
            }
            return maxTotalProfit;
        }
        public static void TestBuyAndSellStockTwice()
        {
            double[] x = { 12, 11, 13, 9, 12, 8, 14, 13, 15 };
            Console.WriteLine($"maximum profit: {BuyAndSellStockTwice(x)}");
            double[] x2 = { 10, 22, 5, 75, 65, 80 };
            Console.WriteLine($"test2; expected: 87  result: {BuyAndSellStockTwice(x2)}");
            double[] x3 = { 2, 30, 15, 10, 8, 25, 80 };
            Console.WriteLine($"test3: expected: 100 result: {BuyAndSellStockTwice(x3)}");
        }
    }
}
