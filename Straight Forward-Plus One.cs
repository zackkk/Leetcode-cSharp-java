Given a non-negative number represented as an array of digits, plus one to the number.

The digits are stored such that the most significant digit is at the head of the list.


public class Solution {
    // return if it is not '9'
    public int[] PlusOne(int[] digits){
        int i = digits.Length - 1; // will plus one position
        while (i >= 0){
            if(digits[i] != 9){
                digits[i]++;
                return digits;
            }
            else{
                digits[i] = 0;
                i--;
            }
        }
        
        // 999999999
        int[] result = new int[digits.Length + 1];
        result[0] = 1;
        return result;
    }
}