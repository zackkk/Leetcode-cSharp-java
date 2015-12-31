Two elements of a binary search tree (BST) are swapped by mistake.

Recover the tree without changing its structure.


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
    // inorder traverse
    // 1 2 3 4 5 6 7 -> 6 & 3 are swappped by mistake
    // 1 2 6 4 5 3 7
    // how to find 6? -> 4 is smaller than 6
    // how to find 3? -> 3 is smaller than 5
    
    TreeNode first, second, prev;
    public void RecoverTree(TreeNode root) {
        Helper(root);
        int tmp = first.val;
        first.val = second.val;
        second.val = tmp;
    }
    
    void Helper(TreeNode root){
        if(root == null) return;
        Helper(root.left);
        
        if(prev != null && root.val < prev.val){
            if(first == null) first = prev;
            second = root;
        }
        prev = root;
        
        Helper(root.right);
    }
}