Given two strings s and t, determine if they are isomorphic.

Two strings are isomorphic if the characters in s can be replaced to get t.

All occurrences of a character must be replaced with another character while preserving the order of characters. 
No two characters may map to the same character but a character may map to itself.

For example,
Given "egg", "add", return true.

Given "foo", "bar", return false.

Given "paper", "title", return true.


public class Solution {
    // intuitve: dictionary for letter mapping
    // Improve: letter-letter-number mapping - see the first succeed submission
    public bool IsIsomorphic(string s, string t) {
        Dictionary<char, char> dict_s = new Dictionary<char, char>();
        Dictionary<char, char> dict_t = new Dictionary<char, char>();
        
        for (int i = 0; i < s.Length; i++)
        {
            if (dict_s.ContainsKey(s[i]) && dict_s[s[i]] != t[i]) return false;
            if (dict_t.ContainsKey(t[i]) && dict_t[t[i]] != s[i]) return false;
            dict_s[s[i]] = t[i];
            dict_t[t[i]] = s[i];
        }
        
        return true;
    }
}