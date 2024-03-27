Problem Description
Given a rod of length N units and an array A of size N denotes prices that contains prices of all pieces of size 1 to N.
Find and return the maximum value that can be obtained by cutting up the rod and selling the pieces.

 A = [3, 4, 1, 6, 2]
Input 2:

 A = [1, 5, 2, 5, 6]

//-----------------------------------------------------------//
class Solution {
    public int solve(List<int> A) {
        int n = A.Count;
        List<int> dp = new List<int>(new int[n+1]);
        dp[0] = 0;
        for(int i=1; i<=n; i++){
            int max = int.MinValue;
            for(int j=1; j<=i; j++){
                max = Math.Max(max, A[j-1] + dp[i - j]);
            }
            dp[i] = max;
        }
        return dp[n];
    }
}
