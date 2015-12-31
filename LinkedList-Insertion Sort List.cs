Sort a linked list using insertion sort.


/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    // helper pointers: dummy, prev, cur, nt
    public ListNode InsertionSortList(ListNode head) {
        if(head == null) return null;
        ListNode dummy = new ListNode(0);
        ListNode cur = head;
        while(cur != null){
            ListNode prev = dummy, nt = cur.next;
            while(prev.next != null && prev.next.val < cur.val){ // find the position from beginning to insert
                prev = prev.next;
            }
            cur.next = prev.next;
            prev.next = cur;
            cur = nt;
        }
        return dummy.next;
    }
}