Given a roman numeral, convert it to an integer.

Input is guaranteed to be within the range from 1 to 3999.


public class Solution {
    //：I（1）V（5）X（10）L（50）C（100）D（500）M（1000） 
    // IV = 4; VI = 6 - 从右往左，比前面数大就作加数，否则作减数
    public int RomanToInt(string s) {
        if (s == null || s.Length == 0) return 0;
        Dictionary<char, int> dict = new Dictionary<char, int>();
        dict.Add('I', 1);
        dict.Add('V', 5);
        dict.Add('X', 10);
        dict.Add('L', 50);
        dict.Add('C', 100);
        dict.Add('D', 500);
        dict.Add('M', 1000);
        int result = dict[s[s.Length-1]];
        int prev = result;
        for (int i = s.Length - 2; i >= 0; i--){
            int cur = dict[s[i]];
            result += (cur >= prev ? cur : -cur);
            prev = cur;
        }
        return result;
    }
}