You want to build a house on an empty land which reaches all buildings in the shortest amount of distance. 

You can only move up, down, left and right. You are given a 2D grid of values 0, 1 or 2, where:
-Each 0 marks an empty land which you can pass by freely.
-Each 1 marks a building which you cannot pass through.
-Each 2 marks an obstacle which you cannot pass through.

For example, given three buildings at (0,0), (0,4), (2,2), and an obstacle at (0,2):

1 - 0 - 2 - 0 - 1
|   |   |   |   |
0 - 0 - 0 - 0 - 0
|   |   |   |   |
0 - 0 - 1 - 0 - 0

The point (1,2) is an ideal empty land to build a house, as the total travel distance of 3+3+1=7 is minimal. So return 7.

Note:
There will be at least one building. If it is not possible to build such house according to the above rules, return -1.


public class Solution {
    // bfs from each house and maintain two extra matrixs: sumDist to all houses & sumVisited of all houses
    public int ShortestDistance(int[,] grid) {
        if(grid.GetLength(0) == 0) return -1;
        int m = grid.GetLength(0), n = grid.GetLength(1);
        int[,] sumDist = new int[m,n];
        int[,] sumVisited = new int[m,n]; // test case like [1,2,0]
        
        int houseNum = 0;
        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                if(grid[i,j] == 1){
                    houseNum++;
                    
                    // bfs from each house
                    Queue<int[]> queue = new Queue<int[]>();
                    queue.Enqueue(new int[]{i, j});
                    bool[,] visited = new bool[m,n];
                    int dist = 0;
                    while(queue.Count > 0){
                        int count = queue.Count;
                        for(int k = 0; k < count; k++){
                            int[] node = queue.Dequeue();
                            int x = node[0], y = node[1];
                            
                            sumDist[x,y] += dist;  // sum up distance to the house
                            sumVisited[x,y] ++;
                            
                            if(x - 1 >= 0 && grid[x-1,y] == 0 && visited[x-1,y] == false){
                                queue.Enqueue(new int[]{x-1,y});
                                visited[x-1,y] = true;
                            }
                            if(x + 1  < m && grid[x+1,y] == 0 && visited[x+1,y] == false){
                                queue.Enqueue(new int[]{x+1,y});
                                visited[x+1,y] = true;
                            }
                            if(y - 1 >= 0 && grid[x,y-1] == 0 && visited[x,y-1] == false){
                                queue.Enqueue(new int[]{x,y-1});
                                visited[x,y-1] = true;
                            }
                            if(y + 1  < n && grid[x,y+1] == 0 && visited[x,y+1] == false){
                                queue.Enqueue(new int[]{x,y+1});
                                visited[x,y+1] = true;
                            }
                        }
                        dist++; // next level
                    }
                }
            }
        }
        
        int result = int.MaxValue;
        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                if(grid[i,j] == 0 && sumVisited[i,j] == houseNum && sumDist[i,j] < result){
                    result = sumDist[i,j];
                }
            }
        }
        return result == int.MaxValue ? -1 : result;
    }
}