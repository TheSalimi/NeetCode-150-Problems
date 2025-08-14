/*
704. Binary Search
------------------
Given an array of integers nums which is sorted in ascending order, and an integer target,
write a function to search target in nums. If target exists, then return its index.
Otherwise, return -1.

You must write an algorithm with O(log n) runtime complexity.

Example 1:
Input: nums = [-1,0,3,5,9,12], target = 9
Output: 4
Explanation: 9 exists in nums and its index is 4

Example 2:
Input: nums = [-1,0,3,5,9,12], target = 2
Output: -1
Explanation: 2 does not exist in nums so return -1
*/

using System;

public class Solution
{
    public int Search(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;

        while (left <= right)
        {
            int mid = left + (right-left) / 2;
            int midValue = nums[mid];

            if (midValue == target) return mid;
            else if (midValue < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return -1;
    }
}

public class Program
{
    public static void Main()
    {
        var solution = new Solution();
        int[] nums = { -1, 0, 3, 5, 9, 12 };
        int target = 9;
        int result = solution.Search(nums, target);
        Console.WriteLine(result); // Expected: 4
    }
}
