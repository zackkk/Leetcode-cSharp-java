Merge two sorted linked lists and return it as a new list. 
The new list should be made by splicing together the nodes of the first two lists.


/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    // Iteration
    public ListNode MergeTwoLists(ListNode l1, ListNode l2) {
        ListNode dummy = new ListNode(0);
        ListNode prev = dummy;
        while(l1 != null || l2 != null){
            if(l1 == null) { prev.next = l2; break; }
            if(l2 == null) { prev.next = l1; break; }
            if(l1.val < l2.val) {
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
    
    // Recursion
    public ListNode MergeTwoLists2(ListNode l1, ListNode l2) {
        if(l1 == null) return l2;
        if(l2 == null) return l1;
        if(l1.val < l2.val){
            l1.next = MergeTwoLists(l1.next, l2);
            return l1;
        }
        else{
            l2.next = MergeTwoLists(l1, l2.next);
            return l2;
        }
    }
}