Given a binary tree, return the bottom-up level order traversal of its nodes values. (ie, from left to right, level by level from leaf to root).

For example:
Given binary tree {3,9,20,#,#,15,7},
    3
   / \
  9  20
    /  \
   15   7
return its bottom-up level order traversal as:
[
  [15,7],
  [9,20],
  [3]
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
    // bfs
    public IList<IList<int>> LevelOrderBottom(TreeNode root) {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        IList<IList<int>> result = new List<IList<int>>(); // WTF C# ! 
        if(root == null) return result;
        queue.Enqueue(root);
        while(queue.Count != 0){
            int size = queue.Count; // size of current level
            List<int> list = new List<int>();
            for (int i = 0; i < size; i++){
                TreeNode node = queue.Dequeue();
                list.Add(node.val);
                if(node.left != null) queue.Enqueue(node.left);
                if(node.right != null) queue.Enqueue(node.right);
            }
            result.Insert(0, list); // add at the front
        }
        return result;
    }
}