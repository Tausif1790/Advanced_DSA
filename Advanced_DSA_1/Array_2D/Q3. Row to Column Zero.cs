You are given a 2D integer matrix A, make all the elements in a row or column zero if the A[i][j] = 0.
 Specifically, make entire ith row and jth column zero.

Problem Constraints
1 <= A.size() <= 103
1 <= A[i].size() <= 103
0 <= A[i][j] <= 103

Input 1:
[1,2,3,4]
[5,6,7,0]
[9,2,0,4]

Output 1:
[1,2,0,0]
[0,0,0,0]
[0,0,0,0]

//-------------------------------------------------------//
class Solution {
    public List<List<int>> solve(List<List<int>> A) {
        int n = A.Count;
        int m = A[0].Count;

        //List<int> iCount = new List<int>();    // TC with this approach ~10000ms
        //List<int> jCount = new List<int>();

        // Create arrays to mark rows and columns containing zeros.
        bool[] zeroRows = new bool[n];          // TC with this approach ~2000ms
        bool[] zeroCols = new bool[m];

        for(int i=0; i<n; i++){
            for(int j=0; j<m; j++){
                if(A[i][j] == 0){
                    //iCount.Add(i);
                    //jCount.Add(j);

                    zeroRows[i] = true; // Mark the row.
                    zeroCols[j] = true; // Mark the column.
                }
            }
        }

        // Second pass: Set elements to 0 based on marked rows and columns.
        for(int i=0; i<n; i++){
            for(int j=0; j<m; j++){
                
                // if(iCount.Contains(i) || jCount.Contains(j)){
                //     A[i][j] = 0;
                // }

                if (zeroRows[i] || zeroCols[j]) {
                    A[i][j] = 0; // Set the element to 0 if it's in a marked row or column.
                }
            }
        }

        return A;
    }
}
