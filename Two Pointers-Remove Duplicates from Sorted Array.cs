Given a sorted array, remove the duplicates in place such that each element appear only once and return the new length.

Do not allocate extra space for another array, you must do this in place with constant memory.

For example,
Given input array nums = [1,1,2],

Your function should return length = 2, with the first two elements of nums being 1 and 2 respectively. 
It doesnt matter what you leave beyond the new length.


public class Solution {
    // two pointers
    public int RemoveDuplicates(int[] nums) {
        int j = 0;
        for(int i = 0; i < nums.Length; i++){
            if(i == 0 || nums[i] != nums[i-1]){
                nums[j++] = nums[i];
            }
        }
        return j;
    }
}