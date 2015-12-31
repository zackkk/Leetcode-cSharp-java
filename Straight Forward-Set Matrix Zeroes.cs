Given a m x n matrix, if an element is 0, set its entire row and column to 0. Do it in place.


public class Solution {
    // save flags in first row and first column
    public void SetZeroes(int[,] matrix) {
        bool first_row_zero = false, first_col_zero = false;
        int m = matrix.GetLength(0), n = matrix.GetLength(1);
        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                if(matrix[i,j] == 0){
                    if(i == 0) first_row_zero = true;
                    if(j == 0) first_col_zero = true;
                    matrix[0,j] = 0;
                    matrix[i,0] = 0;
                }
            }
        }
        
        // indexes start from 1
        for(int i = 1; i < m; i++){
            for(int j = 1; j < n; j++){
                if(matrix[0,j] == 0 || matrix[i,0] == 0) {
                    matrix[i,j] = 0;
                }
            }
        }
        
        if(first_row_zero) {for(int j = 0; j < n; j++) matrix[0,j] = 0;}
        if(first_col_zero) {for(int i = 0; i < m; i++) matrix[i,0] = 0;}
    }
}