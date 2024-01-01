// TC: O(n log n)

class Solution {
    public List<int> solve(List<int> A) {
        MergeSort(A, 0, A.Count - 1);         // Sorting the list using MergeSort
        return A;                             // Returning the sorted list
    }

    void MergeSort(List<int> A, int left, int right) {
        if (left == right) {
            return;                           // Base case: If only one element, it's already sorted
        }
        int mid = (left + right) / 2;

        MergeSort(A, left, mid);              // Recursive call for the left half
        MergeSort(A, mid + 1, right);         // Recursive call for the right half

        Merge(A, left, mid, right);           // Merging the two halves
    }

    void Merge(List<int> A, int left, int mid, int right) {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        List<int> leftArray = new List<int>(A.GetRange(left, n1));
        List<int> rightArray = new List<int>(A.GetRange(mid + 1, n2));

        int i = 0, j = 0, idx = left;         // Initializing indices for leftArray, rightArray, and the main array

        while (i < n1 && j < n2) {
            if (leftArray[i] <= rightArray[j]) {
                A[idx] = leftArray[i];        // Copying element from leftArray
                i++;
            } else {
                A[idx] = rightArray[j];       // Copying element from rightArray
                j++;
            }
            idx++;
        }

        while (i < n1) {
            A[idx] = leftArray[i];            // Copying remaining elements from leftArray
            i++;
            idx++;
        }

        while (j < n2) {
            A[idx] = rightArray[j];            // Copying remaining elements from rightArray
            j++;
            idx++;
        }
    }
}
