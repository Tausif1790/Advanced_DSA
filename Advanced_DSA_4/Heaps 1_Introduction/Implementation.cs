using System;
using System.Collections.Generic;

public class Heap<T> where T : IComparable<T>
{
    private List<T> items = new List<T>();

    public void Insert(T value)
    {
        items.Add(value);
        HeapifyUp();
    }

    public T Peek()
    {
        if (items.Count == 0)
        {
            throw new InvalidOperationException("Heap is empty");
        }
        return items[0];
    }

    public T Extract()
    {
        if (items.Count == 0)
        {
            throw new InvalidOperationException("Heap is empty");
        }

        T root = items[0];
        int lastIndex = items.Count - 1;
        items[0] = items[lastIndex];
        items.RemoveAt(lastIndex);

        HeapifyDown();

        return root;
    }

    private void HeapifyUp()
    {
        int index = items.Count - 1;
        while (index > 0)
        {
            int parentIndex = (index - 1) / 2;

            if (items[index].CompareTo(items[parentIndex]) >= 0)
            {
                break;
            }

            Swap(index, parentIndex);
            index = parentIndex;
        }
    }

    private void HeapifyDown()
    {
        int index = 0;
        int lastIndex = items.Count - 1;

        while (true)
        {
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;
            int smallest = index;

            if (leftChildIndex <= lastIndex && items[leftChildIndex].CompareTo(items[smallest]) < 0)
            {
                smallest = leftChildIndex;
            }

            if (rightChildIndex <= lastIndex && items[rightChildIndex].CompareTo(items[smallest]) < 0)
            {
                smallest = rightChildIndex;
            }

            if (smallest == index)
            {
                break;
            }

            Swap(index, smallest);
            index = smallest;
        }
    }

    private void Swap(int index1, int index2)
    {
        T temp = items[index1];
        items[index1] = items[index2];
        items[index2] = temp;
    }
}

public class MinHeap<T> : Heap<T> where T : IComparable<T>
{
    // MinHeap inherits from the generic Heap class
}

public class MaxHeap<T> : Heap<T> where T : IComparable<T>
{
    // MaxHeap inherits from the generic Heap class

    // Override the comparison for MaxHeap
    protected override void HeapifyUp()
    {
        int index = items.Count - 1;
        while (index > 0)
        {
            int parentIndex = (index - 1) / 2;

            if (items[index].CompareTo(items[parentIndex]) <= 0)
            {
                break;
            }

            Swap(index, parentIndex);
            index = parentIndex;
        }
    }

    protected override void HeapifyDown()
    {
        int index = 0;
        int lastIndex = items.Count - 1;

        while (true)
        {
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;
            int largest = index;

            if (leftChildIndex <= lastIndex && items[leftChildIndex].CompareTo(items[largest]) > 0)
            {
                largest = leftChildIndex;
            }

            if (rightChildIndex <= lastIndex && items[rightChildIndex].CompareTo(items[largest]) > 0)
            {
                largest = rightChildIndex;
            }

            if (largest == index)
            {
                break;
            }

            Swap(index, largest);
            index = largest;
        }
    }
}

class Program
{
    static void Main()
    {
        // Example usage of MinHeap
        MinHeap<int> minHeap = new MinHeap<int>();
        minHeap.Insert(3);
        minHeap.Insert(1);
        minHeap.Insert(4);
        minHeap.Insert(2);

        Console.WriteLine("Min Heap Peek: " + minHeap.Peek()); // Output: 1
        Console.WriteLine("Min Heap Extract: " + minHeap.Extract()); // Output: 1
        Console.WriteLine("Min Heap Peek after Extract: " + minHeap.Peek()); // Output: 2

        // Example usage of MaxHeap
        MaxHeap<int> maxHeap = new MaxHeap<int>();
        maxHeap.Insert(3);
        maxHeap.Insert(1);
        maxHeap.Insert(4);
        maxHeap.Insert(2);

        Console.WriteLine("Max Heap Peek: " + maxHeap.Peek()); // Output: 4
        Console.WriteLine("Max Heap Extract: " + maxHeap.Extract()); // Output: 4
        Console.WriteLine("Max Heap Peek after Extract: " + maxHeap.Peek()); // Output: 3
    }
}
