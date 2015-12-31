Given a 2D board and a word, find if the word exists in the grid.

The word can be constructed from letters of sequentially adjacent cell, 
where "adjacent" cells are those horizontally or vertically neighboring. 
The same letter cell may not be used more than once.

For example,
Given board =
[
  ['A','B','C','E'],
  ['S','F','C','S'],
  ['A','D','E','E']
]
word = "ABCCED", -> returns true,
word = "SEE", -> returns true,
word = "ABCB", -> returns false.


public class Solution {
    // dfs
    public bool Exist(char[,] board, string word) {
        int m = board.GetLength(0), n = board.GetLength(1);
        bool[,] visited = new bool[m,n];
        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                if(board[i,j] == word[0]){
                    if(dfs(board, visited, word, i, j, 0)) return true;
                }
            }
        }
        return false;
    }
    
    bool dfs(char[,] board, bool[,] visited, string word, int row, int col, int cur){
        if(row < 0 || row >= board.GetLength(0)) return false;
        if(col < 0 || col >= board.GetLength(1)) return false;
        if(cur == word.Length) return false;
        if(board[row, col] != word[cur] || visited[row, col]) return false;
        if(cur == word.Length - 1) return true;
    
        visited[row, col] = true;
        if(dfs(board, visited, word, row-1, col, cur+1) || 
           dfs(board, visited, word, row+1, col, cur+1) || 
           dfs(board, visited, word, row, col-1, cur+1) || 
           dfs(board, visited, word, row, col+1, cur+1)) return true;
        visited[row, col] = false; // reset
        return false;
    }
}