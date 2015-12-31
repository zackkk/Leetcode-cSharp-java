Sort a linked list in O(n log n) time using constant space complexity.


/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    // cut into two halfs -> sort each half -> merge two sorted halfs
    public ListNode SortList(ListNode head) {
        if(head == null || head.next == null) return head;
        ListNode slow = head, fast = head, prev = null;
        while(fast != null && fast.next != null){
            prev = slow;
            slow = slow.next;
            fast = fast.next.next;
        }
        prev.next = null;
        
        ListNode l1 = SortList(head);
        ListNode l2 = SortList(slow);
        
        return MergeList(l1, l2);
    }
    
    ListNode MergeList(ListNode l1, ListNode l2){
        ListNode dummy = new ListNode(0), prev = dummy;
        while(l1 != null || l2 != null){
            if(l1 == null){
                prev.next = l2;
                break;
            }
            if(l2 == null){
                prev.next = l1;
                break;
            }
            if(l1.val < l2.val){
                prev.next = l1;
                prev = l1;
                l1 = l1.next;
            }
            else{
                prev.next = l2;
                prev = l2;
                l2 = l2.next;
            }
        }
        return dummy.next;
    }
}