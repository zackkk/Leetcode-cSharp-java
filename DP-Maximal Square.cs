Given a 2D binary matrix filled with 0's and 1's, find the largest square containing all 1s and return its area.

For example, given the following matrix:

1 0 1 0 0
1 0 1 1 1
1 1 1 1 1
1 0 0 1 0

Return 4.


public class Solution {
    // dp[i,j] represent the edge length of the largest square ENDING at position (i, j)
    // dp values for a 3*3 square:
    // 1 1 1
    // 1 2 2 
    // 1 2 3
    public int MaximalSquare(char[,] matrix) {
        int m = matrix.GetLength(0), n = matrix.GetLength(1);
        int[,] dp = new int[m+1, n+1]; // avoid i-1, j-1 out of index
        int maxEdge = 0;
        for(int i = 1; i <= m; i++){
            for(int j = 1; j <= n; j++){
                if(matrix[i-1, j-1] == '1'){
                    dp[i,j] = Math.Min(Math.Min(dp[i-1,j], dp[i,j-1]), dp[i-1,j-1]) + 1; // 1 is itself is a square of 1*1
                    maxEdge = Math.Max(maxEdge, dp[i,j]);
                }
            }
        }
        return maxEdge * maxEdge;
    }
}