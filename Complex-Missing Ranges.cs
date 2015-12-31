Given a sorted integer array where the range of elements are [lower, upper] inclusive, return its missing ranges.

For example, given [0, 1, 3, 50, 75], lower = 0 and upper = 99, return ["2", "4->49", "51->74", "76->99"].


public class Solution {
    // many cases
    public IList<string> FindMissingRanges(int[] nums, int lower, int upper) {
        IList<string> result = new List<string>();
        int n = nums.Length;
        
        // special case
        if(n == 0){
            result.Add(GenerateRange(lower, upper));
            return result;
        }

        if(lower < nums[0]){
            result.Add(GenerateRange(lower, nums[0] - 1));
        }
        for(int i = 1; i < n; i++){
            if(nums[i] - nums[i - 1] > 1){
                result.Add(GenerateRange(nums[i-1] + 1, nums[i] - 1));
            }
        }
        if(nums[n-1] < upper){
            result.Add(GenerateRange(nums[n-1] + 1, upper));
        }
        return result;
    }
    
    string GenerateRange(int start, int end){
        if(start == end) return start.ToString();
        return start.ToString() + "->" + end.ToString();
    }
}