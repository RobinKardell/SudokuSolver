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
            //om det kan lösas 
            if (SolveSudoku(puzzle, 0, 0))
                //skriv ut hela planen med lösningen så man kan visa upp det i konsolen.
                PrintSudoku(puzzle);
        }
        /*
        PrintSudoku ritar ut planen så det någonlunda liknar en sudoku plan.
        */
        public static void PrintSudoku(int[,] puzzle)
        {
            //skriver ut första raden av 
            Console.WriteLine("+-----+-----+-----+");

            //Loopar igenom alla 9 rader 
            for (int i = 1; i < 10; ++i)
            {
                //Loopar igenom så det finns en avskiljare mellan talen. 
                for (int j = 1; j < 10; ++j)
                    Console.Write("|{0}", puzzle[i - 1, j - 1]);
                
                //Denna lägger till den sista avskiljaren så det ramars in på ett snygg sätt.
                Console.WriteLine("|");
                
                //Lägger till botten av spelplanen. 
                if (i % 3 == 0) Console.WriteLine("+-----+-----+-----+");
            }
        }

        /*
        Denna funktion ska göra själva lösningen på sudokun, 
        */
        public static bool SolveSudoku(int[,] puzzle, int row, int col)
        {
            //först kolla så man inte gör mer än behvligt för att lösa sudokun. 
            if (row < 9 && col < 9)
            {
                //om det är en siffra redan utpekad på spelplanen så behövs det inte kollas efter en anna siffra.
                if (puzzle[row, col] != 0)
                {
                    if ((col + 1) < 9) return SolveSudoku(puzzle, row, col + 1);
                    else if ((row + 1) < 9) return SolveSudoku(puzzle, row + 1, 0);
                    else return true;
                }
                else
                {
                    //om det är en 0:a(nolla = tomt fält) på spelplanen så ska det fyllas med en fungerade siffra mellan 1-9,
                    // men ändå vara unik 
                    //i denna lopp går man igenom alla postioner och kollar om det är möjligt att sätta en fungerande siffra mellan 1-9 i rutan.
                    for (int i = 0; i < 9; ++i)
                    {
                        if (IsAvailable(puzzle, row, col, i + 1))
                        {
                            puzzle[row, col] = i + 1;

                            if ((col + 1) < 9)
                            {
                                if (SolveSudoku(puzzle, row, col + 1)) return true;
                                else puzzle[row, col] = 0;
                            }
                            else if ((row + 1) < 9)
                            {
                                if (SolveSudoku(puzzle, row + 1, 0)) return true;
                                else puzzle[row, col] = 0;
                            }
                            else return true;
                        }
                    }
                }

                return false;
            }
            else return true;
        }
        /*
        Här kollar vi om det är möjlgit att sätta en siffra i den angivna positionen. för i sudoku får det inte vara samma siffra inom 3x3 
        vågrätt eler lodrätt på spelplannen som är 9x9.
        */
        private static bool IsAvailable(int[,] puzzle, int row, int col, int num)
        {
            int rowStart = (row / 3) * 3;
            int colStart = (col / 3) * 3;

            for (int i = 0; i < 9; ++i)
            {
                if (puzzle[row, i] == num) return false;
                if (puzzle[i, col] == num) return false;
                if (puzzle[rowStart + (i % 3), colStart + (i / 3)] == num) return false;
            }

            return true;
        }


    }
}
