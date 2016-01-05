Given an array of n positive integers and a positive integer s, 
find the minimal length of a subarray of which the sum ≥ s. If there isnt one, return 0 instead.

For example, given the array [2,3,1,2,4,3] and s = 7,
the subarray [4,3] has the minimal length under the problem constraint.


public class Solution {
    // window with sum greater than or equal to s; while loop at most N times, so O(N) + O(N) = O(N)
    public int MinSubArrayLen(int s, int[] nums) {
        int start = 0, minLen = int.MaxValue, sum = 0;
        for(int i = 0; i < nums.Length; i++){
            sum += nums[i];
            while(sum >= s){
                minLen = Math.Min(minLen, i - start + 1);
                sum -= nums[start];
                start++;  // current window used, then update
            }
        }
        return minLen == int.MaxValue ? 0 : minLen;
    }
}