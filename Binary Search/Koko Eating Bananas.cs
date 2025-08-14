/*
875. Koko Eating Bananas
------------------------
Koko loves to eat bananas. There are n piles of bananas, the ith pile has piles[i] bananas. 
The guards have gone and will come back in h hours.

Koko can decide her bananas-per-hour eating speed of k. Each hour, she chooses some pile of bananas 
and eats k bananas from that pile. If the pile has less than k bananas, she eats all of them instead 
and will not eat any more bananas during this hour.

Koko likes to eat slowly but still wants to finish eating all the bananas before the guards return.

Return the minimum integer k such that she can eat all the bananas within h hours.

Example:
Input: piles = [3,6,7,11], h = 8
Output: 4
*/

using System;

public class Solution
{
    public int MinEatingSpeed(int[] piles, int h)
    {
        int left = 1;
        int right = 0;
        int result = 0;

        foreach (int pile in piles) { 
            if(pile > right) {
                right = pile;
            }
        }
        
        while(left <= right)
        {
            int mid = left + (right - left) / 2;
            int hoursNeeded = 0;

            foreach(int pile in piles)
            {
                hoursNeeded += (pile + mid - 1) / mid;
            }

            if(hoursNeeded <= h)
            {
                result = mid;
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }

        return result;
    }
}

public class Program
{
    public static void Main()
    {
        var solution = new Solution();

        // تست کیس‌ها
        int[] piles1 = { 3, 6, 7, 11 };
        int h1 = 8;
        Console.WriteLine(solution.MinEatingSpeed(piles1, h1));  // Expected: 4

        int[] piles2 = { 30, 11, 23, 4, 20 };
        int h2 = 5;
        Console.WriteLine(solution.MinEatingSpeed(piles2, h2));  // Expected: 30

        int[] piles3 = { 30, 11, 23, 4, 20 };
        int h3 = 6;
        Console.WriteLine(solution.MinEatingSpeed(piles3, h3));  // Expected: 23
    }
}
