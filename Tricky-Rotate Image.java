class Solution {
    //  1 2 3      1            1
    //         ->  2 * * -> * * 2 
    //             3            3
    public void rotate(int[][] matrix) {
        int n = matrix.length;
        for (int i = 0; i < n; i++) {
            for (int j = i; j < n; j++) {
                swap(matrix, i, j, j, i);
            }
        }
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n/2; j++) {
                swap(matrix, i, j, i, n-1-j);
            }
        }
    }

    private void swap(int[][] matrix, int i, int j, int p, int q) {
        int t = matrix[i][j];
        matrix[i][j] = matrix[p][q];
        matrix[p][q] = t;
    }
}
