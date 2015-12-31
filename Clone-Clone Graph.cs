Clone an undirected graph. Each node in the graph contains a label and a list of its neighbors.


OJ s undirected graph serialization:
Nodes are labeled uniquely.

We use # as a separator for each node, and , as a separator for node label and each neighbor of the node.
As an example, consider the serialized graph {0,1,2#1,2#2,2}.

The graph has a total of three nodes, and therefore contains three parts as separated by #.

First node is labeled as 0. Connect node 0 to both nodes 1 and 2.
Second node is labeled as 1. Connect node 1 to node 2.
Third node is labeled as 2. Connect node 2 to node 2 (itself), thus forming a self-cycle.
Visually, the graph looks like the following:

       1
      / \
     /   \
    0 --- 2
         / \
         \_/


/**
 * Definition for undirected graph.
 * public class UndirectedGraphNode {
 *     public int label;
 *     public IList<UndirectedGraphNode> neighbors;
 *     public UndirectedGraphNode(int x) { label = x; neighbors = new List<UndirectedGraphNode>(); }
 * };
 */
public class Solution {
    // dfs - map old to new
    // compare with clone linked list
    
    public UndirectedGraphNode CloneGraph(UndirectedGraphNode node) {
        Dictionary<UndirectedGraphNode, UndirectedGraphNode> dict = new Dictionary<UndirectedGraphNode, UndirectedGraphNode>();
        return Clone(node, dict);
    }
    
    UndirectedGraphNode Clone(UndirectedGraphNode node, Dictionary<UndirectedGraphNode, UndirectedGraphNode> dict){
        if(node == null) return null;
        if(dict.ContainsKey(node)) return dict[node];
        
        UndirectedGraphNode newNode = new UndirectedGraphNode(node.label);
        dict[node] = newNode;
        foreach(UndirectedGraphNode tmp in node.neighbors){
            newNode.neighbors.Add(Clone(tmp, dict));
        }
        return newNode;
    }
}