Given an integer n, return the number of trailing zeroes in n!.

Note: Your solution should be in logarithmic time complexity.


public class Solution {
    // number of zeros -> number of 10s -> number of 2*5 -> # of 2 is always greater than # of 5 -> # of 5
    // 25 = 5*5, 125 = 5*5*5, ...
    // return n/5 + n/25 + n/125 + n/625 + n/3125+...;
    public int TrailingZeroes(int n) {
        long count = 0;
        long five = 5;
        while (five <= n) {
            count += (n / five);
            five *= 5;
        }
        return (int)count;
    }
}