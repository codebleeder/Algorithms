using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter11_Searching
{
    public static class Searching_06_MatrixSearch
    {
        public static Tuple<int,int> MatrixSearch(List<List<int>> matrix, int x)
        {
            if (x < matrix[0][0] || x > matrix[matrix.Count-1][matrix[0].Count-1])
            {
                return null; 
            }
            var i = 0;
            var j = matrix[0].Count - 1;
            while(i < matrix.Count && j > 0)
            {
                var val = matrix[i][j];
                if (val == x)
                {
                    return new Tuple<int, int>(i, j);
                }
                else if(val < x)
                {
                    i++;
                }
                else
                {
                    j--;
                }
            }
            return null;
        }
        public static void Test()
        {
            var matrix = new List<List<int>>
            {
                new List<int> { -1, 2, 4, 4, 6 },
                new List<int> { 1, 5, 5, 9, 21 },
                new List<int> { 3, 6, 6, 9, 22 },
                new List<int> { 3, 6, 8, 10, 24 },
                new List<int> { 6, 8, 9, 12, 25 },
                new List<int> { 8, 10, 12, 13, 40 }
            };
            var tests = new List<int> { 8, 7, 13, -2, 42 };
            Utilities.PrintMatrix(matrix);
            for (var i = 0; i < tests.Count; i++)
            {
                var res = MatrixSearch(matrix, tests[i]);
                var resStr = res == null ? "null" : $"row: {res.Item1}  col: {res.Item2}";
                Console.WriteLine($"x: {tests[i]}  res: {resStr}");
            }
        }
    }
}
