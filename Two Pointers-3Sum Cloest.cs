Given an array S of n integers, find three integers in S such that the sum is closest to a given number, target. 
Return the sum of the three integers. You may assume that each input would have exactly one solution.

    For example, given array S = {-1 2 1 -4}, and target = 1.

    The sum that is closest to the target is 2. (-1 + 2 + 1 = 2).


public class Solution {
    // two pointers
    public int ThreeSumClosest(int[] nums, int target) {
        Array.Sort(nums);
        int result = nums[0] + nums[1] + nums[2];
        for(int i = 0; i < nums.Length - 2; i++){
            int left = i + 1, right = nums.Length - 1;
            while(left < right) {
                int sum = nums[i] + nums[left] + nums[right]; 
                if(sum < target) left++; else right--;
                if(Math.Abs(sum - target) < Math.Abs(result - target)) result = sum;
            }
        }
        return result;
    }
}