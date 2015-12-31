A strobogrammatic number is a number that looks the same when rotated 180 degrees (looked at upside down).

Write a function to determine if a number is strobogrammatic. The number is represented as a string.

For example, the numbers "69", "88", and "818" are all strobogrammatic.


public class Solution {
    // 0-0, 1-1, 8-8, 6-9, 9-6
    public bool IsStrobogrammatic(string num) {
        Dictionary<char, char> dict = new Dictionary<char, char>();
        dict['0'] = '0';
        dict['1'] = '1';
        dict['8'] = '8';
        dict['6'] = '9';
        dict['9'] = '6';
        for(int i = 0, j = num.Length - 1; i <= j; i++, j--) {
            if(dict.ContainsKey(num[i]) == false) return false;
            if(dict[num[i]] != num[j]) return false;
        }
        return true;
    }
}