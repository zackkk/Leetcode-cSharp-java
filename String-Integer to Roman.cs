Given an integer, convert it to a roman numeral.

Input is guaranteed to be within the range from 1 to 3999.


public class Solution {
    // Check from the largest to the smallest 
    public string IntToRoman(int num) {
        int[] values = {1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1};
        string[] strs = {"M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"};
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < values.Length; i++) {
            while (num >= values[i]) {
                sb.Append(strs[i]);
                num -= values[i];
            }
        }
        return sb.ToString();
    }
}