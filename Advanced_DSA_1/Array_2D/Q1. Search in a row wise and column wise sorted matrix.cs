Given a matrix of integers A of size N x M and an integer B.
In the given matrix every row and column is sorted in non-decreasing order. Find 
    and return the position of B in the matrix in the given form:
If A[i][j] = B then return (i * 1009 + j)
If B is not present return -1.

Input 1:-
A = [[1, 2, 3]   <----- start from here
     [4, 5, 6]
     [7, 8, 9]]
B = 2
Input 2:-
A = [[1, 2]
     [3, 3]]
B = 3


Example Output
Output 1:-
1011
Output 2:-
2019

//---------------------Brute force, TC: O(n^2), SC:O(1)---------------------------//
class Solution {
    public int solve(List<List<int>> A, int B) {
        int n = A.Count;
        int m = A[0].Count;
        for(int i=0; i<n; i++){
            for(int j=0; j<m; j++){
                if(A[i][j] == B){
                    int res = (i+1)*1009 + (j+1);
                    return res;
                }
            }
        }
        return -1;
    }
}

//---------Optimised stating from j = m-1, i=0, TC:O(n), SC: O(1)--------------//
class Solution {
    public int solve(List<List<int>> A, int B) {
        int n = A.Count;
        int m = A[0].Count;
        int i = 0;                       // Start from the top row.
        int j = m - 1;                   // Start from the rightmost column.
        int ans = int.MaxValue;          // Initialize the answer to a large value.

        while (i < n && j >= 0) {
            if (A[i][j] == B) {
                int res = (i + 1) * 1009 + (j + 1);         // Encode the position of 'B' as a unique identifier.
                ans = Math.Min(ans, res);                   // we need ans as minimum
                j--;                                        // go to cell whos value is lesser than current value
                                                            // in future itr we want that value also in other cell (if we goto cell lesser that cutter value that we can achieved this)
                continue;                                   // Continue to the next iteration.
            }
            if (A[i][j] < B) {
                i++;                                         // Move down if the current element is less than 'B'.
            } else if (A[i][j] > B) {
                j--;                                        // Move left if the current element is greater than 'B'.
            }
        }

        if (ans == int.MaxValue) {
            return -1;                  // If 'ans' is still the initialized value, 'B' was not found in the list.
        }

        return ans;
    }
}
