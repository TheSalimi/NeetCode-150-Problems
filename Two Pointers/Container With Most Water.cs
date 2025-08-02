/*
11. Container With Most Water
-----------------------------
You are given an integer array height of length n. There are n vertical lines drawn such that
the two endpoints of the i-th line are (i, 0) and (i, height[i]).

Find two lines that together with the x-axis form a container,
such that the container contains the most water.

Return the maximum amount of water a container can store.

Notice that you may not slant the container.

Example 1:
Input: height = [1,8,6,2,5,4,8,3,7]
Output: 49
Explanation:
The above vertical lines are represented by array [1,8,6,2,5,4,8,3,7].
In this case, the max area of water (blue section) the container can contain is 49.

Example 2:
Input: height = [1,1]
Output: 1

Constraints:
- n == height.Length
- 2 <= n <= 10^5
- 0 <= height[i] <= 10^4
*/

using System;

public class Solution
{
    public int MaxArea(int[] height)
    {
        int left = 0;
        int right = height.Length - 1;
        int maxArea = 0;

        while(left < right)
        {
            int x = right - left;
            int y = Math.Min(height[left], height[right]);
            int area = x * y;

            if (area > maxArea) maxArea = area;
        
            if(height[left] < height[right])
            {
                left++;
            }
            else
            {
                right--;
            }
        }

        return maxArea;
    }
}

public class Program
{
    public static void Main()
    {
        var solution = new Solution();

        var h1 = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
        Console.WriteLine(solution.MaxArea(h1)); // Expected: 49

        var h2 = new int[] { 1, 1 };
        Console.WriteLine(solution.MaxArea(h2)); // Expected: 1
    }
}
