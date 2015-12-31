Implement next permutation, which rearranges numbers into the lexicographically next greater permutation of numbers.

If such arrangement is not possible, it must rearrange it as the lowest possible order (ie, sorted in ascending order).

The replacement must be in-place, do not allocate extra memory.

Here are some examples. Inputs are in the left-hand column and its corresponding outputs are in the right-hand column.
1,2,3 → 1,3,2
3,2,1 → 1,2,3
1,1,5 → 1,5,1


public class Solution {
    // step1: find decrease from the end: 2 (3) 6 5 4 1
    // step2: find the first greater from right then swap: 2 (3) 6 5 (4) 1  ->  2 (4) 6 5 (3) 1
    // stpe3: reverse the right part: 2 4 (1 3 5 6)
    public void NextPermutation(int[] nums) {
        for(int i = nums.Length - 2; i >= 0; i--){
            if(nums[i] < nums[i+1]){
                for(int j = nums.Length - 1; j > i; j--){
                    if(nums[j] > nums[i]){
                        Swap(nums, i, j);
                        Reverse(nums, i+1, nums.Length-1);
                        return;
                    }
                }
            }
        }
        Reverse(nums, 0, nums.Length-1); // 6,5,4,3,2,1
    }
    void Swap(int[] nums, int i, int j){
        int tmp = nums[i];
        nums[i] = nums[j];
        nums[j] = tmp;
    }
    void Reverse(int[] nums, int i, int j){
        for( ; i < j; i++, j--){
            Swap(nums, i, j);
        }
    }
    
}