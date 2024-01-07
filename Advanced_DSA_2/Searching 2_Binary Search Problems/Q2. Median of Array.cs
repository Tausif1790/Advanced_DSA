There are two sorted arrays A and B of sizes N and M respectively.
Find the median of the two sorted arrays ( The median of the array formed by merging both the arrays ).
NOTE:
The overall run time complexity should be O(log(m+n)).
IF the number of elements in the merged array is even, then the median is the average of (n/2)th 
and (n/2+1)th element. For example, if the array is [1 2 3 4], the median is (2 + 3) / 2.0 = 2.5.

Input 1:
 A = [1, 4, 5]
 B = [2, 3]
Input 2:
 A = [1, 2, 3]
 B = [4]

Output 1: 3.0
Output 2: 2.5

//-----------------// TC: O(log(min(n1, n2))) //----------------------------//
using System;
using System.Collections.Generic;

class Solution {
    public double findMedianSortedArrays(List<int> A, List<int> B) {
        int n1 = A.Count;
        int n2 = B.Count;

        if (n1 > n2) {
            return findMedianSortedArrays(B, A);  // Recursive call to ensure A is always smaller than B (to reduce time complexity)
        }

        int start = 0, end = n1;                    // Initialize pointers for binary search in arr1/arrA
        int left = (n1 + n2 + 1) / 2;               // Total number of elements required on the left of the symmetry
        int n = n1 + n2;                            // Total number of elements in the merged array (even or odd)

        while (start <= end) {
            int mid1 = (start + end) / 2;           // Midpoint from arr1
            int mid2 = left - mid1;                 // Corresponding midpoint in arr2
                                                                 // assign default values if any one is not exist at there side                                                                  
            int l1 = (mid1 > 0) ? A[mid1 - 1] : int.MinValue;    // Left element of mid1 in arr1 (or int.MinValue if mid1 is at the beginning)
            int l2 = (mid2 > 0) ? B[mid2 - 1] : int.MinValue;    // Left element of mid2 in arr2 (or int.MinValue if mid2 is at the beginning)
            int r1 = (mid1 < n1) ? A[mid1] : int.MaxValue;        // Right element of mid1 in arr1 (or int.MaxValue if mid1 is at the end)
            int r2 = (mid2 < n2) ? B[mid2] : int.MaxValue;        // Right element of mid2 in arr2 (or int.MaxValue if mid2 is at the end)

            // Last 3 cases
            if (l1 <= r2 && l2 <= r1) {                         // Case where we found the correct partition
                if (n % 2 == 1) {
                    return Math.Max(l1, l2);                    // Median for odd-sized array is the maximum of left elements
                } else {
                    return (double)(Math.Max(l1, l2) + Math.Min(r1, r2)) / 2.0;  // Median for even-sized array is the average of max(left) and min(right) elements
                }
            } else if (l1 > r2) {
                end = mid1 - 1;                                  // Adjust pointers for binary search
            } else {
                start = mid1 + 1;                                // Adjust pointers for binary search
            }
        }

        return 0;                                              // Default return if no median found
    }
}

