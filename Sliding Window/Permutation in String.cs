/*
567. Permutation in String
--------------------------
Given two strings s1 and s2, return true if s2 contains a permutation of s1.

Example 1:
Input: s1 = "ab", s2 = "eidbaooo"
Output: true  // "ba" is a permutation of "ab"

Example 2:
Input: s1 = "ab", s2 = "eidboaoo"
Output: false

Constraints:
- 1 <= s1.Length, s2.Length <= 10^4
- s1 and s2 consist of lowercase English letters.
*/

using System;

public class Solution
{
    public bool CheckInclusion(string s1, string s2)
    {
        if (s1.Length > s2.Length) return false;
        int windowLength = s1.Length;
        int[] s1Freq = new int[26];
        int[] s2Freq = new int[26];

        for (int i = 0; i < s1.Length; i++)
        {
            s1Freq[s1[i] - 'a']++;
        }

        for (int i = 0;  i  < s1.Length; i++)
        {
            s2Freq[s2[i] - 'a']++;
        }

        if (Matches(s1Freq, s2Freq)) return true;

        for(int i = windowLength; i < s2.Length; i++)
        {
            s2Freq[s2[i] - 'a']++;
            s2Freq[s2[i - windowLength] - 'a']--;

            if (Matches(s1Freq, s2Freq)) return true;
        }

        return false;
    }

    private bool Matches(int[] arr1, int[] arr2)
    {
        for (int i = 0; i < 26; i++)
        {
            if (arr1[i] != arr2[i])
                return false;
        }
        return true;
    }
}

public class Program
{
    public static void Main()
    {
        var solution = new Solution();

        Console.WriteLine(solution.CheckInclusion("ab", "eidbaooo")); // Expected: true
        Console.WriteLine(solution.CheckInclusion("ab", "eidboaoo")); // Expected: false
    }
}
