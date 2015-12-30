Given a binary tree, find the length of the longest consecutive sequence path.

The path refers to any sequence of nodes from some starting node to any node in the tree along the parent-child connections. The longest consecutive path need to be from parent to child (cannot be the reverse).

For example,
   1
    \
     3
    / \
   2   4
        \
         5
Longest consecutive sequence path is 3-4-5, so return 3.
   2
    \
     3
    / 
   2    
  / 
 1
Longest consecutive sequence path is 2-3,not3-2-1, so return 2.

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
    int max = 0;
    public int LongestConsecutive(TreeNode root) {
        if(root == null) return 0;
        Helper(root, 0, root.val);
        return max;
    }
    
    void Helper(TreeNode root, int len, int target){
        if(root == null) return;
        len = root.val == target ? len + 1 : 1;
        max = Math.Max(max, len);
        Helper(root.left, len, root.val + 1);
        Helper(root.right, len, root.val + 1);
    }
}