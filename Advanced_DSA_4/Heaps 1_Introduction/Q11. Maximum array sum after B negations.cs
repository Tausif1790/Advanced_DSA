Given an array of integers A and an integer B. You must modify the array exactly B number of times. In a single modification, we can replace any one array element A[i] by -A[i].
You need to perform these modifications in such a way that after exactly B modifications, sum of the array must be maximum.

Input 1:
 A = [24, -68, -29, -9, 84]
 B = 4
Input 2:
 A = [57, 3, -14, -87, 42, 38, 31, -7, -28, -61]
 B = 10

Output 1: 196
Output 2: 362

Explanation 1:
Operation 1: Make -29 to 29,
Operation 2: Make -9 to 9,
Operation 3: Make 9 to -9,
Operation 4: Make -68 to 68.
Thus, the final array after 4 modifications = [24, 68, 29, -9, 84]
//--------------------------------------------------------------------//
class Solution {
    List<int> heap = new List<int>();
    public int solve(List<int> A, int B) {
        int n = A.Count;
        int ans = 0;

        // put all elements in min heap
        for(int i = 0; i < n; i++) {
            heapifyUp(A[i]);                 // Enqueue each element into the min heap
        }

        while(B > 0) {
            int val = heapifyDown();         // Extract the minimum element
            val = (-1) * val;                // Negate the value
            heapifyUp(val);                  // Enqueue the negated value back into the min heap
            B--;                             // Decrement the counter
        }

        while(heap.Count != 0) {
            ans += heapifyDown();            // Extract and accumulate elements from the min heap
        }

        return ans;                          // Return the final accumulated sum
    }

    //------------------------// helper methods //---------------------------------------//
    public void heapifyUp(int val){
        heap.Add(val);
        int i = heap.Count - 1;
        while(i > 0){
            int pi = (i - 1) / 2;           // parent of i
            if(heap[pi] > heap[i]){
                swap(pi, i);
                i = pi;
            }
            else{
                break;
            }
        }
    }

    public int heapifyDown() {
        int el = heap[0];
        swap(0, heap.Count - 1);             // Replace the root with the last element
        heap.RemoveAt(heap.Count - 1);       // Remove the last element

        int idx = 0;
        int lastIdx = heap.Count - 1;

        while (true) {
            int lcIdx = (2 * idx) + 1;       // Calculate left child index
            int rcIdx = (2 * idx) + 2;       // Calculate right child index
            int smallestIdx = idx;          // Initialize the index of the smallest element to the current node

            if (lcIdx <= lastIdx && heap[lcIdx] < heap[smallestIdx]) { // Check if left child is smaller
                smallestIdx = lcIdx;
            }
            if (rcIdx <= lastIdx && heap[rcIdx] < heap[smallestIdx]) { // Check if right child is smaller
                smallestIdx = rcIdx;
            }

            if (smallestIdx == idx) {  // If the smallest element is the current node, break the loop
                break;
            }

            swap(idx, smallestIdx);  // Swap the current node with the smallest child
            idx = smallestIdx;  // Update the index to the position of the smallest child
        }
        return el;
    }


    void swap(int a, int b){
        int temp = heap[a];
        heap[a] = heap[b];
        heap[b] = temp;
    }
}


//-------------------------// java //--------------------------------------//
public class Solution {
    public int solve(int[] A, int B) {
        PriorityQueue < Integer > pq = new PriorityQueue();

        // insert all elements into the queue
        for (int x: A) pq.offer(x);

        // perform B modifications

        while (B > 0) {
            // pop minimum lement from the queue
            int x = pq.poll();

            // if minimum element is 0, we will use all remaining opeations on this and the result will be same      
            if (x == 0) {
                B = 0;
            }
            // if minimum element is negative, modify the element to -x and push -x to queue.
            else if (x < 0) {
                pq.offer(-x);
            } else {
                //if remaining operations are even, then in one operation we convert x to -x and in another -x to x. So, no change
                //if operations are odd, we will change the number to -x. Set B = 0.
                if (B % 2 == 0) {
                    pq.offer(x);
                } else {
                    pq.offer(-x);
                }

                B = 0;
                break;
            }

            B--;
        }

        int ans = 0;

        // add all the elements in the queue to the answer
        while (pq.size() > 0) {
            ans += pq.poll();
        }

        return ans;
    }
}
