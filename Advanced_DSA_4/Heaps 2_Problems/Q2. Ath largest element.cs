Given an integer array B of size N.
You need to find the Ath largest element in the subarray [1 to i], where i varies from 1 to N. In other words, find the Ath largest element in the sub-arrays [1 : 1], [1 : 2], [1 : 3], ...., [1 : N].
NOTE: If any subarray [1 : i] has less than A elements, then the output should be -1 at the ith index.
Input 1:
 A = 4  
 B = [1 2 3 4 5 6] 
Input 2:
 A = 2
 B = [15, 20, 99, 1]

Output 1: [-1, -1, -1, 1, 2, 3]
Output 2: [-1, 15, 20, 20]

//------------------// O(Blog(B) + (n-B)log(B)) //----------------------//
public class Solution {
    public ArrayList<Integer> solve(int B, ArrayList<Integer> A) {
        int n = A.size();
        PriorityQueue<Integer> pq = new PriorityQueue<Integer>();

        for (int i = 0; i < B - 1; i++) {
            pq.add(A.get(i));                 // Add current element to the priority queue
            A.set(i, -1);                     // Set the current element in A to -1
        }

        pq.add(A.get(B - 1));                // Add the last element to the priority queue
        A.set(B - 1, pq.peek());              // Set the last element in A to the minimum element in the priority queue

        for (int i = B; i < n; i++) {
            if (A.get(i) > pq.peek()) {
                pq.poll();                      // Remove the minimum element from the priority queue
                pq.add(A.get(i));                // Add the current element to the priority queue
                A.set(i, pq.peek());              // Set the current element in A to the minimum element in the priority queue
            } else {
                A.set(i, pq.peek());              // Set the current element in A to the minimum element in the priority queue
            }
        }

        return A;
    }
}
