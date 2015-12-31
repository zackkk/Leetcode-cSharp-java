Given a binary search tree, write a function kthSmallest to find the kth smallest element in it.

Note: 
You may assume k is always valid, 1 ≤ k ≤ BSTs total elements.


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
    // binary tree in-order traverse
    int result, count;
    public int KthSmallest(TreeNode root, int k) {
        count = k;
        Helper(root);
        return result;
    }
    void Helper(TreeNode root) {
        if(root.left != null) Helper(root.left);
        if(--count == 0) { result = root.val; return; }
        if(root.right != null) Helper(root.right);
    }
}