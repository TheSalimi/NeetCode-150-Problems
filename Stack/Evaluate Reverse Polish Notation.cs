/*
150. Evaluate Reverse Polish Notation
-------------------------------------
Given an array of strings tokens representing an arithmetic expression in Reverse Polish Notation,
evaluate the expression and return its value.
*/

using System;
using System.Collections.Generic;

public class Solution
{
    public int EvalRPN(string[] tokens)
    {
        Stack<int> stack = new Stack<int>();
        foreach (string token in tokens) {

            if (token == "*" || token == "/" || token == "+" || token == "-") { 
                int num2 = stack.Pop();
                int num1 = stack.Pop();

                if (token == "*")
                {
                    int result = num1 * num2;
                    stack.Push(result);
                }
                else if (token == "/") {
                    int result = num1 / num2;
                    stack.Push(result);
                }
                else if(token == "+")
                {
                    int result = num1 + num2;
                    stack.Push(result);
                }
                else if(token == "-")
                {
                    int result = num1 - num2;
                    stack.Push(result);
                }
            }
            else
            {
                stack.Push(int.Parse(token));
            }
        }

        return stack.Pop();
    }
}

public class Program
{
    public static void Main()
    {
        var solution = new Solution();

        string[] tokens1 = { "2", "1", "+", "3", "*" };
        Console.WriteLine(solution.EvalRPN(tokens1)); // Expected: 9

        string[] tokens2 = { "4", "13", "5", "/", "+" };
        Console.WriteLine(solution.EvalRPN(tokens2)); // Expected: 6

        string[] tokens3 = { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" };
        Console.WriteLine(solution.EvalRPN(tokens3)); // Expected: 22
    }
}
