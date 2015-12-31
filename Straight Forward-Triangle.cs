Given a triangle, find the minimum path sum from top to bottom. 
Each step you may move to adjacent numbers on the row below.

For example, given the following triangle
[
     [2],
    [3,4],
   [6,5,7],
  [4,1,8,3]
]
The minimum path sum from top to bottom is 11 (i.e., 2 + 3 + 5 + 1 = 11).


public class Solution {
    // straight forward
    public int MinimumTotal(IList<IList<int>> triangle) {
        int n = triangle.Count;
        int[] prev = new int[n];
        prev[0] = triangle[0][0];
        for(int i = 1; i < n; i++) {
            int[] cur = new int[n];  // bug happened on the position of this initialization
            for(int j = 0; j <= i; j++) {
                if(j == 0) cur[0] = prev[0] + triangle[i][j];
                else if(j == i) cur[j] = prev[j-1] + triangle[i][j];
                else cur[j] = Math.Min(prev[j], prev[j-1]) + triangle[i][j];
            }
            prev = cur;
        }
        int minValue = int.MaxValue;
        for(int i = 0; i < prev.Length; i++) minValue = Math.Min(minValue, prev[i]);
        return minValue;
    }
}