There are a row of n houses, each house can be painted with one of the three colors: red, blue or green. 
The cost of painting each house with a certain color is different. 
You have to paint all the houses such that no two adjacent houses have the same color.

The cost of painting each house with a certain color is represented by a n x 3 cost matrix. 
For example, 
costs[0][0] is the cost of painting house 0 with color red; 
costs[1][2] is the cost of painting house 1 with color green, and so on... 
Find the minimum cost to paint all houses.


public class Solution {
    // change array costs to be minimal total prices for painting i houses with a certain color
    public int MinCost(int[,] costs) {
        int n = costs.GetLength(0);
        if(n == 0) return 0;
        for(int i = 1; i < n; i++){
            costs[i, 0] += Math.Min(costs[i-1, 1], costs[i-1, 2]);   // avoid adjacent same color
            costs[i, 1] += Math.Min(costs[i-1, 0], costs[i-1, 2]); 
            costs[i, 2] += Math.Min(costs[i-1, 0], costs[i-1, 1]); 
        }
        return Math.Min(costs[n-1, 0], Math.Min(costs[n-1, 1], costs[n-1, 2]));
    }
}