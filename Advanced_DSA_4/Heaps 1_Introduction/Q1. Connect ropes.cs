Input 1: A = [1, 2, 3, 4, 5]
Input 2: A = [5, 17, 100, 11]

Output 1: 33
Output 2: 182

Explanation 1:
 Given array A = [1, 2, 3, 4, 5].
 Connect the ropes in the following manner:
 1 + 2 = 3
 3 + 3 = 6
 4 + 5 = 9
 6 + 9 = 15
 So, total cost  to connect the ropes into one is 3 + 6 + 9 + 15 = 33.

 //--------------------------// Java code //--------------------------------------------//
 public class Solution {
    public int solve(int[] A) {

        PriorityQueue < Integer > pq = new PriorityQueue();
        int cost = 0;

        // insert all elements in the queue
        for (int x: A) {
            pq.offer(x);
        }

        // keep on removing elements from the queue untill there is one element in the queue
        while (true) {

            // Take the two ropes with smallest length
            int l1 = pq.poll();
            int l2 = pq.poll();
            // cost of combining these two ropes is l1 + l2.
            cost += l1 + l2;

            if(pq.size() == 0){
                break;
            }
            // add the newly formed rope of length l1 + l2 to the queue.
            pq.offer(l1 + l2);
        }

        return cost;
    }
}
 //------------------------------// O(N * log N). //----------------------------------------//
 class Solution {
    List<int> heap = new List<int>();
    public int solve(List<int> A) {
        int ans = 0;
        int n = A.Count;

        // Enqueue each element into the heap
        for (int i = 0; i < n; i++) {
            heapifyUp(A[i]);
        }

        while (true) {
            // Extract two minimum elements
            int a = heapifyDown();
            int b = heapifyDown();

            int sum = a + b;                // Calculate the sum of the two minimum elements
            ans += sum;                     // Accumulate the sum to the answer

            if (heap.Count == 0) {          // If the heap is empty, exit the loop
                break;
            }

            heapifyUp(sum);                 // Enqueue the sum back into the heap
        }

        return ans;
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
