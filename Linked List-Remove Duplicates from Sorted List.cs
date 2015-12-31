Given a sorted linked list, delete all duplicates such that each element appear only once.

For example,
Given 1->1->2, return 1->2.
Given 1->1->2->3->3, return 1->2->3.


/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode DeleteDuplicates(ListNode head) {
        if (head == null) return null;
        ListNode cur = head;
        while (cur.next != null){
            if(cur.val == cur.next.val){
                cur.next = cur.next.next;
            }
            else{
                cur = cur.next;
            }
        }
        return head;
    }
}