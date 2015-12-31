Given an array of numbers, verify whether it is the correct preorder traversal sequence of a binary search tree.

You may assume each number in the sequence is unique.


public class Solution {
    // it has a stack solution, but hard to understand
    public bool VerifyPreorder(int[] preorder) {
        return Helper(preorder, 0, preorder.Length - 1);
    }
    
    // example: [4,2,1,3,6,5,7]
    bool Helper(int[] preorder, int start, int end){
        if(start >= end) return true;
        int pivot = preorder[start];
        int greaterIndex = -1;
        for(int i = start + 1; i <= end; i++){
            if(greaterIndex == -1 && preorder[i] > pivot) greaterIndex = i;
            if(greaterIndex != -1 && preorder[i] < pivot) return false;
        }
        if(greaterIndex == -1) return Helper(preorder, start + 1, end);
        else return Helper(preorder, start + 1, greaterIndex - 1) && Helper(preorder, greaterIndex, end);
    }
}