Given a binary sorted matrix A of size N x N. Find the row with the maximum number of 1.
NOTE:
If two rows have the maximum number of 1 then return the row which has a lower index.
Rows are numbered from top to bottom and columns are numbered from left to right.
Assume 0-based indexing.
Assume each row to be sorted by values.
Expected time complexity is O(rows + columns).

Input 1:

 A = [   [0, 1, 1]       <----- start from here 
         [0, 0, 1]
         [0, 1, 1]   ]
Input 2:

 A = [   [0, 0, 0, 0]
         [0, 0, 0, 1]
         [0, 0, 1, 1]
         [0, 1, 1, 1]    ]

Example Output
Output 1: 0
Output 2: 3

//-------------------Brute Force-------------------------//
TC: O(n^2)
se O(1)

//-------------------Optimised, TC:O(n), SC:O(1)-------------------------//
 class Solution {
    public int solve(List<List<int>> A) {
        int n = A.Count;
        int ans = 0;
        int i = 0;
        int j = n-1;
        while(i<n && j>=0){
            while(j>=0 && A[i][j] == 1){
                j--;
                ans = i;
            }
            i++;
        }
        return ans;
    }
}

// using two nested loop but TC is O(n) only because its itrs like that