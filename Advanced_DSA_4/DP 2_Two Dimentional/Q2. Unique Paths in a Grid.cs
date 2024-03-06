Input 1:
 A = [
        [0, 0, 0]
        [0, 1, 0]
        [0, 0, 0]
     ]
Input 2:
 A = [
        [0, 0, 0]
        [1, 1, 1]
        [0, 0, 0]
     ]

Output 1: 2
Output 2: 0
//------------------------------------------------//
class Solution {
    public int uniquePathsWithObstacles(List<List<int>> A) {
        int n = A.Count;    
        int m = A[0].Count; 
        
        if(A[0][0] == 1) return 0;                       // If the starting point is an obstacle, no paths are possible

        // Fixed: Initializing dp array correctly
        List<List<int>> dp = new List<List<int>>(n);
        for (int i = 0; i < n; i++) {
            dp.Add(new List<int>(new int[m]));
        }

        for(int i=0; i<n; i++){
            for(int j=0; j<m; j++){
                if(A[i][j] == 1){
                    dp[i][j] = 0;                        // If the current cell is an obstacle, no paths are possible
                }
                else if(i == 0 || j == 0){
                    if(i == 0 && j == 0){
                        dp[i][j] = 1;                    // There is one way to reach the starting point
                    }
                    else if(i == 0 && dp[i][j-1] != 0){
                        dp[i][j] = 1;                    // Initialize the first row based on the obstacle and previous values
                    }
                    else if(j == 0 && dp[i-1][j] != 0){
                        dp[i][j] = 1;                    // Initialize the first column based on the obstacle and previous values
                    }
                }
                else{
                    dp[i][j] = dp[i-1][j] + dp[i][j-1]; // Calculate the number of paths to the current cell
                }
            }
        }
        return dp[n-1][m-1];                         // Return the number of paths to the destination cell
    }
}
