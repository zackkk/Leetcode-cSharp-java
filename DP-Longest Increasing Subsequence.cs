Given an unsorted array of integers, find the length of longest increasing subsequence.

For example,
Given [10, 9, 2, 5, 3, 7, 101, 18],
The longest increasing subsequence is [2, 3, 7, 101], therefore the length is 4. 
Note that there may be more than one LIS combination, it is only necessary for you to return the length.

Your algorithm should run in O(n2) complexity.
Follow up: Could you improve it to O(n log n) time complexity?


public class Solution {
    // classic DP problem - dp[i] = max{dp[j] + 1} if nums[j] < nums[i] && 0 <= j < i
    // Ignore O(NLogN) - too trouble
    public int LengthOfLIS(int[] nums) {
        int n = nums.Length, result = 0;
        int[] dp = new int[n];
        for(int i = 0; i < n; i++){
            dp[i] = 1; // itself has length 1
            for(int j = 0; j < i; j++){
                if(nums[i] > nums[j]) {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
            result = Math.Max(result, dp[i]);
        }
        return result;
    }
}