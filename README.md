# SudokuGrader
A take-home coding assignment; console app that validates Sudoku puzzles

To all who evaluate this solution:
In the spirit of timeboxing this to <4 hours, I'll prioritize a working solution over 100% ideal design.

Along the way, I'll make notes of design decisions that I'd prefer to clean up.

If any code that appears is a "dealbreaker", please let me know, and I can provide a refactor commit.



1. ReadFileTo2DArray()

Initially, I'll return null if file doesn't parse to a 9x9 grid of numbers where 1<=x<=9.

Ideally, I'd throw a meaningful exception.  I avoid null returns in production code.

Initially, this method will have multiple return locations.

Ideally, I'd have a single return location, instead of falling out with null returns in many locations
	as I catch errors.

