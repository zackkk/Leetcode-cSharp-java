Given a binary tree, determine if it is height-balanced.

For this problem, a height-balanced binary tree is defined as 
a binary tree in which the depth of the two subtrees of every node never differ by more than 1.


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
    // intuitive: up-down O(NlogN)
    // improve: bottom-up dfs - return -1 if it is non-balanced binary tree - O(N)
    public bool IsBalanced(TreeNode root) {
        return dfs(root) != -1;
    }
    int dfs(TreeNode root){
        if (root == null) return 0;
        int l = dfs(root.left);
        if (l == -1) return -1;
        int r = dfs(root.right);
        if (r == -1) return -1;
        
        if (Math.Abs(l - r) > 1) return -1;
        return (Math.Max(l, r)) + 1;
    }
}