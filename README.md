# SudokuGrader
A take-home coding assignment; console app that validates Sudoku puzzles

To all who evaluate this solution:
In the spirit of timeboxing this to <4 hours, I'll prioritize a working solution over 100% ideal design.

Along the way, I'll make notes of design decisions that I'd prefer to clean up.

If any code that appears is a "dealbreaker", please let me know, and I can provide a refactor commit.



ReadFileTo2DArray()


1. Initially, I'll return null if file doesn't parse to a 9x9 grid of numbers where 1<=x<=9.

Ideally, I'd throw a meaningful exception.  I avoid null returns in production code.

2. Initially, this method will have multiple return locations.

Ideally, I'd have a single return location, instead of falling out with null returns in many locations
	as I catch errors.



ValidateRows() and ValidateColumns()


These methods duplicate each other with the exception of cell indexing ... [i][j] vs [j][i].

Ideally, I could pass a "transposeRowOrColumn" boolean parameter, to specify traversal or row vs column.

I'll leave them separated for simplicity.


ValidateSquares()


To get the cross product of the 3 sets of "square boundaries" for rows and columns (i and j), I am settling on an easy data structure - 2 separate enumerables of high/low boundary pairs.


I could improve the variable names for iBounds, jBounds, iBoundPair, jBoundPair.
