Write a program to solve a Sudoku puzzle by filling the empty cells.

Empty cells are indicated by the character '.'.

You may assume that there will be only one unique solution.


public class Solution {
    // dfs - like 8 queens - return true/false to prune
    public void SolveSudoku(char[,] board) {
        dfs(board, 0, 0);
    }
    
    bool dfs(char[,] board, int row, int col){
        if(col == 9) return dfs(board, row + 1, 0); // next row
        if(row == 9) return true;
        
        if(board[row, col] != '.') return dfs(board, row, col + 1);
        else{
            for(char val = '1'; val <= '9'; val++){
                if(isValid(board, row, col, val)){
                    board[row, col] = val;
                    if(dfs(board, row, col + 1)) return true;
                    board[row, col] = '.';
                }
            }
            return false;
        }
    }
    
    bool isValid(char[,] board, int row, int col, char val){
        for(int i = 0; i < 9; i++) { if(board[i, col] == val) return false; }
        for(int j = 0; j < 9; j++) { if(board[row, j] == val) return false; }
        for(int i = row/3*3; i < row/3*3 + 3; i++){
            for(int j = col/3*3; j < col/3*3 + 3; j++){
                if(board[i,j] == val) return false;
            }
        }
        
        return true;
    }
}