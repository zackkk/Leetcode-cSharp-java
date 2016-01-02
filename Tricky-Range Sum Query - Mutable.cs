Given an integer array nums, find the sum of the elements between indices i and j (i ≤ j), inclusive.

The update(i, val) function modifies nums by updating the element at index i to val.

Example:
Given nums = [1, 3, 5]
sumRange(0, 2) -> 9
update(1, 2)
sumRange(0, 2) -> 8

Note:
The array is only modifiable by the update function.
You may assume the number of calls to update and sumRange function is distributed evenly.


public class NumArray {
    // Solution 1: keep original array -> SumRange O(N), Update O(1)
    // Solution 2: build a sum array -> SumRange O(1), Update O(N)
    // Solution 3: Segment tree -> SumRange O(logN), Update O(logN) -> http://www.geeksforgeeks.org/segment-tree-set-1-sum-of-given-range/
    class Node{
        public int start, end, sum;
        public Node left, right;
        public Node(int i, int j){
            start = i;
            end = j;
        }
    }
    
    Node root;
    public NumArray(int[] nums) {
        root = buildTree(nums, 0, nums.Length - 1);
    }
    
    Node buildTree(int[] nums, int low, int high){
        if(low > high) return null;
        Node root = new Node(low, high);
        if(low == high){
            root.sum = nums[low];
        }
        else{
            int mid = low + (high - low) / 2;
            root.left = buildTree(nums, low, mid);
            root.right = buildTree(nums, mid + 1, high);
            root.sum = root.left.sum + root.right.sum;
        }
        return root;
    }
    
    /*********************************************************************/
    public void Update(int i, int val) {
        update(root, i, val);
    }
    
    void update(Node root, int i, int val){
        if((root.start == root.end) && (root.start == i)){
            root.sum = val;
        }
        else{
            int mid = root.start + (root.end - root.start) / 2;
            if(i <= mid) update(root.left, i, val);
            else update(root.right, i, val);
            root.sum = root.left.sum + root.right.sum; // update sum attribute
        }
    }

    /*********************************************************************/
    public int SumRange(int i, int j) {
        return sumRange(root, i, j);
    }
    
    int sumRange(Node root, int i, int j){
        if(i == root.start && j == root.end) return root.sum;
        int mid = root.start + (root.end - root.start) / 2;
        if(i > mid){ 
            return sumRange(root.right, i, j);
        }
        else if(j < mid + 1){
            return sumRange(root.left, i, j);
        }
        else{
            return sumRange(root.left, i, mid) + sumRange(root.right, mid + 1, j);
        }
    }
}


// Your NumArray object will be instantiated and called as such:
// NumArray numArray = new NumArray(nums);
// numArray.SumRange(0, 1);
// numArray.Update(1, 10);
// numArray.SumRange(1, 2);