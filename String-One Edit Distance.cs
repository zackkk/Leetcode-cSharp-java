Given two strings S and T, determine if they are both one edit distance apart.


public class Solution {
    // same length: diff only one character
    // diff length: the longer one has only one extra character 
    public bool IsOneEditDistance(string s, string t) {
        int len_s = s.Length, len_t = t.Length;
        if(Math.Abs(len_s - len_t) >= 2) return false;
        if(len_s == len_t) return IsOneModify(s, t);
        if(len_s == len_t + 1) 
            return IsOneDeletion(s, t);
        else
            return IsOneDeletion(t, s);
    }
    
    bool IsOneModify(string s, string t){
        int count = 0;
        for(int i = 0; i < s.Length; i++){
            if(s[i] != t[i]) count++;
        }
        return count == 1;
    }
    
    // string s has one more character than string t
    bool IsOneDeletion(string s, string t){
        for(int i = 0; i < t.Length; i++){
            if(s[i] != t[i]){
                return s.Substring(i+1, t.Length - i) == t.Substring(i, t.Length - i);   
            }
        }
        return true;
    }
}