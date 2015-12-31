Reverse a linked list from position m to n. Do it in-place and in one-pass.

For example:
Given 1->2->3->4->5->NULL, m = 2 and n = 4,

return 1->4->3->2->5->NULL.

Note:
Given m, n satisfy the following condition:
1 ≤ m ≤ n ≤ length of list.


/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    // dummy -> 1 -> 2 -> 3 -> 4 -> 5 : prev=1, cur=2, nt=3
    // dummy -> 1 -> 3 -> 2 -> 4 -> 5 : prev=1, cur=2, nt=4
    // dummy -> 1 -> 4 -> 3 -> 2 -> 5 : done
    public ListNode ReverseBetween(ListNode head, int m, int n) {
        ListNode dummy = new ListNode(0);
        dummy.next = head;
        ListNode prev = dummy;
        for(int i = 0; i < m - 1; i++) prev = prev.next;
        
        ListNode cur = prev.next, nt = cur.next;
        for(int i = 0; i < n - m; i++){
            cur.next = nt.next;
            nt.next = prev.next;
            prev.next = nt;
            nt = cur.next;
        }
        return dummy.next;
    }
}