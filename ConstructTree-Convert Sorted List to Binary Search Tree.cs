Given a singly linked list where elements are sorted in ascending order, convert it to a height balanced BST.


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
    // in-order, use an extra list pointer to move alone the linked list
    ListNode cur;
    public TreeNode SortedListToBST(ListNode head) {
        cur = head;
        ListNode node = head;
        int len = 0;
        while(node != null){
            len++;
            node = node.next;
        }
        return Helper(0, len - 1);
    }
    
    TreeNode Helper(int low, int high){
        if(low > high) return null;
        int mid = low + (high - low) / 2;
        TreeNode l = Helper(low, mid - 1);
        TreeNode root = new TreeNode(cur.val);
        cur = cur.next;
        TreeNode r = Helper(mid + 1, high);
        root.left = l;
        root.right = r;
        return root;
    }
}