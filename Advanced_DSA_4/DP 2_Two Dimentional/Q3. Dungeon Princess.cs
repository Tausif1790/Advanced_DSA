Input 1:
 A = [ 
       [-2, -3, 3],
       [-5, -10, 1],
       [10, 30, -5]
     ]
Input 2:
 A = [ 
       [1, -1, 0],
       [-1, 1, -1],
       [1, 0, -1]
     ]

Output 1: 7
Output 2: 1
//--------------------------------------------------//
class Solution {
    public int calculateMinimumHP(List<List<int>> A) {
        int n = A.Count;
        int m = A[0].Count;
        
        // Initialize the dp array with proper size
        int[][] dp = new int[n][];
        for (int i = 0; i < n; i++) {
            dp[i] = new int[m];
        }

        for (int i = n - 1; i >= 0; i--) {
            for (int j = m - 1; j >= 0; j--) {
                if (i == n - 1 && j == m - 1) {
                    // Calculate the initial health required for the bottom-right cell
                    int x = 1 - A[i][j];
                    dp[i][j] = x <= 0 ? 1 : x;
                } else if (i == n - 1) {
                    // Calculate the initial health required for cells in the last row
                    int x = dp[i][j + 1] - A[i][j];
                    dp[i][j] = x <= 0 ? 1 : x;
                } else if (j == m - 1) {
                    // Calculate the initial health required for cells in the last column
                    int x = dp[i + 1][j] - A[i][j];
                    dp[i][j] = x <= 0 ? 1 : x;
                } else {
                    // Calculate the initial health required for other cells by choosing the minimum between right and bottom
                    int right = dp[i][j + 1] - A[i][j];
                    int bottom = dp[i + 1][j] - A[i][j];
                    int x = Math.Min(right, bottom);
                    dp[i][j] = x <= 0 ? 1 : x;
                }
            }
        }
        return dp[0][0];
    }
}
