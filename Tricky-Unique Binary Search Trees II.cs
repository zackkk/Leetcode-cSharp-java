Given n, generate all structurally unique BST's (binary search trees) that store values 1...n.

For example,
Given n = 3, your program should return all 5 unique BST's shown below.

   1         3     3      2      1
    \       /     /      / \      \
     3     2     1      1   3      2
    /     /       \                 \
   2     1         2                 3


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
    // Tricky recursion: divide and conquer, similar to "Different Ways to Add Parentheses"
    public IList<TreeNode> GenerateTrees(int n) {
        if(n == 0) return new List<TreeNode>();
        return Helper(1, n);
    }
    
    IList<TreeNode> Helper(int start, int end){
        IList<TreeNode> result = new List<TreeNode>();
        if(start > end){
            result.Add(null);
            return result;
        }
        if(start == end){
            result.Add(new TreeNode(start));
            return result;
        }
        
        for(int i = start; i <= end; i++){
            IList<TreeNode> left = Helper(start, i - 1);
            IList<TreeNode> right = Helper(i + 1, end);
            foreach(TreeNode l in left){
                foreach(TreeNode r in right){
                    TreeNode root = new TreeNode(i);
                    root.left = l;
                    root.right = r;
                    result.Add(root);
                }
            }
        }
        return result;
    }
}