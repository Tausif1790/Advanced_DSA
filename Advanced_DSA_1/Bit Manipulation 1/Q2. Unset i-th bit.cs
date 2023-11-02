You are given two integers A and B.
If B-th bit in A is set, make it unset.
If B-th bit in A is unset, leave as it is.

Input 1:
A = 4
B = 1
Input 2:
A = 5
B = 2

//------------------------------------------//
class Solution {
    public int solve(int A, int B) {
        if(checkBit(A, B) == 1){
            A = A^(1<<B);            // Toggle bit if set
        }
        return A;
    }

    int checkBit(int A, int B) {
        if((A & (1<<B)) == 0){
            return 0;
        }
        return 1;
    }
}
