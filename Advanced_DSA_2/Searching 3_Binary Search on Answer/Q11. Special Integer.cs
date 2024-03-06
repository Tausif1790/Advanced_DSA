Q1. Special Integer
Solved
feature icon
Get your doubts resolved blazing fast with Chat GPT Help
Check Chat GPT
feature icon
Using hints is now penalty free
Use Hint
Problem Description
Given an array of integers A and an integer B, find and return the maximum value K such that there is no subarray in A of size K with the sum of elements greater than B.

Input 1
A = [1, 2, 3, 4, 5]
B = 10
Input 2:
A = [5, 17, 100, 11]
B = 130
Example Output
Output 1: 2
Output 2: 3

Explanation 1:
For K = 5, There are subarrays [1, 2, 3, 4, 5] which has a sum > B
For K = 4, There are subarrays [1, 2, 3, 4], [2, 3, 4, 5] which has a sum > B
For K = 3, There is a subarray [3, 4, 5] which has a sum > B
For K = 2, There were no subarray which has a sum > B.
Constraints are satisfied for maximal value of 2.
//-------------------------------------------------------------//
class Solution {
    public int solve(List<int> A, int B) {
        int n = A.Count;
        int ans = 0;
        List<long> pf = prefixSum(A);  // Calculate the prefix sum array.

        int start = 1;            // Binary search start index.
        int end = n;              // Binary search end index.

        while(start <= end){
            int mid = (start + end) / 2;          // mid size
            
            if(check(pf, mid, B)){        // Check if there exists a subarray of size mid with sum less than or equal to B.
                ans = mid;                // Update the result.
                start = mid + 1;          // Move the search to the right.
            }
            else{
                end = mid - 1;            // Move the search to the left.
            }
        }
        return ans;                           // Return the maximum subarray size.
    }

    // Check if there exists a subarray of size k with sum less than or equal to B.
    public bool check(List<long> pf, int k, int B){
        long firstSum = pf[k-1];              // Get the sum of the first k elements.
        if(B < firstSum) return false;        // If B is less than the sum of the first k elements, return false.

        int i = 0;  // Initialize the starting index.
        int j = k;  // Initialize the ending index.
        while(j < pf.Count){
            long currSum = pf[j] - pf[i];     // Calculate the sum of the current subarray.
            if(currSum > B) return false;     // If the sum is greater than B, return false.

            i++;                              // Move the starting index to the right.
            j++;                              // Move the ending index to the right.
        }
        return true;                          // If no subarray with sum greater than B is found, return true.
    }

    public List<long> prefixSum(List<int> A){
        int n = A.Count;
        List<long> pf = new List<long>(new long[n]);  // Initialize the prefix sum array.
        pf[0] = A[0];
        for(int i = 1; i < n; i++){
            pf[i] = pf[i-1] + A[i];  // Calculate the prefix sum for the remaining elements.
        }
        return pf;  // Return the prefix sum array.
    }
}
