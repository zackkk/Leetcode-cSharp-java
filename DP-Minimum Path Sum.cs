Given a m x n grid filled with non-negative numbers, 
find a path from top left to bottom right which minimizes the sum of all numbers along its path.


public class Solution {
    // 2-dimension dp
    public int MinPathSum(int[,] grid) {
        int m = grid.GetLength(0), n = grid.GetLength(1);
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (i == 0 && j == 0) {
                    grid[i, j] = grid[i, j];
                }
                else if (i == 0) {
                    grid[i, j] += grid[i, j - 1];
                }
                else if (j == 0) {
                    grid[i, j] += grid[i - 1, j];
                }
                else {
                    grid[i, j] += Math.Min(grid[i - 1, j], grid[i, j - 1]);
                }
            }
        }
        return grid[m - 1, n - 1];
    }
}