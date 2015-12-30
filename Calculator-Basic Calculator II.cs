Implement a basic calculator to evaluate a simple expression string.

The expression string contains only non-negative integers, +, -, *, / operators and empty spaces . 
The integer division should truncate toward zero.

You may assume that the given expression is always valid.

Some examples:
"3+2*2" = 7
" 3/2 " = 1
" 3+5 / 2 " = 5


public class Solution {
    // one stack save numbers, do the calculation for previous two numbers and its operation 
    public int Calculate(string s) {
        Stack<int> stack = new Stack<int>();
        int num = 0;
        char sign = '+';
        for(int i = 0; i < s.Length; i++){
            if(Char.IsDigit(s[i])){
                num = num * 10 + s[i] - '0';
            }
            // do the calculation for previous two numbers and its operation
            if(i == s.Length - 1 || s[i] == '+' ||  s[i] == '-' || s[i] == '*' || s[i] == '/'){
                if(sign == '+'){
                    stack.Push(num);
                }
                if(sign == '-'){
                    stack.Push(-num);
                }
                if(sign == '*'){
                    stack.Push(stack.Pop() * num);
                }
                if(sign == '/'){
                    stack.Push(stack.Pop() / num);
                }
                num = 0; // reset number 
                sign = s[i]; // record sign
            }
        }
        int result = 0;
        foreach(int i in stack) result += i;
        return result;
    }
}