mplement int sqrt(int x).

Compute and return the square root of x.


public class Solution {
    // binary search
    public int MySqrt(int x) {
        if(x == 0) return 0;
        long low = 1, high = x; // x*x may overflow, or use (mid == x / mid);
        while(low <= high){
            long mid = low + (high - low) / 2;
            if(mid * mid == x) return (int)mid;
            else if(mid * mid > x) { high = mid - 1; }
            else low = mid + 1;
        }
        return low * low > x ? (int)(low - 1) : (int)low;  // special case: 24 -> expected 4
    }
}