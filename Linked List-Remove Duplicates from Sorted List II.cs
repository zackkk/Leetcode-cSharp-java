Given a sorted linked list, delete all nodes that have duplicate numbers, 
leaving only distinct numbers from the original list.

For example,
Given 1->2->3->3->4->4->5, return 1->2->5.
Given 1->1->1->2->3, return 2->3.


/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    // dummy, prev, cur
    public ListNode DeleteDuplicates(ListNode head) {
        ListNode dummy = new ListNode(0);
        dummy.next = head;
        ListNode prev = dummy, cur = head;
        while(cur != null){
            while(cur.next != null && cur.val == cur.next.val) cur = cur.next;
            if(prev.next == cur) { // haven't moved, no duplicates
                prev = cur;
            }
            else {
                prev.next = cur.next;  // skip all these duplicates
            }
            cur = cur.next;
        }
        return dummy.next;
    }
}