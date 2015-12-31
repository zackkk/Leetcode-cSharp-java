Given inorder and postorder traversal of a tree, construct the binary tree.

Note:
You may assume that duplicates do not exist in the tree.


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
    // use index to separate two halfs, and build the tree recursively
    public TreeNode BuildTree(int[] inorder, int[] postorder) {
        return Helper(inorder, 0, inorder.Length - 1, postorder, 0, postorder.Length - 1);
    }
    
    TreeNode Helper(int[] inorder, int istart, int iend, int[] postorder, int pstart, int pend){
        if(istart > iend || pstart > pend) return null;
        int rootVal = postorder[pend];
        int i = 0;
        for( ; i < inorder.Length; i++){  // could improve to use a hashmap to get index from value directly
            if(inorder[i] == rootVal) { break; }
        }
        TreeNode root = new TreeNode(rootVal);
        root.left = Helper(inorder, istart, i - 1, postorder, pstart, pstart + (i - 1 - istart));
        root.right = Helper(inorder, i + 1, iend, postorder, pstart + (i - 1 - istart) + 1, pend - 1); // bug: forgot pend - 1
        return root;
    }
}