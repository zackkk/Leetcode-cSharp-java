Given a linked list, swap every two adjacent nodes and return its head.

For example,
Given 1->2->3->4, you should return the list as 2->1->4->3.

Your algorithm should use only constant space. 
You may not modify the values in the list, only nodes itself can be changed.


/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    // Iteration
    public ListNode SwapPairs(ListNode head) {
        ListNode dummy = new ListNode(0);
        dummy.next = head;
        ListNode prev = dummy, first = head;
        while(first != null){
            ListNode second = first.next;
            if(second == null){
                prev.next = first;
                break;
            }
            
            ListNode third = second.next;
            prev.next = second;
            second.next = first;
            first.next = null;
            prev = first;
            first = third;
        }
        return dummy.next;
    }
    
    // Recursion
    public ListNode SwapPairs2(ListNode head) {
        if(head == null || head.next == null) return head; // return when there are less than two elements
        ListNode first = head;
        ListNode second = head.next;
        first.next = SwapPairs(second.next);
        second.next = first;
        return second;
    }
}