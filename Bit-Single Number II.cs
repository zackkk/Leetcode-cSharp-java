Given an array of integers, every element appears three times except for one. Find that single one.

Note:
Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?


public class Solution {
    // 32 bits - sum up 32 bits separately and mod 3 - sign bit doesn't matter
    public int SingleNumber(int[] nums) {
        int result = 0;
        for (int i = 0; i < 32; i++) {
            int sum = 0;
            for (int j = 0; j < nums.Length; j++) {
                sum += nums[j] >> i & 1;
            }
            sum %= 3;
            result += sum << i;
        }
        return result;
    }
}