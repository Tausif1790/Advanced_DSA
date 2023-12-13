class Solution {
    public List<int> Partition(List<int> A) {
        int pivotValue = A[0];          // Choose the first element as the pivot

        int i = 0, j = A.Count - 1;     // Initialize pointers for partitioning

        while(i<=j){                    // Continue partitioning until the pointers meet
            if(A[i] <= pivotValue){     // Move the left pointer to the right if element is less than or equal to the pivot
                i++;
            }
            else if(A[j] > pivotValue){ // Move the right pointer to the left if element is greater than the pivot
                j--;
            }
            else{                       // Swap elements if the left element is greater and the right element is smaller
                Swap(A, i, j);
                i++;
                j--;
            }
        }
        Swap(A, 0, j);                  // Swap the pivot to its correct position in the partitioned array

        return A;                       // Return the array after partitioning
    }

    public void Swap(List<int> A, int a, int b){
        int temp = A[a];
        A[a] = A[b];
        A[b] = temp;
    }
}
//TC: O(n)
//SC: O(1)
//[54,26,93,17,77,31,44,55,20]