using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create a linked list
        LinkedList<int> linkedList = new LinkedList<int>();

        // Add elements to the end
        linkedList.AddLast(1);
        linkedList.AddLast(2);

        // Add an element to the beginning
        linkedList.AddFirst(0);

        // Add an element after a specific node
        LinkedListNode<int> node = linkedList.Find(1);
        linkedList.AddAfter(node, 1.5);

        // Remove element from the beginning
        linkedList.RemoveFirst();

        // Remove element from the end
        linkedList.RemoveLast();

        // Remove a specific node
        LinkedListNode<int> nodeToRemove = linkedList.Find(2);
        linkedList.Remove(nodeToRemove);

        // Check if a value exists
        bool containsValue = linkedList.Contains(3);

        // Get the number of elements
        int count = linkedList.Count;

        // Iterate through the linked list
        foreach (var item in linkedList)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();

        // Clear the linked list
        linkedList.Clear();

        // Copy elements to an array
        int[] array = new int[linkedList.Count];
        linkedList.CopyTo(array, 0);

        // Find a node by value
        LinkedListNode<int> foundNode = linkedList.Find(2);

        // Insert a node before or after a specific node
        LinkedListNode<int> newNode = new LinkedListNode<int>(4);
        linkedList.AddBefore(foundNode, newNode);

        // Reverse the linked list
        linkedList.Reverse();
    }
}
