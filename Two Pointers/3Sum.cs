/*
15. 3Sum
--------
Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] 
such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

Notice that the solution set must not contain duplicate triplets.

Example 1:
Input: nums = [-1,0,1,2,-1,-4]
Output: [[-1,-1,2],[-1,0,1]]
Explanation:
nums[0] + nums[4] + nums[3] = (-1) + (-1) + 2 = 0
nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0

Example 2:
Input: nums = [0,1,1]
Output: []
Explanation: The only triplet possible does not sum to 0.

Example 3:
Input: nums = [0,0,0]
Output: [[0,0,0]]
Explanation: The only triplet sums to 0.

Constraints:
- 3 <= nums.Length <= 1000
- -10^5 <= nums[i] <= 10^5
*/

using System;
using System.Collections.Generic;

public class Solution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        var result = new List<IList<int>>();

        int left = 0;int right = 0;

        Array.Sort(nums);

        for (int i = 0; i <= nums.Length - 3; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1]) continue;

            left = i + 1;
            right = nums.Length - 1;

            while (left < right)
            {
                int sum = nums[i] + nums[left] + nums[right];

                if (sum == 0)
                {
                    result.Add(new List<int> { nums[i], nums[left], nums[right] });

                    int leftVal = nums[left];
                    while (left < right && nums[left] == leftVal) left++;

                    int rightVal = nums[right];
                    while (left < right && nums[right] == rightVal) right--;
                }
                else if (sum < 0)
                {
                    left++;
                }
                else
                {
                    right--;
                }
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

        var nums1 = new int[] { -1, 0, 1, 2, -1, -4 };
        var output1 = solution.ThreeSum(nums1);
        PrintResult(output1); // Expected: [[-1,-1,2], [-1,0,1]]

        var nums2 = new int[] { 0, 1, 1 };
        var output2 = solution.ThreeSum(nums2);
        PrintResult(output2); // Expected: []

        var nums3 = new int[] { 0, 0, 0 };
        var output3 = solution.ThreeSum(nums3);
        PrintResult(output3); // Expected: [[0,0,0]]
    }

    private static void PrintResult(IList<IList<int>> result)
    {
        Console.Write("[");
        foreach (var triplet in result)
        {
            Console.Write("[" + string.Join(",", triplet) + "]");
        }
        Console.WriteLine("]");
    }
}
