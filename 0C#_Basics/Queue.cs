using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Creating a Queue
        Queue<int> myQueue = new Queue<int>();

        // Enqueue: Adding elements to the Queue
        myQueue.Enqueue(10);
        myQueue.Enqueue(20);
        myQueue.Enqueue(30);

        // Dequeue: Removing and returning the element from the front of the Queue
        int frontElement = myQueue.Dequeue();
        Console.WriteLine("Dequeued element: " + frontElement);

        // Peek: Returning the element at the front without removing it
        int peekElement = myQueue.Peek();
        Console.WriteLine("Peeked element: " + peekElement);

        // Count: Getting the number of elements in the Queue
        int queueCount = myQueue.Count;
        Console.WriteLine("Number of elements in the Queue: " + queueCount);

        // Contains: Checking if a specific element is present in the Queue
        bool containsElement = myQueue.Contains(20);
        Console.WriteLine("Does the Queue contain 20? " + containsElement);

        // Clear: Removing all elements from the Queue
        myQueue.Clear();
        Console.WriteLine("Queue cleared. Number of elements now: " + myQueue.Count);
    }
}

class Queue<T>
{
    private Queue<T> queue = new Queue<T>();

    public void Enqueue(T item)
    {
        queue.Enqueue(item);
    }

    public T Dequeue()
    {
        if (queue.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        return queue.Dequeue();
    }

    public T Peek()
    {
        if (queue.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        return queue.Peek();
    }

    public bool IsEmpty()
    {
        return queue.Count == 0;
    }
}


// Rear: Accessing the rear element
        int rearElement = myQueue.Rear();
        Console.WriteLine("Rear element: " + rearElement);

class QueueWithRear<T>
{
    private LinkedList<T> linkedList = new LinkedList<T>();

    public void Enqueue(T item)
    {
        linkedList.AddLast(item);
    }

    public T Dequeue()
    {
        if (linkedList.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        T front = linkedList.First.Value;
        linkedList.RemoveFirst();
        return front;
    }

    public T Rear()
    {
        if (linkedList.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty");
        }

        return linkedList.Last.Value;
    }
}

//----------------------------------------------// Deque //-----------------------------------------------------//
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Creating a Deque
        Deque<int> myDeque = new Deque<int>();

        // EnqueueFront: Adding elements to the front of the Deque
        myDeque.EnqueueFront(10);
        myDeque.EnqueueFront(20);
        
        // EnqueueRear: Adding elements to the rear of the Deque
        myDeque.EnqueueRear(30);
        myDeque.EnqueueRear(40);

        // DequeueFront: Removing and returning the element from the front of the Deque
        int frontElement = myDeque.DequeueFront();
        Console.WriteLine("Dequeued front element: " + frontElement);

        // DequeueRear: Removing and returning the element from the rear of the Deque
        int rearElement = myDeque.DequeueRear();
        Console.WriteLine("Dequeued rear element: " + rearElement);

        // PeekFront: Returning the element at the front without removing it
        int peekFrontElement = myDeque.PeekFront();
        Console.WriteLine("Peeked front element: " + peekFrontElement);

        // PeekRear: Returning the element at the rear without removing it
        int peekRearElement = myDeque.PeekRear();
        Console.WriteLine("Peeked rear element: " + peekRearElement);

        // IsEmpty: Checking if the Deque is empty
        bool isEmpty = myDeque.IsEmpty();
        Console.WriteLine("Is the Deque empty? " + isEmpty);
    }
}

class Deque<T>
{
    private LinkedList<T> linkedList = new LinkedList<T>();

    public void EnqueueFront(T item)
    {
        linkedList.AddFirst(item);
    }

    public void EnqueueRear(T item)
    {
        linkedList.AddLast(item);
    }

    public T DequeueFront()
    {
        if (linkedList.Count == 0)
        {
            throw new InvalidOperationException("Deque is empty");
        }

        T front = linkedList.First.Value;
        linkedList.RemoveFirst();
        return front;
    }

    public T DequeueRear()
    {
        if (linkedList.Count == 0)
        {
            throw new InvalidOperationException("Deque is empty");
        }

        T rear = linkedList.Last.Value;
        linkedList.RemoveLast();
        return rear;
    }

    public T PeekFront()
    {
        if (linkedList.Count == 0)
        {
            throw new InvalidOperationException("Deque is empty");
        }

        return linkedList.First.Value;
    }

    public T PeekRear()
    {
        if (linkedList.Count == 0)
        {
            throw new InvalidOperationException("Deque is empty");
        }

        return linkedList.Last.Value;
    }

    public bool IsEmpty()
    {
        return linkedList.Count == 0;
    }
}
