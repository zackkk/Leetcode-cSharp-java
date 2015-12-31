There are N children standing in a line. Each child is assigned a rating value.

You are giving candies to these children subjected to the following requirements:

Each child must have at least one candy.
Children with a higher rating get more candies than their neighbors.
What is the minimum candies you must give?


public class Solution {
    // abstract the model and three types of lines: increase, decrease, and horizontal
    public int Candy(int[] ratings) {
        int n = ratings.Length;
        int[] nums = new int[n];
        for(int i = 0; i < n; i++) nums[i] = 1;
        
        // increase
        for(int i = 1; i < n; i++){
            if(ratings[i] > ratings[i-1]){
                nums[i] = nums[i-1] + 1;
            }
        }
        
        // decrease
        for(int i = n-2; i >= 0; i--){
            if(ratings[i] > ratings[i+1] && nums[i] <= nums[i+1]){
                nums[i] = nums[i+1] + 1;
            }
        }
        
        int result = 0;
        for(int i = 0; i < n; i++) result += nums[i];
        return result;
    }
}