/*
42. Trapping Rain Water
-----------------------
Given n non-negative integers representing an elevation map where the width of each bar is 1,
compute how much water it can trap after raining.

Example 1:
Input: height = [0,1,0,2,1,0,1,3,2,1,2,1]
Output: 6

Example 2:
Input: height = [4,2,0,3,2,5]
Output: 9

Constraints:
- n == height.Length
- 1 <= n <= 2 * 10^4
- 0 <= height[i] <= 10^5
*/

using System;

public class Solution
{
    public int Trap(int[] height)
    {
        int left = 0, right=height.Length-1;
        int max_left = height[left];
        int max_right = height[right];
        int trappin_water = 0;

        while(left < right)
        {
            if (height[left] < height[right])
            {
                left++;

                if (height[left] < max_left)
                {
                    trappin_water += max_left - height[left];
                }
                else
                {
                    max_left = height[left];
                }
            }
            else
            {
                right--;

                if (height[right] < max_right)
                {
                    trappin_water += max_right - height[right];
                }
                else
                {
                    max_right = height[right];
                }
            }
        }

        return trappin_water; 
    }
}

public class Program
{
    public static void Main()
    {
        var solution = new Solution();

        var h1 = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
        Console.WriteLine(solution.Trap(h1)); // Expected: 6

        var h2 = new int[] { 4, 2, 0, 3, 2, 5 };
        Console.WriteLine(solution.Trap(h2)); // Expected: 9
    }
}
