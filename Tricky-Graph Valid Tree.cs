Given n nodes labeled from 0 to n - 1 and a list of undirected edges (each edge is a pair of nodes), 
write a function to check whether these edges make up a valid tree.

For example:

Given n = 5 and edges = [[0, 1], [0, 2], [0, 3], [1, 4]], return true.

Given n = 5 and edges = [[0, 1], [1, 2], [2, 3], [1, 3], [1, 4]], return false.


public class Solution {
    // tricky union-find algorithm: http://www.geeksforgeeks.org/union-find/
    public bool ValidTree(int n, int[,] edges) {
        int[] parents = new int[n]; // n points
        for(int i = 0; i < n; i++) parents[i] = -1; // initialize their parents to be -1
        
        for(int i = 0; i < edges.GetLength(0); i++){
            // check if two points of an edge are already connected
            int srcAncestor = Find(parents, edges[i,0]); // src point of the edge
            int destAncestor = Find(parents, edges[i,1]); // dest point of the edge
            if(srcAncestor == destAncestor) return false;
            parents[srcAncestor] = destAncestor; // union
        }
        
        return edges.GetLength(0) == n - 1; // check if is only one part, but multiple parts
    }
    
    int Find(int[] parents, int point){
        if(parents[point] == -1) return point;  // found the "final" parent
        return Find(parents, parents[point]); // go further to find the "final" parent
    }
}