using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter5_Arrays
{
    public class SpiralMatrix
    {
        List<List<int>> Matrix {  get;  set; }
        private int RowCount;
        private int ColCount;
        private int TotalItems;
        public SpiralMatrix(List<List<int>> matrix)
        {
            Matrix = matrix;
            RowCount = matrix.Count;
            ColCount = matrix[0].Count;
            TotalItems = RowCount * ColCount;
        }
        public List<int> MatrixInSpiralOrder()
        {
            var result = new List<int>();
            
            
            var i = 0;
            var iRow = 0;
            var iCol = 0;
            result.Add(Matrix[0][0]);
            
            while (i < TotalItems-1)
            {
                var nextCoordinates = GetNext(iRow, iCol);
                // mark current item as done by making it negative
                Matrix[iRow][iCol] *= -1;
                iRow = nextCoordinates.Item1;
                iCol = nextCoordinates.Item2;
                result.Add(Matrix[iRow][iCol]);
                i++;
            }
            return result;
        }
        public enum Mode { RIGHT, LEFT, DOWN, UP };
        private static Mode mode;
        public Tuple<int, int> GetNext(int iRow, int iCol)
        {
           
            Tuple<int, int> result = new Tuple<int, int>(-1, -1);
            if (iRow == 0 && iCol == 0)
            {
                mode = Mode.RIGHT;
            }
            switch (mode)
            {
                case Mode.RIGHT:
                    if (iCol + 1 >= ColCount || Matrix[iRow][iCol + 1] < 0)
                    {
                        mode = Mode.DOWN;
                        return GetNext(iRow, iCol);
                    }
                    result = new Tuple<int, int>(iRow, iCol + 1);
                    break;
                case Mode.DOWN:
                    if (iRow + 1 >= RowCount || Matrix[iRow + 1][iCol] < 0)
                    {
                        mode = Mode.LEFT;
                        return GetNext(iRow, iCol);
                    }
                    result = new Tuple<int, int>(iRow + 1, iCol);
                    break;
                case Mode.LEFT:
                    if (iCol == 0 || Matrix[iRow][iCol - 1] < 0)
                    {
                        mode = Mode.UP;
                        return GetNext(iRow, iCol);
                    }
                    result = new Tuple<int, int>(iRow, iCol - 1);
                    break;
                case Mode.UP:
                    if (iRow == 0 || Matrix[iRow - 1][iCol] < 0)
                    {
                        mode = Mode.RIGHT;
                        return GetNext(iRow, iCol);
                    }
                    result = new Tuple<int, int>(iRow - 1, iCol);
                    break;
            }
            return result;
        }
        public List<int> MatrixInSpiralOrder2()
        {
            var result = new List<int>();
            var cycleLimit = 1;
            var itemCount = TotalItems;
            var rowCount = RowCount;
            var colCount = ColCount;
            var iRow = 0;
            var iCol = 0;
            var numCycles = Math.Min(RowCount, ColCount);
            var smallestSide = Math.Min(RowCount, ColCount);
            var j = 1;
            for (var i = smallestSide; i > 0; i -=2 )
            {
                // for odd arrays 
                if(i == 1)
                {
                    result.Add(Matrix[iRow][iCol]);
                    break;
                }

                // go right n-i times
                for (var k = 0; k < colCount - j; k++)
                {
                    result.Add(Matrix[iRow][iCol]);
                    iCol += 1;
                }
                
                // go down m-i times
                for (var k = 0; k < rowCount - j; k++)
                {
                    result.Add(Matrix[iRow][iCol]);
                    iRow += 1;
                }
              
                // go left n-i times
                for (var k = 0; k < colCount - j; k++)
                {
                    result.Add(Matrix[iRow][iCol]);
                    iCol -= 1;
                }
               
                // go up m-i times
                for (var k = 0; k < rowCount - j; k++)
                {
                    result.Add(Matrix[iRow][iCol]);
                    iRow -= 1;
                }
                
                // go down one row and move right to enter inner matrix 
                iRow += 1;
                iCol += 1;
                
                // increment cycleLimit
                j += 1;
            }
            return result;               
        }
    }
    public static class Arrays_18_MatrixInSpiralOrder
    {
        // assuming all entries are positive
        public static List<int> MatrixInSpiralOrder(List<List<int>> matrix)
        {
            var spiralMatrix = new SpiralMatrix(matrix);
            return spiralMatrix.MatrixInSpiralOrder2();
        }
        
        public static void Test()
        {
            var matrix = new List<List<int>> {
                new List<int> {1, 2, 3 },
                new List<int> {4, 5, 6 },
                new List<int> {7, 8, 9 }
            };
            Console.WriteLine("expected result: {1, 2, 3, 6, 9, 8, 7, 4, 5}");
            Console.WriteLine("result: ");
            Utilities.PrintList(MatrixInSpiralOrder(matrix));

            var matrix2 = new List<List<int>> {
                new List<int> {1, 2, 3},
                new List<int> {4, 5, 6}
            };
            Console.WriteLine("case 2");
            Console.WriteLine("expected result: {1, 2, 3, 6, 5, 4}");
            Console.WriteLine("result: ");
            Utilities.PrintList(MatrixInSpiralOrder(matrix2));
        }
    }
}
