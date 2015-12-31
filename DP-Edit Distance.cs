Given two words word1 and word2, find the minimum number of steps required to convert word1 to word2. 
(each operation is counted as 1 step.)

You have the following 3 operations permitted on a word:

a) Insert a character
b) Delete a character
c) Replace a character


public class Solution {
    // 2d dp, dp[i,j]: min distance from word1[1..i] to word2[1..j]
    public int MinDistance(string word1, string word2) {
        int m = word1.Length, n = word2.Length;
        int[,] dp = new int[m+1, n+1];
        // delete
        for(int i = 0; i <= m; i++) dp[i, 0] = i;
        for(int j = 0; j <= n; j++) dp[0, j] = j;
        
        for(int i = 1; i <= m; i++){
            for(int j = 1; j <= n; j++){
                if(word1[i-1] == word2[j-1]){
                    dp[i,j] = dp[i-1,j-1];
                }
                else{
                    dp[i,j] = Math.Min(Math.Min(dp[i-1,j], dp[i,j-1]), dp[i-1,j-1]) + 1; // insert, insert, replace
                }
            }
        }
        return dp[m,n];
    }
}