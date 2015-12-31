Numbers can be regarded as product of its factors. For example,

8 = 2 x 2 x 2;
  = 2 x 4.
Write a function that takes an integer n and return all possible combinations of its factors.

Note: 
Each combinations factors must be sorted ascending, for example: The factors of 2 and 6 is [2, 6], not [6, 2].
You may assume that n is always positive.
Factors should be greater than 1 and less than n.

Examples: 

input: 1
output: 
[]

input: 37
output: 
[]

input: 12
output:
[
  [2, 6],
  [2, 2, 3],
  [3, 4]
]

input: 32
output:
[
  [2, 16],
  [2, 2, 8],
  [2, 2, 2, 4],
  [2, 2, 2, 2, 2],
  [2, 4, 4],
  [4, 8]
]


public class Solution {
    // dfs, use n/i to be more efficient
    public IList<IList<int>> GetFactors(int n) {
        IList<int> list = new List<int>();
        IList<IList<int>> result = new List<IList<int>>();
        dfs(n, 2, list, result);
        return result;
    }
    
    void dfs(int n, int cur, IList<int> list, IList<IList<int>> result){
        if(n == 1){
            if(list.Count > 1){  // the following algorithm can't exclude itself
                result.Add(new List<int>(list));
            }
            return;
        }
        
        for(int i = cur; i <= n; i++){
            if(n % i == 0){
                list.Add(i);
                dfs(n/i, i, list, result);
                list.RemoveAt(list.Count - 1);
            }
        }
    }
}