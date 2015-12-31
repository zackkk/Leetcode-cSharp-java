Given two strings s and t, write a function to determine if t is an anagram of s.

For example,
s = "anagram", t = "nagaram", return true.
s = "rat", t = "car", return false.

Note:
You may assume the string contains only lowercase alphabets.


public class Solution {
    // Hashmap
    public bool IsAnagram(string s, string t) {
        if(s.Length != t.Length) return false;
        Dictionary<char, int> dict = new Dictionary<char, int>();
        for(int i = 0; i < s.Length; i++){
            dict[s[i]] = dict.ContainsKey(s[i]) ? dict[s[i]] + 1 : 1;
        }
        for(int i = 0; i < t.Length; i++){
            if(dict.ContainsKey(t[i]) == false || dict[t[i]] == 0){
                return false;
            }
            dict[t[i]]--;
        }
        return true;
    }
}