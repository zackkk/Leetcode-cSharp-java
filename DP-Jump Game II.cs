Given an array of non-negative integers, you are initially positioned at the first index of the array.

Each element in the array represents your maximum jump length at that position.

Your goal is to reach the last index in the minimum number of jumps.

For example:
Given array A = [2,3,1,1,4]

The minimum number of jumps to reach the last index is 2. (Jump 1 step from index 0 to 1, then 3 steps to the last index.)

Note:
You can assume that you can always reach the last index.


public class Solution {
    // maintain two status: max_dist, next_max_dist
    public int Jump(int[] nums) {
        if(nums.Length == 0) return 0;
        int max_dist = 0, next_max_dist = nums[0], steps = 0;
        for(int i = 0; i < nums.Length; i++){
            if(max_dist < i){
                max_dist = next_max_dist;
                steps++;
            }
            next_max_dist = Math.Max(next_max_dist, nums[i] + i);
        }
        return steps;
    }
}