Given an array and a value, remove all instances of that value in place and return the new length.

The order of elements can be changed. It doesnt matter what you leave beyond the new length.


public class Solution {
    // two pointers
    public int RemoveElement(int[] nums, int val) {
        int j = 0;
        for (int i = 0; i < nums.Length; i++){
            if(nums[i] != val){
                nums[j] = nums[i];
                j++;
            }
        }
        return j;
    }
}