Given a complete binary tree, count the number of nodes.

Definition of a complete binary tree from Wikipedia:
In a complete binary tree every level, except possibly the last, is completely filled, 
and all nodes in the last level are as far left as possible. 
It can have between 1 and 2h nodes inclusive at the last level h.


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
    // check if it is a full tree: if it is, then we can get the number of nodes directly; otherwise, go to its childs
    public int CountNodes(TreeNode root) {
        if(root == null) return 0;
        TreeNode l = root, r = root;
        int l_levels = 0, r_levels = 0;
        while(l != null) {
            l_levels++;
            l = l.left;
        }
        while(r != null){
            r_levels++;
            r = r.right;
        }
        if(l_levels == r_levels){   // full tree 
            return (1 << l_levels) - 1; 
        }
        else{ 
            return 1 + CountNodes(root.left) + CountNodes(root.right);
        }
    }
}