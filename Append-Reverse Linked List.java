/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     int val;
 *     ListNode next;
 *     ListNode() {}
 *     ListNode(int val) { this.val = val; }
 *     ListNode(int val, ListNode next) { this.val = val; this.next = next; }
 * }
 */
class Solution {
    // 将当前遍历到的元素插入到最前面
    // -1 ->   3 -> 2 -> 1 -> 4* -> 5
    // -1 ->   4 -> 3 -> 2 -> 1  -> 5
    public ListNode reverseList(ListNode current) {
        if (current == null) {
            return null;
        }
        ListNode dummy = new ListNode();
        dummy.next = current;
        while(current.next != null) {
            ListNode first = dummy.next;
            ListNode second = current.next;
            ListNode third = second.next;
        
            dummy.next = second;
            second.next = first;
            current.next = third;
        }
        return dummy.next;
    }
}
