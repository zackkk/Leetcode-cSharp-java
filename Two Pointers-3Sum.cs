Given an array S of n integers, are there elements a, b, c in S such that a + b + c = 0? Find all unique triplets in the array which gives the sum of zero.

Note:
Elements in a triplet (a,b,c) must be in non-descending order. (ie, a ≤ b ≤ c)
The solution set must not contain duplicate triplets.
    For example, given array S = {-1 0 1 2 -1 -4},

    A solution set is:
    (-1, 0, 1)
    (-1, -1, 2)


public class Solution {
    // two pointers
    public IList<IList<int>> ThreeSum(int[] nums) {
        IList<IList<int>> result = new List<IList<int>>();
        Array.Sort(nums);
        for(int i = 0; i < nums.Length - 2; i++){
            if(i > 0 && nums[i] == nums[i-1]) continue; // avoid duplicates
            int left = i + 1, right = nums.Length - 1;
            while(left < right){
                if(nums[i] + nums[left] + nums[right] == 0){
                    List<int> list = new List<int>{nums[i], nums[left], nums[right]};
                    result.Add(list);
                    left++;
                    right--;
                    while(left < right && nums[left] == nums[left-1]) left++; // avoid duplicates
                    while(left < right && nums[right] == nums[right+1]) right--; // avoid duplicates
                }
                else if(nums[i] + nums[left] + nums[right] < 0){
                    left++;
                }
                else{
                    right--;
                }
            }
        }
        return result;
    }
}