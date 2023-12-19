class Solution {
    public int searchInsert(List<int> A, int B) {
        int start = 0;
        int end = A.Count - 1;

        while (start <= end) {                // Continue the search until the start index is less than or equal to the end index
            int midIdx = (start + end) / 2;    
            int midEl = A[midIdx];             

            if (B == midEl) {
                return midIdx;               // If the target element is equal to the middle element, return the index
            } else if (B < midEl) {
                end = midIdx - 1;            // If the target element is less than the middle element, adjust the end index
            } else {
                start = midIdx + 1;          // If the target element is greater than the middle element, adjust the start index
            }
        }

        return start;                        // If the target element is not found
    }
}
