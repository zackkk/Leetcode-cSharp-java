Given a binary tree, return the postorder traversal of its nodes values.

For example:
Given binary tree {1,#,2,3},
   1
    \
     2
    /
   3
return [3,2,1].


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
    // tricky: use two stacks
    //                            want: 1 3 2 5 7 6 4
    // output stack from bottom to top: 4 6 7 5 2 3 1
    //        input stack pop sequence: 4 6 7 5 2 3 1 
    public IList<int> PostorderTraversal(TreeNode root) {
        Stack<TreeNode> input = new Stack<TreeNode>();
        Stack<TreeNode> output = new Stack<TreeNode>();
        IList<int> result = new List<int>();
        if(root == null) return result;
        
        input.Push(root);
        while(input.Count > 0){
            TreeNode node = input.Pop();
            output.Push(node);
            if(node.left != null) input.Push(node.left);
            if(node.right != null) input.Push(node.right);
        }
        
        while(output.Count > 0){
            TreeNode node = output.Pop();
            result.Add(node.val);
        }
        return result;
    }
}