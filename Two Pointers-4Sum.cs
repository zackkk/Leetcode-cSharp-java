Given an array S of n integers, are there elements a, b, c, and d in S such that a + b + c + d = target? 
Find all unique quadruplets in the array which gives the sum of target.

Note:
Elements in a quadruplet (a,b,c,d) must be in non-descending order. (ie, a ≤ b ≤ c ≤ d)
The solution set must not contain duplicate quadruplets.
    For example, given array S = {1 0 -1 0 -2 2}, and target = 0.

    A solution set is:
    (-1,  0, 0, 1)
    (-2, -1, 1, 2)
    (-2,  0, 0, 2)


public class Solution {
    // point: eliminate duplicates after loop; otherwise case like {0,0,0,0} would be treated as invalid
    public IList<IList<int>> FourSum(int[] nums, int target) {
        Array.Sort(nums);
        IList<IList<int>> result = new List<IList<int>>();
        if(nums.Length < 4) return result;
        for(int i = 0; i < nums.Length - 3; i++){
            for(int j = i + 1; j < nums.Length - 2; j++){
                int l = j + 1, r = nums.Length - 1;
                while(l < r){
                    int sum = nums[i] + nums[j] + nums[l] + nums[r];
                    if(sum == target){
                        IList<int> list = new List<int>(){nums[i], nums[j], nums[l], nums[r]};
                        result.Add(list);
                        while(l < r && nums[l] == list[2]) l++;  // eliminate duplicates
                        while(l < r && nums[r] == list[3]) r--;  // eliminate duplicates
                    }
                    else if(sum < target){
                        l++;
                    }
                    else{
                        r--;
                    }
                }
                while(j + 1 < nums.Length && nums[j+1] == nums[j]) j++; // eliminate duplicates
            }
            while(i + 1 < nums.Length && nums[i+1] == nums[i]) i++; // eliminate duplicates
        }
        return result;
    }
}