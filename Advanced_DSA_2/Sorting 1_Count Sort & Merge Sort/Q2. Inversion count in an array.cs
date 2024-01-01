Given an array of integers A. If i < j and A[i] > A[j], then the pair (i, j) is called an inversion of A.
 Find the total number of inversions of A modulo (109 + 7).

A = [1, 3, 2]
A = [3, 4, 1, 2]

Output 1: 1
Output 2: 4

//-----------------// TC: O(n log n), SC: O(n + log n) //---------------------------//
class Solution {
    int count = 0;                            // Count variable to store the inversion count
    int mod = (int)Math.Pow(10, 9) + 7;       // Modulo value for preventing overflow
    public int solve(List<int> A) {
        MergeSort(A, 0, A.Count - 1);         // Sorting the list using MergeSort
        return count % mod;                   // Returning the inversion count modulo mod
    }

    void MergeSort(List<int> A, int left, int right) {
        if (left == right) {
            return;                           // Base case: If only one element, it's already sorted
        }
        int mid = (left + right) / 2;

        MergeSort(A, left, mid);                // Recursive call for the left half
        MergeSort(A, mid + 1, right);             // Recursive call for the right half

        Merge(A, left, mid, right);               // Merging the two halves
    }

    void Merge(List<int> A, int left, int mid, int right) {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        List<int> leftArray = new List<int>(A.GetRange(left, n1));
        List<int> rightArray = new List<int>(A.GetRange(mid + 1, n2));

        int i = 0, j = 0, idx = left;             // imp -> idx = left

        while (i < n1 && j < n2) {
            if (leftArray[i] <= rightArray[j]) {
                A[idx] = leftArray[i];            // Copying element from leftArray
                i++;
            } else {
                A[idx] = rightArray[j];
                j++;
                // Inversion count logic for unsorted arrays
                //count = (count % mod + (n1 - i) % mod) % mod;          // we calculate this below but this one is better 
            }
            idx++;
        }

        while (i < n1) {
            A[idx] = leftArray[i];                // Copying remaining elements from leftArray
            i++;
            idx++;
        }

        while (j < n2) {
            A[idx] = rightArray[j];               // Copying remaining elements from rightArray
            j++;
            idx++;
        }

        // Inversion count logic for sorted arrays
        // leftArray and rightArray sorted now, so we can calculate A[i] > A[j] (see in class notes)
        int x = 0;
        int y = 0;
        while (x < n1 && y < n2) {
            if (leftArray[x] > rightArray[y]) {
                int totalCount = n1 - x;
                count = (count % mod + totalCount % mod) % mod;
                y++;
            } else {
                x++;
            }
        }

        // working but give TLE for Hard test case
        // for(int x=0; x<n1; x++){
        //     for(int y=0; y<n2; y++){
        //         if(leftArray[x] > rightArray[y]){
        //             count++;
        //         }
        //     }
        // }
    }
}

