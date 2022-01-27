/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode() {}
 *     TreeNode(int val) { this.val = val; }
 *     TreeNode(int val, TreeNode left, TreeNode right) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
class Solution {
    // 1.当前就是root，返回val+ max(left) + max(right)
    // 2.当前不是root，返回val+ max(left, right)

    int ret = Integer.MIN_VALUE;

    public int maxPathSum(TreeNode root) {
        helper(root);
        return ret;
    }

    public int helper(TreeNode root) {
        if (root == null) {
            return 0;
        }        
        int left = Math.max(helper(root.left), 0);// 如果分支小于0 忽略
        int right = Math.max(helper(root.right), 0);

        int curMax = root.val + left + right;
        int pathMax = root.val + Math.max(left, right);

        ret = Math.max(ret, curMax);
        return pathMax;
    }
}
