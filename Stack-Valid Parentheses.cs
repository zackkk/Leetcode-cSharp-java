Given a string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

The brackets must close in the correct order, "()" and "()[]{}" are all valid but "(]" and "([)]" are not.


public class Solution {
    public bool IsValid(string s) {
        Stack<char> stack = new Stack<char>();
        Dictionary<char, char> dict = new Dictionary<char, char>();
        dict['('] = ')';
        dict['['] = ']';
        dict['{'] = '}';
        for(int i = 0; i < s.Length; i++){
            if(dict.ContainsKey(s[i])){
                stack.Push(s[i]);
            }
            else{
                if(stack.Count == 0) return false;  // trick 1 - "]"
                char top = stack.Pop();
                if(dict[top] != s[i]) {
                    return false;
                }
            }
        }
        return stack.Count == 0; // trick 2 - "["
    }
}