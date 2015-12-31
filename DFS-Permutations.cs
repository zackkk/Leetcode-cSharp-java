Given a collection of distinct numbers, return all possible permutations.

For example,
[1,2,3] have the following permutations:
[1,2,3], [1,3,2], [2,1,3], [2,3,1], [3,1,2], and [3,2,1].


public class Solution {
    // [1] + permutaions of [1..n] except 1
    // [2] + permutaions of [1..n] except 2
    public IList<IList<int>> Permute(int[] nums) {
        IList<IList<int>> result = new List<IList<int>>();
        Helper(0, nums, result);
        return result;
    }
    void Helper(int start, int[] nums, IList<IList<int>> result) {
        if (start == nums.Length) {
            result.Add(new List<int>(nums));
            return;
        }
        for (int i = start; i < nums.Length; i++) {
            Swap(nums, start, i);
            Helper(start + 1, nums, result);
            Swap(nums, start, i); // reset
        }
    }
    void Swap(int[] nums, int a, int b) {
        int tmp = nums[a];
        nums[a] = nums[b];
        nums[b] = tmp;
    }
}