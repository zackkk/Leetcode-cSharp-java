Follow up for problem "Populating Next Right Pointers in Each Node".

What if the given tree could be any binary tree? Would your previous solution still work?

Note:

You may only use constant extra space.
For example,
Given the following binary tree,
         1
       /  \
      2    3
     / \    \
    4   5    7
After calling your function, the tree should look like:
         1 -> NULL
       /  \
      2 -> 3 -> NULL
     / \    \
    4-> 5 -> 7 -> NULL


/**
 * Definition for binary tree with next pointer.
 * public class TreeLinkNode {
 *     int val;
 *     TreeLinkNode left, right, next;
 *     TreeLinkNode(int x) { val = x; }
 * }
 */
public class Solution {
    // BFS Java Version
    public void connect(TreeLinkNode root) {
        if(root == null) return;
        Queue<TreeLinkNode> queue = new LinkedList<TreeLinkNode>();
        queue.add(root);
        while(queue.size() > 0){
            int curLevelCount = queue.size();
            TreeLinkNode prev = null;
            for(int i = 0; i < curLevelCount; i++){
                TreeLinkNode node = queue.remove();
                if(node.left != null){
                    queue.add(node.left);
                    if(prev == null){ 
                        prev = node.left;
                    }
                    else{
                        prev.next = node.left;
                        prev = node.left;
                    }
                }
                if(node.right != null){
                    queue.add(node.right);
                    if(prev == null){ 
                        prev = node.right;
                    }
                    else{
                        prev.next = node.right;
                        prev = node.right;
                    }
                }
            }
        }
    }
    
    // BFS - Leetcode doesn't support C# for this question
    /*
    public void connectCSharp(TreeLinkNode root) {
        if(root == null) return;
        Queue<TreeLinkNode> queue = new Queue<TreeLinkNode>();
        queue.Enqueue(root);
        while(queue.Count > 0){
            int curLevelCount = queue.Count;
            TreeLinkNode prev = null;
            for(int i = 0; i < curLevelCount; i++){
                TreeLinkNode node = queue.Dequeue();
                if(node.left != null){
                    queue.Enqueue(node.left);
                    if(prev == null){ 
                        prev = node.left;
                    }
                    else{
                        prev.next = node.left;
                        prev = node.left;
                    }
                }
                if(node.right != null){
                    queue.Enqueue(node.right);
                    if(prev == null){ 
                        prev = node.right;
                    }
                    else{
                        prev.next = node.right;
                        prev = node.right;
                    }
                }
            }
        }
    }
    */
}