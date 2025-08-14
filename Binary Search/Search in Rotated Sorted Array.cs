/*
33. Search in Rotated Sorted Array
-----------------------------------
There is an integer array nums sorted in ascending order (with distinct values).

Prior to being passed to your function, nums is possibly left rotated at an unknown index k (1 <= k < nums.length) such that the resulting array is [nums[k], nums[k+1], ..., nums[n-1], nums[0], nums[1], ..., nums[k-1]] (0-indexed). 
For example, [0,1,2,4,5,6,7] might be left rotated by 3 indices and become [4,5,6,7,0,1,2].

Given the array nums after the possible rotation and an integer target, return the index of target if it is in nums, or -1 if it is not in nums.

You must write an algorithm with O(log n) runtime complexity.

Example 1:
Input: nums = [4,5,6,7,0,1,2], target = 0
Output: 4

Example 2:
Input: nums = [4,5,6,7,0,1,2], target = 3
Output: -1

Example 3:
Input: nums = [1], target = 0
Output: -1
*/

using System;

public class Solution
{
    public int Search(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;

        while(left <= right)
        {
            int mid = left + (right - left) / 2;

            if(nums[mid] == target)
            {
                return mid; 
            }

            if (nums[mid] >= nums[left])
            {
                if(target >= nums[left] && target < nums[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            else
            {
                if(target >= nums[mid] && target < nums[right])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
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

        // Test case 1
        int[] nums1 = { 4, 5, 6, 7, 0, 1, 2 };
        int target1 = 0;
        Console.WriteLine(solution.Search(nums1, target1));  // Expected: 4

        // Test case 2
        int[] nums2 = { 4, 5, 6, 7, 0, 1, 2 };
        int target2 = 3;
        Console.WriteLine(solution.Search(nums2, target2));  // Expected: -1

        // Test case 3
        int[] nums3 = { 1 };
        int target3 = 0;
        Console.WriteLine(solution.Search(nums3, target3));  // Expected: -1
    }
}
