Given a sorted array of integers A (0-indexed) of size N,
 find the left most and the right most index of a given integer B in the array A.
Return an array of size 2, such that 
          First element = Left most index of B in A
          Second element = Right most index of B in A.
If B is not found in A, return [-1, -1].
Note : Your algorithm's runtime complexity must be in the order of O(log n).

 A = [5, 7, 7, 8, 8, 10]
 B = 8

 A = [5, 17, 100, 111]
 B = 3

Output 1: [3, 4]
Output 2: [-1, -1]

//---------------------------// O(log n)---------------------------------//
class Solution {
    public List<int> searchRange(List<int> A, int B) {
        int s = 0;
        int e = A.Count - 1;
        int ansL = -1;                   // Initialize the leftmost index of the target element.
        int ansR = -1;                   // Initialize the rightmost index of the target element.

        // Binary search for the leftmost index of the target element.
        while (s <= e) {
            int midIdx = (s + e) / 2;
            int mid = A[midIdx];

            if (B == mid) {
                ansL = midIdx;                   // Update the leftmost index.
                e = midIdx - 1;                  // Search in the left half for a potential earlier occurrence.
            } else if (B < mid) {
                e = midIdx - 1;                  // If target is smaller, search in the left half.
            } else {
                s = midIdx + 1;                  // If target is larger, search in the right half.
            }
        }

        // Reset variables for the rightmost binary search.
        // s = midIdx; // No need to reset s, as it's already pointing to the potential rightmost occurrence.
        e = A.Count - 1;

        // Binary search for the rightmost index of the target element.
        while (s <= e) {
            int midIdx = (s + e) / 2;
            int mid = A[midIdx];

            if (B == mid) {
                ansR = midIdx;                   // Update the rightmost index.
                s = midIdx + 1;                  // Search in the right half for a potential later occurrence.
            } else if (B < mid) {
                e = midIdx - 1;                  // If target is smaller, search in the left half.
            } else {
                s = midIdx + 1;                  // If target is larger, search in the right half.
            }
        }

        return new List<int> { ansL, ansR };     // Return the range [ansL, ansR].
    }
}

