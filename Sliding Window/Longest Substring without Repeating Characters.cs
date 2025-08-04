/*
3. Longest Substring Without Repeating Characters
-------------------------------------------------
Given a string s, find the length of the longest substring without duplicate characters.

Example 1:
Input: s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with the length of 3.

Example 2:
Input: s = "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.

Constraints:
- 0 <= s.Length <= 5 * 10^4
- s consists of English letters, digits, symbols and spaces.
*/

using System;
using System.Collections.Generic;

public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        HashSet<char> characters = new HashSet<char>();
        int maxLength = 0; ;
        int left = 0, right = 0;

        while(right < s.Length)
        {
            while (characters.Contains(s[right]))
            {
                    characters.Remove(s[left]);
                    left++;
            }
            
            if(!characters.Contains(s[right]))
            {
                characters.Add(s[right]);
                right++;

                if (characters.Count > maxLength)
                {
                    maxLength = characters.Count;
                }
            }
        }

        return maxLength;
    }
}

public class Program
{
    public static void Main()
    {
        var solution = new Solution();

        Console.WriteLine(solution.LengthOfLongestSubstring("abcabcbb")); // Expected: 3
        Console.WriteLine(solution.LengthOfLongestSubstring("bbbbb"));    // Expected: 1
        Console.WriteLine(solution.LengthOfLongestSubstring("pwwkew"));   // Expected: 3
    }
}
