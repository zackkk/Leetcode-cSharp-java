Given a string S, you are allowed to convert it to a palindrome by adding characters in front of it. 
Find and return the shortest palindrome you can find by performing this transformation.

For example:

Given "aacecaaa", return "aaacecaaa".

Given "abcd", return "dcbabcd".


public class Solution {
    // brute force: find the sub-palindrome starting from the first character, append the reverse of the rest at the beginning.
    public string ShortestPalindrome(string s) {
        int start = 0, end = s.Length - 1;
        for (; end >= start; end--) {
            // check if [start,end] is palindrome
            int i = start, j = end;
            while (i < j && s[i] == s[j]) { i++; j--; }
            if (i >= j) break; // is palindrome
        }
        char[] tmp = s.Substring(end + 1).ToCharArray();
        Array.Reverse(tmp);
        return new string(tmp) + s;
    }
    
}