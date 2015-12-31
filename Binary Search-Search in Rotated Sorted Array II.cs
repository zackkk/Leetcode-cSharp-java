Follow up for "Search in Rotated Sorted Array":

What if duplicates are allowed?

Would this affect the run-time complexity? How and why?

Write a function to determine if a given target is in the array.


public class Solution {
    public bool Search(int[] nums, int target) {
        int low = 0, high = nums.Length - 1;
        while(true){
            if(low > high) return false;
            int mid = low + (high - low) / 2;
            if(nums[mid] == target) return true;
            
            if(nums[low] < nums[mid]){  // left half is sorted
                if(target >= nums[low] && target <= nums[mid]){
                    high = mid - 1;
                }
                else {
                    low = mid + 1;
                }
            }
            else if(nums[mid] == nums[low]){
                low++;
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