Implement an iterator over a binary search tree (BST). Your iterator will be initialized with the root node of a BST.

Calling next() will return the next smallest number in the BST.

Note: next() and hasNext() should run in average O(1) time and uses O(h) memory, where h is the height of the tree.


/**
 * Definition for binary tree
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class BSTIterator {
    // revised from iteratively in-order traverse
    Stack<TreeNode> stack;
    TreeNode cur;

    public BSTIterator(TreeNode root) {
        stack = new Stack<TreeNode>();
        cur = root;
    }

    /** @return whether we have a next smallest number */
    public bool HasNext() {
        return cur != null || stack.Count > 0;
    }

    /** @return the next smallest number */
    public int Next() {
        while(cur != null || stack.Count > 0){
            while(cur != null){
                stack.Push(cur);
                cur = cur.left;
            }
            if(stack.Count > 0){
                cur = stack.Peek().right;
                break;
            }
        }
        return stack.Pop().val;
    }
}

/**
 * Your BSTIterator will be called like this:
 * BSTIterator i = new BSTIterator(root);
 * while (i.HasNext()) v[f()] = i.Next();
 */