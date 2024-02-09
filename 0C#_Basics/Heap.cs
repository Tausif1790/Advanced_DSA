using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Example usage of MinHeap
        var minHeap = new PriorityQueue<int>(PriorityQueueType.Minimum);
        minHeap.Enqueue(3);
        minHeap.Enqueue(1);
        minHeap.Enqueue(4);
        minHeap.Enqueue(2);

        Console.WriteLine("Min Heap Peek: " + minHeap.Peek()); // Output: 1
        Console.WriteLine("Min Heap Dequeue: " + minHeap.Dequeue()); // Output: 1
        Console.WriteLine("Min Heap Peek after Dequeue: " + minHeap.Peek()); // Output: 2

        // Example usage of MaxHeap
        var maxHeap = new PriorityQueue<int>(PriorityQueueType.Maximum);
        maxHeap.Enqueue(3);
        maxHeap.Enqueue(1);
        maxHeap.Enqueue(4);
        maxHeap.Enqueue(2);

        Console.WriteLine("Max Heap Peek: " + maxHeap.Peek()); // Output: 4
        Console.WriteLine("Max Heap Dequeue: " + maxHeap.Dequeue()); // Output: 4
        Console.WriteLine("Max Heap Peek after Dequeue: " + maxHeap.Peek()); // Output: 3
    }
}
