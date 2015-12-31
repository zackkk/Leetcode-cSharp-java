Given n non-negative integers representing an elevation map where the width of each bar is 1, 
compute how much water it is able to trap after raining.

For example, 
Given [0,1,0,2,1,0,1,3,2,1,2,1], return 6.


public class Solution {
    // water can be trapped depends on its maxLeft and maxRight
    // two pointers 
    public int Trap(int[] height) {
        int left = 0, right = height.Length - 1;
        int maxLeft = 0, maxRight = 0;
        int maxWater = 0;
        while(left <= right){
            maxLeft = Math.Max(maxLeft, height[left]);
            maxRight = Math.Max(maxRight, height[right]);
            if(maxLeft < maxRight){ // found most water can get for the current position
                maxWater += (maxLeft - height[left]);
                left++;
            }
            else{
                maxWater += (maxRight - height[right]);
                right--;
            }
        }
        return maxWater;
    }
}