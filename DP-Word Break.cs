Given a string s and a dictionary of words dict, 
determine if s can be segmented into a space-separated sequence of one or more dictionary words.

For example, given
s = "leetcode",
dict = ["leet", "code"].

Return true because "leetcode" can be segmented as "leet code".


public class Solution {
    // 1d dp 
    public bool WordBreak(string s, ISet<string> wordDict) {
        int n = s.Length;
        bool[] canBreak = new bool[n + 1]; // better to handle cases at the beginning
        canBreak[0] = true; 
        
        for(int i = 1; i <= n; i++){
            for(int j = 0; j < i; j++){
                if(canBreak[j] == true && wordDict.Contains(s.Substring(j, i-j))){  // j of canBreak and j of substring have diff meaning
                    canBreak[i] = true;
                    break;
                }
            }
        }
        return canBreak[n];
    }
}