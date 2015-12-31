Given a string, determine if it is a palindrome, 
considering only alphanumeric characters and ignoring cases.

For example,
"A man, a plan, a canal: Panama" is a palindrome.
"race a car" is not a palindrome.


public class Solution {
    // be care of not using in-loop while to skip spaces
    public bool IsPalindrome(string s) {
        int left = 0;
        int right = s.Length - 1;
        while (left <= right) {
            if (Char.IsLetterOrDigit(s[left]) == false) {
                left++;
            }
            else if (Char.IsLetterOrDigit(s[right]) == false) {
                right--;
            }
            else {
                if (Char.ToLower(s[left]) != Char.ToLower(s[right])) return false;
                left++;
                right--;
            }
        }
        return true;
    }
}