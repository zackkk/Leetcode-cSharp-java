Given a singly linked list L: L0→L1→…→Ln-1→Ln,
reorder it to: L0→Ln→L1→Ln-1→L2→Ln-2→…

You must do this in-place without altering the nodes values.

For example,
Given {1,2,3,4}, reorder it to {1,4,2,3}.


/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    // cut into two halfs -> reverse the second half -> merge two lists
    public void ReorderList(ListNode head) {
        if(head == null || head.next == null) return;
        
        // cut, length of first half >= length of second half
        ListNode slow = head, fast = head;
        while(fast.next != null && fast.next.next != null){
            slow = slow.next;
            fast = fast.next.next;
        }
        ListNode secondHead = slow.next;
        slow.next = null;
        
        // reverse
        ListNode prev = null, cur = secondHead; // point: initialize prev to be null to avoid loop
        while(cur != null){
            ListNode nt = cur.next;
            cur.next = prev;
            prev = cur;
            cur = nt;
        }
        secondHead = prev;
        
        // merge
        ListNode cur1 = head, cur2 = secondHead;
        while(cur2 != null){
            ListNode nt1 = cur1.next, nt2 = cur2.next;
            cur1.next = cur2;
            cur2.next = nt1;
            cur1 = nt1;
            cur2 = nt2;
        }
    }
}