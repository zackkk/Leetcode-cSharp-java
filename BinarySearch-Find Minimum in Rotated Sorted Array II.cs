Suppose a sorted array is rotated at some pivot unknown to you beforehand.

(i.e., 0 1 2 4 5 6 7 might become 4 5 6 7 0 1 2).

Find the minimum element.

The array may contain duplicates.


public class Solution {
    // tricky binary search
    public int FindMin(int[] nums) {
        int low = 0, high = nums.Length - 1;
        while(low < high){
            int mid = low + (high - low) / 2;
            if(nums[mid] > nums[high]){
                low = mid + 1;
            }
            else if(nums[mid] < nums[high]){
                high = mid;
            }
            else{
                high--;
            }
        }
        return nums[low];
    }
}