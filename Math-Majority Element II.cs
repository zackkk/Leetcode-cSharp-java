Given an integer array of size n, find all elements that appear more than ⌊ n/3 ⌋ times. 
The algorithm should run in linear time and in O(1) space.


public class Solution {
    // same idea as Majority Element I
    public IList<int> MajorityElement(int[] nums) {
        int count1 = 0, count2 = 0, major1 = 0, major2 = 0;
        foreach(int num in nums){
            if(count1 == 0){
                major1 = num;
                count1 = 1;
            }
            else if(num == major1){
                count1++;
            }
            else if(count2 == 0){
                major2 = num;
                count2 = 1;
            }
            else if(num == major2){
                count2++;
            }
            else{
                count1--;
                count2--;
            }
        }
        
        count1 = 0;
        count2 = 0;
        foreach(int num in nums){
            if(num == major1) count1++;
            if(num == major2 && major1 != major2) count2++; // may add extra "0" as major2
        }
        IList<int> result = new List<int>();
        if(count1 > nums.Length / 3) result.Add(major1);
        if(count2 > nums.Length / 3) result.Add(major2);
        return result;
    }
}