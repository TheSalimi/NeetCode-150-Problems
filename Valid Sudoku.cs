/*
36. Valid Sudoku
----------------
Determine if a 9 x 9 Sudoku board is valid. 
Only the filled cells need to be validated according to the following rules:

1. Each row must contain the digits 1-9 without repetition.
2. Each column must contain the digits 1-9 without repetition.
3. Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without repetition.

Note:
- A Sudoku board (partially filled) could be valid but is not necessarily solvable.
- Only the filled cells need to be validated.

Example 1:
Input:
[["5","3",".",".","7",".",".",".","."],
 ["6",".",".","1","9","5",".",".","."],
 [".","9","8",".",".",".",".","6","."],
 ["8",".",".",".","6",".",".",".","3"],
 ["4",".",".","8",".","3",".",".","1"],
 ["7",".",".",".","2",".",".",".","6"],
 [".","6",".",".",".",".","2","8","."],
 [".",".",".","4","1","9",".",".","5"],
 [".",".",".",".","8",".",".","7","9"]]
Output: true

Example 2:
Input:
[["8","3",".",".","7",".",".",".","."],
 ["6",".",".","1","9","5",".",".","."],
 [".","9","8",".",".",".",".","6","."],
 ["8",".",".",".","6",".",".",".","3"],
 ["4",".",".","8",".","3",".",".","1"],
 ["7",".",".",".","2",".",".",".","6"],
 [".","6",".",".",".",".","2","8","."],
 [".",".",".","4","1","9",".",".","5"],
 [".",".",".",".","8",".",".","7","9"]]
Output: false

Constraints:
- board.length == 9
- board[i].length == 9
- board[i][j] is a digit 1-9 or '.'
*/

public class Solution
{
    public bool IsValidSudoku(char[][] board)
    {
        HashSet<int>[] rows = new HashSet<int>[board[0].Length];
        HashSet<int>[] cols = new HashSet<int>[board[0].Length];
        HashSet<int>[] box = new HashSet<int>[board[0].Length];

        for (int i = 0; i < board[0].Length; i++)
        {
            rows[i] = new HashSet<int>();
            cols[i] = new HashSet<int>();
            box[i] = new HashSet<int>();
        }

        for (int i = 0; i < board[0].Length; i++) {
            for (int j = 0; j < board[0].Length; j++)
            {
                char c = board[i][j];
                if (c == '.') continue;

                int box_index = (i / 3) * 3 + j / 3;

                if (
                    rows[i].Contains(c) ||
                    cols[i].Contains(c) ||
                    box[box_index].Contains(c))
                {
                    return false;
                }

                rows[i].Add(c);
                cols[j].Add(c);
                box[box_index].Add(c);
            }

            return true;
        }

        return false;
    }
}

public class Program
{
    public static void Main()
    {
        char[][] board = new char[][]
        {
            new char[] {'5','3','.','.','7','.','.','.','.'},
            new char[] {'6','.','.','1','9','5','.','.','.'},
            new char[] {'.','9','8','.','.','.','.','6','.'},
            new char[] {'8','.','.','.','6','.','.','.','3'},
            new char[] {'4','.','.','8','.','3','.','.','1'},
            new char[] {'7','.','.','.','2','.','.','.','6'},
            new char[] {'.','6','.','.','.','.','2','8','.'},
            new char[] {'.','.','.','4','1','9','.','.','5'},
            new char[] {'.','.','.','.','8','.','.','7','9'}
        };

        var solution = new Solution();
        bool isValid = solution.IsValidSudoku(board);
        Console.WriteLine("Is Valid Sudoku? " + isValid);
    }
}
