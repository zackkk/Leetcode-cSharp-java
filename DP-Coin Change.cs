You are given coins of different denominations and a total amount of money amount. 
Write a function to compute the fewest number of coins that you need to make up that amount. 
If that amount of money cannot be made up by any combination of the coins, return -1.

Example 1:
coins = [1, 2, 5], amount = 11
return 3 (11 = 5 + 5 + 1)

Example 2:
coins = [2], amount = 3
return -1.

Note:
You may assume that you have an infinite number of each kind of coin.


public class Solution {
    // classic 1d dp, get minimal changes for all amounts => dp[i] = min(dp[j] + 1), j < i
    public int CoinChange(int[] coins, int amount) {
        int[] dp = new int[amount + 1];
        for(int i = 1; i <= amount; i++){
            dp[i] = Int32.MaxValue;
            foreach(int coin in coins){
                if(i >= coin && dp[i-coin] != Int32.MaxValue){
                    dp[i] = Math.Min(dp[i], dp[i - coin] + 1);  // dp[0] == 0 handled the base case
                }
            }
        }
        return dp[amount] == Int32.MaxValue ? -1 : dp[amount]; // return -1 for invalid amount
    }
}