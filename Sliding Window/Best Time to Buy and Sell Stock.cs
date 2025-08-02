/*
121. Best Time to Buy and Sell Stock
-----------------------------------
You are given an array prices where prices[i] is the price of a given stock on the ith day.

You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.

Return the maximum amount of profit you can achieve from this transaction. If you cannot achieve any profit, return 0.

Example 1:
Input: prices = [7,1,5,3,6,4]
Output: 5

Example 2:
Input: prices = [7,6,4,3,1]
Output: 0

Constraints:
- 1 <= prices.Length <= 10^5
- 0 <= prices[i] <= 10^4
*/

using System;

public class Solution
{
    public int MaxProfit(int[] prices)
    {
        int left = 0,right = 1;
        int max_profit = 0;
        while (right<prices.Length)
        {
            if (prices[right] < prices[left])
            {
                left = right;
                right++;
            }
            else if (prices[right] >= prices[left])
            {
                int dif = prices[right] - prices[left];
                if (dif > max_profit) max_profit = dif;
                right++;
            }
        }

        return max_profit;
    }
}

public class Program
{
    public static void Main()
    {
        var solution = new Solution();

        var prices1 = new int[] { 7, 1, 5, 3, 6, 4 };
        Console.WriteLine(solution.MaxProfit(prices1)); // Expected: 5

        var prices2 = new int[] { 7, 6, 4, 3, 1 };
        Console.WriteLine(solution.MaxProfit(prices2)); // Expected: 0
    }
}
