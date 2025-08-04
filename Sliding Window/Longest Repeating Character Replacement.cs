/*
424. Longest Repeating Character Replacement
--------------------------------------------
You are given a string s and an integer k. 
You can choose any character of the string and change it to any other uppercase English character. 
You can perform this operation at most k times.

Return the length of the longest substring containing the same letter you can get after performing the above operations.

Example 1:
Input: s = "ABAB", k = 2
Output: 4
Explanation: Replace the two 'A's with two 'B's or vice versa.

Example 2:
Input: s = "AABABBA", k = 1
Output: 4
Explanation: Replace the one 'A' in the middle with 'B' and form "AABBBBA".
The substring "BBBB" has the longest repeating letters, which is 4.

Constraints:
- 1 <= s.Length <= 10^5
- s consists of only uppercase English letters.
- 0 <= k <= s.Length
*/

using System;
using System.Collections.Generic;

public class Solution
{
    public int CharacterReplacement(string s, int k)
    {
        int left = 0;
        Dictionary<char, int> charCount = new Dictionary<char, int>();
        int maxFrequency = 0;
        int maxLength = 0;

        for (int right = 0; right < s.Length; right++)
        {
            if (!charCount.ContainsKey(s[right]))
                charCount[s[right]] = 0;
            charCount[s[right]]++;

            maxFrequency = Math.Max(maxFrequency, charCount[s[right]]);

            while ((right - left + 1) - maxFrequency > k)
            {
                charCount[s[left]]--;
                left++;
            }

            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }
}

public class Program
{
    public static void Main()
    {
        var solution = new Solution();
        Console.WriteLine(solution.CharacterReplacement("BAAAB", 2));
        Console.WriteLine(solution.CharacterReplacement("ABAB", 2));    // Expected: 4
        Console.WriteLine(solution.CharacterReplacement("AABABBA", 1)); // Expected: 4
    }
}
