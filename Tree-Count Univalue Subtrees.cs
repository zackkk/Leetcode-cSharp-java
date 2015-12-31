Given a binary tree, count the number of uni-value subtrees.

A Uni-value subtree means all nodes of the subtree have the same value.

For example:
Given binary tree,
              5
             / \
            1   5
           / \   \
          5   5   5
return 4.


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
    int count;
    public int CountUnivalSubtrees(TreeNode root) {
        count = 0;
        Helper(root);
        return count;
    }
    
    bool Helper(TreeNode root){
        if(root == null) return true;
        bool l = Helper(root.left);
        bool r = Helper(root.right);
        if(l == false || r == false) return false;
        
        if(root.left != null && root.val != root.left.val) return false;
        if(root.right != null && root.val != root.right.val) return false;
        count++;
        return true;
    }
}