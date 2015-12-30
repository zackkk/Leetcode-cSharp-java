Given a binary tree, return all root-to-leaf paths.

For example, given the following binary tree:

   1
 /   \
2     3
 \
  5
All root-to-leaf paths are:

["1->2->5", "1->3"]


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
    // Normal tree traverse
    public IList<string> BinaryTreePaths(TreeNode root) {
        IList<string> result = new List<string>();
        if(root == null) return result;
        helper(root, "", result);
        return result;
    }
    
    void helper(TreeNode root, string path, IList<string> result) {
        if (root.left == null && root.right == null) { result.Add(path + root.val.ToString()); return; }
        if (root.left != null) { helper(root.left, path + root.val.ToString() + "->", result); }
        if (root.right != null) { helper(root.right, path + root.val.ToString() + "->", result); }
    }
}