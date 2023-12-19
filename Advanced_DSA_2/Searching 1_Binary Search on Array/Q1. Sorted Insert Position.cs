Problem Description
You are given a sorted array A of size N and a target value B.
Your task is to find the index (0-based indexing) of the target value in the array.

If the target value is present, return its index.
If the target value is not found, return the index of least element greater than equal to B.
Your solution should have a time complexity of O(log(N)).

A = [1, 3, 5, 6]
B = 5 

A = [1, 4, 9]
B = 3

Output 1: 2 
Output 2: 1
//--------------------------------------------------------------------//
class Solution {
    public int searchInsert(List<int> A, int B) {
        int s = 0;
        int e = A.Count - 1;
        int finalIdx = -1;                   // Initialize a variable to store the final index

        while (s <= e) {                     // Binary search loop
            int midIdx = (s + e) / 2;        // Calculate the index of the middle elemen
            int midEl = A[midIdx];           // Retrieve the middle element
            finalIdx = midIdx;               // Update final index with the current index

            if (B == midEl) {                // Check if target element is equal to the middle element
                return midIdx;                // Return the index of the target element
            } else if (B < midEl) {
                e = midIdx - 1;               // Adjust the end index for the left half
            } else {
                s = midIdx + 1;               // Adjust the start index for the right half
            }
        }

        if (A[finalIdx] > B) {
            return finalIdx;                 // If element at final index is greater than B, return final index
        }
        return finalIdx + 1;                 // If element at final index is less than or equal to B, return next index
    }
}
