Given a collection of integers that might contain duplicates, nums, return all possible subsets.

Note:
Elements in a subset must be in non-descending order.
The solution set must not contain duplicate subsets.
For example,
If nums = [1,2,2], a solution is:

[
  [2],
  [1],
  [1,2,2],
  [2,2],
  [1,2],
  []
]


public class Solution {
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        Array.Sort(nums);
        IList<int> list = new List<int>();
        IList<IList<int>> result = new List<IList<int>>();
        dfs(nums, 0, list, result);
        return result;
    }
    
    void dfs(int[] nums, int cur, IList<int> list, IList<IList<int>> result){
        result.Add(new List<int>(list));
        for(int i = cur; i < nums.Length; i++){
            if(i == cur || nums[i] != nums[i-1]){ // difference from Subsets I
                list.Add(nums[i]);
                dfs(nums, i+1, list, result);
                list.RemoveAt(list.Count-1);
            }
        }
        
    }
}