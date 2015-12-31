Given a string, find the length of the longest substring without repeating characters. For example, 
the longest substring without repeating letters for "abcabcbb" is "abc", which the length is 3. 
For "bbbbb" the longest substring is "b", with the length of 1.


public class Solution {
    // window(there is no repeating characters in it)
    public int LengthOfLongestSubstring(string s) {
        Dictionary<char, int> dict = new Dictionary<char, int>();
        int slow = 0;
        int maxLen = 0;
        for(int i = 0; i < s.Length; i++){
            dict[s[i]] = dict.ContainsKey(s[i]) ? dict[s[i]] + 1 : 1;
            while(dict[s[i]] > 1){
                dict[s[slow]]--; 
                if(dict[s[slow]] == 0) dict.Remove(s[slow]);
                slow++; 
            }
            maxLen = Math.Max(maxLen, i - slow + 1);
        }
        return maxLen;
    }
}