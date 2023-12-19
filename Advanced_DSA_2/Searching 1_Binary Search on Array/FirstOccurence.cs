class Solution {
    public int searchInsert(List<int> A, int B) {
        int start = 0;       
        int end = A.Count - 1;
        int result = -1;         // Initialize the result to -1, indicating not found

        while (start <= end) { 
            int midIdx = (start + end) / 2; 
            int midEl = A[midIdx];      

            if (B == midEl) { 
                result = midIdx;                // Update result with the current index
                end = midIdx - 1;               // Continue searching in the left half for other occurrences
            } else if (B < midEl) {
                end = midIdx - 1; 
            } else {
                start = midIdx + 1;
            }
        }

        return result;                   // Return the final result (index of the target or least element greater than equal to B)
    }
}
