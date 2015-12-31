Write a function to find the longest common prefix string amongst an array of strings.


public class Solution {
    // vertical comparison - compare each character of the first string - i: row - j: col
    public string LongestCommonPrefix(string[] strs) {
        if(strs == null || strs.Length == 0) return "";
        for(int j = 0; j < strs[0].Length; j++){
            for(int i = 1; i < strs.Length; i++){
                if(j == strs[i].Length || strs[0][j] != strs[i][j]){
                    return strs[0].Substring(0, j);    
                }
            }
        }
        return strs[0];
    }
}