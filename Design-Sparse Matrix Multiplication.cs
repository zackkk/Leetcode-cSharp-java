Given two sparse matrices A and B, return the result of AB.

You may assume that A's column number is equal to B's row number.

Example:

A = [
  [ 1, 0, 0],
  [-1, 0, 3]
]

B = [
  [ 7, 0, 0 ],
  [ 0, 0, 0 ],
  [ 0, 0, 1 ]
]


     |  1 0 0 |   | 7 0 0 |   |  7 0 0 |
AB = | -1 0 3 | x | 0 0 0 | = | -7 0 3 |
                  | 0 0 1 |


public class Solution {
    // transfer matrix A into a list of list - lists
    // first row -> lists[0] -> colNum1, value1, colNum2, value2, ...
    // second row -> lists[1] -> colNum1, value1, ...
    public int[,] Multiply(int[,] A, int[,] B) {
        int m = A.GetLength(0), l = A.GetLength(1), n = B.GetLength(1);
        int[,] result = new int[m,n];
        
        // transform matrix
        IList<IList<int>> lists = new List<IList<int>>();
        for(int i = 0; i < m; i++){
            lists.Add(new List<int>());
            for(int j = 0; j < l; j++){
                if(A[i,j] != 0){
                    lists[i].Add(j);
                    lists[i].Add(A[i,j]);
                }
            }
        }
        
        // iterate lists
        for(int i = 0; i < m; i++){
            for(int k = 0; k < lists[i].Count; k += 2){
                int col = lists[i][k];
                int val = lists[i][k+1];
                for(int j = 0; j < n; j++){
                    result[i,j] += B[col, j] * val;
                }
            }
        }
        return result;
    }
}