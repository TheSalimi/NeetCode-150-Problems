/*
76. Minimum Window Substring
----------------------------
Given two strings s and t, return the minimum window substring of s 
such that every character in t (including duplicates) is included in the window.
If no such substring exists, return "".
*/

using System;
using System.Collections.Generic;

public class Solution
{
    public string MinWindow(string s, string t)
    {
        if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t) || t.Length > s.Length)
            return "";

        Dictionary<char,int> tFreq = new Dictionary<char, int>();
        foreach(char c in t)
        {
            if(!tFreq.ContainsKey(c)) { tFreq[c]=0; }
            tFreq[c]++;
        }

        int left = 0,right=0,formed=0,max=tFreq.Count,minLength=int.MaxValue,minLeft=0;
        Dictionary<char, int> have = new Dictionary<char, int>();

        while (right < s.Length)
        {
            char c = s[right];

            if (!have.ContainsKey(c)) { have[c] = 0; }
            have[c]++;

            if (tFreq.ContainsKey(c) && tFreq[c] == have[c])
            {
                formed += 1;
            }

            
            while(left <= right && formed == max)
            {
                if(right-left+1 < minLength)
                {
                    minLeft = left;
                    minLength = right - left + 1;
                }

                char ch = s[left];
                have[ch]--;
                
                if (tFreq.ContainsKey(ch) && tFreq[ch] > have[ch])
                {
                    formed--;
                }

                left++;
            }

            right++;
        }

        return minLength == int.MaxValue ? "" : s.Substring(minLeft,minLength) ;
    }
}

public class Program
{
    public static void Main()
    {
        var solution = new Solution();

        Console.WriteLine(solution.MinWindow("ADOBECODEBANC", "ABC")); // Expected: "BANC"
        Console.WriteLine(solution.MinWindow("a", "a"));               // Expected: "a"
        Console.WriteLine(solution.MinWindow("a", "aa"));              // Expected: ""
    }
}
