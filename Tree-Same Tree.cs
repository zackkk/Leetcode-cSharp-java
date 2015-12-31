Given two binary trees, write a function to check if they are equal or not.

Two binary trees are considered equal if they are structurally identical and the nodes have the same value.


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
    public bool IsSameTree(TreeNode p, TreeNode q) {
        if (p == null && q == null) return true;
        if ((p == null && q != null) || 
            (p != null && q == null) || 
            (p.val != q.val)) {
            return false;
        }
        return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
    }
}