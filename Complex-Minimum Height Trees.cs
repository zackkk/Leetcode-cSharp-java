For a undirected graph with tree characteristics, we can choose any node as the root. 
The result graph is then a rooted tree. 
Among all possible rooted trees, those with minimum height are called minimum height trees (MHTs). 
Given such a graph, write a function to find all the MHTs and return a list of their root labels.

Format
The graph contains n nodes which are labeled from 0 to n - 1. 
You will be given the number n and a list of undirected edges (each edge is a pair of labels).

You can assume that no duplicate edges will appear in edges. Since all edges are undirected, 
[0, 1] is the same as [1, 0] and thus will not appear together in edges.

Example 1:

Given n = 4, edges = [[1, 0], [1, 2], [1, 3]]

        0
        |
        1
       / \
      2   3
return [1]

Example 2:

Given n = 6, edges = [[0, 3], [1, 3], [2, 3], [4, 3], [5, 4]]

     0  1  2
      \ | /
        3
        |
        4
        |
        5
return [3, 4]


public class Solution {
    // We start from every end, by end we mean vertex of degree 1 (aka leaves). 
    // We let the pointers move the same speed. When two pointers meet, we keep only one of them, 
    // until the last two pointers meet or one step away we then find the roots.
    // similar implemention as topological sort
    public IList<int> FindMinHeightTrees(int n, int[,] edges) {
        if(edges.GetLength(0) == 0) return new List<int>(){0}; // only one vertex 
        Dictionary<int, IList<int>> matrix = new Dictionary<int, IList<int>>(); // adjacency matrix
        for(int i = 0; i < n; i++) matrix[i] = new List<int>();
        for(int i = 0; i < edges.GetLength(0); i++){
            int p1 = edges[i, 0], p2 = edges[i, 1]; 
            matrix[p1].Add(p2);
            matrix[p2].Add(p1);
        }
        
        // Collect all leaves
        IList<int> leaves = new List<int>();
        for(int i = 0; i < n; i++) {
            if(matrix[i].Count == 1){
                leaves.Add(i);
            }
        }
        
        // at most two Minimum Height Trees
        while(n > 2){
            n -= leaves.Count;
            IList<int> newLeaves = new List<int>();
            foreach(int leaf in leaves){
                int connected = matrix[leaf][0];
                matrix[connected].Remove(leaf);
                if(matrix[connected].Count == 1) newLeaves.Add(connected);
            }
            leaves = newLeaves;
        }
        
        return leaves;
    }
}