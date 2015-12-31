Given a matrix of m x n elements (m rows, n columns), return all elements of the matrix in spiral order.

For example,
Given the following matrix:

[
 [ 1, 2, 3 ],
 [ 4, 5, 6 ],
 [ 7, 8, 9 ]
]
You should return [1,2,3,6,9,8,7,4,5].


public class Solution {
    public IList<int> SpiralOrder(int[,] matrix) {
        IList<int> result = new List<int>();
        if(matrix.GetLength(0) == 0) return result; // empty case
        
        int rowStart = 0, colStart = 0;
        int rowEnd = matrix.GetLength(0) - 1, colEnd = matrix.GetLength(1) - 1;
        while(rowStart <= rowEnd && colStart <= colEnd){
            // go right
            for(int j = colStart; j <= colEnd; j++){
                result.Add(matrix[rowStart, j]);
            }
            rowStart++;
            
            // go down
            for(int i = rowStart; i <= rowEnd; i++){
                result.Add(matrix[i,colEnd]);
            }
            colEnd--;
            
            // go left
            if(rowStart <= rowEnd){ // rowStart has been changed
                for(int j = colEnd; j >= colStart; j--){
                    result.Add(matrix[rowEnd,j]);
                }
            }
            rowEnd--;
            
            // go up
            if(colStart <= colEnd){ // colEnd has been changed
                for(int i = rowEnd; i >= rowStart; i--){
                    result.Add(matrix[i,colStart]);
                }
            }
            colStart++;
        }
        return result;
    }
}