Given two sorted integer arrays A and B, merge B and A as one sorted array and return it as an output.
Note: A linear time complexity is expected and you should avoid use of any library function.
Input 1:
A = [4, 7, 9]
B = [2, 11, 19]
Input 2:
A = [1]
B = [2]

Output 1: [2, 4, 7, 9, 11, 19]
Output 2: [1, 2]

//--------------------------------------------------//
class Solution {
    public List<int> solve(List<int> A, List<int> B) {
        int n = A.Count;
        int m = B.Count;
        List<int> ans = new List<int>();
        int i = 0, j = 0, idx = 0;  // Pointers for arrays A, B, and result

        // Merge arrays A and B in sorted order
        while (i < n && j < m) {
            if (A[i] <= B[j]) {
                ans.Add(A[i]);
                idx++;
                i++;
            } else {
                ans.Add(B[j]);
                idx++;
                j++;
            }
        }

        // If there are remaining elements in A, add them to the result
        while (i < n) {
            ans.Add(A[i]);
            idx++;
            i++;
        }

        while (j < m) {
            ans.Add(B[j]);
            idx++;
            j++;
        }

        return ans;
    }
}

//TC: O(n)
//SC: O(n)