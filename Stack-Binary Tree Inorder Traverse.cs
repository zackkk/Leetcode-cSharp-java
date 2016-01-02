Given a binary tree, return the inorder traversal of its nodes values.

For example:
Given binary tree {1,#,2,3},
   1
    \
     2
    /
   3
return [1,3,2].

Note: Recursive solution is trivial, could you do it iteratively?


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
    // have to use the pointer to point to the right child
    Stack<TreeNode> stack;
    public IList<int> InorderTraversal(TreeNode root) {
        IList<int> result = new List<int>();
        stack = new Stack<TreeNode>();
        PushAllLeft(root);
        while(stack.Count > 0){
            TreeNode node = stack.Pop();
            PushAllLeft(node.right);
            result.Add(node.val);
        }
        return result;
    }
    
    void PushAllLeft(TreeNode root){
        while(root != null){
            stack.Push(root);
            root = root.left;
        }
    }
}