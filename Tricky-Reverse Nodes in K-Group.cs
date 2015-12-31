Given a linked list, reverse the nodes of a linked list k at a time and return its modified list.

If the number of nodes is not a multiple of k then left-out nodes in the end should remain as it is.

You may not alter the values in the nodes, only nodes itself may be changed.

Only constant memory is allowed.

For example,
Given this linked list: 1->2->3->4->5

For k = 2, you should return: 2->1->4->3->5

For k = 3, you should return: 3->2->1->4->5


/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    // tricky recursive solution
    public ListNode ReverseKGroup(ListNode head, int k) {
        int count = 0;
        ListNode cur = head;
        while(cur != null && count < k){
            count++;
            cur = cur.next;
        }
        if(count == k){  // have enough to reverse
            ListNode prev = ReverseKGroup(cur, k);
            while(count-- > 0){
                ListNode nt = head.next;
                head.next = prev;
                prev = head;
                head = nt;
            }
            head = prev;
        }
        return head;
    }
}