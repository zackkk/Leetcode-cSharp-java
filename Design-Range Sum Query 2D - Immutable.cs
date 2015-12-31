Given a 2D matrix matrix, find the sum of the elements inside the rectangle 
defined by its upper left corner (row1, col1) and lower right corner (row2, col2).

Range Sum Query 2D
The above rectangle (with the red border) is defined by 
(row1, col1) = (2, 1) and (row2, col2) = (4, 3), which contains sum = 8.

Example:
Given matrix = [
  [3, 0, 1, 4, 2],
  [5, 6, 3, 2, 1],
  [1, 2, 0, 1, 5],
  [4, 1, 0, 1, 7],
  [1, 0, 3, 0, 5]
]

sumRegion(2, 1, 4, 3) -> 8
sumRegion(1, 1, 2, 2) -> 11
sumRegion(1, 2, 2, 4) -> 12


public class NumMatrix {
    // sum up the matrix => area = [row2,col2] - [row2,col1-1] - [row1-1,col2] + [row1-1,col1-1]
    int[,] sumMatrix;
    public NumMatrix(int[,] matrix) {
        int m = matrix.GetLength(0), n = matrix.GetLength(1);
        sumMatrix = new int[m,n];
        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                if(i == 0 && j == 0) { sumMatrix[i,j] = matrix[i,j]; continue; }
                if(i == 0) { sumMatrix[i,j] = sumMatrix[i,j-1] + matrix[i,j]; continue; }
                if(j == 0) { sumMatrix[i,j] = sumMatrix[i-1,j] + matrix[i,j]; continue; }
                sumMatrix[i,j] = sumMatrix[i,j-1] + sumMatrix[i-1,j] + matrix[i,j] - sumMatrix[i-1, j-1];
            }
        }
    }

    public int SumRegion(int row1, int col1, int row2, int col2) {
        if(row1 == 0 && col1 == 0) return sumMatrix[row2,col2];
        if(row1 == 0) return sumMatrix[row2,col2] - sumMatrix[row2,col1-1];
        if(col1 == 0) return sumMatrix[row2,col2] - sumMatrix[row1-1,col2];
        return sumMatrix[row2,col2] - sumMatrix[row2,col1-1] - sumMatrix[row1-1,col2] + sumMatrix[row1-1,col1-1];
    }
}


// Your NumMatrix object will be instantiated and called as such:
// NumMatrix numMatrix = new NumMatrix(matrix);
// numMatrix.SumRegion(0, 1, 2, 3);
// numMatrix.SumRegion(1, 2, 3, 4);