Problem Description
Given an array of integers A, find and return the peak element in it.
An array element is considered a peak if it is not smaller than its neighbors. For corner elements, we need to consider only one neighbor.
NOTE:
It is guaranteed that the array contains only a single peak element.
Users are expected to solve this in O(log(N)) time. The array may contain duplicate elements.

Input 1: A = [1, 2, 3, 4, 5]
Input 2: A = [5, 17, 100, 11]

Output 1: 5
Output 2: 100
//--------------------------//
class Solution {
  public int solve(List<int> A) {
    int n = A.Count;
    int s = 1, e = n - 2;

    if (n == 1)
      return A[0];               // If there's only one element, it's the maximum.
    if (A[1] <= A[0])
      return A[0];               // If the second element is less than or equal to the first, the first element is the maximum.
    if (A[n - 1] >= A[n - 2])
      return A[n - 1];           // If the last element is greater than or equal to the second-to-last, the last element is the maximum.
    
    while (s <= e) {
      int mid = (s + e) / 2;    // Calculate the middle index for binary search.

      if (A[mid] >= A[mid - 1] && A[mid] >= A[mid + 1])
        return A[mid];          // If the middle element is greater than or equal to its neighbors, it's the maximum.
      else if (A[mid] >= A[mid - 1])
        s = mid + 1;             // If the middle element is greater than its left neighbor, search in the right half.
      else
        e = mid - 1;            // If the middle element is smaller than its left neighbor, search in the left half.
    }
    return -1;                  // If no peak element is found, return -1.
  }
}


//--------------------------// mine //O(log(N)) ---------------------------------//
class Solution {
    public int solve(List<int> A) {
        int s = 0;
        int e = A.Count - 1;

        // Base case: If the list has only one element, return that element.
        if(A.Count == 1){
            return A[0];
        }

        // Base case: If the list has two elements, return the greater of the two.
        if(A.Count == 2){
            if(A[0] >= A[1]){
                return A[0];
            }
            else{
                return A[1];
            }
        }

        while(s <= e){
            int midIdx = (s + e) / 2;

            // Check if the middle element is a peak (greater than its neighbors).
            if(midIdx == 0 && A[midIdx] >= A[midIdx + 1]){
                return A[midIdx];
            }
            else if(midIdx == A.Count - 1 && A[midIdx] >= A[midIdx - 1]){
                return A[midIdx];
            }

            if(A[midIdx] >= A[midIdx - 1] && A[midIdx] >= A[midIdx + 1]){
                return A[midIdx];
            }
            else if(A[midIdx] > A[midIdx - 1] && A[midIdx] < A[midIdx + 1]){
                s = midIdx + 1;
            }
            else{                                       //(A[midIdx] < A[midIdx - 1] && A[midIdx] > A[midIdx + 1])
                e = midIdx - 1;
            }
        }

        // Default return (not strictly necessary in this problem).
        return 1;
    }
}

//-----------------------// help section //----------------------------------//
public class Solution {
    public int solve(List<int> A) {
        int s = 0;
        int e = A.Count - 1;

        while (s <= e) {
            int midIdx = (s + e) / 2;

            if (midIdx > 0 && A[midIdx] < A[midIdx - 1]) {
                e = midIdx - 1;
            } else if (midIdx < A.Count - 1 && A[midIdx] < A[midIdx + 1]) {
                s = midIdx + 1;
            } else {
                return A[midIdx];
            }
        }

        // Default return (not strictly necessary in this problem).
        return 1;
    }
}


