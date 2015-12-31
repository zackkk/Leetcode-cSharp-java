Follow up for N-Queens problem.

Now, instead outputting board configurations, return the total number of distinct solutions.


public class Solution {
    int count;
    public int TotalNQueens(int n) {
        int[] arr = new int[n]; // a[row] = col;
        count = 0;
        dfs(arr, n, 0);
        return count;
    }
    
    void dfs(int[] arr, int n, int cur){
        if(cur == n){
            count++;
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