Given an array A. Sort this array using Count Sort Algorithm and return the sorted array.
Input 1:
A = [1, 3, 1]
Input 2:
A = [4, 2, 1, 3]

Output 1:
[1, 1, 3]
Output 2:
[1, 2, 3, 4]

//--------------------------// see class and personal notes //--------------------------------------//
class Solution {
    public List<int> solve(List<int> A) {
        List<int> MinMax = MinMaxEl(A);
        int min = MinMax[0];
        int max = MinMax[1];

        // Initialize a frequency array to store the count of each element
        List<int> freqOfEl = new List<int>(new int[max - min + 1]);

        // Count the occurrences of each element
        foreach (int el in A) {
            freqOfEl[el - min] += 1;
        }

        int idx = 0;
        // Reconstruct the sorted array using the frequency information
        for (int i = 0; i < freqOfEl.Count; i++) {
            int freq = freqOfEl[i];

            // Update the original array with sorted elements
            for (int j = 0; j < freq; j++) {
                A[idx] = i + min;
                idx++;
            }
        }

        return A;
    }

    // Helper method to find the minimum and maximum elements in the array
    public List<int> MinMaxEl(List<int> A) {
        int min = int.MaxValue;
        int max = int.MinValue;

        for (int i = 0; i < A.Count; i++) {
            if (A[i] < min) {
                min = A[i];
            }
            if (A[i] > max) {
                max = A[i];
            }
        }

        return new List<int> { min, max };
    }
}

//TC: O(n)