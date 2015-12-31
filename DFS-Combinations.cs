Given two integers n and k, return all possible combinations of k numbers out of 1 ... n.

For example,
If n = 4 and k = 2, a solution is:

[
  [2,4],
  [3,4],
  [2,3],
  [1,2],
  [1,3],
  [1,4],
]


public class Solution {
    public IList<IList<int>> Combine(int n, int k) {
        IList<int> list = new List<int>();
        IList<IList<int>> result = new List<IList<int>>();
        dfs(n, k, 1, list, result);
        return result;
    }
    
    void dfs(int n, int k, int cur, IList<int> list, IList<IList<int>> result){
        if(list.Count == k){
            result.Add(new List<int>(list));
            return;
        }
        for(int i = cur; i <= n; i++){
            if(list.Count == 0 || i > list[list.Count - 1]){
                list.Add(i);
                dfs(n, k, i+1, list, result);
                list.RemoveAt(list.Count-1);
            }
        }
    }
}