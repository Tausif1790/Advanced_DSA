using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Creating a stack
        Stack<int> myStack = new Stack<int>();

        // Pushing elements onto the stack
        myStack.Push(10);
        myStack.Push(20);
        myStack.Push(30);

        // Peeking at the top element
        int topElement = myStack.Peek();
        Console.WriteLine($"Top element: {topElement}");

        // Popping elements from the stack
        int poppedElement = myStack.Pop();
        Console.WriteLine($"Popped element: {poppedElement}");

        // Checking if the stack is empty
        bool isEmpty = myStack.Count == 0;
        Console.WriteLine($"Is stack empty? {isEmpty}");

        // Displaying all elements in the stack
        Console.WriteLine("Elements in the stack:");
        foreach (var item in myStack)
        {
            Console.WriteLine(item);
        }
    }
}
