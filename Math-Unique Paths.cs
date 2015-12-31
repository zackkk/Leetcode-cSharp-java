A robot is located at the top-left corner of a m x n grid (marked 'Start' in the diagram below).

The robot can only move either down or right at any point in time. 
The robot is trying to reach the bottom-right corner of the grid (marked 'Finish' in the diagram below).

How many possible unique paths are there?


public class Solution {
    // Math: only two choices -> either go down or go right -> make sure go right/down steps then know the solution 
    // Select m-1 out of (m-1+n-1) or n-1 out of (m-1+n-1)
    // Result = Combination(N,K) = N! / (K!(N-K)!) 
    public int UniquePaths(int m, int n) {
        int N = m - 1 + n - 1;
        int K = m - 1;
        long result = 1;
        for (int i = 1; i <= K; i++) {
            result = result * (N - K + i) / i;
        }
        return (int)result;
    }
}