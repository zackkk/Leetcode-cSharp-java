Given an input string, reverse the string word by word.

For example,
Given s = "the sky is blue",
return "blue is sky the".


public class Solution {
    // reverse all -> reverse each word -> disgusting test cases like " ", "  ", "   "
    // so, instead, get words consectively and insert at the beginning
    public string ReverseWords(string s) {
        StringBuilder sb = new StringBuilder();
        for(int i = 0; i < s.Length; i++){
            if(s[i] == ' ') continue;
            int start = i;
            while(i + 1 < s.Length && s[i+1] != ' ') i++;
            if(sb.Length > 0){
                sb.Insert(0, s.Substring(start, i - start + 1) + " ");
            }
            else{
                sb.Insert(0, s.Substring(start, i - start + 1));
            }
        }
        return sb.ToString();
    }
}