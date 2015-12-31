Follow up for "Unique Paths":

Now consider if some obstacles are added to the grids. How many unique paths would there be?

An obstacle and empty space is marked as 1 and 0 respectively in the grid.

For example,
There is one obstacle in the middle of a 3x3 grid as illustrated below.

[
  [0,0,0],
  [0,1,0],
  [0,0,0]
]
The total number of unique paths is 2.


public class Solution {
    public int UniquePathsWithObstacles(int[,] obstacleGrid) {
        int m = obstacleGrid.GetLength(0), n = obstacleGrid.GetLength(1);
        int[,] steps = new int[m+1,n+1];
        steps[0,1] = 1;
        for(int i = 1; i <= m; i++){
            for(int j = 1; j <= n; j++){
                if(obstacleGrid[i-1,j-1] != 1){
                    steps[i,j] = steps[i-1,j] + steps[i,j-1];
                }
            }
        }
        return steps[m,n];
    }
}