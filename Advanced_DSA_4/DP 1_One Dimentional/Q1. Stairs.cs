class Solution {
    int mod = (int)Math.Pow(10, 9) + 7;
    
    public int climbStairs(int A) {
        int[] dp = new int[A + 1];
        // Initialize dp array with -1 for memoization
        for (int i = 0; i < dp.Length; i++)
        {
            dp[i] = -1;
        }
        int ans = recursion(A, dp);
        return ans;
    }

    public int recursion(int n, int[] dp){
        if(n == 0 || n == 1){
            dp[n] = n;
            return 1;  // Return 1 for base cases, as it's a counting problem
        }

        if(dp[n] != -1){
            return dp[n];
        }

        int first = recursion(n-1, dp);
        int second = recursion(n-2, dp);

        // Fix: Calculate modulo for intermediate result to avoid overflow
        dp[n] = (first + second) % mod;  // Store result in dp array

        return dp[n];
    }
}
