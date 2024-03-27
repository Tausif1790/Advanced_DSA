Given two integer arrays A and B of size N each which represent values and weights associated with N items respectively.
Also given an integer C which represents knapsack capacity.
Find out the maximum value subset of A such that sum of the weights of this subset is smaller than or equal to C.
NOTE:
You cannot break an item, either pick the complete item, or don't pick it (0-1 property).

Input 1:

 A = [60, 100, 120]
 B = [10, 20, 30]
 C = 50
Input 2:
 A = [10, 20, 30, 40]
 B = [12, 13, 15, 19]
 C = 10

Output 1: 220
Output 2: 0
//---------------------------------------------------//
class Solution {
    // recursive
    public int solve2(List<int> A, List<int> B, int C) {
        // A => Values
        // B => Weights
        int n = A.Count;
        int[,] dp = new int[n, C + 1];

        // Initialize dp array with -1
        for (int i = 0; i < n; i++) {
            for (int j = 0; j <= C; j++) {
                dp[i, j] = -1;
            }
        }

        // Call the recursive function to solve the problem
        int result = Knapsack01(dp, A, B, n - 1, C);
        return result;
    }

    // Recursive function to solve the 0/1 Knapsack problem
    public int Knapsack01(int[,] dp, List<int> val, List<int> wt, int end, int weightLeft) {
        // Base case: If no weight left or no items remaining, return 0
        if (weightLeft <= 0 || end < 0) {
            return 0;
        }

        // If the result for the current state is already computed, return it
        if (dp[end, weightLeft] != -1) {
            return dp[end, weightLeft];
        }

        // Consider including and excluding the current item
        int include = 0;
        if (wt[end] <= weightLeft) {
            include = val[end] + Knapsack01(dp, val, wt, end - 1, weightLeft - wt[end]);
        }
        int exclude = Knapsack01(dp, val, wt, end - 1, weightLeft);

        // Update the dp array with the maximum of include and exclude
        dp[end, weightLeft] = Math.Max(include, exclude);

        // Return the maximum value for the current state
        return dp[end, weightLeft];
    }
}
// Time Complexity: O(n * C), where n is the number of items and C is the knapsack capacity
// Space Complexity: O(n * C), for the dp array representing the memoization table

class Solution {
        // Tabulative approach to solve the 0/1 Knapsack problem
    public int solve(List<int> A, List<int> B, int C) {
        int n = A.Count;
    
        // Initialize dp array with dimensions (n + 1) x (C + 1)
        int[,] dp = new int[n + 1, C + 1];

        // Initialize the first row and column of dp array
        for (int i = 0; i <= n; i++) {
            for (int j = 0; j <= C; j++) {
                dp[i, j] = 0;
            }
        }

        // Iterate through the dp array to fill in values bottom-up
        for (int i = 1; i <= n; i++) {
            for (int j = 0; j <= C; j++) {
                // Base case: If no weight left or no items remaining, value is 0
                if (j == 0) {
                    dp[i, j] = 0;
                }
                // For other cases, consider including and excluding the current item
                else {
                    int include = 0;
                    // Check if including the current item is feasible
                    if (j - B[i - 1] >= 0) {
                        include = dp[i - 1, j - B[i - 1]] + A[i - 1];
                    }
                    int exclude = dp[i - 1, j];

                    // Update dp array with the maximum of include and exclude
                    dp[i, j] = Math.Max(include, exclude);
                }
            }
        }

        // Return the maximum value for the given knapsack capacity
        return dp[n, C];
    }
}
// Time Complexity: O(n * C), where n is the number of items and C is the knapsack capacity
// Space Complexity: O(n * C), for the dp array representing the tabulation table
