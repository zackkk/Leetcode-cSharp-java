Say you have an array for which the ith element is the price of a given stock on day i.

Design an algorithm to find the maximum profit. You may complete as many transactions as you like 
(ie, buy one and sell one share of the stock multiple times) with the following restrictions:

You may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).
After you sell your stock, you cannot buy stock on next day. (ie, cooldown 1 day)

Example:

prices = [1, 2, 3, 0, 2]
maxProfit = 3
transactions = [buy, sell, cooldown, buy, sell]


public class Solution {
    // tricky dp with three states: https://leetcode.com/discuss/72030/share-my-dp-solution-by-state-machine-thinking
    //  s0  <---rest--- s2
    //   --buy      sell->
    //       ->  s1 --
    
    // it satified the constraint that must cooldown after sell 
    // s0 and s1 can rest by itself
    public int MaxProfit(int[] prices) {
        int n = prices.Length;
        if(n < 2) return 0;
        int[] s0 = new int[n], s1 = new int[n], s2 = new int[n];
        s0[0] = 0;
        s1[0] = -prices[0]; // have bought
        s2[0] = 0;
        for(int i = 1; i < n; i++){
            s0[i] = Math.Max(s0[i-1], s2[i-1]);
            s1[i] = Math.Max(s1[i-1], s0[i-1] - prices[i]);
            s2[i] = s1[i-1] + prices[i];
        }
        return Math.Max(Math.Max(s0[n-1], s1[n-1]), s2[n-1]);
    }
}