Given n non-negative integers a1, a2, ..., an, where each represents a point at coordinate (i, ai). 
n vertical lines are drawn such that the two endpoints of line i is at (i, ai) and (i, 0). 
Find two lines, which together with x-axis forms a container, such that the container contains the most water.

Note: You may not slant the container.


public class Solution {
    // two pointers
    public int MaxArea(int[] height) {
        int left = 0, right = height.Length - 1, maxArea = int.MinValue;
        while(left < right){
            int h = Math.Min(height[left], height[right]);
            maxArea = Math.Max(maxArea, h * (right - left));
            if(height[left] < height[right]){
                left++; // can eliminate all positions (left, x); since max height is "left", and width will be shorter. 
            }
            else {
                right--;
            }
        }
        return maxArea;
    }
}