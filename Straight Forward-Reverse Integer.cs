Reverse digits of an integer.

Example1: x = 123, return 321
Example2: x = -123, return -321


public class Solution {
    // straight forward
    public int Reverse(int x) {
        long result = 0;
        while(x != 0) {
            result = result * 10 + x % 10;
            x /= 10;
            if(result > int.MaxValue || result < int.MinValue) return 0;
        }
        return (int)result;
    }
}