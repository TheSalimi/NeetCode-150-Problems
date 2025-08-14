/*
74. Search a 2D Matrix
------------------------
You are given an m x n integer matrix with the following two properties:

1. Each row is sorted in non-decreasing order.
2. The first integer of each row is greater than the last integer of the previous row.

Given an integer target, return true if target is in the matrix or false otherwise.

You must write a solution in O(log(m * n)) time complexity.

Example:
Input: matrix = [
 [1, 4, 7, 11],
 [2, 5, 8, 12],
 [3, 6, 9, 16],
 [10, 13, 14, 17]
], target = 5
Output: true
Explanation: 5 is found in the matrix.

Example 2:
Input: matrix = [
 [1, 2, 3],
 [4, 5, 6],
 [7, 8, 9]
], target = 20
Output: false
Explanation: 20 is not found in the matrix.

Constraints:
- m == matrix.length
- n == matrix[i].length
- 1 <= m, n <= 100
- 1 <= matrix[i][j], target <= 10^4
*/

using System;

public class Solution
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        int m = matrix.Length;
        int n = matrix[0].Length;

        int left = 0;
        int right = m * n - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            int midValue = matrix[mid / n][mid % n];

            if (target == midValue) return true;
            else if (target < midValue) right = mid - 1;
            else left = mid + 1;
        }

        return false; 
    }
}

public class Program
{
    public static void Main()
    {
        var solution = new Solution();

        // Test case 1
        int[][] matrix1 = {
        new int[] {1, 3, 5, 7},
        new int[] {10, 11, 16, 20},
        new int[] {23, 30, 34, 60}
        };
        int target1 = 5;
        Console.WriteLine(solution.SearchMatrix(matrix1, target1)); // Expected: true

        // Test case 2
        int[][] matrix2 = {
            new int[] {1, 2, 3},
            new int[] {4, 5, 6},
            new int[] {7, 8, 9}
        };
        int target2 = 20;
        Console.WriteLine(solution.SearchMatrix(matrix2, target2)); // Expected: false
    }
}
