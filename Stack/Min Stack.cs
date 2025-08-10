/*
155. Min Stack
--------------
Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.

Implement the MinStack class:
- MinStack() initializes the stack object.
- void Push(int val) pushes the element val onto the stack.
- void Pop() removes the element on the top of the stack.
- int Top() gets the top element of the stack.
- int GetMin() retrieves the minimum element in the stack.

You must implement each function in O(1) time complexity.

Example:
---------
Input:
["MinStack","push","push","push","getMin","pop","top","getMin"]
[[],[-2],[0],[-3],[],[],[],[]]

Output:
[null,null,null,null,-3,null,0,-2]
*/

using System;
using System.Collections.Generic;
using System.Linq;

public class MinStack
{
    Stack<int> MainStack = new Stack<int>();
    Stack<int> MinimumStack = new Stack<int>();

    public void Push(int val)
    {
        MainStack.Push(val);
        if(MinimumStack.Count == 0 || val <= MinimumStack.Peek() )
        {
            MinimumStack.Push(val);
        }
    }

    public void Pop()
    {
        int num = MainStack.Pop();
        if(MinimumStack.Count > 0 && num == MinimumStack.Peek())
        {
            MinimumStack.Pop();
        }
    }

    public int Top()
    {
        return MainStack.Peek();
    }

    public int GetMin()
    {
        return MinimumStack.Peek();
    }
}

public class Program
{
    public static void Main()
    {
        var minStack = new MinStack();
        minStack.Push(-2);
        minStack.Push(0);
        minStack.Push(-3);
        Console.WriteLine(minStack.GetMin()); // Expected: -3
        minStack.Pop();
        Console.WriteLine(minStack.Top());    // Expected: 0
        Console.WriteLine(minStack.GetMin()); // Expected: -2
    }
}
