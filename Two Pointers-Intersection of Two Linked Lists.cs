Write a program to find the node at which the intersection of two singly linked lists begins.

For example, the following two linked lists:

A:          a1 → a2
                   ↘
                     c1 → c2 → c3
                   ↗            
B:     b1 → b2 → b3
begin to intersect at node c1.

Notes:

If the two linked lists have no intersection at all, return null.
The linked lists must retain their original structure after the function returns.
You may assume there are no cycles anywhere in the entire linked structure.
Your code should preferably run in O(n) time and use only O(1) memory.


/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    // using a hashset to save common nodes of all lists
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
        HashSet<ListNode> hashset = new HashSet<ListNode>();
        while(headA != null) { hashset.Add(headA); headA = headA.next; }
        while(headB != null) { 
            if(hashset.Contains(headB)){ return headB; }
            headB = headB.next;
        }
        return null;
    }
    
    // want to move longer dist pointer first for (L - S)
    // don't know len diff: (L - S)
    // two pointers move together 
    // when shorter pointer reached end, let it point to longer list, it traverls "S + (L - S)" dist
    // when longer  pointer reached end, let it point to shorter list, it travels "L" dist
    // it would counteract len diff, thus two pointers have equal dist to the collision point
    public ListNode GetIntersectionNode2(ListNode headA, ListNode headB) {
        if (headA == null || headB == null) return null;
        ListNode ptrA = headA;
        ListNode ptrB = headB;
        while(ptrA != ptrB) {
            ptrA = (ptrA == null ? headB : ptrA.next);
            ptrB = (ptrB == null ? headA : ptrB.next);
        }
        return ptrA; // or ptrB
    }
}