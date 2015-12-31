You are given an n x n 2D matrix representing an image.

Rotate the image by 90 degrees (clockwise).


public class Solution {
    // magic two steps: transpose -> flip vertically
    public void Rotate(int[,] matrix) {
        int n = matrix.GetLength(0); // n*n
        for(int i = 0; i < n; i++){
            for(int j = i; j < n; j++){
                Swap(matrix, i, j, j, i);
            }
        }
        for(int i = 0; i < n; i++){
            for(int j = 0; j < n/2; j++){
                Swap(matrix, i, j, i, n-1-j);
            }
        }
    }
    void Swap(int[,] matrix, int i1, int j1, int i2, int j2){
        int tmp = matrix[i1,j1];
        matrix[i1,j1] = matrix[i2,j2];
        matrix[i2,j2] = tmp;
    }
}