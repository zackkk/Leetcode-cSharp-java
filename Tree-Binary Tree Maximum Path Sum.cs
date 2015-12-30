Given a binary tree, find the maximum path sum.

For this problem, a path is defined as any sequence of nodes from some starting node to any node in the tree 
along the parent-child connections. The path does not need to go through the root.

For example:
Given the below binary tree,

       1
      / \
     2   3
Return 6.


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
    // There are four cases that can be possible max: root, root+left, root+right, root+left+right
    
    int maxSum = int.MinValue; 
    
    public int MaxPathSum(TreeNode root) {
        SinglePathSum(root);
        return maxSum;
    }
    
    int SinglePathSum(TreeNode root){
        if(root == null) return 0;
        
        int l = SinglePathSum(root.left);
        int r = SinglePathSum(root.right);
        
        int maxSinglePathSum = Math.Max(root.val, Math.Max(root.val + l, root.val + r));
        maxSum = Math.Max(maxSum, maxSinglePathSum);
        maxSum = Math.Max(maxSum, root.val + l + r);
        
        return maxSinglePathSum;
    }
}