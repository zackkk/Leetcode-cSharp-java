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
    // one stack + one pointer
    // have to use the pointer to point to the right child
    public IList<int> InorderTraversal(TreeNode root) {
        IList<int> result = new List<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode cur = root;
        while(cur != null || stack.Count > 0){
            while(cur != null){
                stack.Push(cur);
                cur = cur.left;
            }
            if(stack.Count > 0){
                TreeNode node = stack.Pop();
                result.Add(node.val);
                cur = node.right;
            }
        }
        return result;
    }
}