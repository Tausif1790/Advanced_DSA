You are given two integers A and B.
Return 1 if B-th bit in A is set
Return 0 if B-th bit in A is unset

Input 1:
A = 4
B = 1
Input 2:
A = 5
B = 2

//-------------------------------------------------//
class Solution {
    public int solve(int A, int B) {
        // Check if the B-th bit in A is set (1) by shifting 1 to the left B times and performing a bitwise AND.
        if((A & (1<<B)) == 0){
            return 0;           // B-th bit is not set, return 0.
        }
        return 1;
    }
}

//TC: O(1)
//SC: O(1)