You are given an integer array nums and you have to return a new counts array. 
The counts array has the property where counts[i] is the number of smaller elements to the right of nums[i].

Example:

Given nums = [5, 2, 6, 1]

To the right of 5 there are 2 smaller elements (2 and 1).
To the right of 2 there is only 1 smaller element (1).
To the right of 6 there is 1 smaller element (1).
To the right of 1 there is 0 smaller element.
Return the array [2, 1, 1, 0].


public class Solution {
    // tricky -> build binary search tree
    
    public class TreeNode{
        public int val;
        public int count;  // number of elements on the left 
        public TreeNode left, right;
        public TreeNode(int value){
            val = value;
            count = 1; // itself
        }    
    }
    
    public IList<int> CountSmaller(int[] nums) {
        IList<int> result = new List<int>();
        int n = nums.Length;
        if(n == 0) return result;
        TreeNode root = new TreeNode(nums[n-1]);
        result.Add(0); // the right most element has no elements on its right
        for(int i = n - 2; i >= 0; i--){
            result.Insert(0, insert(root, nums[i]));
        }
        return result;
    }
    
    int insert(TreeNode root, int val){
        int tmp_count = 0;
        while(true){
            if(val <= root.val){
                root.count++; // increase the number of elements on the left subtree.
                if(root.left != null){
                    root = root.left;
                }
                else{
                    root.left = new TreeNode(val);
                    break;
                }
            }
            else{
                tmp_count += root.count; // all inserted elements are on the right side in the array of the newly inserted element
                if(root.right != null){
                    root = root.right;
                }
                else{
                    root.right = new TreeNode(val);
                    break;
                }
            }
        }
        return tmp_count;
    }
}