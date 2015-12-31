Given an input string, reverse the string word by word. A word is defined as a sequence of non-space characters.

The input string does not contain leading or trailing spaces and the words are always separated by a single space.

For example,
Given s = "the sky is blue",
return "blue is sky the".


public class Solution {
    // "the sky is blue" -> "eulb si yks eht" -> "blue is the sky the"
    public void ReverseWords(char[] s) {
        Reverse(s, 0, s.Length - 1);
        
        // reverse each word
        int i = 0;
        while(i < s.Length) {
            int start = i, end = i;
            while(end < s.Length && s[end] != ' ') end++;
            Reverse(s, start, end - 1);
            i = end + 1;
        }
    }
    
    void Reverse(char[] s, int i, int j){
        for( ; i < j; i++, j--){
            char tmp = s[i];
            s[i] = s[j];
            s[j] = tmp;
        }
    }
}