Given an array nums containing n + 1 integers where each integer is between 1 and n (inclusive), 
prove that at least one duplicate number must exist. Assume that there is only one duplicate number, find the duplicate one.

Note:
You must not modify the array (assume the array is read only).
You must use only constant, O(1) extra space.
Your runtime complexity should be less than O(n2).
There is only one duplicate number in the array, but it could be repeated more than once.


public class Solution {
    // https://en.wikipedia.org/wiki/Cycle_detection
    // idea is like linked list cycle 
    public int FindDuplicate(int[] nums) {
        int slow = nums[0], fast = nums[nums[0]];  // [1..n] would not run out of range
        while(slow != fast){
            slow = nums[slow];
            fast = nums[nums[fast]];
        }
        
        slow = 0;
        while(slow != fast){
            slow = nums[slow];
            fast = nums[fast];
        }
        return slow;
    }
    
    public int FindDuplicate2(int[] nums) {
        HashSet<int> hs = new HashSet<int>();
        foreach(int num in nums){
            if(hs.Contains(num)){
                return num;
            }
            hs.Add(num);
        }
        return -1;
    }
}