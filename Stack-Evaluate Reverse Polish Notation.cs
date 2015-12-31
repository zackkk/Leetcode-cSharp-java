Evaluate the value of an arithmetic expression in Reverse Polish Notation.

Valid operators are +, -, *, /. Each operand may be an integer or another expression.

Some examples:
  ["2", "1", "+", "3", "*"] -> ((2 + 1) * 3) -> 9
  ["4", "13", "5", "/", "+"] -> (4 + (13 / 5)) -> 6


public class Solution {
    // straight forward stack implementation
    public int EvalRPN(string[] tokens) {
        Stack<int> stack = new Stack<int>();
        foreach(string token in tokens){
            if(token == "+"){
                stack.Push(stack.Pop() + stack.Pop());
            }
            else if(token == "-"){
                int a = stack.Pop();
                int b = stack.Pop();
                stack.Push(b - a);
            }
            else if(token == "*"){
                stack.Push(stack.Pop() * stack.Pop());
            }
            else if(token == "/"){
                int a = stack.Pop();
                int b = stack.Pop();
                stack.Push(b / a);
            }
            else{
                stack.Push(Int32.Parse(token));
            }
        }
        return stack.Pop();
    }
}