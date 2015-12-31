Given a list, rotate the list to the right by k places, where k is non-negative.

For example:
Given 1->2->3->4->5->NULL and k = 2,
return 4->5->1->2->3->NULL.


/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    // Get linked list length -> find new head 
    public ListNode RotateRight(ListNode head, int k) {
        if(head == null) return null;
        ListNode tail = head;
        int len = 1;
        while(tail.next != null){
            len++;
            tail = tail.next;
        }
        tail.next = head;  // form a cycle
        
        k = k % len;
        for(int i = 0; i < len - k; i++) tail = tail.next;
        ListNode newHead = tail.next;
        tail.next = null;
        return newHead;
    }
}