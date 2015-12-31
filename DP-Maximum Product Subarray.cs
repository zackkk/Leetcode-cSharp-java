Find the contiguous subarray within an array (containing at least one number) which has the largest product.

For example, given the array [2,3,-2,4],
the contiguous subarray [2,3] has the largest product = 6.


public class Solution {
    // Three possibilities for the result: max*nums[i], min*nums[i] and nums[i]
    public int MaxProduct(int[] nums) {
        if(nums.Length == 0) return 0;
        
        int maxHere, minHere, maxSoFar = nums[0];
        int prevMax = nums[0], prevMin = nums[0];
        for(int i = 1; i < nums.Length; i++){
            maxHere = Math.Max(Math.Max(prevMax * nums[i], prevMin * nums[i]), nums[i]);
            minHere = Math.Min(Math.Min(prevMax * nums[i], prevMin * nums[i]), nums[i]);
            maxSoFar = Math.Max(maxSoFar, maxHere);
            prevMax = maxHere;
            prevMin = minHere;
        }
        return maxSoFar;
    }
}