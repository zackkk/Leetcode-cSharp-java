After robbing those houses on that street, the thief has found himself a new place for his thievery so that 
he will not get too much attention. This time, all houses at this place are arranged in a circle. 
That means the first house is the neighbor of the last one. 
Meanwhile, the security system for these houses remain the same as for those in the previous street.

Given a list of non-negative integers representing the amount of money of each house, 
determine the maximum amount of money you can rob tonight without alerting the police.


public class Solution {
    // break circle into lines to make use of House Robber I
    public int Rob(int[] nums) {
        if(nums.Length == 1) return nums[0];
        // case1: rob the first house, then can't rob the last house
        // case2: don't rob the first house
        return Math.Max(Rob1(nums, 0, nums.Length - 2), Rob1(nums, 1, nums.Length - 1));
    }
    
    int Rob1(int[] nums, int start, int end) {
        int prevYes = 0;
        int prevNo = 0;
        for(int i = start; i <= end; i++){
            // rob current
            int curYes = prevNo + nums[i];
            
            // don't rob current
            int curNo  = Math.Max(prevNo, prevYes);
            
            // update state
            prevYes = curYes;
            prevNo = curNo;
        }
        return Math.Max(prevYes, prevNo);
    }
}