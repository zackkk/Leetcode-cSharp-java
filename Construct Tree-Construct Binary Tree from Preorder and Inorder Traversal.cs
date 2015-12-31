Given preorder and inorder traversal of a tree, construct the binary tree.

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
    // use index to separate two subtrees
    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        return Helper(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1);
    }
    
    TreeNode Helper(int[] preorder, int pstart, int pend, int[] inorder, int istart, int iend){
        if(pstart > pend || istart > iend) return null;
        int rootVal = preorder[pstart];
        int i = 0;
        for( ; i < inorder.Length; i++){
            if(inorder[i] == rootVal) { break; }
        }
        TreeNode root = new TreeNode(rootVal);
        root.left = Helper(preorder, pstart + 1, pstart + 1 + (i - 1 - istart), inorder, istart, i - 1);
        root.right = Helper(preorder, pstart + 1 + (i - 1 - istart) + 1, pend, inorder, i + 1, iend);
        return root;
    }
}