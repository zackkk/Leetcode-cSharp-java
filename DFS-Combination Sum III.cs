Find all possible combinations of k numbers that add up to a number n, 
given that only numbers from 1 to 9 can be used and each combination should be a unique set of numbers.

Ensure that numbers within the set are sorted in ascending order.

Example 1:
Input: k = 3, n = 7
Output:
[[1,2,4]]

Example 2:
Input: k = 3, n = 9
Output:
[[1,2,6], [1,3,5], [2,3,4]]


public class Solution {
    public IList<IList<int>> CombinationSum3(int k, int n) {
        IList<int> list = new List<int>();
        IList<IList<int>> result = new List<IList<int>>();
        dfs(k, n, 1, list, result);
        return result;
    }
    
    void dfs(int k, int n, int cur, IList<int> list, IList<IList<int>> result){
        if(list.Count == k){
            int sum = 0;
            foreach(int i in list) sum += i;
            if(sum == n) result.Add(new List<int>(list));
            return;
        }
        for(int i = cur; i <= 9; i++){
            if(list.Count == 0 || i > list[list.Count - 1]){
                list.Add(i);
                dfs(k, n, i+1, list, result);
                list.RemoveAt(list.Count - 1);
            }
        }
    }
}