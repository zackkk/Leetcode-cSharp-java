Given a non-empty binary search tree and a target value, find the value in the BST that is closest to the target.

Note:
Given target value is a floating point.
You are guaranteed to have only one unique value in the BST that is closest to the target.


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
    // binary search to find a value which is the nearest to the target
    public int ClosestValue(TreeNode root, double target) {
        int closestValue = root.val;
        while(root != null) {
            // update closestValue at each visit
            closestValue = Math.Abs(root.val - target) < Math.Abs(closestValue - target) ? root.val : closestValue;
            if(closestValue == target) return closestValue; // this line can be deleted
            root = target < root.val ? root.left : root.right; // binary search
        }
        return closestValue;
    }
}