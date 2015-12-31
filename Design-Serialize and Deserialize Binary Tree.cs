Serialization is the process of converting a data structure or object into a sequence of bits 
so that it can be stored in a file or memory buffer, or transmitted across a network connection link 
to be reconstructed later in the same or another computer environment.

Design an algorithm to serialize and deserialize a binary tree. 
There is no restriction on how your serialization/deserialization algorithm should work. 
You just need to ensure that a binary tree can be serialized to a string and this string can be deserialized 
to the original tree structure.

For example, you may serialize the following tree

    1
   / \
  2   3
     / \
    4   5
as "[1,2,3,null,null,4,5]", just the same as how LeetCode OJ serializes a binary tree. 
You do not necessarily need to follow this format, so please be creative and come up with different approaches yourself.
Note: Do not use class member/global/static variables to store states. 
Your serialize and deserialize algorithms should be stateless.


/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec {
    // pre-order traverse

    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        StringBuilder sb = new StringBuilder();
        serializeHelper(root, sb);
        return sb.ToString();
    }
    
    void serializeHelper(TreeNode root, StringBuilder sb){
        if(root == null){
            sb.Append("#").Append(",");
            return;
        }
        sb.Append(root.val).Append(",");
        serializeHelper(root.left, sb);
        serializeHelper(root.right, sb);
    }


    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        string[] vals = data.Split(',');
        int[] i = new int[]{0}; // used as a pointer, since we can't use clss member..
        return deserializeHelper(vals, i);
    }
    
    TreeNode deserializeHelper(string[] vals, int[] i){
        if(i[0] == vals.Length) return null; // done for all nodes
        if(vals[i[0]] == "#") { i[0]++; return null; }
        
        TreeNode root = new TreeNode(Int32.Parse(vals[i[0]]));
        i[0]++;
        root.left = deserializeHelper(vals, i);
        root.right = deserializeHelper(vals, i);
        return root;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.deserialize(codec.serialize(root));