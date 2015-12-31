Divide two integers without using multiplication, division and mod operator.

If it is overflow, return MAX_INT.


public class Solution {
    // 72 = 8 + (8+8) + (8+8+8+8) + 8
    public int Divide(int dividend, int divisor) {
        long y = dividend, x = divisor;
        y = Math.Abs(y);
        x = Math.Abs(x);
        
        long count = 0;
        while(y >= x){
            long tmpSum = x; 
            int tmpCount = 1;
            while(y >= tmpSum){
                y -= tmpSum;
                count += tmpCount;
                
                tmpSum *= 2;
                tmpCount *= 2;
            }
        }
        if((dividend > 0) ^ (divisor > 0)) count *= -1;
        if(count > Int32.MaxValue || -count < Int32.MinValue) return Int32.MaxValue; // overflow
        return (int)count;
    }
}