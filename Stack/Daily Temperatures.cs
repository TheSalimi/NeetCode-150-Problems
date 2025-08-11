/*
739. Daily Temperatures
-----------------------
Given an array of integers temperatures representing the daily temperatures, 
return an array answer such that answer[i] is the number of days you have to wait 
after the ith day to get a warmer temperature. If there is no future day for which 
this is possible, keep answer[i] == 0 instead.

Example 1:
Input:  temperatures = [73,74,75,71,69,72,76,73]
Output: [1,1,4,2,1,1,0,0]

Example 2:
Input:  temperatures = [30,40,50,60]
Output: [1,1,1,0]

Example 3:
Input:  temperatures = [30,60,90]
Output: [1,1,0]
*/

using System;
using System.Collections.Generic;

public class Solution
{
    public int[] DailyTemperatures(int[] temperatures)
    {
        int[]answer = new int[temperatures.Length];
        for (int i = 0; i < answer.Length; i++)
        {
            answer[i] = 0;
        }

        Stack<int> lookForWarmer = new Stack<int>();
        lookForWarmer.Push(0);

        for (int i = 1; i < temperatures.Length; i++)
        {
            while (lookForWarmer.Count!= 0 && temperatures[i] > temperatures[lookForWarmer.Peek()])
            {
                int indx = lookForWarmer.Pop();
                answer[indx] = i - indx;
            }

            lookForWarmer.Push(i);
        }
    
        return answer;
    }
}

public class Program
{
    public static void Main()
    {
        var solution = new Solution();

        int[] temperatures = { 73, 74, 75, 71, 69, 72, 76, 73 };
        var result = solution.DailyTemperatures(temperatures);

        Console.WriteLine(string.Join(", ", result)); // Expected: 1,1,4,2,1,1,0,0
    }
}
