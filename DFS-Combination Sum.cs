Given a set of candidate numbers (C) and a target number (T), 
find all unique combinations in C where the candidate numbers sums to T.

The same repeated number may be chosen from C unlimited number of times.

Note:
- All numbers (including target) will be positive integers.
- Elements in a combination (a1, a2, … , ak) must be in non-descending order. (ie, a1 ≤ a2 ≤ … ≤ ak).
- The solution set must not contain duplicate combinations.

For example, given candidate set 2,3,6,7 and target 7, 
A solution set is: 
[7] 
[2, 2, 3] 


public class Solution {
    // dfs
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        Array.Sort(candidates);
        IList<IList<int>> result = new List<IList<int>>();
        IList<int> list = new List<int>();
        Helper(candidates, target, 0, 0, list, result);
        return result;
    }
    
    void Helper(int[] candidates, int target, int cur, int sum, IList<int> list, IList<IList<int>> result){
        if(sum == target){
            result.Add(new List<int>(list));
            return;
        }
        
        for(int i = cur; i < candidates.Length; i++){
            if(sum + candidates[i] <= target){
                list.Add(candidates[i]);
                Helper(candidates, target, i, sum + candidates[i], list, result);
                list.RemoveAt(list.Count - 1);
            }
        }
    }
}