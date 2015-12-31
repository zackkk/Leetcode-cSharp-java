A message containing letters from A-Z is being encoded to numbers using the following mapping:

'A' -> 1
'B' -> 2
...
'Z' -> 26

Given an encoded message containing digits, determine the total number of ways to decode it.

For example,
Given encoded message "12", it could be decoded as "AB" (1 2) or "L" (12).

The number of ways decoding "12" is 2.


public class Solution {
    // 1d dp: climb stairs
    public int NumDecodings(string s) {
        int n = s.Length;
        if(n == 0) return 0;
        int[] dp = new int[n+1];
        dp[0] = 1; // case "10" has one decode way
        dp[1] = s[0] == '0' ? 0 : 1;
        for(int i = 2; i <= n; i++){
            dp[i] += s[i-1] == '0' ? 0 : dp[i-1]; // decode one char at the current position
            
            int num = (s[i-2] - '0') * 10 + (s[i-1] - '0'); // decode two chars at the current position
            dp[i] += num < 10 || num > 26 ? 0 : dp[i-2];
        }
        return dp[n];
    }
}