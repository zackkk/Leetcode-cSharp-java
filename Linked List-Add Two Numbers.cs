You are given two linked lists representing two non-negative numbers. 
The digits are stored in reverse order and each of their nodes contain a single digit. 
Add the two numbers and return it as a linked list.

Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
Output: 7 -> 0 -> 8


/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode dummy = new ListNode(0);
        ListNode prev = dummy;
        int carry = 0;
        while(l1 != null || l2 != null){
            int sum = carry;
            if(l1 != null) { sum += l1.val; l1 = l1.next; }
            if(l2 != null) { sum += l2.val; l2 = l2.next; }
            carry = sum / 10;
            ListNode node = new ListNode(sum % 10);
            prev.next = node;
            prev = node;
        }
        if(carry != 0) { // forgot this
            ListNode node = new ListNode(carry);
            prev.next = node;
        }
        return dummy.next;
    }
}