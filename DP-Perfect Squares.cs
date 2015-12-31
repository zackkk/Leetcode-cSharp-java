Given a positive integer n, find the least number of perfect square numbers (for example, 1, 4, 9, 16, ...) which sum to n.

For example, 
given n = 12, return 3 because 12 = 4 + 4 + 4; given n = 13, return 2 because 13 = 4 + 9.


public class Solution {
    // dp
    // dp[i] = Min{ dp[n - j*j] + 1 }
    public int NumSquares(int n) {
        int[] dp = new int[n+1];
        for(int i = 1; i <= n; i++){
            dp[i] = int.MaxValue;
            for(int j = 1; i-j *j >= 0; j++){
                dp[i] = Math.Min(dp[i], dp[i-j*j] + 1);
            }
        }
        return dp[n];
    }
}