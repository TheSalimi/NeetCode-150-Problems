/*
853. Car Fleet
-------------
There are n cars at given miles away from the starting mile 0, traveling to reach the mile target.

You are given two integer arrays position and speed, both of length n, where position[i] is the starting mile of the ith car 
and speed[i] is the speed of the ith car in miles per hour.

A car cannot pass another car, but it can catch up and then travel next to it at the speed of the slower car.

A car fleet is a car or cars driving next to each other. The speed of the car fleet is the minimum speed of any car in the fleet.

If a car catches up to a car fleet at the mile target, it will still be considered as part of the car fleet.

Return the number of car fleets that will arrive at the destination.

Example:
Input: target = 12, position = [10,8,0,5,3], speed = [2,4,1,1,3]
Output: 3
*/

using System;
using System.Collections.Generic;

public class Solution
{
    public int CarFleet(int target, int[] position, int[] speed)
    {
        var cars = new (int pos, int speed)[position.Length];
        for(int i = 0; i < position.Length; i++)
        {
            cars[i] = (position[i], speed[i]);
        }

        Array.Sort(cars,(a,b) => b.pos.CompareTo(a.pos)); 
        
        Stack<double> stack = new Stack<double>();
        double[]time = new double[position.Length];

        for(int i = 0;i< position.Length; i++)
        {
            time[i] = (double)(target - cars[i].pos) / cars[i].speed;
        }

        stack.Push(time[0]);

        for(int i= 1; i < position.Length; i++)
        {
            if (time[i] <= stack.Peek())
            {
                continue;
            }

            stack.Push(time[i]);
        }

        return stack.Count;
    }
}

public class Program
{
    public static void Main()
    {
        var solution = new Solution();

        int target = 12;
        int[] position = { 10, 8, 0, 5, 3 };
        int[] speed = { 2, 4, 1, 1, 3 };

        int fleets = solution.CarFleet(target, position, speed);
        Console.WriteLine(fleets);  // Expected output: 3
    }
}
