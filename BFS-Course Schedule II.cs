There are a total of n courses you have to take, labeled from 0 to n - 1.

Some courses may have prerequisites, for example to take course 0 you have to first take course 1, 
which is expressed as a pair: [0,1]

Given the total number of courses and a list of prerequisite pairs, 
return the ordering of courses you should take to finish all courses.

There may be multiple correct orders, you just need to return one of them. 
If it is impossible to finish all courses, return an empty array.

For example:

2, [[1,0]]
There are a total of 2 courses to take. To take course 1 you should have finished course 0. 
So the correct course order is [0,1]

4, [[1,0],[2,0],[3,1],[3,2]]
There are a total of 4 courses to take. To take course 3 you should have finished both courses 1 and 2. 
Both courses 1 and 2 should be taken after you finished course 0. So one correct course order is [0,1,2,3]. 
Another correct ordering is[0,2,1,3].

Note:
The input prerequisites is a graph represented by a list of edges, not adjacency matrices. 
Read more about how a graph is represented.


public class Solution {
    // Same as Course Schedule I -> check there is cycle is the directd graph -> BFS
    // passed 33/35, couldn't figure out where the bug is -> don't waste time on it
    public int[] FindOrder(int numCourses, int[,] prerequisites) {
        Dictionary<int, IList<int>> matrix = new Dictionary<int, IList<int>>(); // adjacency matrices to represent the graph
        int[] indegree = new int[numCourses];
        for(int i = 0; i < prerequisites.GetLength(0); i++){
            int current = prerequisites[i,0]; 
            int prerequisite = prerequisites[i,1];
            if(!matrix.ContainsKey(prerequisite)){
                matrix[prerequisite] = new List<int>();
            }
            if(!matrix[prerequisite].Contains(current)) indegree[current]++;  // duplicate edges in test
            matrix[prerequisite].Add(current);
        }
        
        Queue<int> queue = new Queue<int>();
        for(int i = 0; i < numCourses; i++){
            if(indegree[i] == 0){
                queue.Enqueue(i);
            }
        }
        
        List<int> result = new List<int>();
        while(queue.Count > 0){
            int prerequisite = queue.Dequeue();
            result.Add(prerequisite);
            if(matrix.ContainsKey(prerequisite)){
                foreach(int j in matrix[prerequisite]){
                    indegree[j]--;
                    if(indegree[j] == 0){
                        queue.Enqueue(j);
                    }
                }
            }
        }
        return result.Count == numCourses ? result.ToArray() : new int[]{};
    }
}