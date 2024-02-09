You have an empty min heap. You are given an array A consisting of N queries. Let P denote A[i][0] and Q denote A[i][1]. There are two types of queries:
P = 1, Q = -1 : Pop the minimum element from the heap.
P = 2, 1 <= Q <= 109 : Insert Q into the heap.
Return an integer array containing the answer for all the extract min operation. If the size of heap is 0, then extract min should return -1.
Input 1: A = [[1, -1], [2, 2], [2, 1], [1, -1]]
Input 2: A = [[2, 5], [2, 3], [2, 1], [1, -1], [1, -1]]
Output 1: [-1, 1]
Output 2: [1, 3]

Explanation 2:
The heap contains the elements 5, 3 and 1. The first extract min operation gets the element 1 and the second operation gets the element 3.

//----------------------------------------------------//
class Solution {
    List<int> heap = new List<int>();
    List<int> ans = new List<int>();
    public List<int> solve(List<List<int>> A) {
        int n = A.Count;
        int m = A[0].Count;

        for(int i = 0; i < n; i++){
            int operation = A[i][0];
            int val = A[i][1];

            if(operation == 2){
                heapifyUp(val);               // Insert Q into the heap
            }
            if(operation == 1){
                if(heap.Count > 0){
                    ans.Add(heap[0]);         // Extract the minimum element from the heap
                    heapifyDown();                       // Fix: Adjusted comparison for smallest element in heapifyDown
                }else{
                    ans.Add(-1);                          // If the size of the heap is 0, return -1
                }
            }
        }
        return ans;
    }

    void heapifyUp(int val){
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

    void heapifyDown() {
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
    }


    void swap(int a, int b){
        int temp = heap[a];
        heap[a] = heap[b];
        heap[b] = temp;
    }
}


// int a = 6;
// int b = 2;
// int result = a.CompareTo(b);

// If result is less than 0, it means a is less than b.
// If result is 0, it means a is equal to b.
// If result is greater than 0, it means a is greater than b.
// So, after this code executes, the result variable will hold the value 1 because a is greater than b (6 > 2).