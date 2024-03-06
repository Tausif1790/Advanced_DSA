Given an integer A. Return minimum count of numbers, sum of whose squares is equal to A.
Input 1: A = 6
Input 2: A = 5

Output 1: 3
Output 2: 2

Explanation 1:
 Possible combinations are : (12 + 12 + 12 + 12 + 12 + 12) and (12 + 12 + 22).
 Minimum count of numbers, sum of whose squares is 6 is 3. 

//------------------// TC: O(m), SC: O(m)----------------------------//
class Solution {
    // TC: O(n*sqrt(n)), SC(n)
    public int countMinSquares(int n) {
        int[] dp = new int[n + 1];
        // Assigning -1 to all elements of the array
        for (int i = 0; i < dp.Length; i++)
        {
            dp[i] = int.MaxValue;         // Initialize dp array with maximum value to find minimum later
        }
        dp[0] = 0;                        // Base case: 0 squares needed for 0
        dp[1] = 1;                        // Base case: 1 square needed for 1

        for(int i = 2; i <= n; i++){
            for(int x = 1; x*x <= i; x++){                      // 11, 8, 3 for i = 12;
                int currPermutation = dp[i - x*x];              // Get the count of squares for the current permutation
                dp[i] = Math.Min(dp[i], currPermutation + 1);   // Update dp[i] with the minimum count of squares
            }
        }

        return dp[n];                      // Return the minimum count of squares for n
    }


    // Recursive code // TC: O(2^(n/2)), SC(n)
    public int countMinSquares(int n) {
        if(n == 0 || n == 1){
            return n;               // Return n for base cases
        }

        // Initialize as max for each Recursive itr
        int ans = int.MaxValue;      // Initialize ans with maximum possible value to find minimum later
        
        for(int i=1; i*i <= n; i++){
            int currPermutation = countMinSquares(n - i*i);     // Recursive call for remaining value
            ans = Math.Min(ans, currPermutation);               // Update ans with the minimum count of squares
        }

        return (ans + 1);            // Return the minimum count of squares
    }
}

