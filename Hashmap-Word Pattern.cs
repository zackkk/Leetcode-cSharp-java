Given a pattern and a string str, find if str follows the same pattern.

Here follow means a full match, such that there is a bijection between a letter in pattern and a non-empty word in str.

Examples:
pattern = "abba", str = "dog cat cat dog" should return true.
pattern = "abba", str = "dog cat cat fish" should return false.
pattern = "aaaa", str = "dog cat cat dog" should return false.
pattern = "abba", str = "dog dog dog dog" should return false.

Notes:
You may assume pattern contains only lowercase letters, and str contains lowercase letters separated by a single space.


public class Solution {
    // Build 1 to 1 mapping between a letter and a word
    public bool WordPattern(string pattern, string str) {
        string[] words = str.Split(' ');
        if(pattern.Length != words.Length) return false;
        Dictionary<char, string> dict_p = new Dictionary<char, string>();
        Dictionary<string, char> dict_w = new Dictionary<string, char>();
        for(int i = 0; i < pattern.Length; i++){
            if(dict_p.ContainsKey(pattern[i]) && dict_p[pattern[i]] != words[i]) { // "aa" "dog big"
                return false; 
            }
            if(dict_w.ContainsKey(words[i]) && dict_w[words[i]] != pattern[i]){  // "ab" "dog dog"
                return false;
            }
            dict_p[pattern[i]] = words[i];
            dict_w[words[i]] = pattern[i];
        }
        return true;
    }
}