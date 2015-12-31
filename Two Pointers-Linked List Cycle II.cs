Given a linked list, return the node where the cycle begins. If there is no cycle, return null.

Note: Do not modify the linked list.


/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution {
    // two pointers trick
    // slow: k + t
    // fast: k + t + a cycle => k + t = a cycle
    public ListNode DetectCycle(ListNode head) {
        ListNode slow = head, fast = head;
        while(slow != null && fast != null){
            slow = slow.next;
            if(fast.next == null) { return null; } // no cycle
            fast = fast.next.next;
            if(fast == slow) { break; }
        }
        if(fast == null) { return null; } // no cycle
        
        slow = head;
        while(slow != fast){
            slow = slow.next;
            fast = fast.next;
        }
        return fast; // or slow
    }
}