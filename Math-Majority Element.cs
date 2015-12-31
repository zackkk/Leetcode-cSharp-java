Given an array of size n, find the majority element. 
The majority element is the element that appears more than ⌊ n/2 ⌋ times.

You may assume that the array is non-empty and the majority element always exist in the array.


public class Solution {
    // Moore’s Voting Algorithm. 
    // If we cancel out each occurrence of an element e with all the other elements that are different from e 
    // Then e will exist till end if it is a majority element.
    public int MajorityElement(int[] nums) {
        int major = 0;
        int count = 0;
        for (int i = 0; i < nums.Length; i++) {
            if (count == 0) {
                major = nums[i];
                count = 1;
            }
            else {
                count += (nums[i] == major ? 1 : -1);
            }
        }
        return major;
    }
}