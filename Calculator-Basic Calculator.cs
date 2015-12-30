Implement a basic calculator to evaluate a simple expression string.

The expression string may contain open ( and closing parentheses ), the plus + or minus sign -, 
non-negative integers and empty spaces .

You may assume that the given expression is always valid.

Some examples:
"1 + 1" = 2
" 2-1 + 2 " = 3
"(1+(4+5+2)-3)+(6+8)" = 23


public class Solution {
    // the sign associated with each number related to signs before "("
    // 5 - ( 6 + ( 4 - 7 ) ), if we remove all parentheses, the expression becomes 5 - 6 - 4 + 7.
    // sign stack:
    // 6: (-1)(1) = -1
    // 4: (-1)(1)(1) = -1
    // 7: (-1)(1)(-1) = 1
    
    public int Calculate(string s) {
        int result = 0;
        Stack<int> stack = new Stack<int>();
        int sign = 1;
        stack.Push(1);
        for(int i = 0; i < s.Length; i++){
            if(s[i] == ' ') continue;
            else if(s[i] == '(') { stack.Push(stack.Peek() * sign); sign = 1; }
            else if(s[i] == ')') { stack.Pop(); }
            else if(s[i] == '+') { sign = 1; }
            else if(s[i] == '-') { sign = -1; }
            else{
                int num = s[i] - '0';
                while(i + 1 < s.Length && s[i+1] >= '0' && s[i+1] <= '9'){
                    i++;
                    num = num * 10 + s[i] - '0';
                }
                result += num * stack.Peek() * sign;
            }
        }
        return result;
    }
}