using System;

namespace SudokuGrader
{
    public class Program
    {
        static void Main(string[] args)
        {
            string FILEPATH;
            int[][] sudokuBoard;
            bool validSudokuSolution;

            // use a file path if one was passed in.  else, use hardcoded file path.
            if (args.Length == 1)
            {
                Console.WriteLine("reading filePath from CLI args");
                FILEPATH = args[0];
            }
            else
            {
                Console.WriteLine(@"usage: ./SudokuGrader C:\path\to\sudoku\txt\file.txt");
                FILEPATH = @"C:\Development\SudokuGrader\TestFiles\sudoku.txt";
            }
            
            sudokuBoard = ValidateFileAndReadTo2DArray(FILEPATH);

            if (sudokuBoard == null)
            {
                Console.WriteLine("Invalid file format. Expected a 9-line .txt file with 9 digits.");
                return;
            }


        }

        public static bool ValidateRows(int[][] sudokuBoard)
        {
            return true;
        }

        public static bool ValidateColumns(int[][] sudokuBoard)
        {
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
