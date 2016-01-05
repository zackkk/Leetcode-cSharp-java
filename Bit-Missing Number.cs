Given an array containing n distinct numbers taken from 0, 1, 2, ..., n, find the one that is missing from the array.

For example,
Given nums = [0, 1, 3] return 2.

Note:
Your algorithm should run in linear runtime complexity. 
Could you implement it using only constant extra space complexity?


public class Solution {
    // XOR - use index to make numbers appear twice except the missing one
    //   0 1 2 4 5 6
    // - 0 1 2 3 4 5  -> 3 ^ 6 -> need to ^ 6, which is the last index
    //   0 1 2 3
    // - 0 1 2 3  -> need to ^ 4, which is the last index
    public int MissingNumber(int[] nums) {
        int result = 0;
        int i = 0;
        for ( ; i < nums.Length; i++) {
            result = result ^ nums[i] ^ i;
        }
        return result ^ i;
    }
}