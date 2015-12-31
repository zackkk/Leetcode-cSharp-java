There are a total of n courses you have to take, labeled from 0 to n - 1.

Some courses may have prerequisites, 
for example to take course 0 you have to first take course 1, which is expressed as a pair: [0,1]

Given the total number of courses and a list of prerequisite pairs, is it possible for you to finish all courses?

For example:

2, [[1,0]]
There are a total of 2 courses to take. To take course 1 you should have finished course 0. So it is possible.

2, [[1,0],[0,1]]
There are a total of 2 courses to take. To take course 1 you should have finished course 0, and to take course 0 you should also have finished course 1. So it is impossible.

Note:
The input prerequisites is a graph represented by a list of edges, not adjacency matrices. Read more about how a graph is represented.


public class Solution {
    // check there is cycle is the directd graph -> BFS
    public bool CanFinish(int numCourses, int[,] prerequisites) {
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
        
        int count = 0;
        while(queue.Count > 0){
            int prerequisite = queue.Dequeue();
            count++;
            if(matrix.ContainsKey(prerequisite)){
                foreach(int j in matrix[prerequisite]){
                    indegree[j]--;
                    if(indegree[j] == 0){
                        queue.Enqueue(j);
                    }
                }
            }
        }
        return count == numCourses;
    }
}