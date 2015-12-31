Given an unsorted integer array, find the first missing positive integer.

For example,
Given [1,2,0] return 3,
and [3,4,-1,1] return 2.

Your algorithm should run in O(n) time and uses constant space.


public class Solution {
    // use the array itself as a hash table -> turn a[i] to be negative if there exists i
    public int FirstMissingPositive(int[] nums) {
        int n = nums.Length;
        for(int i = 0; i < n; i++){
            if(nums[i] <= 0) nums[i] = n + 10; // exclude non-positive numbers
        }

        for(int i = 0; i < n; i++){
            int index = Math.Abs(nums[i]) - 1;  // nums[i] maybe flipped
            if(index >= 0 && index < n && nums[index] > 0) nums[index] = -nums[index]; // flip only once
        }
        
        for(int i = 0; i < n; i++){
            if(nums[i] > 0) return i + 1;
        }
        return n + 1;
    }
}