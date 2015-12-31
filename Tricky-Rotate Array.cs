Rotate an array of n elements to the right by k steps.

For example, with n = 7 and k = 3, the array [1,2,3,4,5,6,7] is rotated to [5,6,7,1,2,3,4].


public class Solution {
    // Array.Reverse(Array, Index, Length)
    // 1,2,3,4,5,6,7
    // 7,6,5,4,3,2,1
    // 5,6,7,4,3,2,1
    // 5,6,7,1,2,3,4
    public void Rotate(int[] nums, int k) {
        int n = nums.Length;
        // k may be greater than n, transfer it to k % n
        Array.Reverse(nums, 0, n);
        Array.Reverse(nums, 0, k % n);  
        Array.Reverse(nums, k % n, n - k % n);
    }
}