/*
84. Largest Rectangle in Histogram
-----------------------------------
Given an array of integers heights representing the histogram's bar height where the width of each bar is 1, 
return the area of the largest rectangle in the histogram.

Example:
Input: heights = [2,1,5,6,2,3]
Output: 10
Explanation: The largest rectangle is formed by the bars with height 5 and 6, which have an area = 5 * 2 = 10.

Note:
- You should implement your solution with an optimal time complexity, ideally O(n).
*/

using System;
using System.Collections.Generic;

public class Solution
{
    public int LargestRectangleArea(int[] heights)
    {
        Stack<int> h = new Stack<int>();
        int maxArea = 0;
        for (int i = 0; i < heights.Length; i++)
        {
            while(h.Count>0 && heights[i] < heights[h.Peek()])
            {
                int height = heights[h.Peek()];
                int width = h.Count == 0 ? i : i - h.Peek();
                int area = height * width;
                
                if(area > maxArea)
                {
                    maxArea = area;
                }
                h.Pop();
            }

            h.Push(i);
        }

        return maxArea;
    }
}

public class Program
{
    public static void Main()
    {
        var solution = new Solution();

        int[] heights = { 2, 1, 5, 6, 2, 3 };
        int result = solution.LargestRectangleArea(heights);

        Console.WriteLine(result);  // Expected output: 10
    }
}
