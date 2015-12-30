Say you have an array for which the ith element is the price of a given stock on day i.

If you were only permitted to complete at most one transaction (ie, buy one and sell one share of the stock), 
design an algorithm to find the maximum profit.


public class Solution {
    public int MaxProfit(int[] prices) {
        if(prices.Length < 2) return 0;
        int minPrice = prices[0], maxProfit = 0;
        for(int i = 1; i < prices.Length; i++) {
            maxProfit = Math.Max(maxProfit, prices[i] - minPrice);
            minPrice = Math.Min(prices[i], minPrice);
        }
        return maxProfit;
    }
}