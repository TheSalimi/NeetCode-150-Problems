/*
239. Sliding Window Maximum
---------------------------
Given an integer array nums and an integer k, return the maximum value in each sliding window of size k.
*/

using System;
using System.Collections.Generic;

public class Solution
{
    public int[] MaxSlidingWindow(int[] nums, int k)
    {
        LinkedList<int> indexes = new LinkedList<int> ();
        List<int> max = new List<int> ();
        int windowLength = nums.Length;

        for (int i = 0; i < nums.Length; i++) { 
            if(indexes.Count > 0 && indexes.First.Value < i - k + 1)
            {
                indexes.RemoveFirst();
            }

            while(indexes.Count > 0 && nums[i] > nums[indexes.Last.Value])
            {
                indexes.RemoveLast();
            }
            
            indexes.AddLast(i);

            if(i >= k - 1)
            {
                max.Add(nums[indexes.First.Value]);
            }
        }

        return max.ToArray();
    }
}

public class Program
{
    public static void Main()
    {
        var solution = new Solution();

        int[] nums1 = { 1, 3, -1, -3, 5, 3, 6, 7 };
        int[] result1 = solution.MaxSlidingWindow(nums1, 3);
        Console.WriteLine(string.Join(", ", result1)); // Expected: 3, 3, 5, 5, 6, 7

        int[] nums2 = { 1 };
        int[] result2 = solution.MaxSlidingWindow(nums2, 1);
        Console.WriteLine(string.Join(", ", result2)); // Expected: 1
    }
}
