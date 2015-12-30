Given a binary tree, return the vertical order traversal of its nodes values. 
(ie, from top to bottom, column by column).

If two nodes are in the same row and column, the order should be from left to right.

Examples:
Given binary tree [3,9,20,null,null,15,7],
    3
   / \
  9  20
    /  \
   15   7
return its vertical order traversal as:
[
  [9],
  [3,15],
  [20],
  [7]
]
Given binary tree [3,9,20,4,5,2,7],
    _3_
   /   \
  9    20
 / \   / \
4   5 2   7
return its vertical order traversal as:
[
  [4],
  [9],
  [3,5,2],
  [20],
  [7]
]


/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    // bfs, hashmaps <TreeNode, level>, <level, nodes>
    public IList<IList<int>> VerticalOrder(TreeNode root) {
        IList<IList<int>> result = new List<IList<int>>();
        if(root == null) return result;
        
        Queue<TreeNode> queue = new Queue<TreeNode>();
        Dictionary<TreeNode, int> nodeLevel = new Dictionary<TreeNode, int>(); 
        Dictionary<int, IList<int>> levelNodes = new Dictionary<int, IList<int>>();
        queue.Enqueue(root);
        nodeLevel[root] = 0;
        
        while(queue.Count > 0){
            TreeNode node = queue.Dequeue();
            if(levelNodes.ContainsKey(nodeLevel[node]) == false) levelNodes[nodeLevel[node]] = new List<int>();
            levelNodes[nodeLevel[node]].Add(node.val);
            
            if(node.left != null){
                queue.Enqueue(node.left);
                nodeLevel[node.left] = nodeLevel[node] - 1;
            }
            if(node.right != null){
                queue.Enqueue(node.right);
                nodeLevel[node.right] = nodeLevel[node] + 1;
            }
        }
        
        var list = levelNodes.Keys.ToList();
	    list.Sort();
	    foreach (var key in list){
	        result.Add(levelNodes[key]);
	    }
        return result;
    }
}