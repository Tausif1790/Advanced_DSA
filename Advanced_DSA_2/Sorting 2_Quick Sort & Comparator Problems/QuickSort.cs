class Solution {
    public List<int> solve(List<int> A) {
        if (A.Count <= 1) {
            return A;
        }

        QuickSort(A, 0, A.Count - 1);

        return A;
    }

    // QuickSort method to recursively sort subarrays
    private void QuickSort(List<int> A, int low, int high) {
        if (low >= high) {
            return;
        }
        int pivotIndex = PartitionHelper(A, low, high); // Find the correct position of the pivot

        QuickSort(A, low, pivotIndex - 1);              // Recursively sort the left subarray
        QuickSort(A, pivotIndex + 1, high);              // Recursively sort the right subarray
        
    }

    private int PartitionHelper(List<int> A, int low, int high) {
        int pivotValue = A[low];
        int i = low + 1;
        int j = high;

        while (i <= j) {
            if (A[i] <= pivotValue) {
                i++;
            }
            else if (A[j] > pivotValue) {
                j--;
            }
            else {
                Swap(A, i, j);
                i++;
                j--;
            }
        }

        Swap(A, low, j);

        return j;            // This el is 54 because we are swapping last el with el at idx j
                            // so now at j 54 is present which is initial pivot el // so we are returning ind of pivotValue
    }

    private void Swap(List<int> A, int a, int b) {
        int temp = A[a];
        A[a] = A[b];
        A[b] = temp;
    }
}

//TC: O(nlogn)
//SC: O(logn)
//[54,26,93,17,77,31,44,55,20]