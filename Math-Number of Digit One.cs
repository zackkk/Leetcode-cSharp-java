Given an integer n, count the total number of digit 1 appearing in all non-negative integers less than or equal to n.

For example:
Given n = 13,
Return 6, because digit 1 occurred in the following numbers: 1, 10, 11, 12, 13.


public class Solution {
    // For example '8192':
    // 1-999 -> countDigitOne(999)
    // 1000-1999 -> 1000 of 1s + countDigitOne(999)
    // 2000-2999 -> countDigitOne(999)
    // ...
    // 7000-7999 -> countDigitOne(999)
    // 8000-8192 -> countDigitOne(192)
    // Count of 1s : countDigitOne(999)*8 + 1000 + countDigitOne(192)
    public int CountDigitOne(int n) {
        if(n <= 0) return 0;
        if(n < 10) return 1;
        
        int baseNum = (int)Math.Pow(10, n.ToString().Length - 1);
        int factor = n / baseNum;
        int remainder = n % baseNum;
        if(factor == 1){
            return CountDigitOne(baseNum - 1) * factor + (n - baseNum + 1) + CountDigitOne(remainder);
        }
        else {
            return CountDigitOne(baseNum - 1) * factor + baseNum + CountDigitOne(remainder);
        }
    } 
}