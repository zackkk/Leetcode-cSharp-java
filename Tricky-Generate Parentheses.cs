Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

For example, given n = 3, a solution set is:

"((()))", "(()())", "(())()", "()(())", "()()()"


public class Solution {
    // "close" should be equal to or less than "open"
    public IList<string> GenerateParenthesis(int n) {
        IList<string> result = new List<string>();
        Helper(result, "", 0, 0, n);
        return result;
    }
    void Helper(IList<string> result, string str, int open, int close, int n) {
        if (str.Length == n * 2) {
            result.Add(str);
            return;
        }
        if (open < n) Helper(result, str + "(", open + 1, close, n);
        if (close < open) Helper(result, str + ")", open, close + 1, n);
    }
}