Imagine you're an ice cream truck driver in a beachside town. The beach is divided into several sections, and each section has varying numbers of beachgoers wanting ice cream given by the array of integers A.
For simplicity, let's say the beach is divided into 8 sections. One day, you note down the number of potential customers in each section: [5, 12, 3, 4, 8, 10, 2, 7]. This means there are 5 people in the first section, 12 in the second, and so on.
You can only stop your truck in B consecutive sections at a time because of parking restrictions. To maximize sales, you want to park where the most customers are clustered together.
For all B consecutive sections, identify the busiest stretch to park your ice cream truck and serve the most customers. Return an array C, where C[i] is the busiest section in each of the B consecutive sections. Refer to the given example for clarity
NOTE: If B > length of the array, return 1 element with the max of the array.

Input 1:
 A = [1, 3, -1, -3, 5, 3, 6, 7]
 B = 3
Input 2:
 A = [1, 2, 3, 4, 2, 7, 1, 3, 6]
 B = 6

Output 1: [3, 3, 5, 5, 6, 7]
Output 2: [7, 7, 7, 7]

Explanation 1:

 Window position     | Max
 --------------------|-------
 [1 3 -1] -3 5 3 6 7 | 3
 1 [3 -1 -3] 5 3 6 7 | 3
 1 3 [-1 -3 5] 3 6 7 | 5
 1 3 -1 [-3 5 3] 6 7 | 5
 1 3 -1 -3 [5 3 6] 7 | 6
 1 3 -1 -3 5 [3 6 7] | 7

//--------------------------// O(n), O(B) //--------------------------------------//
class Solution {
    public List<int> slidingMaximum(List<int> A, int B) {
        List<int> result = new List<int>();              // To store the maximum values for each window
        Deque<int> myDeque = new Deque<int>();           // A double-ended queue to efficiently track maximum elements

        if (A.Count == 1) return A;                      // If there's only one element, it's the maximum by default

        int left = 0, right = 0;                         // Pointers indicating the current window on the array

        // First window
        while (right < B) {
            // Remove elements from the back of the deque that are smaller than the current element
            while (!myDeque.IsEmpty() && A[right] >= A[myDeque.PeekRear()]) {           // previous mistake //A[right] >= myDeque.PeekRear()
                myDeque.DequeueRear();
            }
            // Enqueue the current index into the deque
            myDeque.EnqueueRear(right);
            right++;
        }
        result.Add(A[myDeque.PeekFront()]);              // Add the maximum of the first window to the result

        // Rest of the windows
        while (right < A.Count) {
            // Remove the front element of the deque if it's outside the current window
            if (left == myDeque.PeekFront()) {
                myDeque.DequeueFront();
            }

            left++;                                      // Move the window to the right
            // Remove elements from the back of the deque that are smaller than the current element
            while (!myDeque.IsEmpty() && A[right] >= A[myDeque.PeekRear()]) {               // previous mistake //A[right] >= myDeque.PeekRear()
                myDeque.DequeueRear();
            }

            myDeque.EnqueueRear(right);                 // Enqueue the current index into the deque
            result.Add(A[myDeque.PeekFront()]);         // Add the maximum of the current window to the result
            right++;                                    // Move the window to the right
        }

        return result;
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
