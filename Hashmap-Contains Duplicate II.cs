Given an array of integers and an integer k, find out whether there are two distinct indices i and j in the array 
such that nums[i] = nums[j] and the difference between i and j is at most k.


public class Solution {
    // Simple solution: Dictionary save value and its position
    // Improve: maintain a size k window, put them in a set to check duplicates - no set in C# 
    public bool ContainsNearbyDuplicate(int[] nums, int k) {
        Dictionary<int, int> dict = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++){
            if (dict.ContainsKey(nums[i]) &&  (i - dict[nums[i]] <= k)) return true;
            dict[nums[i]] = i; // save only the most recent position, since dist would be shorter
        }
        return false;
    }
}