Given an array with n objects colored red, white or blue, 
sort them so that objects of the same color are adjacent, with the colors in the order red, white and blue.

Here, we will use the integers 0, 1, and 2 to represent the color red, white, and blue respectively.

Note:
You are not suppose to use the librarys sort function for this problem.


public class Solution {
    // three pointers: put zeros at left and twos at the right, what left over are ones 
    public void SortColors(int[] nums) {
        int i = 0, zero = 0, two = nums.Length - 1;
        while (i <= two) {
            if(nums[i] == 0 && nums[zero] == 0){
                zero++;
                i++;
            }
            else if (nums[i] == 0 && nums[zero] != 0){
                Swap(nums, i, zero);
                zero++;
            }
            else if(nums[i] == 1){
                i++;
            }
            else{
                Swap(nums, i, two);
                two--;
            }
        }
    }
    
    void Swap(int[] nums, int a, int b) {
        int tmp = nums[a];
        nums[a] = nums[b];
        nums[b] = tmp;
    }
}