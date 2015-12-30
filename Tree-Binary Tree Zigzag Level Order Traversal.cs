Given a binary tree, return the zigzag level order traversal of its nodes values. 
(ie, from left to right, then right to left for the next level and alternate between).

For example:
Given binary tree {3,9,20,#,#,15,7},
    3
   / \
  9  20
    /  \
   15   7
return its zigzag level order traversal as:
[
  [3],
  [20,9],
  [15,7]
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
    // straight forward recursive solution, this is much easier than iteration version
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        IList<IList<int>> result = new List<IList<int>>();
        Helper(root, result, 0);
        return result;
    }
    
    void Helper(TreeNode root, IList<IList<int>> result, int level){
        if(root == null) return;
        if(result.Count == level) result.Add(new List<int>()); // step into a new level
        if(level % 2 == 0){
            result[level].Add(root.val);
        }
        else{
            result[level].Insert(0, root.val);
        }
        Helper(root.left, result, level + 1);
        Helper(root.right, result, level + 1);
    }
}