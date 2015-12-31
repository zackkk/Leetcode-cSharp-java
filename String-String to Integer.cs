mplement atoi to convert a string to an integer.

Hint: Carefully consider all possible input cases. 
If you want a challenge, please do not see below and ask yourself what are the possible input cases.

Notes: It is intended for this problem to be specified vaguely (ie, no given input specs). 
You are responsible to gather all the input requirements up front.


public class Solution {
    // space, sign, overflow
    public int MyAtoi(string str) {
        int i = 0;
        int sign = 1;
        long result = 0;
        while(i < str.Length && str[i] == ' ') { i++; }
        if(i < str.Length && (str[i] == '+' || str[i] == '-')) { sign = str[i] == '+' ? 1 : -1;  i++; }
        while(i < str.Length && str[i] >= '0' && str[i] <= '9'){
            result = result * 10 + (str[i] - '0');
            if(result * sign > int.MaxValue) return int.MaxValue;
            if(result * sign < int.MinValue) return int.MinValue;
            i++; // bug happened
        }
        return (int)result*sign;
    }
}