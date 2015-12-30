Given a non-negative integer num, repeatedly add all its digits until the result has only one digit.

For example:

Given num = 38, the process is like: 3 + 8 = 11, 1 + 1 = 2. Since 2 has only one digit, return it.

Follow up:
Could you do it without any loop/recursion in O(1) runtime?


public class Solution {
    public int AddDigits(int num){
        int result = num;
        while(result >= 10){
            int sum = 0;
            while(result > 0){
                sum += result % 10;
                result /= 10;
            }
            result = sum;
        }
        return result;
    }
    
    
    // 2015 = 2*1000 + 0*100 + 1*10 + 5
    // 1000 % 9 == 1
    // 100  % 9 == 1
    // ...
    // 2+0+1+5 = 2015 % 9 (multiple and module have same order)
    public int AddDigits2(int num) {
        if (num == 0) return 0;
        if (num % 9 == 0) return 9;
        return num % 9;
    }
}