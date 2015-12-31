Given a binary tree containing digits from 0-9 only, each root-to-leaf path could represent a number.

An example is the root-to-leaf path 1->2->3 which represents the number 123.

Find the total sum of all root-to-leaf numbers.

For example,

    1
   / \
  2   3
The root-to-leaf path 1->2 represents the number 12.
The root-to-leaf path 1->3 represents the number 13.

Return the sum = 12 + 13 = 25.


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
    public int SumNumbers(TreeNode root) {
        if(root == null) return 0;
        return Helper(root, 0);
    }
    
    int Helper(TreeNode root, int n){
        if(root.left == null && root.right == null) return n * 10 + root.val;
        int result = 0;
        if(root.left != null) result += Helper(root.left, n * 10 + root.val);
        if(root.right != null) result += Helper(root.right, n * 10 + root.val);
        return result;
    }
}