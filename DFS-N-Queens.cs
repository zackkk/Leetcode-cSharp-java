The n-queens puzzle is the problem of placing n queens on an n×n chessboard such that no two queens attack each other.

Given an integer n, return all distinct solutions to the n-queens puzzle.

Each solution contains a distinct board configuration of the n-queens placement, 
where 'Q' and '.' both indicate a queen and an empty space respectively.

For example,
There exist two distinct solutions to the 4-queens puzzle:

[
 [".Q..",  // Solution 1
  "...Q",
  "Q...",
  "..Q."],

 ["..Q.",  // Solution 2
  "Q...",
  "...Q",
  ".Q.."]
]


public class Solution {
    // same as N-Queens II
    IList<IList<string>> result;
    public IList<IList<string>> SolveNQueens(int n) {
        int[] arr = new int[n]; // a[row] = col;
        result = new List<IList<string>>();
        dfs(arr, n, 0);
        return result;
    }
    
    void dfs(int[] arr, int n, int cur){
        if(cur == n){
            List<string> list = new List<string>();
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < n; i++){ sb.Append('.'); }
            for(int i = 0; i < n; i++){
                sb[arr[i]] = 'Q';
                list.Add(sb.ToString());
                sb[arr[i]] = '.'; // reset
            }
            result.Add(list);
            return;
        }
        
        for(int i = 0; i < n; i++){
            if(isValid(arr, cur, i)){ // fill current row with col i
                arr[cur] = i;
                dfs(arr, n, cur + 1);
            }
        }
    }
    
    bool isValid(int[] arr, int row, int col){
        for(int i = 0; i < row; i++){
            if(arr[i] == col) return false;
            if(Math.Abs(arr[i] - col) == Math.Abs(i - row)) return false;
        }
        return true;
    }
}