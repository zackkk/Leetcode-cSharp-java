Given a sorted integer array without duplicates, return the summary of its ranges.

For example, given [0,1,2,4,5,7], return ["0->2","4->5","7"].


public class Solution {
    // straight forward implementation
    public IList<string> SummaryRanges(int[] nums) {
        IList<string> ranges = new List<string>();
        for (int i = 0; i < nums.Length; i++) {
            int start = i;
            while (i + 1 < nums.Length && nums[i] + 1 == nums[i+1]) { i++; }
            if(nums[i] == nums[start]) {
                ranges.Add(nums[i].ToString());
            }
            else {
                ranges.Add(nums[start].ToString() + "->" + nums[i].ToString());   
            }
        }
        return ranges;
    }
}