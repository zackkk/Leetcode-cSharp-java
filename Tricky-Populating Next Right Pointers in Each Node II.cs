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
    // why leftMost doesn't work ? because it is not complete ! 
    public void connect(TreeLinkNode root) {
        if(root == null) return;
        TreeLinkNode dummy = new TreeLinkNode(0);
        TreeLinkNode leftMost = root;
        while(leftMost != null){
            TreeLinkNode cur = leftMost;
            TreeLinkNode child = dummy; // at each level, assign "next" for child level
            
            while(cur != null){
                if(cur.left != null){
                    child.next = cur.left;
                    child = child.next;
                }
                if(cur.right != null){
                    child.next = cur.right;
                    child = child.next;
                }
                cur = cur.next;
            }
            
            leftMost = dummy.next; // go to its "child" level
            dummy.next = null;
        }
    }
}