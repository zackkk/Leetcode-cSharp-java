According to the Wikipedias article: "The Game of Life, also known simply as Life, 
is a cellular automaton devised by the British mathematician John Horton Conway in 1970."

Given a board with m by n cells, each cell has an initial state live (1) or dead (0). 
Each cell interacts with its eight neighbors (horizontal, vertical, diagonal) using the following four rules:

Any live cell with fewer than two live neighbors dies, as if caused by under-population.
Any live cell with two or three live neighbors lives on to the next generation.
Any live cell with more than three live neighbors dies, as if by over-population..
Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.

Write a function to compute the next state (after one update) of the board given its current state.


public class Solution {
    // Need to record both the current state and next state
    // live cell < 2 || > 3 => 1 -> 0   => 2
    // live cell = 2 || 3   => 1 -> 1   => 1
    // live cell = 3        => 0 -> 1   => 3
    public void GameOfLife(int[,] board) {
        int[,] a = {{-1, -1}, {-1, 0}, {-1, 1}, 
                    { 0, -1}, { 0, 1}, 
                    { 1, -1}, { 1, 0}, { 1, 1}};
        int m = board.GetLength(0), n = board.GetLength(1);
        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                int live = 0;
                for(int k = 0; k < 8; k++){   // check 8 directions
                    int rowDiff = a[k,0], colDiff = a[k,1];
                    if(i + rowDiff >= 0 && i + rowDiff < m && j + colDiff >= 0 && j + colDiff < n){
                        if(board[i + rowDiff, j + colDiff] == 1) live++;  // previous state is live
                        if(board[i + rowDiff, j + colDiff] == 2) live++;
                    }
                }
                if(board[i,j] == 0 && live == 3) board[i,j] = 3;
                if(board[i,j] == 1 && (live < 2 || live > 3)) board[i,j] = 2;
            }
        }
        
        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                board[i,j] %= 2;
            }
        }
    }
}