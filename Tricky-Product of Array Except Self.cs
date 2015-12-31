Given an array of n integers where n > 1, nums, 
return an array output such that output[i] is equal to the product of all the elements of nums except nums[i].

Solve it without division and in O(n).

For example, given [1,2,3,4], return [24,12,8,6].


public class Solution {
    // idea: product of numbers before * product of numbers after
    public int[] ProductExceptSelf(int[] nums) {
        int[] result = new int[nums.Length];
        int prevProduct = 1;
        for (int i = 0; i < nums.Length; i++) {
            result[i] = prevProduct;
            prevProduct *= nums[i];
        }
        int afterProduct = 1;
        for (int i = nums.Length - 1; i >= 0; i--) {
            result[i] *= afterProduct;
            afterProduct *= nums[i];
        }
        return result;
    }
}