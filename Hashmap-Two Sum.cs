public class Solution {
    // dictionary
    public int[] TwoSum(int[] nums, int target) {
        int[] result = new int[2];
        Dictionary<int, int> dict = new Dictionary<int, int>();
        for(int i = 0; i < nums.Length; i++){
            if(dict.ContainsKey(target - nums[i])){
                result[0] = dict[target-nums[i]];
                result[1] = i + 1; // not zero based
                return result;
            }
            dict[nums[i]] = i + 1;
        }
        return result;
    }
}