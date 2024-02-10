N people having different priorities are standing in a queue.
The queue follows the property that each person is standing at most B places away from its position in the sorted queue.
Your task is to sort the queue in the increasing order of priorities.
NOTE:
No two persons can have the same priority.
Use the property of the queue to sort the queue with complexity O(NlogB).
Input 1:
 A = [1, 40, 2, 3]
 B = 2
Input 2:
 A = [2, 1, 17, 10, 21, 95]
 B = 1

Output 1: [1, 2, 3, 40]
Output 2: [1, 2, 10, 17, 21, 95]
//-------------------------// O(NlogB). //----------------------------------//
public class Solution {
    public ArrayList<Integer> solve(ArrayList<Integer> A, int B) {
        int n = A.size();
        PriorityQueue<Integer> pq = new PriorityQueue<Integer>();

        if (B == 0) return A;                // If B is 0, no change is needed, return the original array

        // Insert the first B+1 elements into the heap
        for (int i = 0; i <= B; i++) {
            pq.add(A.get(i));
        }

        int idx = 0;
        // Perform operations on the remaining elements, but the heap size will remain the same
        for (int i = B + 1; i < n; i++) {
            // Update the same array for the result
            A.set(idx, pq.poll());           // Replace the element at idx with the smallest element from the heap
            idx++;
            pq.add(A.get(i));                // Add the current element to the heap
        }

        // Poll the remaining elements from the heap
        while (!pq.isEmpty()) {
            A.set(idx, pq.poll());           // Replace the remaining elements in the array with elements from the heap
            idx++;
        }
        return A;
    }
}
