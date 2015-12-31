A linked list is given such that each node contains an additional random pointer 
which could point to any node in the list or null.

Return a deep copy of the list.


/**
 * Definition for singly-linked list with a random pointer.
 * public class RandomListNode {
 *     public int label;
 *     public RandomListNode next, random;
 *     public RandomListNode(int x) { this.label = x; }
 * };
 */
public class Solution {
    // map old to new
    public RandomListNode CopyRandomList(RandomListNode head) {
        if(head == null) return head;
        Dictionary<RandomListNode, RandomListNode> dict = new Dictionary<RandomListNode, RandomListNode>();
        
        // copy nodes and build map
        RandomListNode cur = head;
        while(cur != null) {
            RandomListNode node = new RandomListNode(cur.label);
            dict[cur] = node;
            cur = cur.next;
        }
        
        // copy pointers
        cur = head;
        while(cur != null) {
            dict[cur].next = (cur.next == null ? null : dict[cur.next]);  // check null cases
            dict[cur].random = (cur.random == null ? null : dict[cur.random]);
            cur = cur.next;
        }
        
        return dict[head];
    }
}