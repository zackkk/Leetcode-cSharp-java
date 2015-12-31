Given a binary tree, determine if it is a valid binary search tree (BST).

Assume a BST is defined as follows:
-The left subtree of a node contains only nodes with keys less than the node's key.
-The right subtree of a node contains only nodes with keys greater than the node's key.
-Both the left and right subtrees must also be binary search trees.


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
    public bool IsValidBST(TreeNode root) {
        return Helper(root, long.MinValue, long.MaxValue); // has some disgusting tests of int.MaxValue/int.MinValue
    }
    
    bool Helper(TreeNode root, long low, long high) {
        if(root == null) return true;
        if(root.val <= low || root.val >= high) return false;
        return Helper(root.left, low, root.val) && Helper(root.right, root.val, high);
    }
}