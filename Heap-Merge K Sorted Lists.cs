Merge k sorted linked lists and return it as one sorted list. 
Analyze and describe its complexity.


/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    // min-heap in C++/Java 
    // find the smalles
    public ListNode MergeKLists(ListNode[] lists) {
        ListNode preHead = new ListNode(-1);
        ListNode prev = preHead;
        while(true){
            int minValue = int.MaxValue;
            int minValuePtr = -1;
            for(int i = 0; i < lists.Length; i++){
                if(lists[i] != null && lists[i].val < minValue){
                    minValue = lists[i].val;
                    minValuePtr = i;
                }
            }
            if(minValuePtr == -1) break;
            prev.next = lists[minValuePtr];
            prev = lists[minValuePtr];
            lists[minValuePtr] = lists[minValuePtr].next;
        }
        return preHead.next; // better to delete preHead 
    }
}