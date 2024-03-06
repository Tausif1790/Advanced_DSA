If there is a solution return the correct ordering.
 If there are multiple solutions print the lexographically smallest one.
Input 1:
 A = 6
 B = [  [6, 3] 
        [6, 1] 
        [5, 1] 
        [5, 2] 
        [3, 4] 
        [4, 2] ]
Input 2:
 A = 3
 B = [  [1, 2]
        [2, 3] 
        [3, 1] ]

Output 1:

 [5, 6, 1, 3, 4, 2]
Output 2: []
//------------------------------------------------------//
class Solution {
    List<int> heap = new List<int>(); // Priority queue implemented as a min heap

    // Function to perform topological sorting
    public List<int> solve(int A, List<List<int>> B) {
        List<int> result = new List<int>();
        List<int> indegree = new List<int>(new int[A + 1]);
        List<int>[] graph = new List<int>[A + 1];

        for (int i = 1; i <= A; i++) {
            graph[i] = new List<int>();
        }

        // Build the graph and calculate indegrees
        for(int i=0; i < B.Count; i++){
            int frm = B[i][0];
            int to = B[i][1];

            graph[frm].Add(to);
            indegree[to]++;
        }

        // Initialize the heap with nodes having zero indegree
        for(int i=1; i <= A; i++){
            if(indegree[i] == 0){
                heapifyUp(i);
            }
        }

        // Perform topological sorting
        while(heap.Count != 0){
            int curr = heapifyDown();
            result.Add(curr);

            List<int> neighbours = graph[curr];         // All neighbors of the current node
            foreach(int neighbour in neighbours){
                indegree[neighbour]--;
                if(indegree[neighbour] == 0){
                    heapifyUp(neighbour);
                }
            }
        }

        return result;
    }

    //------------------------// Helper methods //---------------------------------------//
    // Function to maintain the min heap property during insertion
    public void heapifyUp(int val){
        heap.Add(val);
        int i = heap.Count - 1;
        while(i > 0){
            int pi = (i - 1) / 2;           // Parent of i
            if(heap[pi] > heap[i]){
                swap(pi, i);
                i = pi;
            }
            else{
                break;
            }
        }
    }

    // Function to maintain the min heap property during extraction
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

    // Function to swap elements in the heap
    void swap(int a, int b){
        int temp = heap[a];
        heap[a] = heap[b];
        heap[b] = temp;
    }
}
// Time Complexity: O(A + E), where A is the number of nodes and E is the number of edges
// Space Complexity: O(A)
