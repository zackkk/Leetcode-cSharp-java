A group of two or more people wants to meet and minimize the total travel distance. You are given a 2D grid of values 0 or 1, where each 1 marks the home of someone in the group. The distance is calculated using Manhattan Distance, 
where distance(p1, p2) = |p2.x - p1.x| + |p2.y - p1.y|.

For example, given three people living at (0,0), (0,4), and (2,2):

1 - 0 - 0 - 0 - 1
|   |   |   |   |
0 - 0 - 0 - 0 - 0
|   |   |   |   |
0 - 0 - 1 - 0 - 0
The point (0,2) is an ideal meeting point, as the total travel distance of 2+2+2=6 is minimal. So return 6.


public class Solution {
    // result = |p0x - x| + |p0y - y| + |p1x - x| + |p1y - y| + ...
    //        = |p0x - x| + |p1x - x| + ... + |p0y - y| + |p1y - y| + ...
    //        = The median minimizes the sum of absolute deviations (mathmatical conclusion)
    //        = find medians of xi and yi
    public int MinTotalDistance(int[,] grid) {
        int result = 0;
        int m = grid.GetLength(0), n = grid.GetLength(1);
        List<int> x = new List<int>();
        List<int> y = new List<int>();
        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                if(grid[i,j] == 1){
                    x.Add(i);
                    y.Add(j);
                }
            }
        }
        x.Sort();
        y.Sort();
        for(int i = 0, j = x.Count - 1; i < j; i++, j--){
            result += (x[j] - x[i]);  // sum of distance of xj and xi, to the median
        }
        for(int i = 0, j =y.Count - 1; i < j; i++, j--){
            result += (y[j] - y[i]);  // sum of distance of yj and yi, to the median
        }
        return result;
    }
}