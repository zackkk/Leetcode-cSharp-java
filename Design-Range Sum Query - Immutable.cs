Given an integer array nums, find the sum of the elements between indices i and j (i ≤ j), inclusive.

Example:
Given nums = [-2, 0, 3, -5, 2, -1]

sumRange(0, 2) -> 1
sumRange(2, 5) -> -1
sumRange(0, 5) -> -3

Note:
You may assume that the array does not change.
There are many calls to sumRange function.


public class NumArray {
    // Maintain a sum array: sum[i,j] = sum[0,j] - sum[0,i-1]
    
    int[] sums;
    
    public NumArray(int[] nums) {
        sums = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++) {
            sums[i] = (i == 0 ? nums[0] : sums[i-1] + nums[i]); 
        }
    }

    public int SumRange(int i, int j) {
        if (i == 0) return sums[j];
        return sums[j] - sums[i-1];
    }
}


// Your NumArray object will be instantiated and called as such:
// NumArray numArray = new NumArray(nums);
// numArray.SumRange(0, 1);
// numArray.SumRange(1, 2);