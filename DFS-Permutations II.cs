Given a collection of numbers that might contain duplicates, return all possible unique permutations.

For example,
[1,1,2] have the following unique permutations:
[1,1,2], [1,2,1], and [2,1,1].


public class Solution {
    // different idea from Permutations I
    // to avoid duplicates, [1, 1], the second "1" can be visited as long as the first "1" has been visited
    public IList<IList<int>> PermuteUnique(int[] nums) {
        Array.Sort(nums);
        IList<IList<int>> result = new List<IList<int>>();
        IList<int> list = new List<int>();
        bool[] visited = new bool[nums.Length];
        Helper(nums, visited, list, result);
        return result;
    }
    void Helper(int[] nums, bool[] visited, IList<int> list, IList<IList<int>> result) {
        if (list.Count == nums.Length) {
            result.Add(new List<int>(list));
            return;
        }
        for (int i = 0; i < nums.Length; i++) {
            // same elements must be visited in order
            if(visited[i] || (i > 0 && nums[i] == nums[i-1] && visited[i-1] == false)){ continue; }
            visited[i] = true;
            list.Add(nums[i]);
            Helper(nums, visited, list, result);
            list.RemoveAt(list.Count - 1);
            visited[i] = false;
        }
    }
}