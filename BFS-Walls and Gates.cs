You are given a m x n 2D grid initialized with these three possible values.

1. -1 - A wall or an obstacle.
2. 0 - A gate.
3. INF - Infinity means an empty room. 
We use the value 231 - 1 = 2147483647 to represent INF as you may assume that the distance to a gate is less than 2147483647.

Fill each empty room with the distance to its nearest gate. 
If it is impossible to reach a gate, it should be filled with INF.

For example, given the 2D grid:
INF  -1  0  INF
INF INF INF  -1
INF  -1 INF  -1
  0  -1 INF INF
After running your function, the 2D grid should be:
  3  -1   0   1
  2   2   1  -1
  1  -1   2  -1
  0  -1   3   4


public class Solution {
    // bfs, start from each gate and update distance if it found a shorter one.
    public void WallsAndGates(int[,] rooms) {
        int m = rooms.GetLength(0), n = rooms.GetLength(1);
        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                if(rooms[i,j] == 0){
                    bfs(rooms, m, n, i, j);
                }
            }
        }
    }
    
    void bfs(int[,] rooms, int m, int n, int i, int j){
        if(i-1 >= 0 && i-1 < m && j >= 0 && j < n && rooms[i-1,j] > rooms[i,j] + 1){ // up
            rooms[i-1,j] = rooms[i,j]+1;
            bfs(rooms, m, n, i-1, j);
        }
        if(i+1 >= 0 && i+1 < m && j >= 0 && j < n && rooms[i+1,j] > rooms[i,j] + 1){ // down
            rooms[i+1,j] = rooms[i,j]+1;
            bfs(rooms, m, n, i+1, j);
        }
        if(i >= 0 && i < m && j-1 >= 0 && j-1 < n && rooms[i,j-1] > rooms[i,j] + 1){ // left
            rooms[i,j-1] = rooms[i,j]+1;
            bfs(rooms, m, n, i, j-1);
        }
        if(i >= 0 && i < m && j+1 >= 0 && j+1 < n && rooms[i,j+1] > rooms[i,j] + 1){ // right
            rooms[i,j+1] = rooms[i,j]+1;
            bfs(rooms, m, n, i, j+1);
        }
    }
}