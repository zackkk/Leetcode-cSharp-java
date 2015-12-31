Given a 2D board containing 'X' and 'O', capture all regions surrounded by 'X'.

A region is captured by flipping all 'O's into 'X's in that surrounded region.

For example,
X X X X
X O O X
X X O X
X O X X
After running your function, the board should be:

X X X X
X X X X
X X X X
X O X X


public class Solution {
    // "O" starts from edges won't be flipped
    public void Solve(char[,] board) {
        int m = board.GetLength(0);
        if(m == 0) return;
        int n = board.GetLength(1);
        for(int i = 0; i < m; i++){
            if(board[i, 0] == 'O')   dfs(board, i, 0);
            if(board[i, n - 1] == 'O') dfs(board, i, n - 1);
        }
        for(int j = 0; j < n; j++){
            if(board[0, j] == 'O')   dfs(board, 0, j);
            if(board[m - 1, j] == 'O') dfs(board, m - 1, j);
        }
        
        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                board[i, j] = board[i, j] == 'M' ? 'O' : 'X';
            }
        }
    }
    
    void dfs(char[,] board, int row, int col){
        if(row < 0 || row >= board.GetLength(0)) return;
        if(col < 0 || col >= board.GetLength(1)) return;
        if(board[row, col] != 'O') return;
        board[row, col] = 'M';
        dfs(board, row - 1, col);
        dfs(board, row + 1, col);
        if(col > 1) dfs(board, row, col - 1);  // there is a strange test case which required adding "if(col > 1) ..."
        dfs(board, row, col + 1);
    }
}