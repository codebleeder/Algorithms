using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter5_Arrays
{
    public static class Arrays_20_PascalTriangle
    {
        public static List<List<int>> GeneratePascalTriangle(int n)
        {
            var pascalTriangle = new List<List<int>>();
            for(var i = 0; i < n; i++)
            {
                var row = new List<int>();
                for(var j = 0; j <= i; j++)
                {
                    var v = (j > 0 && j < i) ? (pascalTriangle[i-1][j-1] + pascalTriangle[i-1][j]) : 1;
                    row.Add(v);
                }
                pascalTriangle.Add(row);
            }
            return pascalTriangle;
        }
        public static void Test()
        {
            Console.WriteLine("pascal triangle n = 5");
            Utilities.PrintMatrix(GeneratePascalTriangle(5));
            Console.WriteLine("n = 6");
            Utilities.PrintMatrix(GeneratePascalTriangle(6));
        }
    }
}
