# SudokuGrader
A take-home coding assignment; console app that validates Sudoku puzzles

To all who evaluate this solution:
I'm making an attempt to timebox this effort, and get a working solution.
Along the way, I'll make notes of design decisions that I'd prefer to clean up.

1. ReadFileTo2DArray()
Initially, I'll return null if file doesn't parse to a 9x9 grid of numbers where 1<=x<=9.
Ideally, I'd throw a meaningful exception.

