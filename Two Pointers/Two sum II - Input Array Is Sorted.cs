/*
167. Two Sum II - Input Array Is Sorted
---------------------------------------
Given a 1-indexed array of integers numbers that is already sorted in non-decreasing order, 
find two numbers such that they add up to a specific target number. Let these two numbers 
be numbers[index1] and numbers[index2] where 1 <= index1 < index2 <= numbers.length.

Return the indices of the two numbers, index1 and index2, added by one as an integer 
array [index1, index2] of length 2.

The tests are generated such that there is exactly one solution. 
You may not use the same element twice.

Your solution must use only constant extra space.

Example 1:
Input: numbers = [2,7,11,15], target = 9
Output: [1,2]

Example 2:
Input: numbers = [2,3,4], target = 6
Output: [1,3]

Example 3:
Input: numbers = [-1,0], target = -1
Output: [1,2]

Constraints:
- 2 <= numbers.Length <= 3 * 10^4
- -1000 <= numbers[i] <= 1000
- numbers is sorted in non-decreasing order.
- -1000 <= target <= 1000
- The tests are generated such that there is exactly one solution.
*/

using System;

public class Solution
{
    public int[] TwoSum(int[] numbers, int target)
    {
        int left = 0; int right = numbers.Length - 1;

        while (left<right)
        {
            int sum = numbers[left] + numbers[right];

            if (sum < target)
            {
                left++;
            }
            else if(sum > target)
            {
                right--;
            }
            else
            {
                break;
            }
        }
        
        return [left+1,right+1];
    }
}

public class Program
{
    public static void Main()
    {
        var solution = new Solution();

        var res1 = solution.TwoSum(new int[] { 2, 7, 11, 15 }, 9);
        Console.WriteLine($"[{res1[0]}, {res1[1]}]"); // Expected: [1, 2]

        var res2 = solution.TwoSum(new int[] { 2, 3, 4 }, 6);
        Console.WriteLine($"[{res2[0]}, {res2[1]}]"); // Expected: [1, 3]

        var res3 = solution.TwoSum(new int[] { -1, 0 }, -1);
        Console.WriteLine($"[{res3[0]}, {res3[1]}]"); // Expected: [1, 2]
    }
}
