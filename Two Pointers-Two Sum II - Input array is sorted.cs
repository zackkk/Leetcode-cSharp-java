Given an array of integers that is already sorted in ascending order, 
find two numbers such that they add up to a specific target number.

The function twoSum should return indices of the two numbers such that they add up to the target, 
where index1 must be less than index2. Please note that your returned answers (both index1 and index2) are not zero-based.

You may assume that each input would have exactly one solution.

Input: numbers={2, 7, 11, 15}, target=9
Output: index1=1, index2=2


public class Solution {
    // two pointers
    public int[] TwoSum(int[] numbers, int target) {
        int[] result = {0, 0};
        int left = 0, right = numbers.Length - 1;
        while(left <= right) {
            if(numbers[left] + numbers[right] == target) {
                result[0] = left + 1;  // not zero-based
                result[1] = right + 1;
                return result;
            }
            else if (numbers[left] + numbers[right] < target) {
                left++;
            }
            else {
                right--;
            }
        }
        return result;
    }
}