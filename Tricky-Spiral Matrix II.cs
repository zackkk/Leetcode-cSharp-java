Given an integer n, generate a square matrix filled with elements from 1 to n2 in spiral order.

For example,
Given n = 3,

You should return the following matrix:
[
 [ 1, 2, 3 ],
 [ 8, 9, 4 ],
 [ 7, 6, 5 ]
]


public class Solution {
    // same idea as Spiral Matrix I
    public int[,] GenerateMatrix(int n) {
        int[,] result = new int[n,n];
        if(n == 0) return result; // empty case
        
        int rowStart = 0, colStart = 0;
        int rowEnd = n - 1, colEnd = n - 1;
        int val = 0;
        while(rowStart <= rowEnd && colStart <= colEnd){
            // go right
            for(int j = colStart; j <= colEnd; j++){
                result[rowStart, j] = ++val;
            }
            rowStart++;
            
            // go down
            for(int i = rowStart; i <= rowEnd; i++){
                result[i,colEnd] = ++val;
            }
            colEnd--;
            
            // go left
            if(rowStart <= rowEnd){ // rowStart has been changed
                for(int j = colEnd; j >= colStart; j--){
                    result[rowEnd,j] = ++val;
                }
            }
            rowEnd--;
            
            // go up
            if(colStart <= colEnd){ // colEnd has been changed
                for(int i = rowEnd; i >= rowStart; i--){
                    result[i,colStart] = ++val;
                }
            }
            colStart++;
        }
        return result;
    }
}