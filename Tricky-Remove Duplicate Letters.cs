Given a string which contains only lowercase letters, 
remove duplicate letters so that every letter appear once and only once. 
You must make sure your result is the smallest in lexicographical order among all possible results.

Example:
Given "bcabc"
Return "abc"

Given "cbacdcbc"
Return "acdb"


public class Solution {
    // recursion
    // find the lexicographically smallest letter's position, like "a", delete other "a"s, the do it recursively 
    // O(26*N) = O(N)
    public string RemoveDuplicateLetters(string s) {
        if(s.Length == 0) return "";
        
        int[] count = new int[26]; // count frequency for each letter
        for(int i = 0; i < s.Length; i++) count[s[i] - 'a']++;
        
        int targetIndex = 0;
        for(int i = 0; i < s.Length; i++){
            if(s[i] < s[targetIndex]) targetIndex = i;  // choose the leftmost one, don't update if they are equal
            if(--count[s[i] - 'a'] == 0) break; // all letters must appear at least once
        }
        char selectedChar = s[targetIndex];
        
        // get letter after the selected char and deleted other selected chars
        return selectedChar + 
               RemoveDuplicateLetters(s.Substring(targetIndex + 1, s.Length - (targetIndex + 1)).Replace(selectedChar.ToString(), ""));
    }
}