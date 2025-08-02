/*
128. Longest Consecutive Sequence
---------------------------------
Given an unsorted array of integers nums, return the length of the longest consecutive elements sequence.

You must write an algorithm that runs in O(n) time.

Example 1:
Input: nums = [100,4,200,1,3,2]
Output: 4
Explanation: The longest consecutive elements sequence is [1, 2, 3, 4]. Therefore its length is 4.

Example 2:
Input: nums = [0,3,7,2,5,8,4,6,0,1]
Output: 9

Example 3:
Input: nums = [1,0,1,2]
Output: 3

Constraints:
- 0 <= nums.length <= 10^5
- -10^9 <= nums[i] <= 10^9
*/

using System;
using System.Collections.Generic;

public class Solution
{
    public int LongestConsecutive(int[] nums)
    {
        if (nums.Length == 0) return 0;

        int longest = 1;
        HashSet<int> set = nums.ToHashSet();
        for (int i = 0; i < nums.Length; i++) {
            if (!set.Contains(nums[i] - 1))
            {
                int number = nums[i] + 1;
                int temp_longest = 1;

                while (set.Contains(number)){
                    temp_longest++;
                    if(temp_longest>longest) longest = temp_longest;
                    number++;
                }
            }
        }
        
        return longest;
    }
}

public class Program
{
    public static void Main()
    {
        var solution = new Solution();

        int[] nums1 = { 100, 4, 200, 1, 3, 2 };
        Console.WriteLine(solution.LongestConsecutive(nums1)); // Expected: 4

        int[] nums2 = { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 };
        Console.WriteLine(solution.LongestConsecutive(nums2)); // Expected: 9

        int[] nums3 = { 1, 0, 1, 2 };
        Console.WriteLine(solution.LongestConsecutive(nums3)); // Expected: 3
    }
}
