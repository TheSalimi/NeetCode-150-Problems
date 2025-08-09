/*
20. Valid Parentheses
---------------------
Given a string s containing just the characters '(', ')', '{', '}', '[' and ']',
determine if the input string is valid.

An input string is valid if:
- Open brackets must be closed by the same type of brackets.
- Open brackets must be closed in the correct order.
- Every close bracket has a corresponding open bracket of the same type.

Example 1:
Input: s = "()"
Output: true

Example 2:
Input: s = "()[]{}"
Output: true

Example 3:
Input: s = "(]"
Output: false

Example 4:
Input: s = "([])"
Output: true

Example 5:
Input: s = "([)]"
Output: false
*/

using System;
using System.Collections.Generic;

public class Solution
{
    public bool IsValid(string s)
    {
        Stack<char> chars = new Stack<char>();

        foreach(char c in s)
        {
            if(c == '(' || c == '{' || c == '[')
            {
                chars.Push(c);
            }

            if (chars.Count != 0 && (c == ')' || c == '}' || c == ']'))
            {
                char poped = chars.Pop();

                if(c==')' && poped != '(' ||
                   c == '}' && poped != '{' ||
                   c == ']' && poped != '[')
                {
                    return false;
                }
            }
        }

        return true ? chars.Count==0 : false ;
    }
}

public class Program
{
    public static void Main()
    {
        var solution = new Solution();

        Console.WriteLine(solution.IsValid("()"));      // Expected: true
        Console.WriteLine(solution.IsValid("()[]{}"));  // Expected: true
        Console.WriteLine(solution.IsValid("(]"));      // Expected: false
        Console.WriteLine(solution.IsValid("([])"));    // Expected: true
        Console.WriteLine(solution.IsValid("([)]"));    // Expected: false
    }
}
