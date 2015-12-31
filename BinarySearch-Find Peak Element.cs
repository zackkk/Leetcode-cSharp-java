A peak element is an element that is greater than its neighbors.

Given an input array where num[i] ≠ num[i+1], find a peak element and return its index.

The array may contain multiple peaks, in that case return the index to any one of the peaks is fine.

You may imagine that num[-1] = num[n] = -∞.

For example, in array [1, 2, 3, 1], 3 is a peak element and your function should return the index number 2.


public class Solution {
    // There are 4 different cases: a[0...n-1]
    // the highest point: a[m-1] < a[m] > a[m+1] -> found the peak
    // the lowest point: a[m-1] > a[m] < a[m+1] -> both sides have peak
    // the increasing: a[m-1] < a[m] < a[m+1] -> peak is in a[m+1] ... a[n-1]
    // the decreasing: a[m-1] > a[m] > a[m+1] -> peak is in a[0] ... a[m-1]
    public int FindPeakElement(int[] nums) {
        int low = 0, high = nums.Length - 1;
        while(low <= high) {
            if(low == high) return low;
            if(low + 1 == high) return (nums[low] > nums[high] ? low : high);
            
            int mid = low + (high - low) / 2;
            if(nums[mid] > nums[mid-1] && nums[mid] > nums[mid+1]){ // the highest
                return mid;
            }
            else if(nums[mid] < nums[mid-1] && nums[mid] < nums[mid+1]){ // the lowest: can choose any side
                low = mid + 1;
            }
            else if(nums[mid] > nums[mid - 1] && nums[mid] < nums[mid+1]){ // increasing
                low = mid + 1;
            }
            else { // decreasing
                high = mid - 1;
            }
        }
        return 0;
    }
}