Given a string, find the length of the longest substring T that contains at most 2 distinct characters.

For example, Given s = “eceba”,

T is "ece" which its length is 3.


public class Solution {
    // window(only two distinct characters in it) + two pointers
    public int LengthOfLongestSubstringTwoDistinct(string s) {
        Dictionary<char, int> dict = new Dictionary<char, int>();
        int slow = 0;
        int maxLen = 0;
        for(int i = 0; i < s.Length; i++){
            dict[s[i]] = dict.ContainsKey(s[i]) ? dict[s[i]] + 1 : 1;
            while(dict.Count > 2){
                dict[s[slow]]--;
                if(dict[s[slow]] == 0) dict.Remove(s[slow]);
                slow++;
            }
            maxLen = Math.Max(maxLen, i - slow + 1);
        }
        return maxLen;
    }
}