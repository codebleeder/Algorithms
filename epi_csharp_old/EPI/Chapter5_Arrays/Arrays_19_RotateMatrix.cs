using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPI.Chapter5_Arrays
{
    public static class Arrays_19_RotateMatrix
    {
        // assuming equal number of rows and columns
        public static void RotateSquareMatrix(List<List<int>> matrix)
        {
            for(var iRow = 0; iRow < matrix.Count; iRow++)
            {
                for(var iCol = 0; iCol < matrix[0].Count; iCol++)
                {
                    if(iCol > iRow)
                    {
                        Swap(matrix, new Tuple<int, int>(iRow, iCol), new Tuple<int, int>(iCol, iRow));
                    }
                }
            }
        }
        public static List<List<int>> RotateMatrix(List<List<int>> matrix)
        {
            if(matrix.Count == matrix[0].Count)
            {
                RotateSquareMatrix(matrix);
                return matrix;
            }
            var resultArr = new int[matrix[0].Count, matrix.Count];
            var result = new List<List<int>>();
            
            for(var i = 0; i < matrix.Count; i++)
            {                
                for(var j = 0; j < matrix[0].Count; j++) //
                {
                    resultArr[j, i] = matrix[i][j];
                }                
            }
            for(var i = 0; i < matrix[0].Count; i++)
            {
                var row = new List<int>();
                for(var j = 0; j < matrix.Count; j++)
                {
                    row.Add(resultArr[i, j]);
                }
                result.Add(row);
            }
            return result;
            
        }
        public static void Swap(List<List<int>> matrix, Tuple<int, int> index1, Tuple<int, int> index2)
        {
            var temp = matrix[index1.Item1][index1.Item2];
            matrix[index1.Item1][index1.Item2] = matrix[index2.Item1][index2.Item2];
            matrix[index2.Item1][index2.Item2] = temp; 
        }
        public class RotatedMatrix
        {
            private List<List<int>> Matrix;
            public RotatedMatrix(List<List<int>> matrix)
            {
                Matrix = matrix;                 
            }
            public int ReadEntry(int i, int j)
            {
                return Matrix[j][i];
            }
            public void WriteEntry(int i, int j, int v)
            {
                Matrix[j][i] = v; 
            }
        }
        public static void TestRotatedMatrixClass()
        {
            var mat1 = new List<List<int>>
            {
                new List<int> {1,2,3},
                new List<int> {4,5,6},
                new List<int> {7,8,9}
            };
            var expected1 = new List<List<int>>
            {
                new List<int> {1,4,7},
                new List<int> {2,5,8},
                new List<int> {3,6,9}
            };
            var rotatedMat1 = new RotatedMatrix(mat1);
            var allValuesChecked = true; 
            for(var i=0; i < expected1.Count; i++)
            {
                for (var j = 0; j < expected1[0].Count; j++)
                {
                    if(expected1[i][j] != rotatedMat1.ReadEntry(i, j))
                    {
                        Console.WriteLine($"mismatch at i = {i}, j={j}  expected = {expected1[i][j]} result = {rotatedMat1.ReadEntry(i, j)}");
                        allValuesChecked = false; 
                    }
                }                
            }
            if (allValuesChecked)
            {
                Console.WriteLine("test cleared for square matrix");
            }

            var mat2 = new List<List<int>>
            {
                new List<int> {1,2,3},
                new List<int> {4,5,6}
            };
            var expected2 = new List<List<int>>
            {
                new List<int> {1,4},
                new List<int> {2,5},
                new List<int> {3,6}
            };
            var rotatedMat2 = new RotatedMatrix(mat2);
            allValuesChecked = true;
            for (var i = 0; i < expected2.Count; i++)
            {
                for (var j = 0; j < expected2[0].Count; j++)
                {
                    if (expected2[i][j] != rotatedMat2.ReadEntry(i, j))
                    {
                        Console.WriteLine($"mismatch at i = {i}, j={j}  expected = {expected2[i][j]} result = {rotatedMat2.ReadEntry(i, j)}");
                        allValuesChecked = false;
                    }
                }
            }
            if (allValuesChecked)
            {
                Console.WriteLine("test cleared for non-square matrix");
            }
        }
        public static void TestRotateSquareMatrix()
        {
            var mat1 = new List<List<int>> {
                new List<int> {1,2,3,4 },
                new List<int> {5,6,7,8 },
                new List<int> {9,10,11,12 },
                new List<int> {13,14,15,16 },
            };

            var expected1 = new List<List<int>> {
                new List<int> {1,5,9,13 },
                new List<int> {2,6,10,14 },
                new List<int> {3,7,11,15 },
                new List<int> {4,8,12,16 },
            };
            var mat2 = new List<List<int>>
            {
                new List<int> {1,2,3},
                new List<int> {4,5,6},
                new List<int> {7,8,9}
            };
            var expected2 = new List<List<int>>
            {
                new List<int> {1,4,7},
                new List<int> {2,5,8},
                new List<int> {3,6,9}
            };
            TestCase(mat1, expected1, RotateSquareMatrix);
            TestCase(mat2, expected2, RotateSquareMatrix);
        }
        public delegate void RotateMatrixDelegate(List<List<int>> matrix);
        public static void TestCase(List<List<int>> testMatrix, List<List<int>> expectedMatrix, RotateMatrixDelegate rotateMatrixDelegate)
        {
            Console.WriteLine("original matrix1: ");
            Utilities.PrintMatrix(testMatrix);
            Console.WriteLine("expected result: ");
            Utilities.PrintMatrix(expectedMatrix);
            Console.WriteLine("result: ");
            rotateMatrixDelegate(testMatrix);
            Utilities.PrintMatrix(testMatrix);            
        }
        public static void TestGenericMatrix()
        {
            var mat1 = new List<List<int>>
            {
                new List<int> {1,2,3},
                new List<int> {4,5,6}
            };
            var expected = new List<List<int>>
            {
                new List<int> {1,4},
                new List<int> {2,5},
                new List<int> {3,6}
            };
            Console.WriteLine("original matrix1: ");
            Utilities.PrintMatrix(mat1);
            Console.WriteLine("expected result: ");
            Utilities.PrintMatrix(expected);
            Console.WriteLine("result: ");
            var res = RotateMatrix(mat1);
            Utilities.PrintMatrix(res);
        }
    }
}
