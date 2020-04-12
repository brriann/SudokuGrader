using System;

namespace SudokuGrader
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filePath;
            int[][] sudokuBoard;
            bool validSudokuSolution;

            // use a file path if one was passed in.  else, use hardcoded file path.
            if (args.Length == 1)
            {
                // Won't validate for valid file path. System.IO.File.ReadAllLines would throw exception.
                // placing call to ReadAllLines() in a try-catch structure would be ideal.
                filePath = args[0];
            }
            else
            {
                Console.WriteLine(@"usage: ./SudokuGrader C:\path\to\sudoku\txt\file.txt");
                filePath = @"C:\Development\SudokuGrader\TestFiles\sudoku.txt";
            }
            
            sudokuBoard = ValidateFileAndReadTo2DArray(filePath);

            // ideally, instead of a null return value, I'd try-catch to read file and return a meaningful exception.
            if (sudokuBoard == null)
            {
                // File was not parsed.
                Console.WriteLine("No, invalid");
                return;
            }

            bool validRows = ValidateRows(sudokuBoard);
            bool validColumns = ValidateColumns(sudokuBoard);
            bool validSquares = ValidateSquares(sudokuBoard);

            validSudokuSolution =  validRows && validColumns && validSquares;

            // no return codes, just messaging.
            if (validSudokuSolution)
            {
                Console.WriteLine("Yes, valid");
            }
            else
            {
                Console.WriteLine("No, invalid");
            }
        }

        public static bool ValidateRows(int[][] sudokuBoard)
        {
            for (int i = 0; i < 9; i++)
            {
                // store occurences of digits 1-9 in an array
                // occurence of n stored at hasOccured[n - 1]
                bool[] hasOccured = new bool[9];

                for (int j = 0; j < 9; j++)
                {
                    if (hasOccured[sudokuBoard[i][j] - 1]) 
                    {
                        return false;
                    }
                    else
                    {
                        hasOccured[sudokuBoard[i][j] - 1] = true;
                    }
                }
            }
            return true;
        }

        public static bool ValidateColumns(int[][] sudokuBoard)
        {
            for (int i = 0; i < 9; i++)
            {
                // store occurences of digits 1-9 in an array
                // occurence of n stored at hasOccured[n - 1]
                bool[] hasOccured = new bool[9];

                for (int j = 0; j < 9; j++)
                {
                    if (hasOccured[sudokuBoard[j][i] - 1])
                    {
                        return false;
                    }
                    else
                    {
                        hasOccured[sudokuBoard[j][i] - 1] = true;
                    }
                }
            }
            return true;
        }

        public static bool ValidateSquares(int[][] sudokuBoard)
        {
            return true;
        }

        public static int[][] ValidateFileAndReadTo2DArray(string filePath)
        {
            string[] fileLines = System.IO.File.ReadAllLines(filePath);

            if (fileLines.Length != 9)
            {
                return null;
            }

            int[][] fileAs2DArray = new int[9][];

            for (int i = 0; i < 9; i++) // fileLines.Length is confirmed to be 9 above.
            {
                string[] row = fileLines[i].Split(' ');

                if (row.Length != 9)
                {
                    return null;
                }

                int[] intRow = new int[9];
                for (int j = 0; j < 9; j++) // fileLines.Length is confirmed to be 9 above.
                {
                    int cellValue;
                    if (!int.TryParse(row[j], out cellValue) || cellValue < 1 || cellValue > 9)
                    {
                        return null;
                    }

                    intRow[j] = cellValue;
                }
                fileAs2DArray[i] = intRow;
            }
            return fileAs2DArray;
        }
    }
}
