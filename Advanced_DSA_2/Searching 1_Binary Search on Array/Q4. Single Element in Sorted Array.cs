Given a sorted array of integers A where every element appears twice except for one element which appears once,
 find and return this single element that appears only once.
Elements which are appearing twice are adjacent to each other.
NOTE: Users are expected to solve this in O(log(N)) time.

Input 1: A = [1, 1, 7]
Input 2: A = [2, 3, 3]

Output 1: 7
Output 2: 2
//----------------------------------------------------------------//
class Solution {
    public int solve(List<int> A) {
        int s = 0;
        int e = A.Count - 1;

        while(s <= e){
            int midIdx = (s + e)/2;
            int fo = -1;  // First occurrence of repeated element

            if(A.Count == 1){
                return A[0];
            }
            else if(midIdx == 0){
                // Check if the current element is different from the next one
                if(A[midIdx] != A[midIdx+1]){
                    return A[midIdx];
                } else {
                    fo = midIdx;
                }
            }
            else if(midIdx == A.Count - 1){
                // Check if the current element is different from the previous one
                if(A[midIdx] != A[midIdx-1]){
                    return A[midIdx];
                } else {
                    fo = midIdx-1;
                }
            }
            else{
                // Check if the current element is different from both neighbors
                if(A[midIdx] != A[midIdx-1] && A[midIdx] != A[midIdx+1]){
                    return A[midIdx];
                }

                // Update the first occurrence based on the comparison with the previous element
                if(A[midIdx] == A[midIdx-1]){
                    fo = midIdx-1;
                } else {
                    fo = midIdx;
                }
            }

            // Update pointers for the next iteration
            if(fo%2 == 0){
                s = fo + 2;
            }
            else{
                e = fo - 1;
            }
        }

        return -1;  // If no unique element is found
    }
}
//TC : O(logn);
//SC : O(1)

