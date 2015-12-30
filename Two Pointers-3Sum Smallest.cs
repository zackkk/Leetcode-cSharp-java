Given an array of n integers nums and a target, find the number of index triplets i, j, k with 0 <= i < j < k < n 
that satisfy the condition nums[i] + nums[j] + nums[k] < target.

For example, given nums = [-2, 0, 1, 3], and target = 2.

Return 2. Because there are two triplets which sums are less than 2:

[-2, 0, 1]
[-2, 0, 3]


public class Solution {
    // two pointers
    public int ThreeSumSmaller(int[] nums, int target) {
        Array.Sort(nums);
        int sum = 0;
        for(int i = 0; i < nums.Length - 2; i++){
            int left = i + 1, right = nums.Length - 1;
            while(left < right){
                if(nums[i] + nums[left] + nums[right] < target){
                    sum += (right - left);
                    left++;
                }
                else {
                    right--;   
                }
            }
        }
        return sum;
    }
}