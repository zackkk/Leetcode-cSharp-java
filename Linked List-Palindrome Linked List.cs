Given a singly linked list, determine if it is a palindrome.


/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    // find mid -> reverse the second half -> compare two halfs
    public bool IsPalindrome(ListNode head) {
        if(head == null) return true;
        
        // find mid point
        ListNode slow = head;
        ListNode fast = head.next;
        while(fast != null && fast.next != null){
            slow = slow.next;
            fast = fast.next.next;
        }
        
        // reverse the second half
        ListNode tail = Reverse(slow);
        
        // compare 
        while(head != null && tail != null){
            if(head.val != tail.val) return false;
            head = head.next;
            tail = tail.next;
        }
        return true;
    }
    
    ListNode Reverse(ListNode head){
        ListNode prev = null;
        ListNode cur = head;
        while(cur != null){
            ListNode nt = cur.next;
            cur.next = prev;
            prev = cur;
            cur = nt;
        }
        return prev;
    }
}


