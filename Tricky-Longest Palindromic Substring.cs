Given a string S, find the longest palindromic substring in S. You may assume that the maximum length of S is 1000, 
and there exists one unique longest palindromic substring.

public class Solution {
    // start from a point to its left & right
    public string LongestPalindrome(string s) {
        string result = "";
        for(int i = 0; i < s.Length; i++){
            string s1 = GetPalindrome(s, i, i); // "bab"
            string s2 = "";
            if(i + 1 < s.Length && s[i] == s[i+1]){  // "baab"
                s2 = GetPalindrome(s, i, i+1);
            }
            
            if(s1.Length > result.Length) result = s1;
            if(s2.Length > result.Length) result = s2;
        }
        return result;
    }
    
    string GetPalindrome(string s, int i, int j){
        while(i - 1 >= 0 && j + 1 < s.Length && s[i-1] == s[j+1]){ i--; j++; }
        return s.Substring(i, j - i + 1);
    }
}