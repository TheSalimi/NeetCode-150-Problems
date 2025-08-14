/*
153. Find Minimum in Rotated Sorted Array
-----------------------------------------
You are given an integer array nums that is sorted in ascending order and then rotated at an unknown pivot. 
(For example, nums = [0,1,2,4,5,6,7] might become [4,5,6,7,0,1,2] if it was rotated 4 times.)

Return the minimum element of this array.

You must write an algorithm that runs in O(log n) time.

Example 1:
Input: nums = [3,4,5,1,2]
Output: 1
Explanation: The original array was [1,2,3,4,5] rotated 3 times.

Example 2:
Input: nums = [4,5,6,7,0,1,2]
Output: 0
Explanation: The original array was [0,1,2,4,5,6,7] and it was rotated 4 times.

Example 3:
Input: nums = [11,13,15,17]
Output: 11
Explanation: The original array was [11,13,15,17] and it was rotated 4 times.
*/

using System;

public class Solution
{
    public int FindMin(int[] nums)
    {
        int left = 0 , right = nums.Length - 1;
        int mid = 0;

        while (left < right) { 
            mid = left + (right - left) / 2;

            int midValue = nums[mid];

            if(midValue > nums[right])
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }
        
        return nums[left];
    }
}

public class Program
{
    public static void Main()
    {
        var solution = new Solution();

        // Test case 1
        int[] nums1 = { 3, 4, 5, 1, 2 };
        Console.WriteLine(solution.FindMin(nums1)); // Expected: 1

        // Test case 2
        int[] nums2 = { 4, 5, 6, 7, 0, 1, 2 };
        Console.WriteLine(solution.FindMin(nums2)); // Expected: 0

        // Test case 3
        int[] nums3 = { 11, 13, 15, 17 };
        Console.WriteLine(solution.FindMin(nums3)); // Expected: 11
    }
}
