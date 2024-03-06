Problem Description
Given a M x N grid A of integers, find a path from top left to bottom right which minimizes the sum of all numbers along its path.
Return the minimum sum of the path.
NOTE: You can only move either down or right at any point in time.

Input 1:
 A = [
       [1, 3, 2]
       [4, 3, 1]
       [5, 6, 1]
     ]
Input 2:
 A = [
       [1, -3, 2]
       [2, 5, 10]
       [5, -5, 1]
     ]
Output 1: 8
Output 2: -1

//-------------------------------------------------------//\
class Solution {
    public int minPathSum(List<List<int>> A) {
        int n = A.Count;
        int m = A[0].Count;

        Initialize dp array to store minimum path sums
        int[,] dp = new int[n, m];


        for(int i=0; i<n; i++){
            for(int j=0; j<m; j++){
                // Base case: Top-left corner, no choices, only one path
                if(i == 0 && j == 0){
                    dp[i, j] = A[i][j];
                }
                // Special case: On the first row, can only move right
                else if(i == 0){
                    dp[i, j] = dp[i, j-1] + A[i][j];
                }
                // Special case: On the first column, can only move down
                else if(j == 0){
                    dp[i, j] = dp[i-1, j] + A[i][j];
                }
                // General case: Choose the minimum path sum from above or left
                else{
                    dp[i, j] = Math.Min(dp[i-1, j], dp[i, j-1]) + A[i][j];
                }
            }
        }

        // Return the minimum path sum at the bottom-right corner
        return dp[n-1, m-1];
    }
}
