Given a binary search tree and a node in it, find the in-order successor of that node in the BST.

Note: If the given node has no in-order successor in the tree, return null.


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
    // find the smallest one that is larger than the given value since there are no duplicate values in a BST. 
    // It just like the binary search in a sorted list. 
    public TreeNode InorderSuccessor(TreeNode root, TreeNode p) {
        TreeNode result = null;
        while(root != null){
            if(p.val < root.val){
                result = root;
                root = root.left;
            }
            else{
                root = root.right;
            }
        }
        return result;
    }
}