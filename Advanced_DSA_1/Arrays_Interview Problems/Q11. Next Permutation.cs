Implement the next permutation, which rearranges numbers into the numerically next greater permutation of numbers for a given array A of size N.
If such arrangement is not possible, it must be rearranged as the lowest possible order, i.e., sorted in ascending order.
NOTE:
The replacement must be in-place, do not allocate extra memory.
DO NOT USE LIBRARY FUNCTION FOR NEXT PERMUTATION. Use of Library functions will disqualify your submission retroactively and will give you penalty points.

A = [1, 2, 3]
A = [3, 2, 1]

Output 1: [1, 3, 2]
Output 2: [1, 2, 3]

//--------------------------//TC: O(n) //-------------------------//
class Solution {
    public List<int> nextPermutation(List<int> A) {
        int n = A.Count;

        // Reverse the entire list
        Reverse(A, 0, n - 1);

        // Check if the list is already sorted, if so, return as it is the last permutation
        if (IsSorted(A))
        {
            return A;
        }

        int index = 0;

        // Find the index where the decreasing order starts
        for (int i = 1; i < n; i++)
        {
            if (A[i - 1] > A[i])
            {
                index = i;
                break;
            }
        }

        // Find the first element from the left that is greater than the element at the index
        for (int i = 0; i < index; i++)
        {
            if (A[i] > A[index])
            {
                Swap(A, i, index);
                break;
            }
        }

        // Reverse the sublist from the beginning to the index (exclusive)
        Reverse(A, 0, index - 1);

        // Reverse the entire list
        Reverse(A, 0, n - 1);

        return A;
    }

    // Reverse the elements in the specified range of the list
    public void Reverse(List<int> A, int start, int end)
    {
        int left = start;
        int right = end;
        while (left < right)
        {
            Swap(A, left, right);
            left++;
            right--;
        }
    }

    // Swap two elements in the list
    public void Swap(List<int> A, int i, int j)
    {
        int temp = A[i];
        A[i] = A[j];
        A[j] = temp;
    }

    // Check if the list is sorted in non-decreasing order
    public bool IsSorted(List<int> A)
    {
        bool sorted = true;
        for (int i = 1; i < A.Count; i++)
        {
            if (A[i - 1] > A[i])
            {
                sorted = false;
                break;
            }
        }

        return sorted;
    }
}

// Initial List: [6, 5, 2, 8, 3, 2, 4]

// Reverse the entire list
// After reverse: [4, 2, 3, 8, 2, 5, 6]

// Check if the list is already sorted, it's not, so continue with permutation

// Find the index where the decreasing order starts
// Index: 4

// Find the first element from the left that is greater than the element at the index
// Swap elements at indices 3 and 4
// After swap: [4, 2, 3, 2, 8, 5, 6]

// Reverse the sublist from the beginning to the index (exclusive)
// After reverse: [3, 2, 4, 8, 5, 6]

// Reverse the entire list
// After reverse: [6, 5, 8, 4, 2, 3]

// Final Result: [6, 5, 2, 8, 3, 4, 2]