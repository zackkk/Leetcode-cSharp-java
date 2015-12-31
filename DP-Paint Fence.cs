There is a fence with n posts, each post can be painted with one of the k colors.

You have to paint all the posts such that no more than two adjacent fence posts have the same color.

Return the total number of ways you can paint the fence.


public class Solution {
    // dp: either paint same color with the previous or different with the previous
    public int NumWays(int n, int k) {
        if(k == 0 || n == 0) return 0;
        int[] dp = new int[n];
        for(int i = 0; i < n; i++){
            if(i == 0) dp[i] = k;  // paint one fence
            else if(i == 1) dp[i] = k * k; // paint two fences
            else {
                // if paint the current & previous with same color, this color needs to be different from dp[i-2] -> k-1 choices
                // if paint the current & previous with different color, this color needs to be differrent from dp[i-1] -> k-1 choices
                dp[i] = dp[i-2] * (k-1) + dp[i-1] * (k-1);
            }
        }
        return dp[n-1];
    }
}