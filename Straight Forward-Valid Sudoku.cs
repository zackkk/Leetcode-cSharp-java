Determine if a Sudoku is valid, according to: Sudoku Puzzles - The Rules.

The Sudoku board could be partially filled, where empty cells are filled with the character '.'.


public class Solution {
    // row[rowNum][digit]
    public bool IsValidSudoku(char[,] board) {
        bool[,] row = new bool[9, 9];
        bool[,] col = new bool[9, 9];
        bool[,] blk = new bool[9, 9];
        for (int i = 0; i < 9; i++) {
            for (int j = 0; j < 9; j++) {
                if (board[i,j] == '.') continue;
                int digit = board[i,j] - '1';
                int k = i / 3 * 3 + j / 3;
                if (row[i,digit]) return false;
                if (col[j,digit]) return false;
                if (blk[k,digit]) return false;
                row[i,digit] = true;
                col[j,digit] = true;
                blk[k,digit] = true;
            }
        }
        return true;
    }
}