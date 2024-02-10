Given an array of integers, A denoting a stream of integers. New arrays of integer B and C are formed.
Each time an integer is encountered in a stream, append it at the end of B and append the median of array B at the C.
Find and return the array C.
NOTE:
If the number of elements is N in B and N is odd, then consider the median as B[N/2] ( B must be in sorted order).
If the number of elements is N in B and N is even, then consider the median as B[N/2-1]. ( B must be in sorted order).

Input 1: A = [1, 2, 5, 4, 3]
Input 2: A = [5, 17, 100, 11]

Output 1: [1, 1, 2, 2, 3]
Output 2: [5, 5, 17, 11]
//--------------------------------------------------------//
public class Solution {
    public ArrayList<Integer> solve(ArrayList<Integer> A) {
        int n = A.size();
        ArrayList<Integer> result = new ArrayList<Integer>();
        PriorityQueue<Integer> pq1 = new PriorityQueue<>(Collections.reverseOrder()); // maxHeap
        PriorityQueue<Integer> pq2 = new PriorityQueue<>();                           // minHeap

        pq1.add(A.get(0));
        result.add(pq1.peek());                   // Initial median is the top element of maxHeap

        // Iterate through the array
        for (int i = 1; i < n; i++) {
            int curr = A.get(i);
            if (curr < pq1.peek()) {
                pq1.add(curr);                   // Add to maxHeap if the current element is smaller than the top of maxHeap
            } else {
                pq2.add(curr);                   // Add to minHeap if the current element is greater than or equal to the top of maxHeap
            }

            // Check for balance (difference of sizes between maxHeap and minHeap)
            int diff = pq1.size() - pq2.size();
            if (diff > 1) {
                int el = pq1.poll();
                pq2.add(el);                     // Move the top element from maxHeap to minHeap to maintain balance
            }
            if (diff < 0) {
                int el = pq2.poll();
                pq1.add(el);                     // Move the top element from minHeap to maxHeap to maintain balance
            }

            // Calculate median based on the total number of elements in both heaps
            int totalEl = pq1.size() + pq2.size();
            if (totalEl % 2 == 0) {
                // this will differ acorrind to question
                result.add(pq1.peek());          // If the total number of elements is even, median is the top of maxHeap
            } else {
                result.add(pq1.peek());          // If the total number of elements is odd, median is still the top of maxHeap
            }
        }

        return result;
    }
}
// Time Complexity: O(N * log N)
// Space Complexity: O(N)
