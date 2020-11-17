using System;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] puzzle = {
                                { 3, 2, 1, 7, 0, 4, 0, 0, 0 },
                                { 6, 4, 0, 0, 9, 0, 0, 0, 7 },
                                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                { 0, 0, 0, 0, 4, 5, 9, 0, 0 },
                                { 0, 0, 5, 1, 8, 7, 4, 0, 0 },
                                { 0, 0, 4, 9, 6, 0, 0, 0, 0 },
                                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                { 2, 0, 0, 0, 7, 0, 0, 1, 9 },
                                { 0, 0, 0, 6, 0, 9, 5, 8, 2 }
                            };

            //if (SolveSudoku(puzzle, 0, 0))
                PrintSudoku(puzzle);
        }
        /*
        PrintSudoku ritar ut plannen  
        */
        public static void PrintSudoku(int[,] puzzle)
        {
            Console.WriteLine("+-----+-----+-----+");

            for (int i = 1; i < 10; ++i)
            {
                for (int j = 1; j < 10; ++j)
                    Console.Write("|{0}", puzzle[i - 1, j - 1]);

                Console.WriteLine("|");
                if (i % 3 == 0) Console.WriteLine("+-----+-----+-----+");
            }
        }

    }
}
