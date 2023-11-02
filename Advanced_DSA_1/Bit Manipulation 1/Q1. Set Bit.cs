You are given two integers A and B.
Set the A-th bit and B-th bit in 0, and return output in decimal Number System.

Note:
The bit positions are 0-indexed, which means that the least significant bit (LSB) has index 0.

Input 1:
A = 3
B = 5

Output 1:
40

//-----------------------------------------------//
class Solution {
    public int solve(int A, int B) {
        //int  (0 & (1))

        int n = 0;           // 0 0 0 0 0 0 0

        n = n | (1 << A);    // set bit using OR operator at Ath position
        n = n | (1 << B);

        return n;
    }
}


//TC: O(1)
//SC: O(1)