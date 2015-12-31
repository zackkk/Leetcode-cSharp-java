Given an array of integers, find if the array contains any duplicates. 
Your function should return true if any value appears at least twice in the array, 
and it should return false if every element is distinct.

public class Solution {
    // Hashset
    public bool ContainsDuplicate(int[] nums) {
        HashSet<int> hs = new HashSet<int>();
        for(int i = 0; i < nums.Length; i++){
            if(hs.Contains(nums[i])){
                return true;
            }
            hs.Add(nums[i]);
        }
        return false;
    }
}