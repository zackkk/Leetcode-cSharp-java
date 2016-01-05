Write an algorithm to determine if a number is "happy".

A happy number is a number defined by the following process: Starting with any positive integer, 
replace the number by the sum of the squares of its digits, and repeat the process until the number equals 1 (where it will stay), 
or it loops endlessly in a cycle which does not include 1. 

Those numbers for which this process ends in 1 are happy numbers.

Example: 19 is a happy number

1*1 + 9*9 = 82
8*8 + 2*2 = 68
6*6 + 8*8 = 100
1*1 + 0*0 + 0*0 = 1


public class Solution {
    // key: detect loop
    public bool IsHappy(int n) {
        int x = n;
        int y = n;
        while (x > 0){
            x = cal(x);
            if (x == 1) return true;
            y = cal(cal(y)); 
            if (y == 1) return true;
            
            if (x == y) return false; // loop detection
        }
        return true;
    }
    
    int cal(int n) {
        int sum = 0;
        while (n > 0){
            sum += ((n % 10) * (n % 10));
            n /= 10;
        }
        return sum;
    }
}