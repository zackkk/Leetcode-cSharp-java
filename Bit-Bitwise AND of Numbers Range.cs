Given a range [m, n] where 0 <= m <= n <= 2147483647, return the bitwise AND of all numbers in this range, inclusive.

For example, given the range [5, 7], you should return 4.


public class Solution {
    // bitwise AND of an odd number and an even number would be zero
    // if m != n, there is at least a pair of odd and even
    // move m and n to the right until they are equal
    public int RangeBitwiseAnd(int m, int n) {
        int factor = 1;
        while(m != n){
            m = m >> 1;
            n = n >> 1;
            factor = factor << 1;
        }
        return m * factor;
    }
}