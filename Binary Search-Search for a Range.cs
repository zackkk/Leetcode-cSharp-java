Given a sorted array of integers, find the starting and ending position of a given target value.

Your algorithms runtime complexity must be in the order of O(log n).

If the target is not found in the array, return [-1, -1].

For example,
Given [5, 7, 7, 8, 8, 10] and target value 8,
return [3, 4].


public class Solution {
    // embeded binary search
    public int[] SearchRange(int[] nums, int target) {
        int[] range = {nums.Length, -1};
        Helper(nums, target, 0, nums.Length-1, range);
        if(range[0] > range[1]) range[0] = -1;
        return range;
    }
    
    void Helper(int[] nums, int target, int start, int end, int[] range){
        if(start > end) return;
        int mid = start + (end - start) / 2;
        if(nums[mid] == target){
            if(mid < range[0]){
                range[0] = mid;
                Helper(nums, target, start, mid - 1, range);
            }
            if(mid > range[1]){
                range[1] = mid;
                Helper(nums, target, mid + 1, end, range);
            }
        }
        else if(nums[mid] > target){
            Helper(nums, target, start, mid - 1, range);
        }
        else{
            Helper(nums, target, mid + 1, end, range);
        }
    }
}