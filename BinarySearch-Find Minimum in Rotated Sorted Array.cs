Suppose a sorted array is rotated at some pivot unknown to you beforehand.

(i.e., 0 1 2 4 5 6 7 might become 4 5 6 7 0 1 2).

Find the minimum element.

You may assume no duplicate exists in the array.


public class Solution {
    // binary search, min will be on non-sorted half
    public int FindMin(int[] nums) {
        int low = 0, high = nums.Length - 1;
        while(low < high) {
            if (nums[low] < nums[high]) return nums[low]; // not rotated
            int mid = low + (high - low) / 2;
            
            if (nums[low] <= nums[mid]) low = mid + 1; // left side is sorted, min will be on the right side
            else high = mid; // right side is sorted, min will be on the left side
        }
        return nums[low];
    }
}