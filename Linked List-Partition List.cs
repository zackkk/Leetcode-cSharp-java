Given a linked list and a value x, partition it such that all nodes less than x come before nodes greater than or equal to x.

You should preserve the original relative order of the nodes in each of the two partitions.

For example,
Given 1->4->3->2->5->2 and x = 3,
return 1->2->2->4->3->5.


/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    // two dummies
    public ListNode Partition(ListNode head, int x) {
        ListNode dummy1 = new ListNode(0), dummy2 = new ListNode(0);
        ListNode cur1 = dummy1, cur2 = dummy2;
        while(head != null){
            if(head.val < x){
                cur1.next = head;
                cur1 = head;
            }
            else{
                cur2.next = head;
                cur2 = head;
            }
            head = head.next;
        }
        cur2.next = null;
        cur1.next = dummy2.next;
        return dummy1.next;
    }
}