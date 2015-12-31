Write an efficient algorithm that searches for a value in an m x n matrix. 

This matrix has the following properties:
-Integers in each row are sorted from left to right.
-The first integer of each row is greater than the last integer of the previous row.

For example,
Consider the following matrix:
[
  [1,   3,  5,  7],
  [10, 11, 16, 20],
  [23, 30, 34, 50]
]
Given target = 3, return true.


public class Solution {
    // transfer it to one-dimension array
    public bool SearchMatrix(int[,] matrix, int target) {
        int m = matrix.GetLength(0), n = matrix.GetLength(1); 
        int start = 0, end = m * n - 1;
        while(start <= end){
            int mid = start + (end - start) / 2;
            int num = matrix[mid/n, mid%n];
            if(num == target) return true;
            else if(num < target) start++;
            else end--;
        }
        return false;
    }
}