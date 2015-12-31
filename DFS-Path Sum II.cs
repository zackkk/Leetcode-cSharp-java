Given a binary tree and a sum, find all root-to-leaf paths where each paths sum equals the given sum.

For example:
Given the below binary tree and sum = 22,
              5
             / \
            4   8
           /   / \
          11  13  4
         /  \    / \
        7    2  5   1
return
[
   [5,4,11,2],
   [5,8,4,5]
]


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
    // this version is true, but failed in a test case using c#
    public IList<IList<int>> PathSum(TreeNode root, int sum) {
        IList<IList<int>> result = new List<IList<int>>();
        IList<int> list = new List<int>();
        if(root == null) return result;
        dfs(root, sum, list, result);
        return result;
    }
    
    void dfs(TreeNode root, int sum, IList<int> list, IList<IList<int>> result){
        list.Add(root.val);
        if(root.left == null && root.right == null && root.val == sum){
            result.Add(new List<int>(list));
        }
        if(root.left != null){ dfs(root.left, sum - root.val, list, result); }
        if(root.right != null) { dfs(root.right, sum - root.val, list, result);}
        list.Remove(list.Count - 1);
    }
}