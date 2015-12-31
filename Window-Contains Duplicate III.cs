Given an array of integers, find out whether there are two distinct indices i and j in the array 
such that the difference between nums[i] and nums[j] is at most t and the difference between i and j is at most k.


public class Solution {
    // maintain size k window
    // sorted set has logK for indexing
    public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t) {
        if (nums.Length == 0 || k < 0 || t < 0) return false;
        SortedSet<long> ss = new SortedSet<long>();  // doesn't have duplicates
        Dictionary<int, int> dict = new Dictionary<int, int>(); // complement duplicates for SortedSet
        for (int i = 0; i < nums.Length; i++) {
            ss.Add(nums[i]);
            dict[nums[i]] = dict.ContainsKey(nums[i]) ? dict[nums[i]] + 1 : 1;
            if (i > k) {
                int num = nums[i - k - 1];
                if (--dict[num] == 0) ss.Remove(num);
            }

            // check if the current nums[i] can find a pair within range [nums[i]-t, nums[i]+t]
            long lower = Math.Min((long)nums[i] - t, (long)nums[i] + t), upper = Math.Max((long)nums[i] - t, (long)nums[i] + t);
            int count = 0;
            foreach (int num in ss.GetViewBetween(lower, upper)) {
                count += dict[num];
            }
            if (count > 1) return true;
        }
        return false;
    }
}