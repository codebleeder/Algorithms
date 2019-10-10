using System;
using System.Collections.Generic;
using System.Text;

namespace EPI.Chapter5_Arrays
{
    public static class Arrays_17_IsValidSudoku
    {
        public static bool IsValidSudoku(List<List<int>> sudoku)
        {
            var count = sudoku.Count;
            // check all rows
            for(var i = 0; i < count; i++)
            {                                
                if (!HasNoDuplicates(sudoku, startRow: i, endRow: i, startColumn: 0, endColumn: count - 1))
                {
                    return false; 
                }
            }

            // check all columns 
            for(var i = 0; i < count; i++)
            {
                if(!HasNoDuplicates(sudoku, startRow: 0, endRow: count-1, startColumn: i, endColumn: i))
                {
                    return false; 
                }
            }

            var sqrtCount = (int) Math.Sqrt(count);
            // check all blocks
            for(var i = 0; i < sqrtCount; i++)
            {
                for(var j = 0; j < sqrtCount; j++)
                {
                    if (!HasNoDuplicates(sudoku, startRow: i*sqrtCount, endRow: i * sqrtCount + sqrtCount - 1, startColumn: j * sqrtCount, endColumn: j * sqrtCount + sqrtCount - 1))
                    {
                        return false;
                    }
                }
            }
            return true; 
        }
        public static bool HasNoDuplicates(List<List<int>> sudoku, int startRow, int endRow, int startColumn, int endColumn)
        {
            var IsPresent = new List<bool>();
            for(var i = 0; i < sudoku.Count; i++)
            {
                IsPresent.Add(false); 
            }

            for(var iRow = startRow; iRow <= endRow; iRow++)
            {
                for(var iCol = startColumn; iCol <= endColumn; iCol++)
                {
                    var val = sudoku[iRow][iCol];
                    if (IsPresent[val-1] == true)
                    {
                        return false; 
                    }
                    else
                    {
                        IsPresent[val-1] = true; 
                    }
                }
            }
            return true; 
        }
        public static void Test()
        {
            var sudoku = new List<List<int>> {
                new List<int>{ 1, 3, 4, 2 },
                new List<int>{ 2,4,1,3},
                new List<int>{ 3,1,2,4},
                new List<int>{ 4,2,3,1 }
            };
            Console.WriteLine($"checking sudoku. expected: true");
            Console.WriteLine(IsValidSudoku(sudoku));
            sudoku[0][0] = 2;
            Console.WriteLine("checking modified sudoku; expected: false");
            Console.WriteLine(IsValidSudoku(sudoku));
        }
    }    
}
