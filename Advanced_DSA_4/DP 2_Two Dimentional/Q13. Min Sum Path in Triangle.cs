Problem Description
Given a triangle, find the minimum path sum from top to bottom. Each step you may move to adjacent numbers on the row below.
Adjacent numbers for jth column of ith row is jth and (j+1)th column of (i + 1)th row

Input 1:
 
A = [ 
         [2],
        [3, 4],
       [6, 5, 7],
      [4, 1, 8, 3]
    ]
Input 2:
 A = [ [1] ]

Output 1: 11
Output 2: 1
//-----------------------------------------------//
using System; 
using System.Collections.Generic;

public class Solution {
    public int MinimumTotal(List<List<int>> A) {
        int n = A.Count;

        // Initialize dp array with the same structure as A
        List<List<int>> dp = new List<List<int>>();
        for(int i = 1; i <= n; i++){
            dp.Add(new List<int>(new int[i]));
        }

        for(int i = 0; i < n; i++){
            for(int j = 0; j <= i; j++){
                // Base case: Top-left corner, only one path
                if(i == 0 && j == 0){
                    dp[i][j] = A[i][j];
                }
                // Special case: On the leftmost edge, can only come from above
                else if(j == 0){
                    dp[i][j] =  dp[i - 1][j] + A[i][j];
                }
                // Special case: On the rightmost edge, can only come from above and left
                else if(i == j){
                    dp[i][j] =  dp[i - 1][j - 1] + A[i][j];
                }
                // General case: Choose the minimum path sum from above or left
                else{
                    int min = Math.Min(dp[i - 1][j - 1], dp[i - 1][j]);
                    dp[i][j] =  min + A[i][j];
                }
            }
        }

        int ans = int.MaxValue;
        // Retrieve the minimum element at the last index of the dp array
        foreach(int el in dp[n - 1]){
            ans = Math.Min(ans, el);
        }

        return ans;
    }
}
// Time Complexity: O(n^2), where n is the number of rows in the input triangle
// Space Complexity: O(n^2), for the dp array representing the minimum path sums
