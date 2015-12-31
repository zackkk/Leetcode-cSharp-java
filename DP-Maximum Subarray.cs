Find the contiguous subarray within an array (containing at least one number) which has the largest sum.

For example, given the array [−2,1,−3,4,−1,2,1,−5,4],
the contiguous subarray [4,−1,2,1] has the largest sum = 6.


public class Solution {
    // similar to "Maximum Product Subarray"
    public int MaxSubArray(int[] nums) {
        int maxSoFar = int.MinValue;
        int maxHere = 0;
        for(int i = 0; i < nums.Length; i++){
            maxHere = Math.Max(maxHere + nums[i], nums[i]);
            maxSoFar = Math.Max(maxSoFar, maxHere);
        }
        return maxSoFar;
    }
}