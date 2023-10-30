Given an integer A, generate a square matrix filled with elements from 1 to A2 in spiral order and return the generated square matrix.
Example Input
Input 1: 1
Input 2: 2
Input 3: 5

Example Output
Output 1:
[ [1] ]

Output 2:
[ [1, 2], 
  [4, 3] ]

Output 2:
[ [1,   2,  3,  4, 5], 
  [16, 17, 18, 19, 6], 
  [15, 24, 25, 20, 7], 
  [14, 23, 22, 21, 8], 
  [13, 12, 11, 10, 9] ]

//--------------------------------------------------------------//
class Solution {
    public List<List<int>> generateMatrix(int A) {
        List<List<int>> matrix = new List<List<int>>();
        // Initialize the matrix with all elements set to 0.
        for (int p = 0; p < A; p++) {
            List<int> row = new List<int>();
            for (int q = 0; q < A; q++) {
                row.Add(0);
            }
         matrix.Add(row);
        }

        int i = 0;
        int j = 0;
        int z = 1;
        int loopPrint = A - 1;

        while(loopPrint >= 0){
            // Set the center element when the matrix size is odd.
            if(loopPrint == 0){
                //matrix[i][j] += 1;                 // this line is not working as expected
                matrix[i][j] = z++;
                break;
            }

            // Fill the matrix in a spiral pattern.
            // first row
            for(int k=0; k<loopPrint; k++){
                //matrix[i][j] += 1;
                matrix[i][j] = z++;
                j++;
            }
            // last col
            for(int k=0; k<loopPrint; k++){
                //matrix[i][j] += 1;
                matrix[i][j] = z++;
                i++;
            }
            // last row
            for(int k=0; k<loopPrint; k++){
                //matrix[i][j] += 1;
                matrix[i][j] = z++;
                j--;
            }
            // first col
            for(int k=0; k<loopPrint; k++){
                //matrix[i][j] += 1;
                matrix[i][j] = z++;
                i--;
            }
            i++;
            j++;
            loopPrint -= 2;
        }
        return matrix;
    } 
}
