/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode(int x) { val = x; }
 * }
 */
class Solution {
    // 遍历寻找p和q
    // 1.如果p,q分布于两侧，则当前root是LCA
    // 2.如果p,q分布于一侧，则去某一侧找

    public TreeNode lowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if (root == null) {
            return null;
        }
        if (root == p || root == q) {
            return root;
        }

        TreeNode left = lowestCommonAncestor(root.left, p, q);
        TreeNode right = lowestCommonAncestor(root.right, p, q);

        // 左右各有一个
        if (left != null && right != null) {
            return root;
        }
        // 左边一个没有
        if (left == null) {
            return right;
        }
        // 右边一个没有
        if (right == null) {
            return left;
        }
        return null;
    }
}
