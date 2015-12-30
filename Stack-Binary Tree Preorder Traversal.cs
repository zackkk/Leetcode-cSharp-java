Given a binary tree, return the preorder traversal of its nodes values.

For example:
Given binary tree {1,#,2,3},
   1
    \
     2
    /
   3
return [1,2,3].


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
    // stack
    public IList<int> PreorderTraversal(TreeNode root) {
        IList<int> result = new List<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        if (root == null) return result;
        stack.Push(root);
        while (stack.Count != 0) {
            TreeNode node = stack.Pop();
            if (node.right != null) stack.Push(node.right);
            if (node.left != null) stack.Push(node.left);
            result.Add(node.val);
        }
        return result;
    }
}