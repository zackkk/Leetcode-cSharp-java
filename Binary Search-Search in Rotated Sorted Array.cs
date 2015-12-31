Suppose a sorted array is rotated at some pivot unknown to you beforehand.

(i.e., 0 1 2 4 5 6 7 might become 4 5 6 7 0 1 2).

You are given a target value to search. If found in the array return its index, otherwise return -1.

You may assume no duplicate exists in the array.


public class Solution {
    public int Search(int[] nums, int target) {
        int low = 0, high = nums.Length - 1;
        while(true){
            if(low > high) return -1;
            int mid = low + (high - low) / 2;
            if(nums[mid] == target) return mid;
            
            if(nums[low] <= nums[mid]){  // left half is sorted
                if(target >= nums[low] && target <= nums[mid]){
                    high = mid - 1;
                }
                else {
                    low = mid + 1;
                }
            }
            else{  // right half is sorted
                if(target >= nums[mid] && target <= nums[high]){
                    low = mid + 1;
                }
                else {
                    high = mid - 1;
                }
            }
        　  
        }
    }
}