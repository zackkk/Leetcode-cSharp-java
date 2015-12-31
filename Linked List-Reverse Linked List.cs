Reverse a singly linked list.

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    // maintain a previous pointer
    public ListNode ReverseList(ListNode head) {
        ListNode prev = null;
        while(head != null) {
            ListNode nt = head.next;
            head.next = prev;
            prev = head;
            head = nt;
        }
        return prev;
    }
}