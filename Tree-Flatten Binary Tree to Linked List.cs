Given a binary tree, flatten it to a linked list in-place.

For example,
Given

         1
        / \
       2   5
      / \   \
     3   4   6
The flattened tree should look like:
   1
    \
     2
      \
       3
        \
         4
          \
           5
            \
             6


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
    // in-order + extra pointer
    TreeNode prev = null;
    public void Flatten(TreeNode root) {
        if(root == null) return;
        TreeNode r = root.right;
        
        if(prev == null) { 
            prev = root; 
        }
        else{
            prev.left = null;
            prev.right = root;
            prev = root;
        }
        Flatten(root.left);
        Flatten(r);
    }
}