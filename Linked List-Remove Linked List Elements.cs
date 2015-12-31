Remove all elements from a linked list of integers that have value val.

Example
Given: 1 --> 2 --> 6 --> 3 --> 4 --> 5 --> 6, val = 6
Return: 1 --> 2 --> 3 --> 4 --> 5


/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    // Normal
    public ListNode RemoveElements(ListNode head, int val) {
        ListNode preHead = new ListNode(0);
        preHead.next = head;
        ListNode prev = preHead;
        ListNode cur = head;
        while(cur != null){
            if(cur.val == val){
                prev.next = cur.next;
            }
            else{
                prev = prev.next;
            }
            cur = cur.next;
        }
        return preHead.next;
    }
}