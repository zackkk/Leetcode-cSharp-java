Given a binary tree, return the level order traversal of its nodes values. (ie, from left to right, level by level).

For example:
Given binary tree {3,9,20,#,#,15,7},
    3
   / \
  9  20
    /  \
   15   7
return its level order traversal as:
[
  [3],
  [9,20],
  [15,7]
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
    // Recursion
    IList<IList<int>> result; 
    public IList<IList<int>> LevelOrder(TreeNode root) {
        result = new List<IList<int>>();
        Helper(root, 0);
        return result;
    }
    void Helper(TreeNode root, int depth){
        if(root == null) return;
        if(depth == result.Count) result.Add(new List<int>());
        result[depth].Add(root.val);
        Helper(root.left, depth + 1);
        Helper(root.right, depth + 1);
    }
    
    // Iteration
    public IList<IList<int>> LevelOrderIterative(TreeNode root) {
        IList<IList<int>> result = new List<IList<int>>();
        if(root == null) return result;
        
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while(queue.Count != 0) {
            int curNum = queue.Count; // the number of nodes of the current level
            List<int> list = new List<int>(); 
            for(int i = 0; i < curNum; i++){
                TreeNode node = queue.Dequeue();
                list.Add(node.val);
                if(node.left != null) queue.Enqueue(node.left);
                if(node.right != null) queue.Enqueue(node.right);
            }
            result.Add(list);
        }
        return result;
    }
}