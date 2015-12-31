Given a collection of candidate numbers (C) and a target number (T), 
find all unique combinations in C where the candidate numbers sums to T.

Each number in C may only be used once in the combination.

Note:
- All numbers (including target) will be positive integers.
- Elements in a combination (a1, a2, … , ak) must be in non-descending order. (ie, a1 ≤ a2 ≤ … ≤ ak).
- The solution set must not contain duplicate combinations.

For example, given candidate set 10,1,2,7,6,1,5 and target 8, 
A solution set is: 
[1, 7] 
[1, 2, 5] 
[2, 6] 
[1, 1, 6] 


public class Solution {
    // dfs
    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
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
            if(i > cur && candidates[i] == candidates[i-1]) continue; // same number can appear in next dfs, but not the same iteration
            if(sum + candidates[i] <= target){
                list.Add(candidates[i]);
                Helper(candidates, target, i + 1, sum + candidates[i], list, result); // i + 1: each number only once
                list.RemoveAt(list.Count - 1);
            }
        }
    }
}