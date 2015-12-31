Follow up for "Remove Duplicates":
What if duplicates are allowed at most twice?

For example,
Given sorted array nums = [1,1,1,2,2,3],

Your function should return length = 5, with the first five elements of nums being 1, 1, 2, 2 and 3. 
It doesnt matter what you leave beyond the new length.


public class Solution {
    // elegant two pointers
    public int RemoveDuplicates(int[] nums) {
        int j = 0;
        for(int i = 0; i < nums.Length; i++){
            if(j < 2 || nums[i] > nums[j-2]){
                nums[j++] = nums[i];
            }
        }
        return j;
    }
}