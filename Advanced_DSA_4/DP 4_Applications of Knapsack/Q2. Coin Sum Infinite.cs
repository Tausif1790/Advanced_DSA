Problem Description
You are given a set of coins A. In how many ways can you make sum B assuming you have infinite amount of each coin in the set.
NOTE:
Coins in set A will be unique. Expected space complexity of this problem is O(B).
The answer can overflow. So, return the answer % (106 + 7).

Input 1:
 A = [1, 2, 3]
 B = 4
Output 1: 4
Example Explanation
Explanation 1:
 The 4 possible ways are:
 {1, 1, 1, 1}
 {1, 1, 2}
 {2, 2}
 {1, 3} 

//--------------------------------------------------//
class Solution {
    public int coinchange2(List<int> A, int B) {
        int mod = (int)Math.Pow(10, 6) + 7;
        int n = A.Count;
        List<int> dp = new List<int>(new int[B + 1]);    // Dynamic programming array to store the number of ways to make each sum up to B
        dp[0] = 1;                           // There is only one way to make sum 0, i.e., by choosing no coins
        
        // Loop through each coin in the set
        for(int j = 0; j < n; j++){
            // Loop through each possible sum from 1 to B
            for(int i = 1; i <= B; i++){
                // Check if the current coin can be used to make the current sum
                if(i - A[j] >= 0){
                    // Update the number of ways to make the current sum using the current coin
                    dp[i] = (dp[i] % mod + dp[i - A[j]] % mod) % mod;
                }
            }
        }
        return dp[B] % mod; // Return the number of ways to make the required sum B
    }
}
