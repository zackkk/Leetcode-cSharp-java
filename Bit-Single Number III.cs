Given an array of numbers nums, 
in which exactly two elements appear only once and all the other elements appear exactly twice. 
Find the two elements that appear only once.

For example:

Given nums = [1, 2, 1, 3, 2, 5], return [3, 5].

Note:
The order of the result is not important. So in the above example, [5, 3] is also correct.
Your algorithm should run in linear runtime complexity. 
Could you implement it using only constant space complexity?


public class Solution {
    // XOR all numbers, put its result in "diff" -> there is at least one bit is not zero -> the two numbers differ in those bits
    // Get the last set bit of number "diff", to differciate two numbers
    // Put all numbers into two groups: each group has one of the two numbers using "diff"
    public int[] SingleNumber(int[] nums) {
        int diff = 0;
        for (int i = 0; i < nums.Length; i++) {
            diff ^= nums[i];
        }
        
        int lastSetBit = 1;
        while((lastSetBit & diff) == 0) lastSetBit <<= 1;
        int[] result = new int[2];
        for (int i = 0; i < nums.Length; i++) {
            if ((nums[i] & lastSetBit) != 0) {
                result[0] ^= nums[i];
            }
            else {
                result[1] ^= nums[i];
            }
        }
        return result;
    }
}