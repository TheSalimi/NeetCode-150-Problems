/*
22. Generate Parentheses
-------------------------
Given n pairs of parentheses, generate all combinations of well-formed parentheses.
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using System.Threading.Tasks;

public class Solution
{
    public IList<string> GenerateParenthesis(int n)
    {
        List<string> result = new List<string>();
        Stack<(string,int,int)> state = new Stack<(string, int, int)>();

        state.Push(("",0,0));
        
        while (state.Count > 0) {
            var (current,open,close) = state.Pop();
            
            if(current.Length == 2 * n)
            {
                result.Add(current);
            }
            else
            {
                if (open < n)
                {
                    state.Push((current + "(", open + 1, close));
                }
                if (close < open)
                {
                    state.Push((current + ")", open, close + 1));
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

        int n = 3;
        var result = solution.GenerateParenthesis(n);

        Console.WriteLine($"All combinations of well-formed parentheses for n = {n}:");
        foreach (var s in result)
        {
            Console.WriteLine(s);
        }
    }
}

