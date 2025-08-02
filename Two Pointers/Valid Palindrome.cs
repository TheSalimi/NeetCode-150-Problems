/*
125. Valid Palindrome
---------------------
A phrase is a palindrome if, after converting all uppercase letters into lowercase letters 
and removing all non-alphanumeric characters, it reads the same forward and backward. 
Alphanumeric characters include letters and numbers.

Given a string s, return true if it is a palindrome, or false otherwise.

Example 1:
Input: s = "A man, a plan, a canal: Panama"
Output: true
Explanation: "amanaplanacanalpanama" is a palindrome.

Example 2:
Input: s = "race a car"
Output: false
Explanation: "raceacar" is not a palindrome.

Example 3:
Input: s = " "
Output: true
Explanation: s is an empty string "" after removing non-alphanumeric characters.

Constraints:
- 1 <= s.Length <= 2 * 10^5
- s consists only of printable ASCII characters.
*/

using System;

public class Solution
{
    public bool IsPalindrome(string s)
    {
        int left_idx = 0;
        int right_idx = s.Length-1;
        s = s.ToLower();

        while (left_idx < right_idx) {
            while (left_idx < right_idx && !char.IsLetterOrDigit(s[left_idx]))
            {
                left_idx++;
            }

            while (left_idx < right_idx && !char.IsLetterOrDigit(s[right_idx]))
            {
                right_idx--;
            }

            if (s[left_idx] != s[right_idx]) return false;

            left_idx++;right_idx--;
        }

        return true; 
    }
}

public class Program
{
    public static void Main()
    {
        var solution = new Solution();

        Console.WriteLine(solution.IsPalindrome("A man, a plan, a canal: Panama")); // Expected: true
        Console.WriteLine(solution.IsPalindrome("race a car")); // Expected: false
        Console.WriteLine(solution.IsPalindrome(" ")); // Expected: true
    }
}
